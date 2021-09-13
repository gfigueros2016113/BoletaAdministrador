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
    public partial class Marcas : Form
    {
        #region Constructor
        public Marcas()
        {
            InitializeComponent();
        }
        #endregion
        #region Variables
        ConsultasSQL sql = new ConsultasSQL();
        #endregion
        #region Load
        private void Marcas_Load(object sender, EventArgs e)
        {
            marcas_dgv.DataSource = sql.ObtenerMarcas();
            DataGridViewColumn colIdUsuario = marcas_dgv.Columns[6];
            DataGridViewColumn colHora = marcas_dgv.Columns[7];
            colIdUsuario.Visible = false;
            colHora.Visible = false;
            usuario_cmb.DataSource = sql.MostrarUsuarios();
            usuario_cmb.DisplayMember = "nombre";
            usuario_cmb.ValueMember = "idUsuario";
            usuario_cmb.Enabled = false;
        }
        #endregion
        #region Click Boton Buscar
        private void buscar_btn_Click(object sender, EventArgs e)
        {
            if(buscar_id_chb.Checked == true)
            {
                string id = usuario_cmb.SelectedValue.ToString();
                marcas_dgv.DataSource = sql.ObtenerMarcasPorID(id);
            }
            else
            {
                string fInicial = desde_dtp.Value.ToString("yyyy-MM-dd");
                string fFinal = hasta_dtp.Value.ToString("yyyy-MM-dd");
                marcas_dgv.DataSource = sql.ObtenerMarcasPorFecha(fInicial, fFinal);
            }
           
        }
        #endregion
        #region Click Checkbox Buscar Por Usuario
        private void buscar_id_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (buscar_id_chb.Checked == true)
            {
                usuario_cmb.Enabled = true;
                hasta_dtp.Enabled = false;
                desde_dtp.Enabled = false;
            }
            else
            {
                usuario_cmb.Enabled = false;
                hasta_dtp.Enabled = true;
                desde_dtp.Enabled = true;
            }
        }
        #endregion
        #region Click Boton Excel
        private void excel_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (marcas_dgv.DataSource != null)
                {
                    marcas_dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    marcas_dgv.MultiSelect = true;
                    marcas_dgv.SelectAll();
                    DataObject dataObj = marcas_dgv.GetClipboardContent();
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
                    marcas_dgv.ClearSelection();
                    marcas_dgv.MultiSelect = false;
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
        #region Doble Click Celda
        private void marcas_dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow fila = marcas_dgv.Rows[e.RowIndex];
            string nombre_usuario = Convert.ToString(fila.Cells[1].Value);
            string depto = Convert.ToString(fila.Cells[2].Value);
            string fecha = Convert.ToString(fila.Cells[3].Value);
            string hora = Convert.ToString(fila.Cells[4].Value);
            string tipo = Convert.ToString(fila.Cells[5].Value);
            string idUsuario = Convert.ToString(fila.Cells[6].Value);
            DateTime horaSinFormato = Convert.ToDateTime(fila.Cells[7].Value);
            DetallesMarca detallesMarca = new DetallesMarca();
            detallesMarca.nombre_usuario = nombre_usuario;
            detallesMarca.depto = depto;
            detallesMarca.fecha = fecha;
            detallesMarca.hora = hora;
            detallesMarca.tipo = tipo;
            detallesMarca.idUsuario = idUsuario;
            detallesMarca.horaSinFormato = horaSinFormato;
            detallesMarca.Show();        
        }
        #endregion
    }
}
