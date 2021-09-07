using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoletasUsuario
{
    public partial class perfil : Form
    {
        public perfil()
        {
            InitializeComponent();
        }

        public string nombre;
        public string id;
        public string puesto;
        public string dias;
        public string contador;
        public string inicioLabores;
        public string permiso;
        public string empresa;
        public string departamentoPrincipal;
        ConsultasSQL SQL = new ConsultasSQL();
        private void perfil_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            SQL.ObtenerUsuarioXid(id);
            nombre = SQL.nombre;
            dias = SQL.dias;
            puesto = SQL.puesto;
            inicioLabores = SQL.inicioLabores;
            empresa = SQL.idEmpresa;
            departamentoPrincipal = SQL.departamentoPrincipal;
            comboBox2.DataSource = SQL.MostrarDepartamentos();
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "idDepartamento";

            comboBox3.DataSource = SQL.MostrarDepartamentos();
            comboBox3.DisplayMember = "nombre";
            comboBox3.ValueMember = "idDepartamento";

            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "1");
            test.Add("2", "2");
            test.Add("3", "3");
            test.Add("4", "4");

            comboBox4.DataSource = new BindingSource(test, null);
            comboBox4.DisplayMember = "Value";
            comboBox4.ValueMember = "Value";

            comboBox1.DataSource = SQL.MostrarEmpresas();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idEmpresa";

            textBox1.Text = nombre;
            textBox2.Text = puesto;
            comboBox1.SelectedValue = empresa;
            dateTimePicker1.Value = Convert.ToDateTime(inicioLabores);
            numericUpDown1.Value = Convert.ToDecimal(dias);
            comboBox2.SelectedValue = departamentoPrincipal;
            dataGridView1.DataSource = SQL.ObtenerDepartamentosXId(id);




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            label6.Text = Convert.ToString(fila.Cells[0].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea eliminar al registro: "+label6.Text+"?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (SQL.EliminarRegistro(label6.Text))
                {
                    MessageBox.Show("Registro eliminado correctamente");
                    dataGridView1.DataSource = SQL.ObtenerDepartamentosXId(id);
                }
                else
                {
                    MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                }

            }
            else
            {
                MessageBox.Show("La eliminación ha sido cancelada", "Eliminación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea editar al empleado?", "Editar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (SQL.EditarEmpleado(textBox1.Text, textBox2.Text,comboBox1.SelectedValue.ToString(), dateTimePicker1.Value.ToShortDateString(),numericUpDown1.Value.ToString(),comboBox2.SelectedValue.ToString(),id))
                {
                    MessageBox.Show("Empleado editado correctamente");                  
                }
                else
                {
                    MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                }

            }
            else
            {
                MessageBox.Show("La modificación ha sido cancelada", "Modificación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea registrar al empleado?", "Registrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (SQL.RegistrarEmpleado(id, comboBox3.SelectedValue.ToString(), comboBox4.SelectedValue.ToString()))
                {
                    MessageBox.Show("Empleado registrado correctamente");
                    dataGridView1.DataSource = SQL.ObtenerDepartamentosXId(id);
                }
                else
                {
                    MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                }

            }
            else
            {
                MessageBox.Show("El registro ha sido cancelado", "Registro Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
