namespace GiaoDucPhoCap
{
    partial class frmThonXom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThonXom));
            this.lblMaThon = new System.Windows.Forms.Label();
            this.lblTenThon = new System.Windows.Forms.Label();
            this.txtMaThon = new System.Windows.Forms.TextBox();
            this.txtTenThon = new System.Windows.Forms.TextBox();
            this.dgvThon = new System.Windows.Forms.DataGridView();
            this.clMaThon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clTenThon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaThon
            // 
            this.lblMaThon.AutoSize = true;
            this.lblMaThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaThon.Location = new System.Drawing.Point(86, 24);
            this.lblMaThon.Name = "lblMaThon";
            this.lblMaThon.Size = new System.Drawing.Size(55, 16);
            this.lblMaThon.TabIndex = 0;
            this.lblMaThon.Text = "Mã thôn";
            // 
            // lblTenThon
            // 
            this.lblTenThon.AutoSize = true;
            this.lblTenThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenThon.Location = new System.Drawing.Point(86, 54);
            this.lblTenThon.Name = "lblTenThon";
            this.lblTenThon.Size = new System.Drawing.Size(60, 16);
            this.lblTenThon.TabIndex = 0;
            this.lblTenThon.Text = "Tên thôn";
            // 
            // txtMaThon
            // 
            this.txtMaThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThon.Location = new System.Drawing.Point(166, 18);
            this.txtMaThon.Name = "txtMaThon";
            this.txtMaThon.Size = new System.Drawing.Size(100, 22);
            this.txtMaThon.TabIndex = 0;
            // 
            // txtTenThon
            // 
            this.txtTenThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThon.Location = new System.Drawing.Point(166, 51);
            this.txtTenThon.Name = "txtTenThon";
            this.txtTenThon.Size = new System.Drawing.Size(209, 22);
            this.txtTenThon.TabIndex = 1;
            this.txtTenThon.TextChanged += new System.EventHandler(this.txtTenThon_TextChanged);
            // 
            // dgvThon
            // 
            this.dgvThon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThon.BackgroundColor = System.Drawing.Color.White;
            this.dgvThon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clMaThon,
            this.clTenThon});
            this.dgvThon.Location = new System.Drawing.Point(12, 178);
            this.dgvThon.MultiSelect = false;
            this.dgvThon.Name = "dgvThon";
            this.dgvThon.ReadOnly = true;
            this.dgvThon.Size = new System.Drawing.Size(464, 105);
            this.dgvThon.TabIndex = 6;
            this.dgvThon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThon_CellClick);
            // 
            // clMaThon
            // 
            this.clMaThon.DataPropertyName = "MaThon";
            this.clMaThon.HeaderText = "Mã thôn";
            this.clMaThon.Name = "clMaThon";
            this.clMaThon.ReadOnly = true;
            // 
            // clTenThon
            // 
            this.clTenThon.DataPropertyName = "TenThon";
            this.clTenThon.HeaderText = "Tên thôn";
            this.clTenThon.Name = "clTenThon";
            this.clTenThon.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(488, 29);
            this.textBox1.TabIndex = 32;
            this.textBox1.Text = "DANH MỤC THÔN XÓM";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(289, 92);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(86, 28);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(198, 92);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 28);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Location = new System.Drawing.Point(89, 92);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(94, 28);
            this.btnThemMoi.TabIndex = 2;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.txtTenThon);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.lblMaThon);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.lblTenThon);
            this.groupBox1.Controls.Add(this.btnThemMoi);
            this.groupBox1.Controls.Add(this.txtMaThon);
            this.groupBox1.Location = new System.Drawing.Point(13, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 139);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin";
            // 
            // frmThonXom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 295);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvThon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThonXom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThonXom";
            this.Load += new System.EventHandler(this.frmThonXom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaThon;
        private System.Windows.Forms.Label lblTenThon;
        private System.Windows.Forms.TextBox txtMaThon;
        private System.Windows.Forms.TextBox txtTenThon;
        private System.Windows.Forms.DataGridView dgvThon;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaThon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenThon;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}