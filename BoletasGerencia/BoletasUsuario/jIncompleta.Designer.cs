
namespace BoletasUsuario
{
    partial class jIncompleta
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
            this.dgv_jIncompleta = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jIncompleta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_jIncompleta
            // 
            this.dgv_jIncompleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jIncompleta.Location = new System.Drawing.Point(30, 63);
            this.dgv_jIncompleta.Name = "dgv_jIncompleta";
            this.dgv_jIncompleta.Size = new System.Drawing.Size(756, 360);
            this.dgv_jIncompleta.TabIndex = 0;
            // 
            // jIncompleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.dgv_jIncompleta);
            this.Name = "jIncompleta";
            this.Text = "jIncompleta";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jIncompleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_jIncompleta;
    }
}