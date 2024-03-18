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
    public partial class frmThanhVien : Form
    {
        public DataGridView DG;
        public String MaHo;
        public String HanhDong;
        public frmThanhVien()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        private void frmThanhVien_Load(object sender, EventArgs e)
        {
            if (HanhDong == "Sửa")
            {
                tbThanhVien thanhvien = db.tbThanhViens.SingleOrDefault(p => p.MaThanhVien.ToString() == DG.CurrentRow.Cells["MaThanhVien"].Value.ToString());

                txtTenThanhVien.Text = thanhvien.TenThanhVien;

                if (thanhvien.QuanHeVoiChuHo == "Chủ hộ")
                {
                    cboQuanHe.Enabled = false;
                }
                if (thanhvien.QuanHeVoiChuHo != null)
                {
                    cboQuanHe.SelectedText = thanhvien.QuanHeVoiChuHo;
                }
                if (thanhvien.NgaySinh != null)
                {
                DateTime dt = (DateTime)thanhvien.NgaySinh;
                string day = "";
                string month = "";
                if (dt.Day < 10)
                {
                    day = "0" + dt.Day.ToString();
                }

                else
                {
                    day = dt.Day.ToString();
                }
                if (dt.Month < 10)
                {
                    month = "0" + dt.Month.ToString();

                }
                else
                {
                    month = dt.Month.ToString();
                }


               
                    mtxtNgaySinh.Text = month + day + dt.Year.ToString();

                }
                if (thanhvien.GioiTinh.Trim() == "Nam")
                {
                    radNam.Checked = true;

                }
                if (thanhvien.GioiTinh.Trim() == "Nữ")
                {

                    radNu.Checked = true;
                }
                if (thanhvien.GiaDinhChinhSach != null)
                {
                    cboGIaDinhCS.SelectedText = thanhvien.GiaDinhChinhSach;
                }
                if (thanhvien.TinhTrang != null)
                {
                    cboTinhTrang.SelectedText = thanhvien.TinhTrang;
                }
                if (thanhvien.DanToc != null)
                {
                    cboDanToc.SelectedText = thanhvien.DanToc;
                }
                if (thanhvien.TrinhDo1 != null)
                {
                    cboTD1.SelectedText = thanhvien.TrinhDo1;
                }
                if (thanhvien.TrinhDo2 != null)
                {
                    cboTD2.SelectedText = thanhvien.TrinhDo2;
                }
                if (thanhvien.TrinhDo3 != null)
                {
                    cboTD3.SelectedText = thanhvien.TrinhDo3;
                }
                if (thanhvien.TrinhDo4 != null)
                {
                    cboTD4.SelectedText = thanhvien.TrinhDo4;
                }
                if (thanhvien.TrinhDo5 != null)
                {
                    cboTD5.SelectedText = thanhvien.TrinhDo5;
                }
                if (thanhvien.GhiChu != null)
                {
                  txtGhiChu.Text = thanhvien.GhiChu;
                }

                if (thanhvien.NamBoHoc != null)
                {
                    txtNamBoHoc.Text = thanhvien.NamBoHoc;
                }
                if (thanhvien.NamTotNghiep != null)
                {
                    txtNamTN.Text = thanhvien.NamTotNghiep;
                }
                if (thanhvien.TenTruong != null)
                {
                    txtTruong.Text = thanhvien.TenTruong;
                }
                lbChuHo.Text = "Mã thành viên:";
               
                lblTenChuHo.Text = DG.CurrentRow.Cells["MaThanhVien"].Value.ToString();
            }
            if (HanhDong == "Thêm")
            {
                lbChuHo.Text = "Mã Hộ :";
                lblTenChuHo.Text = MaHo;
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (HanhDong == "Thêm")
            {

                tbChuHo HoGiaDinh = db.tbChuHos.SingleOrDefault(p => p.MaHoGiaDinh == MaHo);

                tbThanhVien ThanhVien = new tbThanhVien();

                ThanhVien.TenThanhVien = txtTenThanhVien.Text;
                ThanhVien.QuanHeVoiChuHo = cboQuanHe.Text;
                try
                {
                    ThanhVien.NgaySinh = DateTime.Parse(mtxtNgaySinh.Text);
             

                }
                catch
                {
                    if (mtxtNgaySinh.Text != "  /  /")
                    {
                        MessageBox.Show("Không điền đúng định dạng ngày");
                        return;
                    }


                }
                if (radNu.Checked == true)
                {
                    ThanhVien.GioiTinh = "Nữ";
                }
                else
                {
                    ThanhVien.GioiTinh = "Nam";
                }

                ThanhVien.DanToc = cboDanToc.Text;
                ThanhVien.GiaDinhChinhSach = cboGIaDinhCS.Text;
                ThanhVien.TinhTrang = cboTinhTrang.Text;
                ThanhVien.GhiChu = txtGhiChu.Text;
                ThanhVien.TrinhDo1 = cboTD1.Text;
                ThanhVien.TrinhDo2 = cboTD2.Text;
                ThanhVien.TrinhDo3 = cboTD3.Text;
                ThanhVien.TrinhDo4 = cboTD4.Text;
                ThanhVien.TrinhDo5 = cboTD5.Text;
                ThanhVien.NamBoHoc = txtNamBoHoc.Text;
                ThanhVien.NamTotNghiep = txtNamTN.Text;
                ThanhVien.TenTruong = txtTruong.Text;
                if (ThanhVien.TenTruong != null)
                {
                    ThanhVien.TenTruong = txtTruong.Text;
                }
               
                try
                {
                    ThanhVien.NgayChuyenDen = DateTime.Parse(txtNgayChuyenDen.Text);
                }
                catch
                {
                    if (txtNgayChuyenDen.Text != "  /  /")
                    {
                        MessageBox.Show("Không điền đúng định dạng ngày");
                        return;
                    }
                }
                ThanhVien.NoiKhac = txtNoiKhac.Text;
                try
                {
                    ThanhVien.NgayChuyenDi = DateTime.Parse(txtNgayChuyenDi.Text);
                    
                }
                catch
                {
                    if (txtNgayChuyenDi.Text != "  /  /")
                    {
                        MessageBox.Show("Không điền đúng định dạng ngày");
                        return;
                    }
                }
                ThanhVien.NoiChuyenDen = txtNoiChuyenDi.Text;

                HoGiaDinh.tbThanhViens.Add(ThanhVien);
                //HoGiaDinh.tbThanhViens.Add(ThanhVien);
                db.SubmitChanges();

                var thanhvien =(from tv in db.tbThanhViens
                            select new
                            {
                                tv.tbChuHo.TenChuHo,
                                tv.TenTruong,
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
                                tv.NgayChuyenDi,
                                tv.NoiChuyenDen,
                                tv.GhiChu,
                                tv.MaThanhVien
                            }).OrderBy(p=>p.MaHoGiaDinh);
                DG.DataSource = thanhvien;
                UpdateGridView();
                //    DG.Refresh();
                MessageBox.Show("Them thanh cong");
                this.Close();
            }
            if (HanhDong == "Sửa")
            {
                if (DG.CurrentRow.Cells["MaThanhVien"].Value == null)
                {
                    MessageBox.Show("Bạn hãy chọn một hàng để sửa");
                    return;
                }

                tbThanhVien ThanhVien = db.tbThanhViens.SingleOrDefault(p => p.MaThanhVien.ToString() == DG.CurrentRow.Cells["MaThanhVien"].Value.ToString());

                if (ThanhVien.TenTruong != null)
                {
                    ThanhVien.TenTruong = txtTruong.Text;
                }
                ThanhVien.TenThanhVien = txtTenThanhVien.Text;
                ThanhVien.DanToc = cboDanToc.Text;
                ThanhVien.GiaDinhChinhSach = cboGIaDinhCS.Text;
                ThanhVien.TinhTrang = cboTinhTrang.Text;
                if (radNu.Checked == true)
                {
                    ThanhVien.GioiTinh = "Nam";
                }
                else
                {
                    ThanhVien.GioiTinh = "Nữ";
                }
                ThanhVien.NamBoHoc = txtNamBoHoc.Text;
                ThanhVien.NamTotNghiep = txtNamTN.Text;
                try
                {
                    ThanhVien.NgaySinh = DateTime.Parse(mtxtNgaySinh.Text);
                }
                catch
                {
                    if (mtxtNgaySinh.Text != "  /  /")
                    {
                        MessageBox.Show("Không điền đúng định dạng ngày");
                        return;
                    }
                }
                ThanhVien.QuanHeVoiChuHo = cboQuanHe.Text;
              
                ThanhVien.GhiChu = txtGhiChu.Text;
                ThanhVien.TrinhDo1 = cboTD1.Text;
                ThanhVien.TrinhDo2 = cboTD2.Text;
                ThanhVien.TrinhDo3 = cboTD3.Text;
                ThanhVien.TrinhDo4 = cboTD4.Text;
                ThanhVien.TrinhDo5 = cboTD5.Text;
                ThanhVien.TenTruong = txtTruong.Text;
                try
                {
                    ThanhVien.NgayChuyenDen = DateTime.Parse(txtNgayChuyenDen.Text);
                }
                catch
                {
                    if (txtNgayChuyenDen.Text != "  /  /")
                    {
                        MessageBox.Show("Không điền đúng định dạng ngày");
                        return;
                    }

                }
                ThanhVien.NoiKhac = txtNoiKhac.Text;

                try
                {
                    ThanhVien.NgayChuyenDi = DateTime.Parse(txtNgayChuyenDi.Text);
                }
                catch
                {
                    if (txtNgayChuyenDi.Text != "  /  /")
                    {
                        MessageBox.Show("Không điền đúng định dạng ngày");
                        return;
                    }
                }
                ThanhVien.NoiChuyenDen = txtNoiChuyenDi.Text;
                db.SubmitChanges();
                var thanhvien = (from tv in db.tbThanhViens
                                 select new
                                 {
                                     tv.tbChuHo.TenChuHo,
                                     tv.TenTruong,
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
                                     tv.NgayChuyenDi,
                                     tv.NoiChuyenDen,
                                     tv.GhiChu,
                                     tv.MaThanhVien
                                 }).OrderBy(p => p.MaHoGiaDinh);
                DG.DataSource = thanhvien;
                UpdateGridView();

                MessageBox.Show("Sửa thành công");
                this.Close();
            }
        }

        private void txtNamTN_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNamBoHoc_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
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
        private void btKetThuc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTinhTrang_Click(object sender, EventArgs e)
        {

        }
    }
}
