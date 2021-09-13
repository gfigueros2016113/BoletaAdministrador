
namespace BoletasUsuario
{
    partial class Marcas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.marcas_dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.excel_btn = new System.Windows.Forms.Button();
            this.buscar_id_chb = new System.Windows.Forms.CheckBox();
            this.usuario_cmb = new System.Windows.Forms.ComboBox();
            this.buscar_btn = new System.Windows.Forms.Button();
            this.hasta_dtp = new System.Windows.Forms.DateTimePicker();
            this.desde_dtp = new System.Windows.Forms.DateTimePicker();
            this.hasta_lbl = new System.Windows.Forms.Label();
            this.desde_lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.marcas_dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // marcas_dgv
            // 
            this.marcas_dgv.AllowUserToAddRows = false;
            this.marcas_dgv.AllowUserToDeleteRows = false;
            this.marcas_dgv.AllowUserToResizeRows = false;
            this.marcas_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marcas_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.marcas_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.marcas_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.marcas_dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.marcas_dgv.Location = new System.Drawing.Point(18, 186);
            this.marcas_dgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.marcas_dgv.Name = "marcas_dgv";
            this.marcas_dgv.ReadOnly = true;
            this.marcas_dgv.Size = new System.Drawing.Size(1076, 651);
            this.marcas_dgv.TabIndex = 52;
            this.marcas_dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.marcas_dgv_CellContentDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.excel_btn);
            this.groupBox1.Controls.Add(this.buscar_id_chb);
            this.groupBox1.Controls.Add(this.usuario_cmb);
            this.groupBox1.Controls.Add(this.buscar_btn);
            this.groupBox1.Controls.Add(this.hasta_dtp);
            this.groupBox1.Controls.Add(this.desde_dtp);
            this.groupBox1.Controls.Add(this.hasta_lbl);
            this.groupBox1.Controls.Add(this.desde_lbl);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(510, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(584, 163);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // excel_btn
            // 
            this.excel_btn.BackColor = System.Drawing.Color.Transparent;
            this.excel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excel_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.excel_btn.Image = global::BoletasUsuario.Properties.Resources.Logo_excel_opt;
            this.excel_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excel_btn.Location = new System.Drawing.Point(512, 105);
            this.excel_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.excel_btn.Name = "excel_btn";
            this.excel_btn.Size = new System.Drawing.Size(51, 46);
            this.excel_btn.TabIndex = 53;
            this.excel_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel_btn.UseVisualStyleBackColor = false;
            this.excel_btn.Click += new System.EventHandler(this.excel_btn_Click);
            // 
            // buscar_id_chb
            // 
            this.buscar_id_chb.AutoSize = true;
            this.buscar_id_chb.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_id_chb.Location = new System.Drawing.Point(315, 112);
            this.buscar_id_chb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buscar_id_chb.Name = "buscar_id_chb";
            this.buscar_id_chb.Size = new System.Drawing.Size(122, 17);
            this.buscar_id_chb.TabIndex = 6;
            this.buscar_id_chb.Text = "Buscar por usuario";
            this.buscar_id_chb.UseVisualStyleBackColor = true;
            this.buscar_id_chb.CheckedChanged += new System.EventHandler(this.buscar_id_chb_CheckedChanged);
            // 
            // usuario_cmb
            // 
            this.usuario_cmb.DropDownHeight = 150;
            this.usuario_cmb.DropDownWidth = 246;
            this.usuario_cmb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario_cmb.FormattingEnabled = true;
            this.usuario_cmb.IntegralHeight = false;
            this.usuario_cmb.Location = new System.Drawing.Point(14, 105);
            this.usuario_cmb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usuario_cmb.Name = "usuario_cmb";
            this.usuario_cmb.Size = new System.Drawing.Size(290, 25);
            this.usuario_cmb.TabIndex = 5;
            this.usuario_cmb.Tag = "";
            this.usuario_cmb.Text = "Usuario";
            // 
            // buscar_btn
            // 
            this.buscar_btn.BackColor = System.Drawing.Color.White;
            this.buscar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar_btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_btn.Image = global::BoletasUsuario.Properties.Resources.busqueda__1_;
            this.buscar_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buscar_btn.Location = new System.Drawing.Point(432, 49);
            this.buscar_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buscar_btn.Name = "buscar_btn";
            this.buscar_btn.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.buscar_btn.Size = new System.Drawing.Size(130, 46);
            this.buscar_btn.TabIndex = 4;
            this.buscar_btn.Text = "Buscar";
            this.buscar_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buscar_btn.UseVisualStyleBackColor = false;
            this.buscar_btn.Click += new System.EventHandler(this.buscar_btn_Click);
            // 
            // hasta_dtp
            // 
            this.hasta_dtp.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hasta_dtp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hasta_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hasta_dtp.Location = new System.Drawing.Point(222, 49);
            this.hasta_dtp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hasta_dtp.MaximumSize = new System.Drawing.Size(178, 30);
            this.hasta_dtp.MinimumSize = new System.Drawing.Size(178, 30);
            this.hasta_dtp.Name = "hasta_dtp";
            this.hasta_dtp.Size = new System.Drawing.Size(178, 30);
            this.hasta_dtp.TabIndex = 3;
            // 
            // desde_dtp
            // 
            this.desde_dtp.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desde_dtp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desde_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde_dtp.Location = new System.Drawing.Point(14, 49);
            this.desde_dtp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.desde_dtp.MaximumSize = new System.Drawing.Size(178, 30);
            this.desde_dtp.MinimumSize = new System.Drawing.Size(178, 30);
            this.desde_dtp.Name = "desde_dtp";
            this.desde_dtp.Size = new System.Drawing.Size(178, 30);
            this.desde_dtp.TabIndex = 2;
            // 
            // hasta_lbl
            // 
            this.hasta_lbl.AutoSize = true;
            this.hasta_lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hasta_lbl.Location = new System.Drawing.Point(218, 18);
            this.hasta_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hasta_lbl.Name = "hasta_lbl";
            this.hasta_lbl.Size = new System.Drawing.Size(44, 17);
            this.hasta_lbl.TabIndex = 1;
            this.hasta_lbl.Text = "Hasta:";
            // 
            // desde_lbl
            // 
            this.desde_lbl.AutoSize = true;
            this.desde_lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desde_lbl.Location = new System.Drawing.Point(9, 18);
            this.desde_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.desde_lbl.Name = "desde_lbl";
            this.desde_lbl.Size = new System.Drawing.Size(48, 17);
            this.desde_lbl.TabIndex = 0;
            this.desde_lbl.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(18, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 40);
            this.label4.TabIndex = 21;
            this.label4.Text = "Marcas Empleados";
            // 
            // Marcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::BoletasUsuario.Properties.Resources.FONDO_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1112, 855);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.marcas_dgv);
            this.Controls.Add(this.label4);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Marcas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marcas";
            this.Load += new System.EventHandler(this.Marcas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marcas_dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView marcas_dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox usuario_cmb;
        private System.Windows.Forms.Button buscar_btn;
        private System.Windows.Forms.DateTimePicker hasta_dtp;
        private System.Windows.Forms.DateTimePicker desde_dtp;
        private System.Windows.Forms.Label hasta_lbl;
        private System.Windows.Forms.Label desde_lbl;
        private System.Windows.Forms.CheckBox buscar_id_chb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button excel_btn;
    }
}