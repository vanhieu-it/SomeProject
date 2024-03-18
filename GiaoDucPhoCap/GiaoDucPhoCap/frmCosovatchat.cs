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
    public partial class frmCosovatchat : Form
    {
        public frmCosovatchat()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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
        private void LoadDGVCSVC()
        {
            var csvc = from vc in db.tbCSVCs select new { vc.MaCSVC, vc.TenCSVC, vc.SoLuong, vc.GhiChu };
            dgvCSVC.DataSource = csvc;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            if (txtMaCSVC.Text != "" && txtTenCSVC.Text != "" && txtSoLuong.Text != "")
            {
                tbCSVC vc = new tbCSVC();
                vc.MaCSVC = txtMaCSVC.Text;
                vc.TenCSVC = txtTenCSVC.Text;
                vc.SoLuong = int.Parse(txtSoLuong.Text);
                vc.GhiChu = txtGhiChu.Text;
                db.tbCSVCs.InsertOnSubmit(vc);
                db.SubmitChanges();
                LoadDGVCSVC();


            }
            else
                MessageBox.Show("Hãy điền đầy đủ thông tin cần thiết?");

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa thông tin này!?", "AptechFinanceManage", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                tbCSVC cosovatchat = db.tbCSVCs.SingleOrDefault(vc => vc.TenCSVC == txtTenCSVC.Text);
                if (cosovatchat != null)
                {
                    db.tbCSVCs.DeleteOnSubmit(cosovatchat);
                    dgvCSVC.Rows.RemoveAt(dgvCSVC.CurrentRow.Index);
                    db.SubmitChanges();
                    LoadDGVCSVC();
                }
                MessageBox.Show("Xóa thành công");

            }
            else
                MessageBox.Show(" ");
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin này!?", "AptechFinanceManage", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                hangchon = dgvCSVC.CurrentRow.Index;
                tbCSVC vc = db.tbCSVCs.SingleOrDefault(vc1 => vc1.MaCSVC == txtMaCSVC.Text);

                //gv.MaGiaoVien = txtMaGiaoVien.Text;
                vc.TenCSVC = txtTenCSVC.Text;
                vc.SoLuong = int.Parse(txtSoLuong.Text);
                vc.GhiChu = txtGhiChu.Text;
                db.SubmitChanges();
                LoadDGVCSVC();
            }
            else
                MessageBox.Show("Sửa thành công!");
        }

        int hangchon = 0;

        private void dgvCSVC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            hangchon = dgvCSVC.CurrentRow.Index;
            if (hangchon >= 0)
            {
                txtMaCSVC.Enabled = false;
             
                txtMaCSVC.Text = dgvCSVC.Rows[hangchon].Cells["clMaCSVC"].Value.ToString();

                txtTenCSVC.Text = dgvCSVC.Rows[hangchon].Cells[1].Value.ToString();
                txtSoLuong.Text = dgvCSVC.Rows[hangchon].Cells[2].Value.ToString();
                txtGhiChu.Text = dgvCSVC.Rows[hangchon].Cells[3].Value.ToString();
            }

        }

        private void btLamMoi_Click(object sender, EventArgs e)
        {
            txtMaCSVC.Enabled = true;
            txtMaCSVC.Text = "";
            txtTenCSVC.Text = "";
            txtSoLuong.Text = "";
            txtGhiChu.Text = "";


        }

        private void frmCosovatchat_Load(object sender, EventArgs e)
        {
            LoadDGVCSVC();
        }
    }
}