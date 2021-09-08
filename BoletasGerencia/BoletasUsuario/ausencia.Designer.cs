
namespace BoletasUsuario
{
    partial class ausencia
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
            this.dgv_ausencia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ausencia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ausencia
            // 
            this.dgv_ausencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ausencia.Location = new System.Drawing.Point(26, 62);
            this.dgv_ausencia.Name = "dgv_ausencia";
            this.dgv_ausencia.Size = new System.Drawing.Size(569, 441);
            this.dgv_ausencia.TabIndex = 0;
            // 
            // ausencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 536);
            this.Controls.Add(this.dgv_ausencia);
            this.Name = "ausencia";
            this.Text = "ausencia";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ausencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ausencia;
    }
}