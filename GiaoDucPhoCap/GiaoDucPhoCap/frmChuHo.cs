using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiaoDucPhoCap
{
    public partial class frmChuHo : Form
    {
        public string HanhDong;
        public DataGridView DG;
        public frmChuHo()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        private bool KiemTraMa(string Values)
        {
            bool kt = false;
            var Ma = (from ch in db.tbChuHos where ch.MaHoGiaDinh == Values select ch).Count();
            if (Ma == 1)
            {
                kt = true;
                MessageBox.Show("Mã này đã tồn tại", "");
            }
            return kt;
        }
        void UpdateGridView()
        {
            if (DG.Rows.Count > 0)
            {
                tbChuHo hogiadinh = db.tbChuHos.SingleOrDefault(p => p.TenChuHo == DG.Rows[0].Cells["TenChuHo"].Value.ToString());
                DG.Rows[0].Cells["MaHo"].Value = hogiadinh.MaHoGiaDinh;

                for (int i = 1; i < DG.Rows.Count; i++)
                {
                    if (DG.Rows[i].Cells["TenChuHo"].Value.ToString() != DG.Rows[i - 1].Cells["TenChuHo"].Value.ToString())
                    {
                        hogiadinh = db.tbChuHos.SingleOrDefault(p => p.TenChuHo == DG.Rows[i].Cells["TenChuHo"].Value.ToString());

                        DG.Rows[i].Cells["MaHo"].Value = hogiadinh.MaHoGiaDinh;

                    }
                }
            }
        }
        private void LamMoi()
        {
            cboThon.Text = "";
            txtMaHo.Text = "";
            txtTenChuHo.Text = "";
            txtNgaySinh.Text = "";
            cboDanToc.Text = "";
            
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboThon.Text != "" && txtMaHo.Text != "" && txtTenChuHo.Text != "" && txtNgaySinh.Text != "")
                {
                    if (KiemTraMa(txtMaHo.Text) == false)
                    {
                        tbThonXom thon = db.tbThonXoms.SingleOrDefault(p => p.TenThon == cboThon.Text.Trim());
                        tbChuHo hogd = new tbChuHo()
                        {

                            MaHoGiaDinh = txtMaHo.Text.Trim(),
                            TenChuHo = txtTenChuHo.Text.Trim(),
                            NgaySinh = DateTime.Parse(txtNgaySinh.Text.Trim()),
                            DanToc = cboDanToc.Text.Trim(),
                            MaThon = thon.MaThon
                        };



                        if (rdbNam.Checked == true)
                        {
                            hogd.GioiTinh = "Nam";
                        }
                        if (rdbNu.Checked == true)
                        {
                            hogd.GioiTinh = "Nữ";
                        }

                        tbThanhVien ThanhVien = new tbThanhVien();
                        ThanhVien.GioiTinh = hogd.GioiTinh;
                        ThanhVien.TenThanhVien = hogd.TenChuHo;
                        ThanhVien.NgaySinh = hogd.NgaySinh;
                        ThanhVien.QuanHeVoiChuHo = "Chủ hộ";
                        ThanhVien.DanToc = hogd.DanToc;
                        hogd.tbThanhViens.Add(ThanhVien);
                        db.tbChuHos.InsertOnSubmit(hogd);
                        db.SubmitChanges();
                        LamMoi();
                        MessageBox.Show("Thêm thành công");
                        var thanhvien = (from tv in db.tbThanhViens
                                         select

                         new
                         {
                             tv.tbChuHo.TenChuHo,
                             tv.MaHoGiaDinh,
                                tv.TenThanhVien,
                                tv.QuanHeVoiChuHo,
                                tv.NgaySinh,
                                tv.GioiTinh,
                                tv.TinhTrang,
                                tv.GiaDinhChinhSach,
                                tv.DanToc,
                                tv.NamTotNghiep,
                                tv.NamBoHoc,
                                tv.TrinhDo1,
                                tv.TrinhDo2,
                                tv.TrinhDo3,
                                tv.TrinhDo4,
                                tv.TrinhDo5,
                                tv.NgayChuyenDen,
                                tv.NoiKhac,
                                tv.GhiChu,
                             tv.MaThanhVien
                         }).OrderBy(p => p.TenChuHo);
                        DG.DataSource = thanhvien;
                        UpdateGridView();
                        this.Close();
                    }
                    else
                        MessageBox.Show("hãy nhập mã khác");
                }
                else
                {
                    MessageBox.Show("Hãy điền đủ các thông tin");
                } 
                return;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChuHo_Load(object sender, EventArgs e)
        {
            var dsThon = from th in db.tbThonXoms select th.TenThon;
            cboThon.DataSource = dsThon;
        }

        private void rdbNam_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
