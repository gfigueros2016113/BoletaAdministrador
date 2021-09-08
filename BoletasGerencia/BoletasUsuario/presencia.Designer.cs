
namespace BoletasUsuario
{
    partial class presencia
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
            this.dgv_presencia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presencia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_presencia
            // 
            this.dgv_presencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_presencia.Location = new System.Drawing.Point(23, 58);
            this.dgv_presencia.Name = "dgv_presencia";
            this.dgv_presencia.Size = new System.Drawing.Size(705, 399);
            this.dgv_presencia.TabIndex = 0;
            this.dgv_presencia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_presencia_CellContentClick);
            // 
            // presencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 486);
            this.Controls.Add(this.dgv_presencia);
            this.Name = "presencia";
            this.Text = "presencia";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_presencia;
    }
}