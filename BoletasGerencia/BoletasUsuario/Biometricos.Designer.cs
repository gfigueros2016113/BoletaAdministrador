
namespace BoletasUsuario
{
    partial class Biometricos
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
            this.marcas_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.precencia = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.ausencia = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.jIncompleta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // marcas_btn
            // 
            this.marcas_btn.BackColor = System.Drawing.Color.Transparent;
            this.marcas_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.marcas_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.marcas_btn.Image = global::BoletasUsuario.Properties.Resources.lista_de_asistentes;
            this.marcas_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.marcas_btn.Location = new System.Drawing.Point(128, 83);
            this.marcas_btn.Name = "marcas_btn";
            this.marcas_btn.Size = new System.Drawing.Size(142, 139);
            this.marcas_btn.TabIndex = 39;
            this.marcas_btn.Text = "Marcas Empleados.";
            this.marcas_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.marcas_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.marcas_btn.UseVisualStyleBackColor = false;
            this.marcas_btn.Click += new System.EventHandler(this.marcas_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 37);
            this.label3.TabIndex = 40;
            this.label3.Text = "Elija un tipo de reporte.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(568, 420);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 21);
            this.label1.TabIndex = 46;
            this.label1.Text = "Aplicación de Reporteria de Marcas";
            // 
<<<<<<< Updated upstream
            // precencia
            // 
            this.precencia.BackColor = System.Drawing.Color.Transparent;
            this.precencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.precencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precencia.Image = global::BoletasUsuario.Properties.Resources.trabajar;
            this.precencia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.precencia.Location = new System.Drawing.Point(276, 228);
            this.precencia.Name = "precencia";
            this.precencia.Size = new System.Drawing.Size(142, 139);
            this.precencia.TabIndex = 52;
            this.precencia.Text = "Reporte precencia.";
            this.precencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.precencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.precencia.UseVisualStyleBackColor = false;
            this.precencia.Click += new System.EventHandler(this.precencia_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Image = global::BoletasUsuario.Properties.Resources.horario_de_trabajo;
            this.button6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button6.Location = new System.Drawing.Point(424, 83);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 139);
            this.button6.TabIndex = 51;
            this.button6.Text = "Reporte Horarios.";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = false;
            // 
            // ausencia
            // 
            this.ausencia.BackColor = System.Drawing.Color.Transparent;
            this.ausencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ausencia.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ausencia.Image = global::BoletasUsuario.Properties.Resources.falta_de_futbol;
            this.ausencia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ausencia.Location = new System.Drawing.Point(424, 228);
            this.ausencia.Name = "ausencia";
            this.ausencia.Size = new System.Drawing.Size(142, 139);
            this.ausencia.TabIndex = 50;
            this.ausencia.Text = "Reporte ausencia.";
            this.ausencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ausencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ausencia.UseVisualStyleBackColor = false;
            this.ausencia.Click += new System.EventHandler(this.ausencia_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::BoletasUsuario.Properties.Resources.salida;
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(128, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 139);
            this.button2.TabIndex = 49;
            this.button2.Text = "Reporte salida previa.";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
=======
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::BoletasUsuario.Properties.Resources.trabajar;
            this.button7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button7.Location = new System.Drawing.Point(276, 228);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(142, 139);
            this.button7.TabIndex = 52;
            this.button7.Text = "Reporte preencia.";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // horario_btn
            // 
            this.horario_btn.BackColor = System.Drawing.Color.Transparent;
            this.horario_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.horario_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horario_btn.Image = global::BoletasUsuario.Properties.Resources.horario_de_trabajo;
            this.horario_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.horario_btn.Location = new System.Drawing.Point(424, 83);
            this.horario_btn.Name = "horario_btn";
            this.horario_btn.Size = new System.Drawing.Size(142, 139);
            this.horario_btn.TabIndex = 51;
            this.horario_btn.Text = "Reporte Horarios.";
            this.horario_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.horario_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.horario_btn.UseVisualStyleBackColor = false;
            this.horario_btn.Click += new System.EventHandler(this.horario_btn_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::BoletasUsuario.Properties.Resources.falta_de_futbol;
            this.button4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button4.Location = new System.Drawing.Point(424, 228);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 139);
            this.button4.TabIndex = 50;
            this.button4.Text = "Reporte ausencia.";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // previa_btn
            // 
            this.previa_btn.BackColor = System.Drawing.Color.Transparent;
            this.previa_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.previa_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previa_btn.Image = global::BoletasUsuario.Properties.Resources.salida;
            this.previa_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.previa_btn.Location = new System.Drawing.Point(128, 228);
            this.previa_btn.Name = "previa_btn";
            this.previa_btn.Size = new System.Drawing.Size(142, 139);
            this.previa_btn.TabIndex = 49;
            this.previa_btn.Text = "Reporte salida previa.";
            this.previa_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.previa_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.previa_btn.UseVisualStyleBackColor = false;
            this.previa_btn.Click += new System.EventHandler(this.previa_btn_Click);
>>>>>>> Stashed changes
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::BoletasUsuario.Properties.Resources.huella_dactilar;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(276, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(142, 139);
            this.button3.TabIndex = 47;
            this.button3.Text = "Reporte Marcas.";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = false;
            // 
<<<<<<< Updated upstream
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::BoletasUsuario.Properties.Resources.retrasar;
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(572, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 139);
            this.button1.TabIndex = 53;
            this.button1.Text = "Reporte entrada tarde.";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // jIncompleta
            // 
            this.jIncompleta.BackColor = System.Drawing.Color.Transparent;
            this.jIncompleta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.jIncompleta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jIncompleta.Image = global::BoletasUsuario.Properties.Resources.archivo1;
            this.jIncompleta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.jIncompleta.Location = new System.Drawing.Point(572, 228);
            this.jIncompleta.Name = "jIncompleta";
            this.jIncompleta.Size = new System.Drawing.Size(142, 139);
            this.jIncompleta.TabIndex = 54;
            this.jIncompleta.Text = "Reporte jornada incompleta.";
            this.jIncompleta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.jIncompleta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.jIncompleta.UseVisualStyleBackColor = false;
            this.jIncompleta.Click += new System.EventHandler(this.jIncompleta_Click);
=======
            // tarde_btn
            // 
            this.tarde_btn.BackColor = System.Drawing.Color.Transparent;
            this.tarde_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tarde_btn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarde_btn.Image = global::BoletasUsuario.Properties.Resources.retrasar;
            this.tarde_btn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tarde_btn.Location = new System.Drawing.Point(572, 83);
            this.tarde_btn.Name = "tarde_btn";
            this.tarde_btn.Size = new System.Drawing.Size(142, 139);
            this.tarde_btn.TabIndex = 53;
            this.tarde_btn.Text = "Reporte entrada tarde.";
            this.tarde_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tarde_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tarde_btn.UseVisualStyleBackColor = false;
            this.tarde_btn.Click += new System.EventHandler(this.tarde_btn_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = global::BoletasUsuario.Properties.Resources.archivo1;
            this.button5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button5.Location = new System.Drawing.Point(572, 228);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(142, 139);
            this.button5.TabIndex = 54;
            this.button5.Text = "Reporte jornada incompleta.";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
>>>>>>> Stashed changes
            // 
            // Biometricos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BoletasUsuario.Properties.Resources.fondo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(842, 450);
            this.Controls.Add(this.jIncompleta);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.precencia);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.ausencia);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.marcas_btn);
            this.DoubleBuffered = true;
            this.Name = "Biometricos";
            this.Text = "Biometricos";
            this.Load += new System.EventHandler(this.Biometricos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button marcas_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button precencia;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button ausencia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button jIncompleta;
    }
}