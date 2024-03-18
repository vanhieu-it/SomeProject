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
    public partial class frmGiaoVien : Form
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void LoadDGVGiaoVien()
        {
            var dsGiaovien = from gv in db.tbGiaoViens
                             select new
                             {
                                 gv.MaGiaoVien,
                                 gv.TenGiaoVien,
                                 gv.NgaySinh,
                                 gv.GioiTinh,
                                 gv.ChucVu,
                                 gv.ChuyenNganh,
                                 gv.SoTietDay,
                                 gv.TinhTrangCongTac,
                                 gv.XepLoaiGiaoVien,
                                 gv.DangDayLop,
                                 gv.TrinhDo,
                                 gv.DanToc
                                 
                             };
            dgvGiaoVien.DataSource = dsGiaovien;
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            LoadDGVGiaoVien();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaGiaoVien.Enabled = true;
            txtMaGiaoVien.Text = "";
            txtTenGiaoVien.Text = "";
            txtNgaySinh.Text = "";
            txtChucVu.Text = "";
            txtChuyenNganh.Text = "";
            txtSoTiet.Text = "";
            cboDanToc.Text = "";
            cboLop.Text = "";
            cboTinhTrang.Text = "";
            cboXepLoai.Text = "";

        }
        private bool KiemTraMa(string values)
        {
            bool kt = false;
            var Ma = (from gv in db.tbGiaoViens where gv.MaGiaoVien == values select gv).Count();
            if (Ma == 1)
            {
                kt = true;
                MessageBox.Show("Mã này đã tồn tại", "");
            }
            return kt;
        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaGiaoVien.Text != "" && txtTenGiaoVien.Text != "" && txtNgaySinh.Text != ""
                && txtChucVu.Text != "" && txtChuyenNganh.Text != "" && txtSoTiet.Text != ""
                && cboTinhTrang.Text != "" && cboLop.Text != "")
            {
                if (KiemTraMa(txtMaGiaoVien.Text) == false)
                {
                    tbGiaoVien gv = new tbGiaoVien();
                    gv.MaGiaoVien = txtMaGiaoVien.Text;
                    gv.TenGiaoVien = txtTenGiaoVien.Text;
                    gv.NgaySinh = DateTime.Parse(txtNgaySinh.Text);
                    gv.ChucVu = txtChucVu.Text;
                    gv.ChuyenNganh = txtChuyenNganh.Text;
                    gv.SoTietDay = int.Parse(txtSoTiet.Text);
                    gv.TinhTrangCongTac = cboTinhTrang.Text;
                    gv.XepLoaiGiaoVien = cboXepLoai.Text;
                    gv.DangDayLop = cboLop.Text;
                    gv.TrinhDo = cboTrinhDo.Text;
                    gv.DanToc = cboDanToc.Text;
                    if (rdoNam.Checked == true)
                    {
                        gv.GioiTinh = "Nam";
                    }
                    if (rdoNu.Checked == true)
                    {
                        gv.GioiTinh = "Nữ";
                    }

                    db.tbGiaoViens.InsertOnSubmit(gv);
                    db.SubmitChanges();
                    LoadDGVGiaoVien();
                }
                else
                    MessageBox.Show("Hãy nhập mã khác!");
            }
            else
                MessageBox.Show("Hãy điền đầy đủ thông tin cần thiết?");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin này!?", "AptechFinanceManage", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                tbGiaoVien giaovien = db.tbGiaoViens.SingleOrDefault(gv => gv.TenGiaoVien == txtTenGiaoVien.Text);
                if (giaovien != null)
                {
                    db.tbGiaoViens.DeleteOnSubmit(giaovien);
                    dgvGiaoVien.Rows.RemoveAt(dgvGiaoVien.CurrentRow.Index);
                    db.SubmitChanges();
                    LoadDGVGiaoVien();
                }
                MessageBox.Show("Xóa thành công");
                
            }
            else
                MessageBox.Show(" ");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn sửa thông tin này!?", "AptechFinanceManage", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                hangchon = dgvGiaoVien.CurrentRow.Index;

                tbGiaoVien gv = db.tbGiaoViens.SingleOrDefault(g1 => g1.MaGiaoVien == txtMaGiaoVien.Text);
                //gv.MaGiaoVien = txtMaGiaoVien.Text;
                gv.TenGiaoVien = txtTenGiaoVien.Text;
                gv.NgaySinh = DateTime.Parse(txtNgaySinh.Text);
                if (dgvGiaoVien.Rows[hangchon].Cells[3].Value.ToString() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                if (dgvGiaoVien.Rows[hangchon].Cells[3].Value.ToString() == "Nữ")
                {
                    rdoNu.Checked = true;
                }
                gv.ChucVu = txtChucVu.Text;
                gv.ChuyenNganh = txtChuyenNganh.Text;
                gv.SoTietDay = int.Parse(txtSoTiet.Text);
                cboTinhTrang.Text = "";
                cboTinhTrang.Text = dgvGiaoVien.Rows[hangchon].Cells[7].Value.ToString();
                cboXepLoai.Text = "";
                cboXepLoai.Text = dgvGiaoVien.Rows[hangchon].Cells[8].Value.ToString();
                cboLop.Text = "";
                cboLop.Text = dgvGiaoVien.Rows[hangchon].Cells[9].Value.ToString();
                cboTrinhDo.Text = "";
                cboTrinhDo.SelectedText = dgvGiaoVien.Rows[hangchon].Cells[10].Value.ToString();
                cboDanToc.Text = "";
                cboDanToc.Text = dgvGiaoVien.Rows[hangchon].Cells[11].Value.ToString();

                //
                db.SubmitChanges();
                LoadDGVGiaoVien();
            }
            else
                MessageBox.Show("Sửa thành công!");
        }
        int hangchon = 0;
        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hangchon = dgvGiaoVien.CurrentRow.Index;
            if (hangchon >= 0)
            {
                txtMaGiaoVien.Enabled = false;

                txtMaGiaoVien.Text = dgvGiaoVien.Rows[hangchon].Cells["clMaGiaoVien"].Value.ToString();
                
                txtTenGiaoVien.Text = dgvGiaoVien.Rows[hangchon].Cells[1].Value.ToString();
                txtNgaySinh.Text = dgvGiaoVien.Rows[hangchon].Cells[2].Value.ToString();
                if (dgvGiaoVien.Rows[hangchon].Cells[3].Value.ToString() == "Nam")
                {
                    rdoNam.Checked = true;
                }
                if (dgvGiaoVien.Rows[hangchon].Cells[3].Value.ToString() == "Nữ")
                {

                    rdoNu.Checked = true;
                }
                txtChucVu.Text = dgvGiaoVien.Rows[hangchon].Cells[4].Value.ToString();
                txtChuyenNganh.Text = dgvGiaoVien.Rows[hangchon].Cells[5].Value.ToString();
                txtSoTiet.Text = dgvGiaoVien.Rows[hangchon].Cells[6].Value.ToString();
                cboTinhTrang.Text = "";
                cboTinhTrang.SelectedText = dgvGiaoVien.Rows[hangchon].Cells[7].Value.ToString();
                cboXepLoai.Text = "";
                cboXepLoai.SelectedText = dgvGiaoVien.Rows[hangchon].Cells[8].Value.ToString();
                cboLop.Text = "";
                cboLop.SelectedText = dgvGiaoVien.Rows[hangchon].Cells[9].Value.ToString();
                cboTrinhDo.Text = "";
                cboTrinhDo.SelectedText = dgvGiaoVien.Rows[hangchon].Cells[10].Value.ToString();
                cboDanToc.Text = "";
                cboDanToc.SelectedText = dgvGiaoVien.Rows[hangchon].Cells[11].Value.ToString();
            }
        } 
    }
}
