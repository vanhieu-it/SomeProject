using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiaoDucPhoCap
{
    public partial class USThongTinDonVi : UserControl
    {
        public USThongTinDonVi()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        private void btnXong_Click(object sender, EventArgs e)
        {

        }

        private void txtMaTruong_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void USThongTinDonVi_Load(object sender, EventArgs e)
        {
            tbTruong truong = db.tbTruongs.SingleOrDefault(p => p.TenTruong == "Trường tiểu học xã dân tiến");
        
            txtTenTruong.Text = truong.TenTruong;
            txtMaTruong.Text = truong.MaTruong;
            txtTenHieuTruong.Text = truong.TenHieuTruong;
            txtNamDieuTra.Text = DateTime.Now.Year.ToString();
            txtTenHuyen.Text = "Khoái châu";
            txtTenTinh.Text = "Long An";
            txtTenXa.Text = "Dân tiến";
            
        }
        }

       
    }

