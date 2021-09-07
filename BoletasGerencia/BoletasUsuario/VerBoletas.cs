using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office;
using Excel = Microsoft.Office.Interop.Excel;


namespace BoletasUsuario
{
    public partial class VerBoletas : Form
    {
        public VerBoletas()
        {
            InitializeComponent();
        }
        public string id;
        public string nombre;
        public string puesto;
        public string dias;
        public string empresa;
        public string permiso;
        public string contador;
        public string departamentoPrincipal;
        public int opcion;
        ConsultasSQL sql = new ConsultasSQL();

        private void VerBoletas_Load(object sender, EventArgs e)
        {
            //dgvEngaño.Height = 0;
            comboBox1.DataSource = sql.MostrarDepartamentos();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idDepartamento";
            comboBox1.SelectedItem = null;

            comboBox3.DataSource = sql.MostrarEstados();
            comboBox3.DisplayMember = "nombre";
            comboBox3.ValueMember = "idEstado";
            comboBox3.SelectedItem = null;

            dataGridView2.DataSource = sql.ReporteFaltasJustificadas();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                if (Convert.ToString(row.Cells["Fecha Ausencia 1"].Value) == "1/01/2000 00:00:00")
                {
                    row.Cells["Fecha Ausencia 1"].Value = DBNull.Value;
                }

                if (Convert.ToString(row.Cells["Fecha Ausencia 2"].Value) == "1/01/2000 00:00:00")
                {
                    row.Cells["Fecha Ausencia 2"].Value = DBNull.Value;
                }

                if (Convert.ToString(row.Cells["Fecha Ausencia 3"].Value) == "1/01/2000 00:00:00")
                {
                    row.Cells["Fecha Ausencia 3"].Value = DBNull.Value;
                }

                if (Convert.ToString(row.Cells["Fecha Ausencia 4"].Value) == "1/01/2000 00:00:00")
                {
                    row.Cells["Fecha Ausencia 4"].Value = DBNull.Value;
                }

                if (Convert.ToString(row.Cells["Fecha Ausencia 5"].Value) == "1/01/2000 00:00:00")
                {
                    row.Cells["Fecha Ausencia 5"].Value = DBNull.Value;
                }

            }

            if (opcion == 1)
            {
                dataGridView1.DataSource = sql.VacacionesOp0();
                dgvEngaño.DataSource = sql.VacacionesOp0();
                button2.BackColor = System.Drawing.Color.MidnightBlue;
                button1.BackColor = System.Drawing.Color.RoyalBlue;
                button4.BackColor = System.Drawing.Color.RoyalBlue;
                button5.BackColor = System.Drawing.Color.RoyalBlue;
                button3.BackColor = System.Drawing.Color.RoyalBlue;
                button6.BackColor = System.Drawing.Color.RoyalBlue;
            }
            else if (opcion == 2)
            {
                dataGridView1.DataSource = sql.ReposicionOp0();
                dgvEngaño.DataSource = sql.ReposicionOpEngaño();
                button1.BackColor = System.Drawing.Color.MidnightBlue;
                button2.BackColor = System.Drawing.Color.RoyalBlue;
                button4.BackColor = System.Drawing.Color.RoyalBlue;
                button5.BackColor = System.Drawing.Color.RoyalBlue;
                button3.BackColor = System.Drawing.Color.RoyalBlue;
                button6.BackColor = System.Drawing.Color.RoyalBlue;
            }
            else if (opcion == 3)
            {
                dataGridView1.DataSource = sql.EspecialOp0();
                dgvEngaño.DataSource = sql.EspecialEngaño();
                button4.BackColor = System.Drawing.Color.MidnightBlue;
                button1.BackColor = System.Drawing.Color.RoyalBlue;
                button2.BackColor = System.Drawing.Color.RoyalBlue;
                button5.BackColor = System.Drawing.Color.RoyalBlue;
                button3.BackColor = System.Drawing.Color.RoyalBlue;
                button6.BackColor = System.Drawing.Color.RoyalBlue;
            }
            else if (opcion == 4)
            {
                dataGridView1.DataSource = sql.ConsultaOp0();
                dgvEngaño.DataSource = sql.ConsultaOp0();
                button5.BackColor = System.Drawing.Color.MidnightBlue;
                button1.BackColor = System.Drawing.Color.RoyalBlue;
                button4.BackColor = System.Drawing.Color.RoyalBlue;
                button2.BackColor = System.Drawing.Color.RoyalBlue;
                button3.BackColor = System.Drawing.Color.RoyalBlue;
                button6.BackColor = System.Drawing.Color.RoyalBlue;
            }
            else if (opcion == 5)
            {
                dataGridView1.DataSource = sql.suspensionOp0();
                dgvEngaño.DataSource = sql.suspensionOp0();
                button3.BackColor = System.Drawing.Color.MidnightBlue;
                button1.BackColor = System.Drawing.Color.RoyalBlue;
                button4.BackColor = System.Drawing.Color.RoyalBlue;
                button5.BackColor = System.Drawing.Color.RoyalBlue;
                button2.BackColor = System.Drawing.Color.RoyalBlue;
                button6.BackColor = System.Drawing.Color.RoyalBlue;
            }
            else if (opcion == 6)
            {
                dataGridView1.DataSource = sql.sancionOp0();
                dgvEngaño.DataSource = sql.sancionOp0();
                button6.BackColor = System.Drawing.Color.MidnightBlue;
                button1.BackColor = System.Drawing.Color.RoyalBlue;
                button4.BackColor = System.Drawing.Color.RoyalBlue;
                button5.BackColor = System.Drawing.Color.RoyalBlue;
                button3.BackColor = System.Drawing.Color.RoyalBlue;
                button2.BackColor = System.Drawing.Color.RoyalBlue;
            }
        }   

        private void button7_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= dateTimePicker2.Value)
            {
                string fechaI = dateTimePicker1.Value.ToShortDateString();
                string fechaF = dateTimePicker2.Value.ToShortDateString();

                switch (opcion)
                {
                    case 1:
                        if(comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null)//opcion 1
                        {
                            dataGridView1.DataSource = sql.VacacionesOp1(fechaI, fechaF);
                        } 
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null) //opcion 2
                        {
                            dataGridView1.DataSource = sql.VacacionesOp2(fechaI, fechaF,comboBox1.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 3
                        {
                            dataGridView1.DataSource = sql.VacacionesOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue == null) //opcion 4
                        {
                            dataGridView1.DataSource = sql.VacacionesOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue != null) //opcion 5
                        {
                            dataGridView1.DataSource = sql.VacacionesOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 6
                        {
                            dataGridView1.DataSource = sql.VacacionesOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        break;
                    case 2:
                        if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null)//opcion 1
                        {
                            dataGridView1.DataSource = sql.ReposicionOp1(fechaI, fechaF);
                            dgvEngaño.DataSource = sql.ReposicionEngañoOp1(fechaI, fechaF);
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null) //opcion 2
                        {
                            dataGridView1.DataSource = sql.ReposicionOp2(fechaI, fechaF, comboBox1.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.ReposicionEngañoOp2(fechaI, fechaF, comboBox1.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 3
                        {
                            dataGridView1.DataSource = sql.ReposicionOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.ReposicionEngañoOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue == null) //opcion 4
                        {
                            dataGridView1.DataSource = sql.ReposicionOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.ReposicionEngañoOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue != null) //opcion 5
                        {
                            dataGridView1.DataSource = sql.ReposicionOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.ReposicionEngañoOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 6
                        {
                            dataGridView1.DataSource = sql.ReposicionOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.ReposicionEngañoOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        break;
                    case 3:
                        if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null)//opcion 1
                        {
                            dataGridView1.DataSource = sql.EspecialOp1(fechaI, fechaF);
                            dgvEngaño.DataSource = sql.EspecialEngañoOp1(fechaI, fechaF);
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null) //opcion 2
                        {
                            dataGridView1.DataSource = sql.EspecialOp2(fechaI, fechaF, comboBox1.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.EspecialEngañoOp2(fechaI, fechaF, comboBox1.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 3
                        {
                            dataGridView1.DataSource = sql.EspecialOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.EspecialEngañoOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue == null) //opcion 4
                        {
                            dataGridView1.DataSource = sql.EspecialOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.EspecialEngañoOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue != null) //opcion 5
                        {
                            dataGridView1.DataSource = sql.EspecialOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.EspecialEngañoOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 6
                        {
                            dataGridView1.DataSource = sql.EspecialOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                            dgvEngaño.DataSource = sql.EspecialEngañoOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        break;
                    case 4:
                        if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null)//opcion 1
                        {
                            dataGridView1.DataSource = sql.ConsultaOp1(fechaI, fechaF);
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null) //opcion 2
                        {
                            dataGridView1.DataSource = sql.ConsultaOp2(fechaI, fechaF, comboBox1.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 3
                        {
                            dataGridView1.DataSource = sql.ConsultaOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue == null) //opcion 4
                        {
                            dataGridView1.DataSource = sql.ConsultaOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue != null) //opcion 5
                        {
                            dataGridView1.DataSource = sql.ConsultaOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 6
                        {
                            dataGridView1.DataSource = sql.ConsultaOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        break;
                    case 5:
                        if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null)//opcion 1
                        {
                            dataGridView1.DataSource = sql.suspensionOp1(fechaI, fechaF);
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null) //opcion 2
                        {
                            dataGridView1.DataSource = sql.suspensionOp2(fechaI, fechaF, comboBox1.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 3
                        {
                            dataGridView1.DataSource = sql.suspensionOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue == null) //opcion 4
                        {
                            dataGridView1.DataSource = sql.suspensionOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue != null) //opcion 5
                        {
                            dataGridView1.DataSource = sql.suspensionOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 6
                        {
                            dataGridView1.DataSource = sql.suspensionOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        break;
                    case 6:
                        if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null)//opcion 1
                        {
                            dataGridView1.DataSource = sql.sancionOp1(fechaI, fechaF);
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue == null) //opcion 2
                        {
                            dataGridView1.DataSource = sql.sancionOp2(fechaI, fechaF, comboBox1.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue == null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 3
                        {
                            dataGridView1.DataSource = sql.sancionOp3(fechaI, fechaF, comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue == null) //opcion 4
                        {
                            dataGridView1.DataSource = sql.sancionOp4(fechaI, fechaF, comboBox2.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue != null & comboBox3.SelectedValue != null) //opcion 5
                        {
                            dataGridView1.DataSource = sql.sancionOp5(fechaI, fechaF, comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        else if (comboBox1.SelectedValue != null & comboBox2.SelectedValue == null & comboBox3.SelectedValue != null) //opcion 6
                        {
                            dataGridView1.DataSource = sql.sancionOp6(fechaI, fechaF, comboBox1.SelectedValue.ToString(), comboBox3.SelectedValue.ToString());
                        }
                        break;
                    default:
                        MessageBox.Show("No ha seleccionado un tipo de Boleta...");
                        break;
                }

            }
            else
            {
                MessageBox.Show("Rango de fechas invalido...");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(opcion == 2 || opcion == 3)
                {
                    if (dgvEngaño.DataSource != null)
                    {
                        dgvEngaño.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                        dgvEngaño.MultiSelect = true;
                        dgvEngaño.SelectAll();
                        dataGridView1.MultiSelect = true;
                        dataGridView1.SelectAll();
                        DataObject dataObj = dgvEngaño.GetClipboardContent();
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
                        dgvEngaño.ClearSelection();
                        dgvEngaño.MultiSelect = false;
                        dataGridView1.ClearSelection();
                        dataGridView1.MultiSelect = false;
                    }
                    else
                    {
                        MessageBox.Show("No hay nada en la tabla...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue != null)
            {
                string id = comboBox1.SelectedValue.ToString();
                Boolean isNumeric = int.TryParse(id, out int n);
                if (isNumeric == true)
                {
                    Console.WriteLine(id);
                    comboBox2.DataSource = sql.MostrarEmpleados(id);
                    comboBox2.DisplayMember = "nombre";
                    comboBox2.ValueMember = "idUsuario";
                    comboBox2.SelectedItem = null;
                }
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(opcion == 1)
            {
                dataGridView1.DataSource = sql.BuscarVacaciones(textBox1.Text);
            }
            else if(opcion == 2)
            {
                dataGridView1.DataSource = sql.BuscarReposicion(textBox1.Text);
                dgvEngaño.DataSource = sql.BuscarReposicionEngaño(textBox1.Text);
            }
            else if (opcion == 3)
            {
                dataGridView1.DataSource = sql.BuscarEspecial(textBox1.Text);
                dgvEngaño.DataSource = sql.BuscarEspecialEngaño(textBox1.Text);
            }
            else if (opcion == 4)
            {
                dataGridView1.DataSource = sql.BuscarConsulta(textBox1.Text);
            }
            else if (opcion == 5)
            {
                dataGridView1.DataSource = sql.BuscarSuspension(textBox1.Text);
            }
            else if (opcion == 6)
            {
                dataGridView1.DataSource = sql.BuscarSancion(textBox1.Text);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel3.Visible = false;
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
                panel3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            if (opcion == 1)
            {
                dataGridView1.DataSource = sql.VacacionesOp0();
            }
            else if (opcion == 2)
            {
                dataGridView1.DataSource = sql.ReposicionOp0();
            }
            else if (opcion == 3)
            {
                dataGridView1.DataSource = sql.EspecialOp0();
            }
            else if (opcion == 4)
            {
                dataGridView1.DataSource = sql.ConsultaOp0();
            }
            else if (opcion == 5)
            {
                dataGridView1.DataSource = sql.suspensionOp0();
            }
            else if (opcion == 6)
            {
                dataGridView1.DataSource = sql.sancionOp0();
            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            string idBoleta = Convert.ToString(fila.Cells[0].Value);

            if (opcion == 1)
            {
                DetalleVacaciones menu = new DetalleVacaciones();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
              //  menu.opcion = 1;
                menu.Show();
              //  this.Close();
            }
            else if (opcion == 2)
            {
                DetalleReposicion menu = new DetalleReposicion();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
              //  menu.opcion = 1;
                menu.Show();
             //   this.Close();
            }
            else if (opcion == 3)
            {
                DetalleEspecial menu = new DetalleEspecial();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
               // menu.opcion = 1;
                menu.Show();
             //   this.Close();
            }
            else if (opcion == 4)
            {
                DetalleConsulta menu = new DetalleConsulta();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
             //   menu.opcion = 1;
                menu.Show();
               // this.Close();
            }
            else if (opcion == 5)
            {
                DetalleSuspension menu = new DetalleSuspension();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
               // menu.opcion = 1;
                menu.Show();
              //  this.Close();
            }
            else if (opcion == 6)
            {
                DetalleSancion menu = new DetalleSancion();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
              //  menu.opcion = 1;
                menu.Show();
              //  this.Close();
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            opcion = 1;
            VerBoletas_Load(sender, e);
            button2.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            opcion = 2;
            VerBoletas_Load(sender, e);
            button1.BackColor = System.Drawing.Color.MidnightBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            opcion = 3;
            VerBoletas_Load(sender, e);
            button4.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            opcion = 4;
            VerBoletas_Load(sender, e);
            button5.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            opcion = 5;
            VerBoletas_Load(sender, e);
            button3.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            opcion = 6;
            VerBoletas_Load(sender, e);
            button6.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.DataSource != null)
                {
                    dataGridView2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    dataGridView2.MultiSelect = true;
                    dataGridView2.SelectAll();
                    DataObject dataObj = dataGridView2.GetClipboardContent();
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
                    dataGridView2.ClearSelection();
                    dataGridView2.MultiSelect = false;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
