namespace GiaoDucPhoCap
{
    partial class USDanhMucThonXom
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.clTenThon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMaThon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvThon = new System.Windows.Forms.DataGridView();
            this.clSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.txtTenThon = new System.Windows.Forms.TextBox();
            this.txtMaThon = new System.Windows.Forms.TextBox();
            this.lblTenThon = new System.Windows.Forms.Label();
            this.lblMaThon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThon)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(500, 31);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "DANH MỤC THÔN XÓM";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(207, 105);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 28);
            this.btnXoa.TabIndex = 39;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // clTenThon
            // 
            this.clTenThon.DataPropertyName = "TenThon";
            this.clTenThon.HeaderText = "Tên thôn";
            this.clTenThon.Name = "clTenThon";
            // 
            // clMaThon
            // 
            this.clMaThon.DataPropertyName = "MaThon";
            this.clMaThon.HeaderText = "Mã thôn";
            this.clMaThon.Name = "clMaThon";
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(107, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(94, 28);
            this.btnSua.TabIndex = 38;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // dgvThon
            // 
            this.dgvThon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThon.BackgroundColor = System.Drawing.Color.White;
            this.dgvThon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSTT,
            this.clMaThon,
            this.clTenThon});
            this.dgvThon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvThon.Location = new System.Drawing.Point(0, 147);
            this.dgvThon.Name = "dgvThon";
            this.dgvThon.Size = new System.Drawing.Size(500, 138);
            this.dgvThon.TabIndex = 40;
            // 
            // clSTT
            // 
            this.clSTT.HeaderText = "Số thứ tự";
            this.clSTT.Name = "clSTT";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMoi.Location = new System.Drawing.Point(7, 105);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(94, 28);
            this.btnThemMoi.TabIndex = 37;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            // 
            // txtTenThon
            // 
            this.txtTenThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThon.Location = new System.Drawing.Point(92, 74);
            this.txtTenThon.Name = "txtTenThon";
            this.txtTenThon.Size = new System.Drawing.Size(369, 22);
            this.txtTenThon.TabIndex = 36;
            // 
            // txtMaThon
            // 
            this.txtMaThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThon.Location = new System.Drawing.Point(92, 41);
            this.txtMaThon.Name = "txtMaThon";
            this.txtMaThon.Size = new System.Drawing.Size(100, 22);
            this.txtMaThon.TabIndex = 33;
            // 
            // lblTenThon
            // 
            this.lblTenThon.AutoSize = true;
            this.lblTenThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenThon.Location = new System.Drawing.Point(12, 77);
            this.lblTenThon.Name = "lblTenThon";
            this.lblTenThon.Size = new System.Drawing.Size(68, 16);
            this.lblTenThon.TabIndex = 34;
            this.lblTenThon.Text = "Tên thôn";
            // 
            // lblMaThon
            // 
            this.lblMaThon.AutoSize = true;
            this.lblMaThon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaThon.Location = new System.Drawing.Point(12, 47);
            this.lblMaThon.Name = "lblMaThon";
            this.lblMaThon.Size = new System.Drawing.Size(62, 16);
            this.lblMaThon.TabIndex = 35;
            this.lblMaThon.Text = "Mã thôn";
            // 
            // DanhMucThonXom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dgvThon);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.txtTenThon);
            this.Controls.Add(this.txtMaThon);
            this.Controls.Add(this.lblTenThon);
            this.Controls.Add(this.lblMaThon);
            this.Controls.Add(this.textBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DanhMucThonXom";
            this.Size = new System.Drawing.Size(500, 285);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn clTenThon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMaThon;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvThon;
        private System.Windows.Forms.DataGridViewTextBoxColumn clSTT;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.TextBox txtTenThon;
        private System.Windows.Forms.TextBox txtMaThon;
        private System.Windows.Forms.Label lblTenThon;
        private System.Windows.Forms.Label lblMaThon;
    }
}
