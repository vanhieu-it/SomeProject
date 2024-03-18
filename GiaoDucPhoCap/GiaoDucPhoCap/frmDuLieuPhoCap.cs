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
    public partial class frmDuLieuPhoCap : Form
    {
        public frmDuLieuPhoCap()
        {
            InitializeComponent();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();

        void UpdateGridView()
        {
            if (dgvThongTin.Rows.Count > 0)
            {
                tbChuHo hogiadinh = db.tbChuHos.SingleOrDefault(p => p.TenChuHo == dgvThongTin.Rows[0].Cells["TenChuHo"].Value.ToString());
                dgvThongTin.Rows[0].Cells["MaHo"].Value = hogiadinh.MaHoGiaDinh;

                for (int i = 1; i < dgvThongTin.Rows.Count; i++)
                {
                    if (dgvThongTin.Rows[i].Cells["TenChuHo"].Value.ToString() != dgvThongTin.Rows[i - 1].Cells["TenChuHo"].Value.ToString())
                    {
                        hogiadinh = db.tbChuHos.SingleOrDefault(p => p.TenChuHo == dgvThongTin.Rows[i].Cells["TenChuHo"].Value.ToString());

                        dgvThongTin.Rows[i].Cells["MaHo"].Value = hogiadinh.MaHoGiaDinh;

                    }
                }
            }
        }
        private void btnThemThanhVien_Click(object sender, EventArgs e)
        {
            frmThanhVien frm = new frmThanhVien();
            if (dgvThongTin.CurrentRow.Cells[0].Value == null)
            {
                int i = dgvThongTin.CurrentRow.Index;
                while (dgvThongTin.Rows[i].Cells[0].Value == null)
                {
                    i = i - 1;
                }
                frm.MaHo = dgvThongTin.Rows[i].Cells["MaHo"].Value.ToString();
            }
            else
            {
                frm.MaHo = dgvThongTin.CurrentRow.Cells["MaHo"].Value.ToString();
            }



            frm.DG = dgvThongTin;
            frm.HanhDong = "Thêm";
            frm.ShowDialog();
        }
        void LoadDaTaGidView()
        {
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
                            }).OrderBy(p=>p.MaHoGiaDinh);
            dgvThongTin.DataSource = thanhvien;

            dgvThongTin.Columns["TD5"].HeaderText = (DateTime.Now.Year - 1).ToString() + " - " + DateTime.Now.Year.ToString();
            dgvThongTin.Columns["TD4"].HeaderText = (DateTime.Now.Year - 2).ToString() + " - " + (DateTime.Now.Year - 1).ToString();
            dgvThongTin.Columns["TD3"].HeaderText = (DateTime.Now.Year - 3).ToString() + " - " + (DateTime.Now.Year - 2).ToString();
            dgvThongTin.Columns["TD2"].HeaderText = (DateTime.Now.Year - 4).ToString() + " - " + (DateTime.Now.Year - 3).ToString();
            dgvThongTin.Columns["TD1"].HeaderText = (DateTime.Now.Year - 5).ToString() + " - " + (DateTime.Now.Year - 4).ToString();
            UpdateGridView();
        }
        private void frmDuLieuPhoCap_Load(object sender, EventArgs e)
        {
            //LoadTreeView();
            LoadDaTaGidView();

        }
      
        private void btnThemHo_Click(object sender, EventArgs e)
        {
            frmChuHo frm = new frmChuHo();
            frm.DG = dgvThongTin;
            frm.HanhDong = "Thêm";
            frm.ShowDialog();
        }
        //private void LoadTreeView()
        //{
        //    var dsThon = from th in db.tbThonXoms select th;
        //    foreach (tbThonXom thon in dsThon)
        //    {
        //        TreeNode node = new TreeNode();
        //        node.Name = thon.TenThon;
        //        node.Text = thon.TenThon;
        //        treeView1.Nodes.Add(node);
        //    }
        //}

        //private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //     bool LaThon = false;
        //    tbThonXom thon = db.tbThonXoms.SingleOrDefault(p => p.TenThon == e.Node.Text.ToString());

        //    if (thon != null)
        //    {
        //        LaThon = true;
        //    }

        //    if (LaThon == true)
        //    {
        //        var thanhvien = (from tv in db.tbThanhViens
        //                        where tv.tbChuHo.tbThonXom.TenThon == e.Node.Text.ToString()
        //                        select new
        //                        {
        //                            tv.tbChuHo.TenChuHo,
        //                            tv.MaHoGiaDinh,
        //                            tv.TenThanhVien,
        //                            tv.QuanHeVoiChuHo,
        //                            tv.NgaySinh,
        //                            tv.GioiTinh,
        //                            tv.TinhTrang,
        //                            tv.GiaDinhChinhSach,
        //                            tv.DanToc,
        //                            tv.NamTotNghiep,
        //                            tv.NamBoHoc,
        //                            tv.TrinhDo1,
        //                            tv.TrinhDo2,
        //                            tv.TrinhDo3,
        //                            tv.TrinhDo4,
        //                            tv.TrinhDo5,
        //                            tv.NgayChuyenDen,
        //                            tv.NoiKhac,
        //                            tv.NgayChuyenDi,
        //                            tv.NoiChuyenDen,
        //                            tv.GhiChu,
        //                            tv.MaThanhVien
        //                        }).OrderBy(p => p.TenChuHo); 
        //        dgvThongTin.DataSource = thanhvien;
        //    }
        //}

        private void dgvThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongTin.CurrentRow.Cells["MaThanhVien"].Value == null)
            {
                MessageBox.Show("Bạn hãy chọn một thành viên để xóa");
                return;
            }
            else
            {
                tbThanhVien thanhvien = db.tbThanhViens.SingleOrDefault(p => p.MaThanhVien.ToString() == dgvThongTin.CurrentRow.Cells["MaThanhVien"].Value.ToString());
                
                if (MessageBox.Show("Bạn có chắc muốn xóa thông tin này!?", "AptechFinanceManage", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    db.tbThanhViens.DeleteOnSubmit(thanhvien);
                    db.SubmitChanges();

                }
            }
            LoadDaTaGidView();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            frmThanhVien frm = new frmThanhVien();
            if (dgvThongTin.CurrentRow.Cells[0].Value == null)
            {
                int i = dgvThongTin.CurrentRow.Index;
               
                while (dgvThongTin.Rows[i].Cells[0].Value == null)
                {
                    i = i - 1;
                }
                frm.MaHo = dgvThongTin.Rows[i].Cells["MaHo"].Value.ToString();
            }
            else
            {
                frm.MaHo = dgvThongTin.CurrentRow.Cells["MaHo"].Value.ToString();
            }
          
            frm.DG = dgvThongTin;
      
            frm.HanhDong = "Sửa";
            frm.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            var thanhvien =( from tv in db.tbThanhViens

                            where tv.TenThanhVien.IndexOf(txtTimKiem.Text)!=-1
                            select new
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
                                tv.NgayChuyenDi,
                                tv.NoiChuyenDen,
                                tv.GhiChu
                            }).OrderBy(p => p.TenChuHo);
            dgvThongTin.DataSource = thanhvien;
            UpdateGridView();
        }

        private void dgvThongTin_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
