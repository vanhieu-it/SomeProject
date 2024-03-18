namespace GiaoDucPhoCap
{
    partial class frmDuLieuPhoCap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuLieuPhoCap));
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnThemHo = new System.Windows.Forms.Button();
            this.btnThemThanhVien = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvThongTin = new System.Windows.Forms.DataGridView();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.MaHo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaHoGiaDinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenChuHo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTruong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TD1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TD3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TD4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TD5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cl11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayChuyenDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiOCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNgayChuyenDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clNoiDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaThanhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimKiem.Location = new System.Drawing.Point(12, 40);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(130, 16);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm kiếm theo hộ:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(148, 40);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(124, 22);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnThemHo
            // 
            this.btnThemHo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemHo.ForeColor = System.Drawing.Color.Black;
            this.btnThemHo.Location = new System.Drawing.Point(322, 35);
            this.btnThemHo.Name = "btnThemHo";
            this.btnThemHo.Size = new System.Drawing.Size(108, 32);
            this.btnThemHo.TabIndex = 4;
            this.btnThemHo.Text = "Thêm hộ mới";
            this.btnThemHo.UseVisualStyleBackColor = true;
            this.btnThemHo.Click += new System.EventHandler(this.btnThemHo_Click);
            // 
            // btnThemThanhVien
            // 
            this.btnThemThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemThanhVien.ForeColor = System.Drawing.Color.Black;
            this.btnThemThanhVien.Location = new System.Drawing.Point(464, 35);
            this.btnThemThanhVien.Name = "btnThemThanhVien";
            this.btnThemThanhVien.Size = new System.Drawing.Size(133, 32);
            this.btnThemThanhVien.TabIndex = 4;
            this.btnThemThanhVien.Text = "Thêm thành viên";
            this.btnThemThanhVien.UseVisualStyleBackColor = true;
            this.btnThemThanhVien.Click += new System.EventHandler(this.btnThemThanhVien_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(616, 35);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(74, 32);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa ";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(706, 35);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(69, 32);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvThongTin
            // 
            this.dgvThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongTin.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongTin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHo,
            this.clMaHoGiaDinh,
            this.TenChuHo,
            this.cl2,
            this.cl3,
            this.cl4,
            this.cl5,
            this.cl7,
            this.cl6,
            this.cl8,
            this.TenTruong,
            this.TD1,
            this.TD2,
            this.TD3,
            this.TD4,
            this.TD5,
            this.cl10,
            this.cl11,
            this.NgayChuyenDen,
            this.NoiOCu,
            this.clNgayChuyenDi,
            this.clNoiDen,
            this.clGhiChu,
            this.MaThanhVien});
            this.dgvThongTin.Location = new System.Drawing.Point(0, 77);
            this.dgvThongTin.Name = "dgvThongTin";
            this.dgvThongTin.ReadOnly = true;
            this.dgvThongTin.RowHeadersVisible = false;
            this.dgvThongTin.Size = new System.Drawing.Size(942, 400);
            this.dgvThongTin.TabIndex = 5;
            this.dgvThongTin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongTin_CellContentClick_1);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(946, 29);
            this.textBox2.TabIndex = 23;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "THÔNG TIN HỘ GIA ĐÌNH VÀ THÀNH VIÊN";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MaHo
            // 
            this.MaHo.DataPropertyName = "MaHoGiaDinha";
            this.MaHo.HeaderText = "Mã hộ";
            this.MaHo.Name = "MaHo";
            this.MaHo.ReadOnly = true;
            this.MaHo.Width = 60;
            // 
            // clMaHoGiaDinh
            // 
            this.clMaHoGiaDinh.DataPropertyName = "MaHoGiaDinh";
            this.clMaHoGiaDinh.HeaderText = "Mã hộ gia đình";
            this.clMaHoGiaDinh.Name = "clMaHoGiaDinh";
            this.clMaHoGiaDinh.ReadOnly = true;
            this.clMaHoGiaDinh.Visible = false;
            // 
            // TenChuHo
            // 
            this.TenChuHo.DataPropertyName = "TenChuHo";
            this.TenChuHo.HeaderText = "Tên  chủ hộ";
            this.TenChuHo.Name = "TenChuHo";
            this.TenChuHo.ReadOnly = true;
            this.TenChuHo.Visible = false;
            // 
            // cl2
            // 
            this.cl2.DataPropertyName = "TenThanhVien";
            this.cl2.HeaderText = "Tên thành viên";
            this.cl2.Name = "cl2";
            this.cl2.ReadOnly = true;
            this.cl2.Width = 150;
            // 
            // cl3
            // 
            this.cl3.DataPropertyName = "QuanHeVoiChuHo";
            this.cl3.HeaderText = "Quan hệ với chủ hộ";
            this.cl3.Name = "cl3";
            this.cl3.ReadOnly = true;
            this.cl3.Width = 65;
            // 
            // cl4
            // 
            this.cl4.DataPropertyName = "NgaySinh";
            this.cl4.HeaderText = "Ngày sinh";
            this.cl4.Name = "cl4";
            this.cl4.ReadOnly = true;
            // 
            // cl5
            // 
            this.cl5.DataPropertyName = "GioiTinh";
            this.cl5.HeaderText = "Giới tính";
            this.cl5.Name = "cl5";
            this.cl5.ReadOnly = true;
            this.cl5.Width = 55;
            // 
            // cl7
            // 
            this.cl7.DataPropertyName = "TinhTrang";
            this.cl7.HeaderText = "Tình trạng";
            this.cl7.Name = "cl7";
            this.cl7.ReadOnly = true;
            this.cl7.Width = 70;
            // 
            // cl6
            // 
            this.cl6.DataPropertyName = "GiaDinhChinhSach";
            this.cl6.HeaderText = "Gia đình chính sách";
            this.cl6.Name = "cl6";
            this.cl6.ReadOnly = true;
            // 
            // cl8
            // 
            this.cl8.DataPropertyName = "DanToc";
            this.cl8.HeaderText = "Dân tộc";
            this.cl8.Name = "cl8";
            this.cl8.ReadOnly = true;
            this.cl8.Width = 55;
            // 
            // TenTruong
            // 
            this.TenTruong.DataPropertyName = "TenTruong";
            this.TenTruong.HeaderText = "Tên trường";
            this.TenTruong.Name = "TenTruong";
            this.TenTruong.ReadOnly = true;
            this.TenTruong.Width = 150;
            // 
            // TD1
            // 
            this.TD1.DataPropertyName = "TrinhDo1";
            this.TD1.HeaderText = "Trình độ 1";
            this.TD1.Name = "TD1";
            this.TD1.ReadOnly = true;
            this.TD1.Width = 50;
            // 
            // TD2
            // 
            this.TD2.DataPropertyName = "TrinhDo2";
            this.TD2.HeaderText = "Trình độ 2";
            this.TD2.Name = "TD2";
            this.TD2.ReadOnly = true;
            this.TD2.Width = 50;
            // 
            // TD3
            // 
            this.TD3.DataPropertyName = "TrinhDo3";
            this.TD3.HeaderText = "Trình độ 3";
            this.TD3.Name = "TD3";
            this.TD3.ReadOnly = true;
            this.TD3.Width = 50;
            // 
            // TD4
            // 
            this.TD4.DataPropertyName = "TrinhDo4";
            this.TD4.HeaderText = "Trình độ 4";
            this.TD4.Name = "TD4";
            this.TD4.ReadOnly = true;
            this.TD4.Width = 50;
            // 
            // TD5
            // 
            this.TD5.DataPropertyName = "TrinhDo5";
            this.TD5.HeaderText = "Trình độ 5";
            this.TD5.Name = "TD5";
            this.TD5.ReadOnly = true;
            this.TD5.Width = 50;
            // 
            // cl10
            // 
            this.cl10.DataPropertyName = "NamTotNghiep";
            this.cl10.HeaderText = "Năm TN";
            this.cl10.Name = "cl10";
            this.cl10.ReadOnly = true;
            this.cl10.Width = 50;
            // 
            // cl11
            // 
            this.cl11.DataPropertyName = "NamBoHoc";
            this.cl11.HeaderText = "Năm bỏ học";
            this.cl11.Name = "cl11";
            this.cl11.ReadOnly = true;
            this.cl11.Width = 55;
            // 
            // NgayChuyenDen
            // 
            this.NgayChuyenDen.DataPropertyName = "NgayChuyenDen";
            this.NgayChuyenDen.HeaderText = "Ngày chuyển đến";
            this.NgayChuyenDen.Name = "NgayChuyenDen";
            this.NgayChuyenDen.ReadOnly = true;
            // 
            // NoiOCu
            // 
            this.NoiOCu.DataPropertyName = "NoiKhac";
            this.NoiOCu.HeaderText = "Nơi ở cũ";
            this.NoiOCu.Name = "NoiOCu";
            this.NoiOCu.ReadOnly = true;
            // 
            // clNgayChuyenDi
            // 
            this.clNgayChuyenDi.DataPropertyName = "NgayChuyenDi";
            this.clNgayChuyenDi.HeaderText = "Ngày chuyển đi";
            this.clNgayChuyenDi.Name = "clNgayChuyenDi";
            this.clNgayChuyenDi.ReadOnly = true;
            // 
            // clNoiDen
            // 
            this.clNoiDen.DataPropertyName = "NoiChuyenDen";
            this.clNoiDen.HeaderText = "Nơi chuyển đến";
            this.clNoiDen.Name = "clNoiDen";
            this.clNoiDen.ReadOnly = true;
            // 
            // clGhiChu
            // 
            this.clGhiChu.DataPropertyName = "GhiChu";
            this.clGhiChu.HeaderText = "Ghi chú";
            this.clGhiChu.Name = "clGhiChu";
            this.clGhiChu.ReadOnly = true;
            this.clGhiChu.Width = 130;
            // 
            // MaThanhVien
            // 
            this.MaThanhVien.DataPropertyName = "MaThanhVien";
            this.MaThanhVien.HeaderText = "Mã thành viên";
            this.MaThanhVien.Name = "MaThanhVien";
            this.MaThanhVien.ReadOnly = true;
            this.MaThanhVien.Visible = false;
            // 
            // frmDuLieuPhoCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 489);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dgvThongTin);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThemThanhVien);
            this.Controls.Add(this.btnThemHo);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDuLieuPhoCap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DuLieuPhoCap";
            this.Load += new System.EventHandler(this.frmDuLieuPhoCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThemHo;
        private System.Windows.Forms.Button btnThemThanhVien;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvThongTin;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaHoGiaDinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenChuHo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl4;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl7;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl8;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTruong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TD1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TD2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TD3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TD4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TD5;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl10;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl11;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyenDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiOCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNgayChuyenDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clNoiDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn clGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThanhVien;
    }
}

