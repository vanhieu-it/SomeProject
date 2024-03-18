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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

            int tongtongsothanhvien = 0;
            int tongtongsothanhviennu = 0;
            int tongtongsothanhviennam = 0;
            int tongdantoc = 0;
            int tongkhuyettat = 0;
            int tongphaiphocap = 0;
            int tongdanghoclop1 = 0;
            int tongdanghoclop2 = 0;
            int tongdanghoclop3 = 0;
            int tongdanghoclop4 = 0;
            int tongdanghoclop5 = 0;
            int tongbohoclop1 = 0;
            int tongbohoclop2 = 0;
            int tongbohoclop3 = 0;
            int tongbohoclop4 = 0;
            int tongbohoclop5 = 0;
            int namsinhhientai = DateTime.Now.Year - 6;
            for (int i = 0; i < 7; i++)
            {
                int namsinh = namsinhhientai - i;
                string[] mangdong = new string[17];
                mangdong[0] = namsinh.ToString();

                //tong so thanh vien co nam sinh 
                int tongsothanhvien = (from p in db.tbThanhViens
                                       where p.NgaySinh.Value.Year == namsinh
                                       select p).Count();
                tongtongsothanhvien = tongtongsothanhvien + tongsothanhvien;
                mangdong[1] = tongsothanhvien.ToString();

                //tong so thanhvien nu trong nam do
                int tongsothanhviennu = (from p in db.tbThanhViens
                                         where p.NgaySinh.Value.Year == namsinh && p.GioiTinh == "Nữ"
                                         select p).Count();
                tongtongsothanhviennu = tongtongsothanhviennu + tongsothanhviennu;
                mangdong[2] = tongsothanhviennu.ToString();
                int tongsothanhviennam = (from p in db.tbThanhViens
                                          where p.NgaySinh.Value.Year == namsinh && p.GioiTinh == "Nam"
                                          select p).Count();
                tongtongsothanhviennam = tongtongsothanhviennam + tongsothanhviennam;
                mangdong[3] = tongsothanhviennam.ToString();

                int dantoc = (from p in db.tbThanhViens
                              where p.NgaySinh.Value.Year == namsinh && p.DanToc != "Kinh"
                              select p).Count();
                tongdantoc = tongdantoc + dantoc;
                mangdong[4] = dantoc.ToString();

                int khuyettat = (from p in db.tbThanhViens
                                 where p.NgaySinh.Value.Year == namsinh && p.TinhTrang != "bình thường"
                                 select p).Count();
                tongkhuyettat = tongkhuyettat + khuyettat;
                mangdong[5] = khuyettat.ToString();
                int phaiphocap = tongsothanhvien - khuyettat;
                tongphaiphocap = tongphaiphocap + phaiphocap;
                mangdong[6] = phaiphocap.ToString();
                int danghoclop1 = (from p in db.tbThanhViens
                                   where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 1"
                                   select p).Count();
                tongdanghoclop1 = tongdanghoclop1 + danghoclop1;
                mangdong[7] = danghoclop1.ToString();
                int danghoclop2 = (from p in db.tbThanhViens
                                   where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 2"
                                   select p).Count();
                tongdanghoclop2 = tongdanghoclop2 + danghoclop2;
                mangdong[8] = danghoclop2.ToString();
                int danghoclop3 = (from p in db.tbThanhViens
                                   where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 3"
                                   select p).Count();
                tongdanghoclop3 = tongdanghoclop3 + danghoclop3;
                mangdong[9] = danghoclop3.ToString();
                int danghoclop4 = (from p in db.tbThanhViens
                                   where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 4"
                                   select p).Count();
                tongdanghoclop4 = tongdanghoclop4 + danghoclop4;
                mangdong[10] = danghoclop4.ToString();
                int danghoclop5 = (from p in db.tbThanhViens
                                   where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 5"
                                   select p).Count();
                tongdanghoclop5 = tongdanghoclop5 + danghoclop5;

                mangdong[11] = danghoclop5.ToString();

                int bohoclop1 = (from p in db.tbThanhViens where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "BH1" select p).Count();
                tongbohoclop1 = tongbohoclop1 + bohoclop1;
                mangdong[12] = bohoclop1.ToString();


                int bohoclop2 = (from p in db.tbThanhViens where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "BH2" select p).Count();
                tongbohoclop2 = tongbohoclop2 + bohoclop2;
                mangdong[13] = bohoclop2.ToString();


                int bohoclop3 = (from p in db.tbThanhViens where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "BH3" select p).Count();
                
                tongbohoclop3 = tongbohoclop3 + bohoclop3;
                mangdong[14] = bohoclop3.ToString();



                int bohoclop4 = (from p in db.tbThanhViens where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "BH4" select p).Count();
                tongbohoclop4 = tongbohoclop4 + bohoclop4;
                mangdong[15] = bohoclop1.ToString();



                int bohoclop5 = (from p in db.tbThanhViens where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "BH5" select p).Count();
                tongbohoclop5 = tongbohoclop5 + bohoclop5;
                mangdong[16] = bohoclop5.ToString();



                
                dgvPhoCap.Rows.Add(mangdong);
            }


            string[] mangtongso = new string[17];
            mangtongso[0] = "Tổng số:";
            mangtongso[1] = tongtongsothanhvien.ToString();
            mangtongso[2] = tongtongsothanhviennu.ToString();
            mangtongso[3] = tongtongsothanhviennam.ToString();
            mangtongso[4] = tongdantoc.ToString();
            mangtongso[5] = tongkhuyettat.ToString();
            mangtongso[6] = tongphaiphocap.ToString();
            mangtongso[7] = tongdanghoclop1.ToString();
            mangtongso[8] = tongdanghoclop2.ToString();
            mangtongso[9] = tongdanghoclop3.ToString();
            mangtongso[10] = tongdanghoclop4.ToString();
            mangtongso[11] = tongdanghoclop5.ToString();
            mangtongso[12] = tongbohoclop1.ToString();
            mangtongso[13] = tongbohoclop2.ToString();
            mangtongso[14] = tongbohoclop3.ToString();
            mangtongso[15] = tongbohoclop4.ToString();
            mangtongso[16] = tongbohoclop5.ToString();
            dgvPhoCap.Rows.Add(mangtongso);


        }

        private void tbnTKGiaoVien_Click(object sender, EventArgs e)
        {

        }

        private void tbnTKGiaoVien_Click_1(object sender, EventArgs e)
        {

            var dstruong = from p in db.tbTruongs select p;
            foreach (tbTruong truong in dstruong)
            {
                string[] mangdong = new string[21];

                mangdong[0] = truong.TenTruong;

                int sohieutruong = (from p in db.tbGiaoViens
                                    where p.MaTruong == truong.MaTruong && p.ChucVu == "Hiệu trưởng"
                                    select p).Count();
                mangdong[1] = sohieutruong.ToString();
                int sophohieutruong = (from p in db.tbGiaoViens
                                       where p.MaTruong == truong.MaTruong && p.ChucVu == "Phó hiệu trưởng"
                                       select p).Count();
                mangdong[2] = sophohieutruong.ToString();
                int socanbo = (from p in db.tbGiaoViens
                               where p.MaTruong == truong.MaTruong
                               select p).Count();
                mangdong[3] = socanbo.ToString();

                int sobienche = (from p in db.tbGiaoViens
                                 where p.MaTruong == truong.MaTruong && p.TinhTrangCongTac == "Biên chế"
                                 select p).Count();
                mangdong[4] = sobienche.ToString();

                int sonam = (from p in db.tbGiaoViens
                             where p.MaTruong == truong.MaTruong && p.GioiTinh == "Nam"
                             select p).Count();
                mangdong[5] = sonam.ToString();
                int sonu = (from p in db.tbGiaoViens
                            where p.MaTruong == truong.MaTruong && p.GioiTinh == "Nữ"
                            select p).Count();
                mangdong[6] = sonu.ToString();

                int sotrendaihoc = (from p in db.tbGiaoViens
                                    where p.MaTruong == truong.MaTruong && p.TrinhDo == "Trên đại học"
                                    select p).Count();
                mangdong[7] = sotrendaihoc.ToString();

                int sodaihoc = (from p in db.tbGiaoViens
                                where p.MaTruong == truong.MaTruong && p.TrinhDo == "Đại học"
                                select p).Count();
                mangdong[8] = sodaihoc.ToString();
                int socaodang = (from p in db.tbGiaoViens
                                 where p.MaTruong == truong.MaTruong && p.TrinhDo == "Cao đẳng"
                                 select p).Count();
                mangdong[9] = socaodang.ToString();

                int sotrungcap = (from p in db.tbGiaoViens
                                  where p.MaTruong == truong.MaTruong && p.TrinhDo == "Trung cấp"
                                  select p).Count();
                mangdong[10] = sotrungcap.ToString();
                int socoban = (from p in db.tbGiaoViens
                               where p.MaTruong == truong.MaTruong && p.ChuyenNganh == "Tổng hợp"
                               select p).Count();
                mangdong[11] = socoban.ToString();
                int soamnhac = (from p in db.tbGiaoViens
                                where p.MaTruong == truong.MaTruong && p.ChuyenNganh == "Âm nhạc"
                                select p).Count();
                mangdong[12] = soamnhac.ToString();
                int somythuat = (from p in db.tbGiaoViens
                                 where p.MaTruong == truong.MaTruong && p.ChuyenNganh == "Mỹ thuật"
                                 select p).Count();
                mangdong[13] = somythuat.ToString();
                int sotheduc = (from p in db.tbGiaoViens
                                where p.MaTruong == truong.MaTruong && p.ChuyenNganh == "Thể dục"
                                select p).Count();
                mangdong[14] = sotheduc.ToString();
                int sotin = (from p in db.tbGiaoViens
                             where p.MaTruong == truong.MaTruong && p.ChuyenNganh == "Tin"
                             select p).Count();
                mangdong[15] = sotin.ToString();
                int songoaingu = (from p in db.tbGiaoViens
                                  where p.MaTruong == truong.MaTruong && p.ChuyenNganh == "Ngoại ngữ"
                                  select p).Count();
                mangdong[16] = songoaingu.ToString();
                int sogioicaptinh = (from p in db.tbGiaoViens
                                     where p.MaTruong == truong.MaTruong && p.XepLoaiGiaoVien == "Giỏi cấp tỉnh"
                                     select p).Count();
                mangdong[17] = sogioicaptinh.ToString();

                int sogioicaptruong = (from p in db.tbGiaoViens
                                       where p.MaTruong == truong.MaTruong && p.XepLoaiGiaoVien == "Giỏi cấp trường"
                                       select p).Count();
                mangdong[19] = sogioicaptruong.ToString();
                int sogioicaphuyen = (from p in db.tbGiaoViens
                                      where p.MaTruong == truong.MaTruong && p.XepLoaiGiaoVien == "Giỏi cấp huyện"
                                      select p).Count();
                mangdong[18] = sogioicaphuyen.ToString();
                int socanbovanphong = (from p in db.tbGiaoViens
                                       where p.MaTruong == truong.MaTruong && p.ChucVu == "Cán bộ văn thư"
                                       select p).Count();
                mangdong[20] = socanbovanphong.ToString();
                dgvTKGiaoVien.Rows.Add(mangdong);
            }




        }

        private void btnTKGioiTinh_Click(object sender, EventArgs e)
        {
            int tongtongsothanhvien = 0;
            int tongtongsothanhviennu = 0;
            int tongtongsothanhviennam = 0;
            int tongdanghoclop1nu = 0;
            int tongdanghoclop1nam = 0;
            int tongdanghoclop2nu = 0;
            int tongdanghoclop2nam = 0;
            int tongdanghoclop3nu = 0;
            int tongdanghoclop3nam = 0;
            int tongdanghoclop4nu = 0;
            int tongdanghoclop4nam = 0;
          
            int tongdanghoclop5nu = 0;
            int tongdanghoclop5nam = 0;
            int namsinhhientai = DateTime.Now.Year - 6;
            int namhientai = DateTime.Now.Year;
            for (int i = 0; i < 7; i++)
            {
                int namsinh = namsinhhientai - i;
                string[] mangdong = new string[17];
                mangdong[0] = namsinh.ToString();


                int dotuoi = namhientai - namsinh;
                mangdong[1] = dotuoi.ToString();

                int tongsothanhvien = (from p in db.tbThanhViens
                                       where p.NgaySinh.Value.Year == namsinh
                                       select p).Count();
                tongtongsothanhvien = tongtongsothanhvien + tongsothanhvien;
                mangdong[2] = tongsothanhvien.ToString();

                int tongsothanhviennu = (from p in db.tbThanhViens
                                         where p.NgaySinh.Value.Year == namsinh && p.GioiTinh == "Nữ"
                                         select p).Count();
                tongtongsothanhviennu = tongtongsothanhviennu + tongsothanhviennu;
                mangdong[4] = tongsothanhviennu.ToString();

                int tongsothanhviennam = (from p in db.tbThanhViens
                                          where p.NgaySinh.Value.Year == namsinh && p.GioiTinh == "Nam"
                                          select p).Count();
                tongtongsothanhviennam = tongtongsothanhviennam + tongsothanhviennam;
                mangdong[3] = tongsothanhviennam.ToString();

             

                int danghoclop1nu = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 1" && p.GioiTinh == "Nữ"
                                     select p).Count();
                tongdanghoclop1nu = tongdanghoclop1nu + danghoclop1nu;
                
              
                mangdong[6] = danghoclop1nu.ToString();

                int danghoclop1nam = (from p in db.tbThanhViens
                                      where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 1" && p.GioiTinh == "Nam"
                                      select p).Count();
                tongdanghoclop1nam = tongdanghoclop1nam + danghoclop1nam;
                mangdong[5] = danghoclop1nam.ToString();
               

                int danghoclop2nu = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 2" && p.GioiTinh == "Nữ"
                                     select p).Count();
                tongdanghoclop2nu = tongdanghoclop2nu + danghoclop2nu;
                mangdong[8] = danghoclop2nu.ToString();
                int danghoclop2nam = (from p in db.tbThanhViens
                                      where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 2" && p.GioiTinh == "Nam"
                                      select p).Count();
                tongdanghoclop2nam = tongdanghoclop2nam + danghoclop2nam;
                mangdong[7] = danghoclop2nam.ToString();
                

                int danghoclop3nu = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 3" && p.GioiTinh == "Nữ"
                                     select p).Count();
                tongdanghoclop3nu = tongdanghoclop3nu + danghoclop3nu;
                mangdong[10] = danghoclop3nu.ToString();
                int danghoclop3nam = (from p in db.tbThanhViens
                                      where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 3" && p.GioiTinh == "Nam"
                                      select p).Count();
                tongdanghoclop3nam = tongdanghoclop3nam + danghoclop3nam;

                mangdong[9] = danghoclop3nam.ToString();
                

                int danghoclop4nu = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 4" && p.GioiTinh == "Nữ"
                                     select p).Count();
                tongdanghoclop4nu = tongdanghoclop4nu + danghoclop4nu;
                mangdong[12] = danghoclop4nu.ToString();


                int danghoclop4nam = (from p in db.tbThanhViens
                                      where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 4" && p.GioiTinh == "Nam"
                                      select p).Count();
                tongdanghoclop4nam = tongdanghoclop4nam + danghoclop4nam;
                mangdong[11] = danghoclop4nam.ToString();
               

                int danghoclop5nu = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 5"
                                     select p).Count();
                tongdanghoclop5nu = tongdanghoclop5nu + danghoclop5nu;
                mangdong[14] = danghoclop5nu.ToString();

                int danghoclop5nam = (from p in db.tbThanhViens
                                      where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 5" && p.GioiTinh == "Nam"
                                      select p).Count();
                tongdanghoclop5nam = tongdanghoclop5nam + danghoclop5nam;
                mangdong[13] = danghoclop5nam.ToString();
               // tong so nam
                int tongnam = danghoclop1nam + danghoclop2nam + danghoclop3nam + danghoclop4nam + danghoclop5nam;
                mangdong[15] = tongnam.ToString();
                // tong nu 
                int tongnu = danghoclop1nu + danghoclop2nu + danghoclop3nu + danghoclop4nu + danghoclop5nu;
                mangdong[16] = tongnu.ToString();
                dgvGioiTinh.Rows.Add(mangdong);
            }

                string[] mangtongso = new string[17];
                mangtongso[0] = "Tổng:";
                mangtongso[2] = tongtongsothanhvien.ToString();
                mangtongso[4] = tongtongsothanhviennu.ToString();
                mangtongso[3] = tongtongsothanhviennam.ToString();
                mangtongso[5] = tongdanghoclop1nam.ToString();
                mangtongso[6] = tongdanghoclop1nu.ToString();
                mangtongso[7] = tongdanghoclop2nam.ToString();
                mangtongso[8] = tongdanghoclop2nu.ToString();
                mangtongso[9] = tongdanghoclop3nam.ToString();
                mangtongso[10] = tongdanghoclop3nu.ToString();
                mangtongso[11] = tongdanghoclop4nam.ToString();
                mangtongso[12] = tongdanghoclop4nu.ToString();
                mangtongso[13] = tongdanghoclop5nam.ToString();
                mangtongso[14] = tongdanghoclop5nu.ToString();
                dgvGioiTinh. Rows.Add(mangtongso);


        

                
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

        private void btnXuat_Click(object sender, EventArgs e)
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

                    xlWorkSheet.get_Range("g4", "k4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g4", "k4");
                    chageRange.FormulaR1C1 = "THỐNG KÊ HỌC SINH PHỔ CẬP";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 16;

                    int sodong = dgvPhoCap.RowCount + 7;
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
                    string M = "M" + sodong.ToString();
                    string N = "N" + sodong.ToString();
                    string o = "o" + sodong.ToString();
                    string p = "p" + sodong.ToString();
                    string q = "q" + sodong.ToString();


                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 10;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 9;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 4;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", D);
                    chageRange.ColumnWidth = 4;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 4;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth =12 ;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //h
                    chageRange = xlWorkSheet.get_Range("h1", h);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //i
                    chageRange = xlWorkSheet.get_Range("i1", I);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //j
                    chageRange = xlWorkSheet.get_Range("j1", J);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //k
                    chageRange = xlWorkSheet.get_Range("k1", k);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //l
                    chageRange = xlWorkSheet.get_Range("l1", l);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    chageRange = xlWorkSheet.get_Range("M1", M);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    chageRange = xlWorkSheet.get_Range("N1", N);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    chageRange = xlWorkSheet.get_Range("o1", o);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;


                    chageRange = xlWorkSheet.get_Range("p1", p);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    chageRange = xlWorkSheet.get_Range("q1", q);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    xlWorkSheet.get_Range("p1", "q1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("p1", "q1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("p2", "q2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("p2", "q2");
                    chageRange.FormulaR1C1 = "Tỉnh Long An";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("I5", "k5").Merge(false);
                    chageRange = xlWorkSheet.get_Range("I5", "k5");
                    chageRange.FormulaR1C1 = "Thời điểm tháng 9 năm 2011";
                    chageRange.RowHeight = 20;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


                    chageRange = xlWorkSheet.get_Range("a7", "g7");
                    chageRange.RowHeight = 30;
                    chageRange.Font.Bold = true;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //Font chữ
                    chageRange = xlWorkSheet.get_Range("a1", q);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a7", q);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //chageRange = xlWorkSheet.get_Range("a6", a);
                    xlWorkSheet.get_Range("a7", "a7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a7", "a7");
                    chageRange.FormulaR1C1 = "Năm sinh";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("b7", "b7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b7", "b7");
                    chageRange.FormulaR1C1 = "Tổng số";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c7", "c7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c7", "c7");
                    chageRange.FormulaR1C1 = "Nữ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d7", "d7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d7", "d7");
                    chageRange.FormulaR1C1 = "Nam";
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
                    chageRange.FormulaR1C1 = "Khuyết tật ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g7", "g7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g7", "g7");
                    chageRange.FormulaR1C1 = "Phải PC";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("h7", "h7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("h7", "h7");
                    chageRange.FormulaR1C1 = "Học Lớp 1";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;




                    xlWorkSheet.get_Range("i7", "i7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("i7", "i7");
                    chageRange.FormulaR1C1 = "Học Lớp 2";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("j7", "j7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("j7", "j7");
                    chageRange.FormulaR1C1 = "Học Lớp 3";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("k7", "k7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("k7", "k7");
                    chageRange.FormulaR1C1 = "Học Lớp 4";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("l7", "l7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("l7", "l7");
                    chageRange.FormulaR1C1 = "Học Lớp 5";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("M7", "M7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("M7", "M7");
                    chageRange.FormulaR1C1 = "Bỏ học L1";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("N7", "N7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("N7", "N7");
                    chageRange.FormulaR1C1 = "Bỏ học L2";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("o7", "o7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("o7", "o7");
                    chageRange.FormulaR1C1 = "Bỏ học L3";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("p7", "p7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("p7", "p7");
                    chageRange.FormulaR1C1 = "Bỏ học L4";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("q7", "q7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("q7", "q7");
                    chageRange.FormulaR1C1 = "Bỏ học L5";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;





                    int n = 0;
                    int m = 0;

                    for (n = 0; n <= dgvPhoCap.RowCount - 1; n++)
                    {
                        for (m = 0; m <= dgvPhoCap.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvPhoCap[m, n];
                            xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;
                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                        }

                    }
                    string N1 = "N" + (sodong + 5).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(N1, N1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    //
                    string N2 = "N" + (sodong + 6).ToString();
                    string q1 = "q" + (sodong + 6).ToString();
                    chageRange = xlWorkSheet.get_Range(N2, q1);
                    xlWorkSheet.get_Range(N2, q1).Merge(false);
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

        private void button1_Click(object sender, EventArgs e)
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


                    xlWorkSheet.get_Range("a1", "b1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a1", "b1");
                    chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    xlWorkSheet.get_Range("a2", "b2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a2", "b2");
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.FormulaR1C1 = "Xã Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;

                    xlWorkSheet.get_Range("c4", "k4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c4", "k4");
                    chageRange.FormulaR1C1 = "THỐNG KÊ ĐỘI NGŨ GIÁO VIÊN ";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 16;

                    int sodong = dgvPhoCap.RowCount + 7;
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
                    string M = "m" + sodong.ToString();
                    string N = "n" + sodong.ToString();
                    string o = "o" + sodong.ToString();
                    string p = "p" + sodong.ToString();
                    string q = "q" + sodong.ToString();
                    string r = "r" + sodong.ToString();
                    string s = "s" + sodong.ToString();
                    string t = "t" + sodong.ToString();



                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 25;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 4;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 4;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", D);
                    chageRange.ColumnWidth = 9;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth = 5;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //h
                    chageRange = xlWorkSheet.get_Range("h1", h);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //i
                    chageRange = xlWorkSheet.get_Range("i1", I);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //j
                    chageRange = xlWorkSheet.get_Range("j1", J);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //k
                    chageRange = xlWorkSheet.get_Range("k1", k);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //l
                    chageRange = xlWorkSheet.get_Range("l1", l);
                    chageRange.ColumnWidth = 5;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //m
                    chageRange = xlWorkSheet.get_Range("m1", M);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //n
                    chageRange = xlWorkSheet.get_Range("n1", N);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //o
                    chageRange = xlWorkSheet.get_Range("o1", o);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //p
                    chageRange = xlWorkSheet.get_Range("p1", p);
                    chageRange.ColumnWidth = 4;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //q
                    chageRange = xlWorkSheet.get_Range("q1", q);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //r
                    chageRange = xlWorkSheet.get_Range("r1", r);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //s
                    chageRange = xlWorkSheet.get_Range("s1", s);
                    chageRange.ColumnWidth = 5;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //t
                    chageRange = xlWorkSheet.get_Range("t1", t);
                    chageRange.ColumnWidth = 3;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    xlWorkSheet.get_Range("o1", "t1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("o1", "t1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("o2", "t2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("o2", "t2");
                    chageRange.FormulaR1C1 = "Tỉnh Long An";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("e5", "J5").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e5", "J5");
                    chageRange.FormulaR1C1 = "Thời điểm tháng 9 năm 2010";
                    chageRange.RowHeight = 20;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;



                    //Font chữ
                    chageRange = xlWorkSheet.get_Range("a1", t);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a7", t);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //chageRange = xlWorkSheet.get_Range("a6", a);
                    xlWorkSheet.get_Range("a7", "a7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a7", "a7");
                    chageRange.FormulaR1C1 = "Tên trường";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("b7", "b7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b7", "b7");
                    chageRange.FormulaR1C1 = "HT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c7", "c7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c7", "c7");
                    chageRange.FormulaR1C1 = "PHT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d7", "d7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d7", "d7");
                    chageRange.FormulaR1C1 = "Tổng GV";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("e7", "e7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e7", "e7");
                    chageRange.FormulaR1C1 = "BC";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("f7", "f7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f7", "f7");
                    chageRange.FormulaR1C1 = "Nam ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g7", "g7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g7", "g7");
                    chageRange.FormulaR1C1 = "Nữ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("h7", "h7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("h7", "h7");
                    chageRange.FormulaR1C1 = "Trên ĐH";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;




                    xlWorkSheet.get_Range("i7", "i7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("i7", "i7");
                    chageRange.FormulaR1C1 = "ĐH";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("j7", "j7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("j7", "j7");
                    chageRange.FormulaR1C1 = "CĐ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("k7", "k7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("k7", "k7");
                    chageRange.FormulaR1C1 = "CB";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("l7", "l7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("l7", "l7");
                    chageRange.FormulaR1C1 = "Nhạc";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("m7", "m7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("m7", "m7");
                    chageRange.FormulaR1C1 = "MT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("n7", "n7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("n7", "n7");
                    chageRange.FormulaR1C1 = "TD";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("o7", "o7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("o7", "o7");
                    chageRange.FormulaR1C1 = "Tin";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("p7", "p7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("p7", "p7");
                    chageRange.FormulaR1C1 = "NN";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("q7", "q7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("q7", "q7");
                    chageRange.FormulaR1C1 = "CT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("r7", "r7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("r7", "r7");
                    chageRange.FormulaR1C1 = "CH";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("s7", "s7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("s7", "s7");
                    chageRange.FormulaR1C1 = "CTr";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("t7", "t7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("t7", "t7");
                    chageRange.FormulaR1C1 = "NV";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    int n = 0;
                    int m = 0;

                    for (n = 0; n <= dgvTKGiaoVien.RowCount - 1; n++)
                    {
                        for (m = 0; m <= dgvTKGiaoVien.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvTKGiaoVien[m, n];
                            xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;
                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                        }

                    }
                    //string a1 = "a" + (sodong + 4).ToString();
                    //chageRange = xlWorkSheet.get_Range(a1, a1);
                    //chageRange.RowHeight = 20;
                    //chageRange.FormulaR1C1 = "Tỷ lệ giáo viên: ";
                    //chageRange.Font.Name = "Time New Roman";
                    //chageRange.Font.Bold = true;
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;


                    string a2 = "a" + (sodong + 5).ToString();
                    chageRange = xlWorkSheet.get_Range(a2, a2);
                    chageRange.RowHeight = 20;
                    chageRange.FormulaR1C1 = "Người lập biểu ";
                    chageRange.Font.Name = "Time New Roman";

                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    //string a3 = "a" + (sodong + 6).ToString();
                    //chageRange = xlWorkSheet.get_Range(a3, a3);
                    //chageRange.RowHeight = 20;
                    //chageRange.FormulaR1C1 = "Đạt chuẩn ";
                    //chageRange.Font.Name = "Time New Roman";
                    //chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    string l1 = "l" + (sodong + 5).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(l1, l1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    ////
                    string l2 = "l" + (sodong + 6).ToString();
                    string t1 = "t" + (sodong + 6).ToString();
                    chageRange = xlWorkSheet.get_Range(l2, t1);
                    xlWorkSheet.get_Range(l2, t1).Merge(false);
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

        private void button2_Click(object sender, EventArgs e)
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


                    xlWorkSheet.get_Range("a1", "e1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a1", "e1");
                        
                    chageRange.FormulaR1C1 = "Trường tiểu học Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    xlWorkSheet.get_Range("a2", "e2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a2", "e2");
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.FormulaR1C1 = "Xã Dân Tiến";
                    chageRange.RowHeight = 20;
                    chageRange.Font.Size = 12;

                    xlWorkSheet.get_Range("g4", "J4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g4", "J4");
                    chageRange.FormulaR1C1 = "THỐNG KÊ GIỚI TÍNH";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 16;

                    int sodong = dgvPhoCap.RowCount + 7;
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
                    string M = "m" + sodong.ToString();
                    string N = "n" + sodong.ToString();
                    string o = "o" + sodong.ToString();
                    string p = "p" + sodong.ToString();
                    string q = "q" + sodong.ToString();






                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 4;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 4;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 8;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", D);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 6;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth = 7;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 7;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //h
                    chageRange = xlWorkSheet.get_Range("h1", h);
                    chageRange.ColumnWidth = 7;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //i
                    chageRange = xlWorkSheet.get_Range("i1", I);
                    chageRange.ColumnWidth = 7;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //j
                    chageRange = xlWorkSheet.get_Range("j1", J);
                    chageRange.ColumnWidth = 7;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //k
                    chageRange = xlWorkSheet.get_Range("k1", k);
                    chageRange.ColumnWidth = 6;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //l
                    chageRange = xlWorkSheet.get_Range("l1", l);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //m
                    chageRange = xlWorkSheet.get_Range("m1", M);
                    chageRange.ColumnWidth = 6;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //n
                    chageRange = xlWorkSheet.get_Range("n1", N);
                    chageRange.ColumnWidth = 8;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //o
                    chageRange = xlWorkSheet.get_Range("o1", o);
                    chageRange.ColumnWidth = 6;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    chageRange = xlWorkSheet.get_Range("p1", p);
                    chageRange.ColumnWidth = 4;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    chageRange = xlWorkSheet.get_Range("q1", q);
                    chageRange.ColumnWidth = 4;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    //chageRange = xlWorkSheet.get_Range("o1", o);
                    //chageRange.ColumnWidth = 8;

                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    xlWorkSheet.get_Range("n1", "q1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("n1", "q1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("n2", "q2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("n2", " q2");
                    chageRange.FormulaR1C1 = "Tỉnh Long An";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("h5", "k5").Merge(false);
                    chageRange = xlWorkSheet.get_Range("h5", "k5");
                    chageRange.FormulaR1C1 = "Thời điểm tháng 9 năm 2011";
                    chageRange.RowHeight = 20;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                    chageRange = xlWorkSheet.get_Range("a7", "g7");
                    chageRange.RowHeight = 30;
                    chageRange.Font.Bold = true;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    //Font chữ
                    chageRange = xlWorkSheet.get_Range("a1", q);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a7", q);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //chageRange = xlWorkSheet.get_Range("a6", a);
                    xlWorkSheet.get_Range("a7", "a7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a7", "a7");
                    chageRange.FormulaR1C1 = "NS";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("b7", "b7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b7", "b7");
                    chageRange.FormulaR1C1 = "ĐT";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c7", "c7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c7", "c7");
                    chageRange.FormulaR1C1 = "Tổng PC";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d7", "d7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d7", "d7");
                    chageRange.FormulaR1C1 = " Nam PC";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("e7", "e7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e7", "e7");
                    chageRange.FormulaR1C1 = "Nữ PC";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("f7", "f7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f7", "f7");
                    chageRange.FormulaR1C1 = "NamL1 ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g7", "g7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g7", "g7");
                    chageRange.FormulaR1C1 = "Nữ L1";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("h7", "h7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("h7", "h7");
                    chageRange.FormulaR1C1 = "Nam L2";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;




                    xlWorkSheet.get_Range("i7", "i7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("i7", "i7");
                    chageRange.FormulaR1C1 = "Nữ L2";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("j7", "j7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("j7", "j7");
                    chageRange.FormulaR1C1 = "NamL3";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("k7", "k7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("k7", "k7");
                    chageRange.FormulaR1C1 = "Nữ L3";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("l7", "l7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("l7", "l7");
                    chageRange.FormulaR1C1 = "Nam L4";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("m7", "m7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("m7", "m7");
                    chageRange.FormulaR1C1 = "Nữ L4";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("n7", "n7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("n7", "n7");
                    chageRange.FormulaR1C1 = "Nam L5";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("o7", "o7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("o7", "o7");
                    chageRange.FormulaR1C1 = "Nữ L5";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("p7", "p7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("p7", "p7");
                    chageRange.FormulaR1C1 = "TN";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("q7", "q7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("q7", "q7");
                    chageRange.FormulaR1C1 = "Nữ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;






                    int n = 0;
                    int m = 0;

                    for (n = 0; n <= dgvGioiTinh.RowCount - 1; n++)
                    {
                        for (m = 0; m <= dgvGioiTinh.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvGioiTinh[m, n];
                            xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;

                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                        }

                    }


                    string l1 = "l" + (sodong + 10).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(l1, l1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    //////
                    string l2 = "l" + (sodong + 11).ToString();
                    string q1 = "q" + (sodong +11).ToString();
                    chageRange = xlWorkSheet.get_Range(l2, q1);
                    xlWorkSheet.get_Range(l2, q1).Merge(false);
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



        private void button3_Click(object sender, EventArgs e)
        {
            int namsinhhientai = DateTime.Now.Year - 6;
            int namhientai = DateTime.Now.Year;
            for (int i = 0; i < 7; i++)
            {
                int namsinh = namsinhhientai - i;
                string[] mangdong = new string[10];
                mangdong[0] = namsinh.ToString();

                int dotuoi = namhientai - namsinh;
                mangdong[1] = dotuoi.ToString();

                int tongsothanhvien = (from p in db.tbThanhViens
                                       where p.NgaySinh.Value.Year == namsinh
                                       select p).Count();
                mangdong[2] = tongsothanhvien.ToString();
                int danghoclop1cs = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 1" && p.GiaDinhChinhSach == "Thương binh" && p.GiaDinhChinhSach == "Liệt sĩ"
                                     select p).Count();
                //tongdanghoclop1 = tongdanghoclop1 + danghoclop1;
                mangdong[4] = danghoclop1cs.ToString();


                int dienchinhsach = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.GiaDinhChinhSach == "Thương binh" && p.GiaDinhChinhSach == "Liệt sĩ"
                                     select p).Count();
                mangdong[3] = dienchinhsach.ToString();

                int danghoclop2cs = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 2" && p.GiaDinhChinhSach == "Thương binh" && p.GiaDinhChinhSach == "Liệt sĩ"
                                     select p).Count();
                //tongdanghoclop1 = tongdanghoclop1 + danghoclop1;
                mangdong[5] = danghoclop2cs.ToString();

                int danghoclop3cs = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 3" && p.GiaDinhChinhSach == "Thương binh" && p.GiaDinhChinhSach == "Liệt sĩ"
                                     select p).Count();
                //tongdanghoclop1 = tongdanghoclop1 + danghoclop1;
                mangdong[6] = danghoclop3cs.ToString();

                int danghoclop4cs = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 3" && p.GiaDinhChinhSach == "Thương binh" && p.GiaDinhChinhSach == "Liệt sĩ"
                                     select p).Count();
                //tongdanghoclop1 = tongdanghoclop1 + danghoclop1;
                mangdong[7] = danghoclop3cs.ToString();


                int danghoclop5cs = (from p in db.tbThanhViens
                                     where p.NgaySinh.Value.Year == namsinh && p.TrinhDo5 == "Lớp 3" && p.GiaDinhChinhSach == "Thương binh" && p.GiaDinhChinhSach == "Liệt sĩ"
                                     select p).Count();
                //tongdanghoclop1 = tongdanghoclop1 + danghoclop1;
                mangdong[8] = danghoclop3cs.ToString();
                int tongchinhsach = danghoclop1cs + danghoclop2cs + danghoclop3cs + danghoclop4cs + danghoclop5cs;
                mangdong[9] = tongchinhsach.ToString();

                dgvDCS.Rows.Add(mangdong);



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

                    xlWorkSheet.get_Range("d4", "g4").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d4", "g4");
                    chageRange.FormulaR1C1 = "THỐNG KÊ DIỆN CHÍNH SÁCH";
                    chageRange.RowHeight = 25;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;
                    chageRange.Font.Size = 16;

                    int sodong = dgvPhoCap.RowCount + 7;
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
                  

                    //a
                    chageRange = xlWorkSheet.get_Range("a1", a);
                    chageRange.ColumnWidth = 10;
                    chageRange.Columns.Cells.FillLeft();
                    //b
                    chageRange = xlWorkSheet.get_Range("b1", b);
                    chageRange.ColumnWidth = 10;
                    chageRange.Columns.Cells.FillLeft();
                    //c
                    chageRange = xlWorkSheet.get_Range("c1", c);
                    chageRange.ColumnWidth = 8;
                    //d
                    chageRange = xlWorkSheet.get_Range("d1", D);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //e
                    chageRange = xlWorkSheet.get_Range("e1", E);
                    chageRange.ColumnWidth = 10;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //f
                    chageRange = xlWorkSheet.get_Range("f1", f);
                    chageRange.ColumnWidth = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //g
                    chageRange = xlWorkSheet.get_Range("g1", g);
                    chageRange.ColumnWidth = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //h
                    chageRange = xlWorkSheet.get_Range("h1", h);
                    chageRange.ColumnWidth = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //i
                    chageRange = xlWorkSheet.get_Range("i1", I);
                    chageRange.ColumnWidth = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    //j
                    chageRange = xlWorkSheet.get_Range("j1", J);
                    chageRange.ColumnWidth = 12;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    xlWorkSheet.get_Range("I1", "J1").Merge(false);
                    chageRange = xlWorkSheet.get_Range("I1", "J1");
                    chageRange.FormulaR1C1 = "Huyện Khoái Châu";
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Size = 12;


                    xlWorkSheet.get_Range("I2", "J2").Merge(false);
                    chageRange = xlWorkSheet.get_Range("I2", "J2");
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
                    chageRange = xlWorkSheet.get_Range("a1", J);
                    chageRange.Font.Name = "Time New Roman";

                    //kẻ khung
                    chageRange = xlWorkSheet.get_Range("a7", J);
                    chageRange.Borders.Value = 1;
                    chageRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                    //chageRange = xlWorkSheet.get_Range("a6", a);
                    xlWorkSheet.get_Range("a7", "a7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("a7", "a7");
                    chageRange.FormulaR1C1 = "Năm sinh";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("b7", "b7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("b7", "b7");
                    chageRange.FormulaR1C1 = "Độ tuổi";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("c7", "c7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("c7", "c7");
                    chageRange.FormulaR1C1 = "Tổng PC";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("d7", "d7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("d7", "d7");
                    chageRange.FormulaR1C1 = "DCS PC";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("e7", "e7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("e7", "e7");
                    chageRange.FormulaR1C1 = "DCS Lớp1";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("f7", "f7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("f7", "f7");
                    chageRange.FormulaR1C1 = "DCS Lớp2 ";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("g7", "g7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("g7", "g7");
                    chageRange.FormulaR1C1 = "DCS Lớp3";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                    xlWorkSheet.get_Range("h7", "h7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("h7", "h7");
                    chageRange.FormulaR1C1 = "DCS Lớp4";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;




                    xlWorkSheet.get_Range("i7", "i7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("i7", "i7");
                    chageRange.FormulaR1C1 = "DCS Lớp5";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;


                    xlWorkSheet.get_Range("j7", "j7").Merge(false);
                    chageRange = xlWorkSheet.get_Range("j7", "j7");
                    chageRange.FormulaR1C1 = "Tổng DCS";
                    chageRange.Font.Size = 11;
                    chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    chageRange.Font.Bold = true;

                 


                    int n = 0;
                    int m = 0;

                    for (n = 0; n <= dgvDCS.RowCount - 1; n++)
                    {
                        for (m = 0; m <= dgvDCS.ColumnCount - 1; m++)
                        {
                            DataGridViewCell cell = dgvDCS[m, n];
                            xlWorkSheet.Cells[n + 8, m + 1] = cell.Value;
                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                            chageRange.Font.Name = "Time New Roman";
                            chageRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                            chageRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                            //chageRange.Borders.LineStyle = BorderStyle.FixedSingle;
                        }

                    }
                    string h1 = "h" + (sodong + 9).ToString();
                    string[] date = DateTime.Now.ToShortDateString().Split('/');
                    chageRange = xlWorkSheet.get_Range(h1, h1);
                    chageRange.FormulaR1C1 = "Long An, Ngày " + date[0] + " tháng " + date[1] + " năm " + date[2];
                    chageRange.RowHeight = 20;
                    chageRange.Font.Name = "Time New Roman";
                    //////

                    string h2 = "h" + (sodong + 10).ToString();
                    string J1 = "J" + (sodong + 10).ToString();
                    chageRange = xlWorkSheet.get_Range(h2, J1);
                    xlWorkSheet.get_Range(h2, J1).Merge(false);
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



        private void button5_Click(object sender, EventArgs e)
        {
//            var dstruong = from p in db.tbTruongs select p;
//            foreach (tbTruong truong in dstruong)
//            {
//                string[] mangdong = new string[15];

//                mangdong[0] = truong.TenTruong;
//int trencap4 =( from p in db.tbCSVCs
//                                where p.MaTruong == truong.MaTruong && p.TenCSVC == "Phòng học trên cấp 4"
//                                select new { p.SoLuong });
//              //dgvTKCSVC.DataSource = trencap4;

//              mangdong[1] = trencap4.ToString();

//                int cap4 = (from p in db.tbCSVCs
//                            where p.MaTruong == truong.MaTruong && p.TenCSVC == "Phòng học cấp 4"
//                            select new { p.SoLuong });
//                mangdong[2] = trencap4.ToString();

//                int duoicap4 = (from p in db.tbCSVCs
//                                where p.MaTruong == truong.MaTruong && p.TenCSVC == "Phòng học dưới cấp 4"
//                                select new { p.SoLuong });
//                mangdong[3] = duoicap4.ToString();


//                int BGH = (from p in db.tbCSVCs
//                           where p.MaTruong == truong.MaTruong && p.TenCSVC == "Phòng BGH"
//                           select new { p.SoLuong });
//                mangdong[4] = BGH.ToString();


//                int ThuVien = (from p in db.tbCSVCs
//                               where p.MaTruong == truong.MaTruong && p.TenCSVC == "Thư viện"
//                               select new { p.SoLuong });
//                mangdong[5] = ThuVien.ToString();

//                int doi = (from p in db.tbCSVCs
//                           where p.MaTruong == truong.MaTruong && p.TenCSVC == "Phòng đội"
//                           select new { p.SoLuong });
//                mangdong[6] = doi.ToString();




//                int yte = (from p in db.tbCSVCs
//                           where p.MaTruong == truong.MaTruong && p.TenCSVC == "Phòng y tế"
//                           select new { p.SoLuong });
//                mangdong[7] = yte.ToString();


//                int tin = (from p in db.tbCSVCs
//                           where p.MaTruong == truong.MaTruong && p.TenCSVC == "Phòng tin"
//                           select new { p.SoLuong });
//                mangdong[8] = tin.ToString();


//                int baitap = (from p in db.tbCSVCs
//                              where p.MaTruong == truong.MaTruong && p.TenCSVC == "Bãi tập"
//                              select new { p.SoLuong });
//                mangdong[9] = baitap.ToString();

//                int sanchoi = (from p in db.tbCSVCs
//                               where p.MaTruong == truong.MaTruong && p.TenCSVC == "Sân chơi"
//                               select new { p.SoLuong }).Count();
//                mangdong[10] = sanchoi.ToString();

//                int maytinh = (from p in db.tbCSVCs
//                               where p.MaTruong == truong.MaTruong && p.TenCSVC == "Số máy tính"
//                               select new { p.SoLuong }).Count();
//                mangdong[11] = maytinh.ToString();


//                int maychieu = (from p in db.tbCSVCs
//                                where p.MaTruong == truong.MaTruong && p.TenCSVC == "Số máy chiếu"
//                                select new { p.SoLuong });
//                mangdong[12] = maychieu.ToString();


//                int ban1cho = (from p in db.tbCSVCs
//                               where p.MaTruong == truong.MaTruong && p.TenCSVC == "số bàn 1 chỗ ngồi"
//                               select new { p.SoLuong });
//                mangdong[13] = ban1cho.ToString();


//                int ban2cho = (from p in db.tbCSVCs
//                               where p.MaTruong == truong.MaTruong && p.TenCSVC == "Số bàn ghế 2 chỗ ngồi"
//                               select new { p.SoLuong });
//                mangdong[14] = ban2cho.ToString();

//                dgvTKCSVC.Rows.Add(mangdong);
//            }
            //var vc = from csvc in db.tbCSVCs  select new {csvc.TenCSVC, csvc.SoLuong };
            //dgv.DataSource = vc;
        }

       

        private void dgvDCS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPhoCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {

        }

        private void tabGioiTnh_Click(object sender, EventArgs e)
        {

        }

        private void tabPhoCap_Click(object sender, EventArgs e)
        {

        }

    }
}
