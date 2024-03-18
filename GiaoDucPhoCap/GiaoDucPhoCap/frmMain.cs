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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void xãToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThonXom frm = new frmThonXom();
            frm.ShowDialog();
        }

        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGiaoVien frm = new frmGiaoVien();
            frm.ShowDialog();
        }

        private void dữLiệuPhổCậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDuLieuPhoCap frm = new frmDuLieuPhoCap();
            frm.ShowDialog();
        }

        
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.ShowDialog();
        }

        private void danhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhSach ds = new frmDanhSach();
            ds.ShowDialog();
        }

        private void thôngTinĐơnVịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usThongTinDonVi1.Visible = true;

        }

       

        private void cơSởVậtChấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCosovatchat csvc = new frmCosovatchat();
            csvc.ShowDialog();
        }

        private void phổCậpTiểuHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
