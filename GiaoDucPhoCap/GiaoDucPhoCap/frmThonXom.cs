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
    public partial class frmThonXom : Form
    {
        public frmThonXom()
        {
            InitializeComponent();
        }

        DataClasses1DataContext db = new DataClasses1DataContext();

        private void txtTenThon_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadDGVThon()
        {
            var dsThon = from th in db.tbThonXoms select new { th.MaThon, th.TenThon };
            dgvThon.DataSource = dsThon;
        }
        private bool KiemTraMa(string Values)
        {
            bool kt = false;
            var Ma = (from th in db.tbThonXoms where th.MaThon == Values select th).Count();
            if (Ma == 1)
            {
                kt = true;
                MessageBox.Show("Mã này đã tồn tại", "");
            }
            return kt;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (txtMaThon.Text != "" && txtTenThon.Text != "")
            {
                if (KiemTraMa(txtMaThon.Text) == false)
                {
                    tbThonXom thon = new tbThonXom();
                    thon.MaThon = txtMaThon.Text;
                    thon.TenThon = txtTenThon.Text;
                    db.tbThonXoms.InsertOnSubmit(thon);
                    db.SubmitChanges();
                    LoadDGVThon();
                    txtMaThon.Text = "";
                    txtTenThon.Text = "";
                }
                else
                    MessageBox.Show("Nhập mã khác!");
            }
            else
                MessageBox.Show("Bạn hãy điền đầy đủ thông tin!");
        }

        private void frmThonXom_Load(object sender, EventArgs e)
        {
            LoadDGVThon();
        }
        int hang = 0;
        private void dgvThon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hang = dgvThon.CurrentRow.Index;
            if (hang >= 0)
            {
                txtMaThon.Enabled = false;
                txtMaThon.Text = dgvThon.Rows[hang].Cells[1].Value.ToString();
                txtTenThon.Text = dgvThon.Rows[hang].Cells[2].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa thông tin này!?", "AptechFinanceManage", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                hang = dgvThon.CurrentRow.Index;
                tbThonXom th = db.tbThonXoms.SingleOrDefault(t1 => t1.MaThon == txtMaThon.Text);
                th.MaThon = txtMaThon.Text;
                th.TenThon = txtTenThon.Text;
                db.SubmitChanges();
                LoadDGVThon();
                txtMaThon.Text = "";
                txtTenThon.Text = "";
                txtMaThon.Enabled = true;
            }
            
                MessageBox.Show("Sửa thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn xóa thông tin này?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                tbThonXom th = db.tbThonXoms.SingleOrDefault(t1 => t1.MaThon == txtMaThon.Text);
                if (th != null)
                {
                    dgvThon.Rows.RemoveAt(dgvThon.CurrentRow.Index);
                    db.tbThonXoms.DeleteOnSubmit(th);
                    db.SubmitChanges();
                    LoadDGVThon();
                    txtMaThon.Text = "";
                    txtTenThon.Text = "";
                    txtMaThon.Enabled = true;
                }

            } MessageBox.Show("Xóa thành công");
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            
        }

    }
}
