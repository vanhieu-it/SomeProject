using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
namespace GiaoDucPhoCap
{
    public partial class frmDanhSach : Form
    {
        public frmDanhSach()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();


        private void btnXem_Click(object sender, EventArgs e)
        {

            if (rdoChuyenDen.Checked == true)
            {
                dgvChuyenDi.Visible = false;
                dgvDoTuoi.Visible = false;
                dgvKhuyettat.Visible = false;
                dgvBoHoc.Visible = false;
                dgvKhoiLop.Visible = false;
                dgvChuyenDen.Visible = true;

                var DSChuyenDen = from cd in db.tbThanhViens
                                  where cd.NgayChuyenDen != null
                                  select new
                                  {
                                      cd.MaThanhVien,
                                      cd.TenThanhVien,
                                      cd.NgaySinh,
                                      cd.GioiTinh,
                                      cd.GhiChu,
                                      cd.NoiKhac,
                                      cd.TenTruong,
                                      cd.TrinhDo5,
                                      cd.NgayChuyenDen
                                  };
                dgvChuyenDen.DataSource = DSChuyenDen;

            }
            if (rdoKhoiLop.Checked == true)
            {
                dgvKhuyettat.Visible = false;
                dgvDoTuoi.Visible = false;
                dgvChuyenDen.Visible = false;
                dgvChuyenDi.Visible = false;
                dgvBoHoc.Visible = false;
                dgvKhoiLop.Visible = true;

                //var DSKhoilop = from kl in db.tbThanhViens where kl.TrinhDo5 == "Lop 1" select new {kl.MaThanhVien,kl.TenThanhVien,kl.DanToc,kl.GioiTinh,kl.tbChuHo.TenChuHo,kl.tbChuHo.tbThonXom.TenThon,kl.TrinhDo5 };
                //dgvKhoiLop.DataSource = DSKhoilop;
                if (cboKhoiLop.Text != "")
                {
                    var dsKhoiLop = from kl in db.tbThanhViens
                                    where kl.TrinhDo5 == cboKhoiLop.Text
                                    select new
                                    {
                                        kl.MaThanhVien,
                                        kl.TenThanhVien,
                                        kl.NgaySinh,
                                        kl.GioiTinh,
                                        kl.tbChuHo.TenChuHo,
                                        kl.tbChuHo.tbThonXom.TenThon,
                                        kl.TrinhDo5

                                    };
                    dgvKhoiLop.DataSource = dsKhoiLop;
                }

            }
            if (rdoBoHoc.Checked == true)
            {
                dgvBoHoc.Visible = true;
                dgvKhuyettat.Visible = false;
                dgvDoTuoi.Visible = false;
                dgvChuyenDen.Visible = false;
                dgvChuyenDi.Visible = false;
                dgvKhoiLop.Visible = false;


                var DsboHoc = from bh in db.tbThanhViens
                              where bh.NamBoHoc != null && bh.NamBoHoc != ""
                              select new
                              {
                                  bh.MaThanhVien,
                                  bh.TenThanhVien,
                                  bh.NgaySinh,
                                  bh.GioiTinh,
                                  bh.tbChuHo.TenChuHo,
                                  bh.tbChuHo.tbThonXom.TenThon,
                                  bh.NamBoHoc
                              };
                dgvBoHoc.DataSource = DsboHoc;

            }
           
            if (rdoChuyenDi.Checked == true)
            {
                dgvKhuyettat.Visible = false;
                dgvDoTuoi.Visible = false;
                dgvChuyenDen.Visible = false;
                dgvBoHoc.Visible = false;
                dgvKhoiLop.Visible = false;
                dgvChuyenDi.Visible = true;

            }

            if (rdoKhuyetTat.Checked == true)
            {
                dgvBoHoc.Visible = false;
                dgvDoTuoi.Visible = false;
                dgvChuyenDen.Visible = false;
                dgvChuyenDi.Visible = false;
                dgvKhoiLop.Visible = false;
                dgvKhuyettat.Visible = true;

                var dsKhuyetTat = from tv in db.tbThanhViens
                                  where tv.TinhTrang != null && tv.TinhTrang != "" && tv.TinhTrang != "Bình thường"
                                  select new
                                  {
                                      tv.MaThanhVien,
                                      tv.TenThanhVien,
                                      tv.NgaySinh,
                                      tv.GioiTinh,
                                      tv.tbChuHo.TenChuHo,
                                      tv.tbChuHo.tbThonXom.TenThon,
                                      tv.TinhTrang,
                                      tv.GhiChu
                                  };
                dgvKhuyettat.DataSource = dsKhuyetTat;

            }

        }

        private void btXem_Click(object sender, EventArgs e)
        {
            var DSGiaoVien = from gv in db.tbGiaoViens select new { gv.MaGiaoVien, gv.TenGiaoVien, gv.NgaySinh, gv.GioiTinh, gv.ChucVu, gv.ChuyenNganh, gv.TrinhDo, gv.SoTietDay, gv.XepLoaiGiaoVien, gv.DangDayLop, gv.DanToc };
            dgvGiaoVien.DataSource = DSGiaoVien;
        }


        private void frmDanhSach_Load(object sender, EventArgs e)
        {


            for (int i = 0; i <= 6; i++)
            {
                int nam = DateTime.Now.Year - i - 6;
                cbNS.Items.Add(nam);
            }
            cbNS.SelectedIndex = 1;

            var dstenthon = from th in db.tbThonXoms select th.TenThon;
            foreach (string ten in dstenthon)
            {
                cbthon.Items.Add(ten);
            }
             cbthon .SelectedIndex = 1;
        }

       
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                GC.Collect();
            }

        }

       

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file *.xls|*.xls";
                if (save.ShowDialog() == DialogResult.OK)
                {

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Excel.Range chageRange;
                    //dinh dang xuat du lieu theo kho nghang excel
                    xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;


                    xlWorkSheet.get_Range("a1", "c1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a1", "c1");
                    chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    xlWorkSheet.get_Range("a2", "c2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a2", "c2");
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.FormulaR1C1 = "Xã Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;

                    xlWorkSheet.get_Range("d4", "g4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d4", "g4");
                    chageRange.FormulaR1C1 = "DANH SÁCH GIAÓ VIÊN";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 16;

                    int sodong = dgvGiaoVien.RowCount + 7;
                    string a = "a" + sodong.ToString();
                    string b = "b" + sodong.ToString();
                    string c = "c" + sodong.ToString();
                    string D = "d" + sodong.ToString();
                    string E = "e" + sodong.ToString();
                    string f = "f" + sodong.ToString();
                    string g = "g" + sodong.ToString();
                    string h = "h" + sodong.ToString();
                    string I = "i" + sodong.ToString();
                    string J = "j" + sodong.ToString();
                    string k = "k" + sodong.ToString();



                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 6;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 17;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 10;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", D);
                    chageRange.ColumnWidth = 6;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 15;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth = 9;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //h
                    chageRange = xlWorkSheet.get_Range("h1", h);
                    chageRange.ColumnWidth = 7;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //i
                    chageRange = xlWorkSheet.get_Range("i1", I);
                    chageRange.ColumnWidth = 15;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //j
                    chageRange = xlWorkSheet.get_Range("j1", J);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //k
                    chageRange = xlWorkSheet.get_Range("k1", k);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;



                    xlWorkSheet.get_Range("I1", "k1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("I1", "k1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("I2", "k2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("I2", "k2");
                    chageRange.FormulaR1C1 = "Tỉnh Long An";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("f5", "h5").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f5", "h5");
                    chageRange.FormulaR1C1 = "Thời điểm tháng 9 năm 2011";
                    chageRange.RowHeight = 20;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


                    chageRange = xlWorkSheet.get_Range("a7", "g7");
                    chageRange.RowHeight = 30;
                    chageRange.Font.Bold = true;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //Font chữ
                    chageRange = xlWorkSheet.get_Range("a1", k);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a7", k);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    xlWorkSheet.get_Range("a7", "a7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a7", "a7");
                    chageRange.FormulaR1C1 = "Mã GV";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("b7", "b7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b7", "b7");
                    chageRange.FormulaR1C1 = "Họ tên";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c7", "c7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c7", "c7");
                    chageRange.FormulaR1C1 = "Ngày sinh";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d7", "d7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d7", "d7");
                    chageRange.FormulaR1C1 = "GT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("e7", "e7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e7", "e7");
                    chageRange.FormulaR1C1 = "Chức vụ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("f7", "f7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f7", "f7");
                    chageRange.FormulaR1C1 = "CN ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g7", "g7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g7", "g7");
                    chageRange.FormulaR1C1 = "Trình độ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("h7", "h7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("h7", "h7");
                    chageRange.FormulaR1C1 = "Số tiết";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;




                    xlWorkSheet.get_Range("i7", "i7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("i7", "i7");
                    chageRange.FormulaR1C1 = "Xếp loại";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("j7", "j7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("j7", "j7");
                    chageRange.FormulaR1C1 = "Dạy lớp";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("k7", "k7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("k7", "k7");
                    chageRange.FormulaR1C1 = "Dân tộc";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;





                    int n = 0;
                    int m = 0;

                    for (n = 0; n <= dgvGiaoVien.RowCount - 1; n++)
                    {
                        for (m = 0; m <= dgvGiaoVien.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvGiaoVien[m, n];
                            xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;
                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                        }

                    }
                    string h1 = "h" + (sodong + 5).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(h1, h1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    //
                    string h2 = "h" + (sodong + 6).ToString();
                    string k1 = "k" + (sodong + 6).ToString();
                    chageRange = xlWorkSheet.get_Range(h2, k1);
                    xlWorkSheet.get_Range(h2, k1).Merge(false);
                    chageRange.FormulaR1C1 = "Người lập biểu";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    xlWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở File?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(save.FileName);
                    }
                }
            }
            catch { }

        }



        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (rdoKhuyetTat.Checked == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file *.xls|*.xls";
                if (save.ShowDialog() == DialogResult.OK)
                {

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Excel.Range chageRange;
                    //dinh dang in kho ngang
                    xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;
                    xlWorkSheet.get_Range("a1", "c1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a1", "c1");
                    chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    xlWorkSheet.get_Range("a2", "c2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a2", "c2");
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.FormulaR1C1 = "Năm học 2010-2011";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;

                    xlWorkSheet.get_Range("a4", "h4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a4", "h4");
                    chageRange.FormulaR1C1 = "DANH SÁCH HỌC SINH KHUYẾT TẬT";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 13;

                    int sodong = dgvGiaoVien.RowCount + 6;
                    string a = "a" + sodong.ToString();
                    string b = "b" + sodong.ToString();
                    string c = "c" + sodong.ToString();
                    string d = "d" + sodong.ToString();
                    string E = "e" + sodong.ToString();
                    string f = "f" + sodong.ToString();
                    string g = "g" + sodong.ToString();
                    //string h = "h" + sodong.ToString();


                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 6;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 17;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 12;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", d);
                    chageRange.ColumnWidth = 5;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 20;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //h
                    //chageRange = xlWorkSheet.get_Range("h1", h);
                    //chageRange.ColumnWidth = 14;
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    xlWorkSheet.get_Range("f1", "g1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f1", "g1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("f2", "g2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f2", "g2");
                    chageRange.FormulaR1C1 = "Tỉnh Long An";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    chageRange = xlWorkSheet.get_Range("a6", "h6");
                    chageRange.RowHeight = 30;
                    chageRange.Font.Bold = true;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //Font chữ
                    chageRange = xlWorkSheet.get_Range("a1", g);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a6", g);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //chageRange = xlWorkSheet.get_Range("a6", a);
                    xlWorkSheet.get_Range("a6", "a6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a6", "a6");
                    chageRange.FormulaR1C1 = "Mã HS";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("b6", "b6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b6", "b6");
                    chageRange.FormulaR1C1 = "Họ tên";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c6", "c6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c6", "c6");
                    chageRange.FormulaR1C1 = "Ngày sinh";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d6", "d6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d6", "d6");
                    chageRange.FormulaR1C1 = "GT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("e6", "e6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e6", "e6");
                    chageRange.FormulaR1C1 = "Tên bố mẹ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("f6", "f6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f6", "f6");
                    chageRange.FormulaR1C1 = "Địa chỉ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g6", "g6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g6", "g6");
                    chageRange.FormulaR1C1 = "Loại KT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    //xlWorkSheet.get_Range("h6", "h6").Merge(false);
                    //chageRange = xlWorkSheet.get_Range("h6", "h6");
                    //chageRange.FormulaR1C1 = "Ghi chú";
                    //chageRange.Font.Size = 11;
                    //chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //chageRange.Font.Bold = true;
                    string e1 = "e" + (sodong + 5).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(e1, e1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    //
                    string e2 = "e" + (sodong + 6).ToString();
                    string g1 = "g" + (sodong + 6).ToString();
                    chageRange = xlWorkSheet.get_Range(e2, g1);
                    xlWorkSheet.get_Range(e2, g1).Merge(false);
                    chageRange.FormulaR1C1 = "HIỆU TRƯỞNG";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    int n = 0;
                    int m = 0;

                    for (n = 0; n <= dgvKhuyettat.RowCount - 1; n++)
                    {
                        for (m = 0; m <= dgvKhuyettat.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvKhuyettat[m, n];
                            xlWorkSheet.Cells[n + 7, m + 1] = cell.Value;
                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                        }

                    }

                    xlWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    if (MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở File?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(save.FileName);
                    }
                }
            }

            if (rdoChuyenDen.Checked == true)
            {
                try
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Excel file *.xls|*.xls";
                    if (save.ShowDialog() == DialogResult.OK)
                    {

                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;

                        xlApp = new Excel.ApplicationClass();
                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        Excel.Range chageRange;
                        //dinh dang xuat du lieu theo kho nghang excel
                        xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;


                        xlWorkSheet.get_Range("a1", "c1").Merge(false);
                        chageRange = xlWorkSheet.get_Range("a1", "c1");
                        chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                        chageRange.RowHeight = 20;
                        chageRange.Font.Size = 12;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                        xlWorkSheet.get_Range("a2", "c2").Merge(false);
                        chageRange = xlWorkSheet.get_Range("a2", "c2");
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.FormulaR1C1 = "Xã Dân Tiến";
                        chageRange.RowHeight = 20;
                        chageRange.Font.Size = 12;

                        xlWorkSheet.get_Range("c4", "f4").Merge(false);
                        chageRange = xlWorkSheet.get_Range("c4", "f4");
                        chageRange.FormulaR1C1 = "DANH SÁCH HỌC SINH TẠM TRÚ";
                        chageRange.RowHeight = 25;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;
                        chageRange.Font.Size = 14;

                        int sodong = dgvChuyenDen.RowCount + 7;
                        string a = "a" + sodong.ToString();
                        string b = "b" + sodong.ToString();
                        string c = "c" + sodong.ToString();
                        string D = "d" + sodong.ToString();
                        string E = "e" + sodong.ToString();
                        string f = "f" + sodong.ToString();
                        string g = "g" + sodong.ToString();
                        string h = "h" + sodong.ToString();
                        string I = "i" + sodong.ToString();



                        //a
                        chageRange = xlWorkSheet.get_Range("a1", a);
                        chageRange.ColumnWidth = 6;
                        chageRange.Columns.Cells.FillLeft();
                        //b
                        chageRange = xlWorkSheet.get_Range("b1", b);
                        chageRange.ColumnWidth = 17;
                        chageRange.Columns.Cells.FillLeft();
                        //c
                        chageRange = xlWorkSheet.get_Range("c1", c);
                        chageRange.ColumnWidth = 10;
                        //d
                        chageRange = xlWorkSheet.get_Range("d1", D);
                        chageRange.ColumnWidth = 6;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //e
                        chageRange = xlWorkSheet.get_Range("e1", E);
                        chageRange.ColumnWidth = 15;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //f
                        chageRange = xlWorkSheet.get_Range("f1", f);
                        chageRange.ColumnWidth = 20;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //g
                        chageRange = xlWorkSheet.get_Range("g1", g);
                        chageRange.ColumnWidth = 17;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //h
                        chageRange = xlWorkSheet.get_Range("h1", h);
                        chageRange.ColumnWidth = 9;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //i
                        chageRange = xlWorkSheet.get_Range("i1", I);
                        chageRange.ColumnWidth = 10;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;




                        xlWorkSheet.get_Range("h1", "I1").Merge(false);
                        chageRange = xlWorkSheet.get_Range("h1", "I1");
                        chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Size = 12;


                        xlWorkSheet.get_Range("h2", "I2").Merge(false);
                        chageRange = xlWorkSheet.get_Range("h2", "I2");
                        chageRange.FormulaR1C1 = "Tỉnh Long An";
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Size = 12;


                        //xlWorkSheet.get_Range("f5", "h5").Merge(false);
                        //chageRange = xlWorkSheet.get_Range("f5", "h5");
                        //chageRange.FormulaR1C1 = "Thời điểm tháng 9 năm 2011";
                        //chageRange.RowHeight = 20;
                        //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


                        chageRange = xlWorkSheet.get_Range("a7", "g7");
                        chageRange.RowHeight = 30;
                        chageRange.Font.Bold = true;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //Font chữ
                        chageRange = xlWorkSheet.get_Range("a1", I);
                        chageRange.Font.Name = "Time New Roman";

                        //kẻ khung
                        chageRange = xlWorkSheet.get_Range("a7", I);
                        chageRange.Borders.Value = 1;
                        chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                        xlWorkSheet.get_Range("a7", "a7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("a7", "a7");
                        chageRange.FormulaR1C1 = "Mã HS";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;


                        xlWorkSheet.get_Range("b7", "b7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("b7", "b7");
                        chageRange.FormulaR1C1 = "Họ tên";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("c7", "c7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("c7", "c7");
                        chageRange.FormulaR1C1 = "Ngày sinh";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("d7", "d7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("d7", "d7");
                        chageRange.FormulaR1C1 = "GT";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("e7", "e7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("e7", "e7");
                        chageRange.FormulaR1C1 = "Tên bố mẹ";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("f7", "f7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("f7", "f7");
                        chageRange.FormulaR1C1 = "Nơi ở cũ ";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("g7", "g7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("g7", "g7");
                        chageRange.FormulaR1C1 = "Trường cũ";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("h7", "h7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("h7", "h7");
                        chageRange.FormulaR1C1 = "Học lớp";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;




                        xlWorkSheet.get_Range("i7", "i7").Merge(false);
                        chageRange = xlWorkSheet.get_Range("i7", "i7");
                        chageRange.FormulaR1C1 = "Ngày đến";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;








                        int n = 0;
                        int m = 0;

                        for (n = 0; n <= dgvChuyenDen.RowCount - 1; n++)
                        {
                            for (m = 0; m <= dgvChuyenDen.ColumnCount - 1; m++)
                            {
                                DataGridViewCell cell = dgvChuyenDen[m, n];
                                xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;
                                //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                                chageRange.Font.Name = "Time New Roman";
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                            }

                        }
                        string g1 = "g" + (sodong + 5).ToString();
                        string[] date = DateTime.Now.ToShortDateString().Split('/');
                        chageRange = xlWorkSheet.get_Range(g1, g1);
                        chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                        chageRange.RowHeight = 20;
                        chageRange.Font.Name = "Time New Roman";
                        //
                        string g2 = "g" + (sodong + 6).ToString();
                        string I1 = "I" + (sodong + 6).ToString();
                        chageRange = xlWorkSheet.get_Range(g2, I1);
                        xlWorkSheet.get_Range(g2, I1).Merge(false);
                        chageRange.FormulaR1C1 = "Người lập biểu";
                        chageRange.RowHeight = 20;
                        chageRange.Font.Name = "Time New Roman";
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        xlWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);

                        if (MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở File?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(save.FileName);
                        }
                    }
                }
                catch { }

            }

            if (rdoBoHoc.Checked == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file *.xls|*.xls";

                if (save.ShowDialog() == DialogResult.OK)
                {

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Excel.Range chageRange;
                    //dinh dang in kho ngang
                    xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;

                    xlWorkSheet.get_Range("a1", "b1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a1", "b1");
                    chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    xlWorkSheet.get_Range("a2", "b2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a2", "b2");
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.FormulaR1C1 = "Năm học 2010-2011";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;

                    xlWorkSheet.get_Range("a4", "g4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a4", "g4");
                    chageRange.FormulaR1C1 = "DANH SÁCH HỌC SINH BỎ HỌC";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 14;

                    int sodong = dgvGiaoVien.RowCount + 6;
                    string a = "a" + sodong.ToString();
                    string b = "b" + sodong.ToString();
                    string c = "c" + sodong.ToString();
                    string d = "d" + sodong.ToString();
                    string E = "e" + sodong.ToString();
                    string f = "f" + sodong.ToString();
                    string g = "g" + sodong.ToString();


                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 7;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 17;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 10;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", d);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 17;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth = 17;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 9;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    xlWorkSheet.get_Range("f1", "g1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f1", "g1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("f2", "g2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f2", "g2");
                    chageRange.FormulaR1C1 = "Tỉnh Long An";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    chageRange = xlWorkSheet.get_Range("a6", "g6");
                    chageRange.RowHeight = 30;
                    chageRange.Font.Bold = true;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //Font chữ
                    chageRange = xlWorkSheet.get_Range("a1", g);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a6", g);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //chageRange = xlWorkSheet.get_Range("a6", a);
                    xlWorkSheet.get_Range("a6", "a6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a6", "a6");
                    chageRange.FormulaR1C1 = "Mã HS";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("b6", "b6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b6", "b6");
                    chageRange.FormulaR1C1 = "Họ tên";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c6", "c6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c6", "c6");
                    chageRange.FormulaR1C1 = "Ngày sinh";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d6", "d6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d6", "d6");
                    chageRange.FormulaR1C1 = "GT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("e6", "e6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e6", "e6");
                    chageRange.FormulaR1C1 = "Tên bố mẹ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("f6", "f6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f6", "f6");
                    chageRange.FormulaR1C1 = "Địa chỉ ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g6", "g6").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g6", "g6");
                    chageRange.FormulaR1C1 = "Năm BH";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;



                    int n = 0;
                    int m = 0;

                    for (n = 0; n < dgvBoHoc.RowCount - 1; n++)
                    {

                        for (m = 0; m < dgvBoHoc.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvBoHoc[m, n];
                            xlWorkSheet.Cells[n + 7, m + 1] = cell.Value;
                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                        }
                    }

                    string e1 = "e" + (sodong + 5).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(e1, e1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    //
                    string e2 = "e" + (sodong + 6).ToString();
                    string g1 = "g" + (sodong + 6).ToString();
                    chageRange = xlWorkSheet.get_Range(e2, g1);
                    xlWorkSheet.get_Range(e2, g1).Merge(false);
                    chageRange.FormulaR1C1 = "HIỆU TRƯỞNG";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    xlWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    if (MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở File?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(save.FileName);
                    }
                }
            }
                if (rdoKhoiLop.Checked == true)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "Excel file *.xls|*.xls";

                    if (save.ShowDialog() == DialogResult.OK)
                    {

                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;

                        xlApp = new Excel.ApplicationClass();
                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        Excel.Range chageRange;
                        //dinh dang in kho ngang
                        xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlPortrait;

                        xlWorkSheet.get_Range("a1", "b1").Merge(false);
                        chageRange = xlWorkSheet.get_Range("a1", "b1");
                        chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                        chageRange.RowHeight = 20;
                        chageRange.Font.Size = 12;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                        xlWorkSheet.get_Range("a2", "b2").Merge(false);
                        chageRange = xlWorkSheet.get_Range("a2", "b2");
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.FormulaR1C1 = "Năm học 2010-2011";
                        chageRange.RowHeight = 20;
                        chageRange.Font.Size = 12;

                        xlWorkSheet.get_Range("a4", "g4").Merge(false);
                        chageRange = xlWorkSheet.get_Range("a4", "g4");
                        chageRange.FormulaR1C1 = "DANH SÁCH HỌC SINH THEO KHỐI LỚP";
                        chageRange.RowHeight = 25;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;
                        chageRange.Font.Size = 13;

                        int sodong = dgvKhoiLop.RowCount + 6;
                        string a = "a" + sodong.ToString();
                        string b = "b" + sodong.ToString();
                        string c = "c" + sodong.ToString();
                        string d = "d" + sodong.ToString();
                        string E = "e" + sodong.ToString();
                        string f = "f" + sodong.ToString();
                        //string g = "g" + sodong.ToString();


                        //a
                        chageRange = xlWorkSheet.get_Range("a1", a);
                        chageRange.ColumnWidth = 7;
                        chageRange.Columns.Cells.FillLeft();
                        //b
                        chageRange = xlWorkSheet.get_Range("b1", b);
                        chageRange.ColumnWidth = 17;
                        chageRange.Columns.Cells.FillLeft();
                        //c
                        chageRange = xlWorkSheet.get_Range("c1", c);
                        chageRange.ColumnWidth = 10;
                        //d
                        chageRange = xlWorkSheet.get_Range("d1", d);
                        chageRange.ColumnWidth = 8;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //e
                        chageRange = xlWorkSheet.get_Range("e1", E);
                        chageRange.ColumnWidth = 20;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //f
                        chageRange = xlWorkSheet.get_Range("f1", f);
                        chageRange.ColumnWidth = 17;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                        //g
                        //chageRange = xlWorkSheet.get_Range("g1", g);
                        //chageRange.ColumnWidth = 9;
                        //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                        xlWorkSheet.get_Range("f1", "f1").Merge(false);
                        chageRange = xlWorkSheet.get_Range("f1", "f1");
                        chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Size = 12;


                        xlWorkSheet.get_Range("f2", "f2").Merge(false);
                        chageRange = xlWorkSheet.get_Range("f2", "f2");
                        chageRange.FormulaR1C1 = "Tỉnh Long An";
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Size = 12;


                        chageRange = xlWorkSheet.get_Range("a6", "g6");
                        chageRange.RowHeight = 30;
                        chageRange.Font.Bold = true;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //Font chữ
                        chageRange = xlWorkSheet.get_Range("a1", f);
                        chageRange.Font.Name = "Time New Roman";

                        //kẻ khung
                        chageRange = xlWorkSheet.get_Range("a6", f);
                        chageRange.Borders.Value = 1;
                        chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                        //chageRange = xlWorkSheet.get_Range("a6", a);
                        xlWorkSheet.get_Range("a6", "a6").Merge(false);
                        chageRange = xlWorkSheet.get_Range("a6", "a6");
                        chageRange.FormulaR1C1 = "Mã HS";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("b6", "b6").Merge(false);
                        chageRange = xlWorkSheet.get_Range("b6", "b6");
                        chageRange.FormulaR1C1 = "Họ tên";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("c6", "c6").Merge(false);
                        chageRange = xlWorkSheet.get_Range("c6", "c6");
                        chageRange.FormulaR1C1 = "Ngày sinh";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("d6", "d6").Merge(false);
                        chageRange = xlWorkSheet.get_Range("d6", "d6");
                        chageRange.FormulaR1C1 = "GT";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("e6", "e6").Merge(false);
                        chageRange = xlWorkSheet.get_Range("e6", "e6");
                        chageRange.FormulaR1C1 = "Tên bố mẹ";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        xlWorkSheet.get_Range("f6", "f6").Merge(false);
                        chageRange = xlWorkSheet.get_Range("f6", "f6");
                        chageRange.FormulaR1C1 = "Địa chỉ ";
                        chageRange.Font.Size = 11;
                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        chageRange.Font.Bold = true;

                        //xlWorkSheet.get_Range("g6", "g6").Merge(false);
                        //chageRange = xlWorkSheet.get_Range("g6", "g6");
                        //chageRange.FormulaR1C1 = "Khối lớp";
                        //chageRange.Font.Size = 11;
                        //chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                        //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        //chageRange.Font.Bold = true;



                        int n = 0;
                        int m = 0;

                        for (n = 0; n <dgvKhoiLop.RowCount - 1; n++)
                        {

                            for (m = 0; m < dgvKhoiLop.ColumnCount - 1; m++)
                            {
                                DataGridViewCell cell = dgvKhoiLop[m, n];
                                xlWorkSheet.Cells[n + 7, m + 1] = cell.Value;
                                //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                                chageRange.Font.Name = "Time New Roman";
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            }
                        }

                        string e1 = "e" + (sodong + 5).ToString();
                        string[] date = DateTime.Now.ToShortDateString().Split('/');
                        chageRange = xlWorkSheet.get_Range(e1, e1);
                        chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                        chageRange.RowHeight = 20;
                        chageRange.Font.Name = "Time New Roman";
                        //
                        string e2 = "e" + (sodong + 6).ToString();
                        string g1 = "g" + (sodong + 6).ToString();
                        chageRange = xlWorkSheet.get_Range(e2, g1);
                        xlWorkSheet.get_Range(e2, g1).Merge(false);
                        chageRange.FormulaR1C1 = "HIỆU TRƯỞNG";
                        chageRange.RowHeight = 20;
                        chageRange.Font.Name = "Time New Roman";
                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        xlWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                        if (MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở File?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(save.FileName);
                        }

                    }
                }
            
                    if(rdoChuyenDi.Checked == true)
                    {
                        try
                        {
                            SaveFileDialog save = new SaveFileDialog();
                            save.Filter = "Excel file *.xls|*.xls";
                            if (save.ShowDialog() == DialogResult.OK)
                            {

                                Excel.Application xlApp;
                                Excel.Workbook xlWorkBook;
                                Excel.Worksheet xlWorkSheet;
                                object misValue = System.Reflection.Missing.Value;

                                xlApp = new Excel.ApplicationClass();
                                xlWorkBook = xlApp.Workbooks.Add(misValue);
                                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                                Excel.Range chageRange;
                                //dinh dang xuat du lieu theo kho nghang excel
                                xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;


                                xlWorkSheet.get_Range("a1", "c1").Merge(false);
                                chageRange = xlWorkSheet.get_Range("a1", "c1");
                                chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                                chageRange.RowHeight = 20;
                                chageRange.Font.Size = 12;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                                xlWorkSheet.get_Range("a2", "c2").Merge(false);
                                chageRange = xlWorkSheet.get_Range("a2", "c2");
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.FormulaR1C1 = "Năm học 2010-2011";
                                chageRange.RowHeight = 20;
                                chageRange.Font.Size = 12;

                                xlWorkSheet.get_Range("c4", "f4").Merge(false);
                                chageRange = xlWorkSheet.get_Range("c4", "f4");
                                chageRange.FormulaR1C1 = "DANH SÁCH HỌC SINH TẠM VẮNG";
                                chageRange.RowHeight = 25;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;
                                chageRange.Font.Size = 14;

                                int sodong = dgvChuyenDi.RowCount + 7;
                                string a = "a" + sodong.ToString();
                                string b = "b" + sodong.ToString();
                                string c = "c" + sodong.ToString();
                                string D = "d" + sodong.ToString();
                                string E = "e" + sodong.ToString();
                                string f = "f" + sodong.ToString();
                                string g = "g" + sodong.ToString();
                                string h = "h" + sodong.ToString();
                                string I = "i" + sodong.ToString();



                                //a
                                chageRange = xlWorkSheet.get_Range("a1", a);
                                chageRange.ColumnWidth = 6;
                                chageRange.Columns.Cells.FillLeft();
                                //b
                                chageRange = xlWorkSheet.get_Range("b1", b);
                                chageRange.ColumnWidth = 17;
                                chageRange.Columns.Cells.FillLeft();
                                //c
                                chageRange = xlWorkSheet.get_Range("c1", c);
                                chageRange.ColumnWidth = 10;
                                //d
                                chageRange = xlWorkSheet.get_Range("d1", D);
                                chageRange.ColumnWidth = 6;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                //e
                                chageRange = xlWorkSheet.get_Range("e1", E);
                                chageRange.ColumnWidth = 17;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                //f
                                chageRange = xlWorkSheet.get_Range("f1", f);
                                chageRange.ColumnWidth = 15;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                //g
                                chageRange = xlWorkSheet.get_Range("g1", g);
                                chageRange.ColumnWidth = 9;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                //h
                                chageRange = xlWorkSheet.get_Range("h1", h);
                                chageRange.ColumnWidth = 9;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                                //i
                                chageRange = xlWorkSheet.get_Range("i1", I);
                                chageRange.ColumnWidth = 13;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;




                                xlWorkSheet.get_Range("h1", "I1").Merge(false);
                                chageRange = xlWorkSheet.get_Range("h1", "I1");
                                chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Size = 12;


                                xlWorkSheet.get_Range("h2", "I2").Merge(false);
                                chageRange = xlWorkSheet.get_Range("h2", "I2");
                                chageRange.FormulaR1C1 = "Tỉnh Long An";
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Size = 12;


                                //xlWorkSheet.get_Range("f5", "h5").Merge(false);
                                //chageRange = xlWorkSheet.get_Range("f5", "h5");
                                //chageRange.FormulaR1C1 = "Thời điểm tháng 9 năm 2011";
                                //chageRange.RowHeight = 20;
                                //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


                                chageRange = xlWorkSheet.get_Range("a7", "g7");
                                chageRange.RowHeight = 30;
                                chageRange.Font.Bold = true;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                //Font chữ
                                chageRange = xlWorkSheet.get_Range("a1", I);
                                chageRange.Font.Name = "Time New Roman";

                                //kẻ khung
                                chageRange = xlWorkSheet.get_Range("a7", I);
                                chageRange.Borders.Value = 1;
                                chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                                xlWorkSheet.get_Range("a7", "a7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("a7", "a7");
                                chageRange.FormulaR1C1 = "Mã HS";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;


                                xlWorkSheet.get_Range("b7", "b7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("b7", "b7");
                                chageRange.FormulaR1C1 = "Họ tên";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;

                                xlWorkSheet.get_Range("c7", "c7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("c7", "c7");
                                chageRange.FormulaR1C1 = "Ngày sinh";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;

                                xlWorkSheet.get_Range("d7", "d7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("d7", "d7");
                                chageRange.FormulaR1C1 = "GT";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;

                                xlWorkSheet.get_Range("e7", "e7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("e7", "e7");
                                chageRange.FormulaR1C1 = "Tên bố mẹ";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;

                                xlWorkSheet.get_Range("f7", "f7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("f7", "f7");
                                chageRange.FormulaR1C1 = "Địa chỉ ";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;

                                xlWorkSheet.get_Range("g7", "g7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("g7", "g7");
                                chageRange.FormulaR1C1 = "Học lớp";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;

                                xlWorkSheet.get_Range("h7", "h7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("h7", "h7");
                                chageRange.FormulaR1C1 = "Ngày đi";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;




                                xlWorkSheet.get_Range("i7", "i7").Merge(false);
                                chageRange = xlWorkSheet.get_Range("i7", "i7");
                                chageRange.FormulaR1C1 = "Nơi đến";
                                chageRange.Font.Size = 11;
                                chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                chageRange.Font.Bold = true;








                                int n = 0;
                                int m = 0;

                                for (n = 0; n <= dgvChuyenDi.RowCount - 1; n++)
                                {
                                    for (m = 0; m <= dgvChuyenDi.ColumnCount - 1; m++)
                                    {
                                        DataGridViewCell cell = dgvChuyenDi[m, n];
                                        xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;
                                        //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                                        chageRange.Font.Name = "Time New Roman";
                                        chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                                        chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                                        //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                                    }

                                }
                                string g1 = "g" + (sodong + 5).ToString();
                                string[] date = DateTime.Now.ToShortDateString().Split('/');
                                chageRange = xlWorkSheet.get_Range(g1, g1);
                                chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                                chageRange.RowHeight = 20;
                                chageRange.Font.Name = "Time New Roman";
                                //
                                string g2 = "g" + (sodong + 6).ToString();
                                string I1 = "I" + (sodong + 6).ToString();
                                chageRange = xlWorkSheet.get_Range(g2, I1);
                                xlWorkSheet.get_Range(g2, I1).Merge(false);
                                chageRange.FormulaR1C1 = "HIỆU TRƯỞNG";
                                chageRange.RowHeight = 20;
                                chageRange.Font.Name = "Time New Roman";
                                chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                                xlWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                                xlWorkBook.Close(true, misValue, misValue);
                                xlApp.Quit();

                                releaseObject(xlWorkSheet);
                                releaseObject(xlWorkBook);
                                releaseObject(xlApp);

                                if (MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở File?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    Process.Start(save.FileName);
                                }
                            }
                        }
                        catch { }

                    }




                }

        private void button1_Click(object sender, EventArgs e)
        {
            var DShgd = from hgd in db.tbChuHos select new { hgd.MaHoGiaDinh, hgd.TenChuHo,hgd.NgaySinh  };
            dgvchuho.DataSource = DShgd;
            string []mangdong = new string[5];
            int sokhau = (from p in db.tbThanhViens where p.QuanHeVoiChuHo != "Chủ hộ" select p).Count();
            mangdong[4] = sokhau.ToString();
           
            //dgvchuho.Rows.Add(mangdong);
        }

        private void tabGiaoVien_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbNS.Text != "" && cbthon.Text != "")
            {

                var dsDoTuoi = from tv in db.tbThanhViens
                               where tv.NgaySinh.Value.Year.ToString() == cbNS.Text && tv.tbChuHo.tbThonXom.TenThon == cbthon.Text
                               select new
                               {
                                   tv.MaThanhVien,
                                   tv.TenThanhVien,
                                   tv.NgaySinh,
                                   tv.GioiTinh,
                                   tv.DanToc,
                                   tv.tbChuHo.TenChuHo,
                                   tv.tbChuHo.tbThonXom.TenThon,
                                   tv.TrinhDo1,
                                   tv.TrinhDo2,
                                   tv.TrinhDo3,
                                   tv.TrinhDo4,
                                   tv.TrinhDo5,
                                   tv.NamTotNghiep,
                                   tv.NamBoHoc,
                                   tv.TenTruong
                               };
                dgvDoTuoi.DataSource = dsDoTuoi;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel file *.xls|*.xls";
                if (save.ShowDialog() == DialogResult.OK)
                {

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    Excel.Range chageRange;
                    //dinh dang xuat du lieu theo kho nghang excel
                    xlWorkSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;


                    xlWorkSheet.get_Range("a1", "c1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a1", "c1");

                    chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    xlWorkSheet.get_Range("a2", "c2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a2", "c2");
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.FormulaR1C1 = "Xã Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;

                    xlWorkSheet.get_Range("e4", "I4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e4", "I4");
                    chageRange.FormulaR1C1 = "DANH SÁCH HỌC SINH THEO ĐỘ TUỔI";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 13;

                    int sodong = dgvDoTuoi.RowCount + 7;
                    string a = "a" + sodong.ToString();
                    string b = "b" + sodong.ToString();
                    string c = "c" + sodong.ToString();
                    string D = "d" + sodong.ToString();
                    string E = "e" + sodong.ToString();
                    string f = "f" + sodong.ToString();
                    string g = "g" + sodong.ToString();
                    string h = "h" + sodong.ToString();
                    string I = "i" + sodong.ToString();
                    string J = "j" + sodong.ToString();
                    string k = "k" + sodong.ToString();
                    string l = "l" + sodong.ToString();
                    //string M = "m" + sodong.ToString();
                    //  string N = "n" + sodong.ToString();







                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 4;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 16;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 9;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", D);
                    chageRange.ColumnWidth = 5;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 4;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth = 16;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 9;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //h
                    chageRange = xlWorkSheet.get_Range("h1", h);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //i
                    chageRange = xlWorkSheet.get_Range("i1", I);
                    chageRange.ColumnWidth =10 ;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //j
                    chageRange = xlWorkSheet.get_Range("j1", J);
                    chageRange.ColumnWidth =10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //k
                    chageRange = xlWorkSheet.get_Range("k1", k);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //l
                    chageRange = xlWorkSheet.get_Range("l1", l);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    //m
                    //chageRange = xlWorkSheet.get_Range("m1", M);
                    //chageRange.ColumnWidth = 9;
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //n
                    //chageRange = xlWorkSheet.get_Range("n1", N);
                    //chageRange.ColumnWidth = 8;
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    //chageRange = xlWorkSheet.get_Range("o1", o);
                    //chageRange.ColumnWidth = 8;

                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                    xlWorkSheet.get_Range("J1", "l1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("J1", "l1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("J2", "l2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("J2", " l2");
                    chageRange.FormulaR1C1 = "Tỉnh Long An";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;






                    //Font chữ
                    chageRange = xlWorkSheet.get_Range("a1", l);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a7", l);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //chageRange = xlWorkSheet.get_Range("a6", a);
                    xlWorkSheet.get_Range("a7", "a7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a7", "a7");
                    chageRange.FormulaR1C1 = "Mã";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("b7", "b7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b7", "b7");
                    chageRange.FormulaR1C1 = "Họ tên";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c7", "c7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c7", "c7");
                    chageRange.FormulaR1C1 = "NS";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d7", "d7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d7", "d7");
                    chageRange.FormulaR1C1 = " GT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("e7", "e7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e7", "e7");
                    chageRange.FormulaR1C1 = "DT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("f7", "f7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f7", "f7");
                    chageRange.FormulaR1C1 = "Tên bố mẹ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g7", "g7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g7", "g7");
                    chageRange.FormulaR1C1 = "Điạ chỉ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("h7", "h7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("h7", "h7");
                    chageRange.FormulaR1C1 = "2006-2007";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;




                    xlWorkSheet.get_Range("i7", "i7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("i7", "i7");
                    chageRange.FormulaR1C1 = "2007-2008";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("j7", "j7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("j7", "j7");
                    chageRange.FormulaR1C1 = "2008-2009";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("k7", "k7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("k7", "k7");
                    chageRange.FormulaR1C1 = "2009-2010";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("l7", "l7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("l7", "l7");
                    chageRange.FormulaR1C1 = "2010-2011";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    //xlWorkSheet.get_Range("m7", "m7").Merge(false);
                    //chageRange = xlWorkSheet.get_Range("m7", "m7");
                    //chageRange.FormulaR1C1 = "Năm BH";
                    //chageRange.Font.Size = 11;
                    //chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //chageRange.Font.Bold = true;


                    //xlWorkSheet.get_Range("n7", "n7").Merge(false);
                    //chageRange = xlWorkSheet.get_Range("n7", "n7");
                    //chageRange.FormulaR1C1 = "Năm TN";
                    //chageRange.Font.Size = 11;
                    //chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //chageRange.Font.Bold = true;







                    int n = 0;
                    int m = 0;

                    for (n = 0; n <= dgvDoTuoi.RowCount - 1; n++)
                    {
                        for (m = 0; m <= dgvDoTuoi.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvDoTuoi[m, n];
                            xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;

                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                        }

                    }


                    string I1 = "I" + (sodong + 10).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(I1, I1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    //////
                    string I2 = "I" + (sodong + 11).ToString();
                    string l1 = "l" + (sodong + 11).ToString();
                    chageRange = xlWorkSheet.get_Range(I2, l1);
                    xlWorkSheet.get_Range(I2, l1).Merge(false);
                    chageRange.FormulaR1C1 = "HIỆU TRƯỞNG";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;



                    xlWorkBook.SaveAs(save.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (MessageBox.Show("Xuất Excel thành công!\nBạn có muốn mở File?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(save.FileName);
                    }
                }
            }
            catch { }


        }

        private void rdoChuyenDen_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoiLop.Enabled = false;
        }

        private void rdoChuyenDi_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoiLop.Enabled = false;
        }

        private void rdoBoHoc_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoiLop.Enabled = false;
        }

        private void rdoKhuyetTat_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoiLop.Enabled = false;
        }

        private void rdoKhoiLop_CheckedChanged(object sender, EventArgs e)
        {
            cboKhoiLop.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var DS = from vc in db.tbCSVCs select new { vc.MaCSVC,vc.TenCSVC,vc.SoLuong,vc.GhiChu};
            dgvcsvc.DataSource  = DS;
        }

        private void dgvcsvc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

       

       
      
       

      
       
            }









        }



    
