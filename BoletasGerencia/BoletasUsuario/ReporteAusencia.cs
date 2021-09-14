using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace BoletasUsuario
{
    public partial class ReporteAusencia : Form
    {
        public ReporteAusencia()
        {
            InitializeComponent();
        }
        #region variables globales
        ConsultasSQL sql = new ConsultasSQL();
        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ReporteAusencia_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.ReporteAusencia();
        }

        private void buscar_btn_Click(object sender, EventArgs e)
        {
            string fechas = fecha.Value.ToString("dd/MM/yyyy");
            dataGridView1.DataSource = sql.ObtenerReporteAusenciaBuscar(fechas);
        }


        #region boton excel
        private void excel_btn_Click(object sender, EventArgs e)
        {
                try
                {
                    if (dataGridView1.DataSource != null)
                    {
                        dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                        dataGridView1.MultiSelect = true;
                        dataGridView1.SelectAll();
                        DataObject dataObj = dataGridView1.GetClipboardContent();
                        if (dataObj != null)
                            Clipboard.SetDataObject(dataObj);

                        Microsoft.Office.Interop.Excel.Application xlexcel;
                        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;
                        xlexcel = new Excel.Application();
                        xlWorkBook = xlexcel.Workbooks.Add(misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        Excel.Range rango = (Excel.Range)xlWorkSheet.Cells[1, 1];
                        rango.Select();
                        xlWorkSheet.PasteSpecial(rango, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                        //  la primera fila en negrita, centrada y con fondo gris
                        Excel.Range fila1 = (Excel.Range)xlWorkSheet.Rows[1];
                        fila1.Select();
                        fila1.EntireRow.Font.Bold = true;
                        fila1.EntireRow.HorizontalAlignment = HorizontalAlignment.Center;
                        // si la primera celda de la primera columna está vacía, elimino la primera columna
                        Excel.Range c1f1 = (Excel.Range)xlWorkSheet.Cells[1, 1];
                        if (c1f1.Text == "")
                        {
                            Excel.Range columna1 = (Excel.Range)xlWorkSheet.Columns[1];
                            columna1.Select();
                            columna1.Delete();
                        }

                        //selecciono la primera celda de la primera columna
                        Excel.Range c1 = (Excel.Range)xlWorkSheet.Cells[1, 1];
                        c1.Select();
                        xlexcel.Cells.Select();
                        xlexcel.Cells.EntireColumn.AutoFit();
                        xlexcel.Visible = true;
                        dataGridView1.ClearSelection();
                        dataGridView1.MultiSelect = false;
                    }
                    else
                    {
                        MessageBox.Show("No hay nada en la tabla...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
            
        }
#endregion
    }
}
