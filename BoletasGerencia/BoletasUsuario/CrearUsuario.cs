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
    public partial class CrearUsuario : Form
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }
        ConsultasSQL sql = new ConsultasSQL();
        public string user;
        public string pass;
        public string nombre;
        public string puesto;
        public string empresa;
        public string fecha;
        public string vacaciones;
        public string depa;
        public string id;
        private void CrearUsuario_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            comboBox1.DataSource = sql.MostrarEmpresas();
            comboBox1.DisplayMember = "nombre";
            comboBox1.ValueMember = "idEmpresa";
            comboBox2.DataSource = sql.MostrarDepartamentos();
            comboBox2.DisplayMember = "nombre";
            comboBox2.ValueMember = "idDepartamento";

            comboBox3.DataSource = sql.MostrarDepartamentos();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea crear al empleado?", "Crear", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                user = textBox4.Text;
                pass = textBox3.Text;
                nombre = textBox1.Text;
                puesto = textBox2.Text;
                empresa = comboBox1.SelectedValue.ToString();
                fecha = dateTimePicker1.Value.ToShortDateString();
                vacaciones = numericUpDown1.Value.ToString();
                depa = comboBox2.SelectedValue.ToString();

                if (sql.CrearEmpleado(user,nombre,pass,puesto,vacaciones,fecha,empresa,depa))
                {
                    MessageBox.Show("Empleado creado correctamente");
                    MessageBox.Show("Ahora debe registrar en al menos un departamento al usuario creado...","Continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    comboBox3.SelectedValue = depa;
                    panel1.Visible = false;
                    panel2.Visible = true;
                    sql.ObtenerUltimoId();
                    id = sql.ultimo;
                }
                else
                {
                    MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                }

            }
            else
            {
                MessageBox.Show("La creación ha sido Cancelada", "Creación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea registrar al empleado?", "Registrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (sql.RegistrarEmpleado(id, comboBox3.SelectedValue.ToString(), comboBox4.SelectedValue.ToString()))
                {
                    MessageBox.Show("Empleado registrado correctamente");
                    DialogResult dialog2 = MessageBox.Show("¿Registrar en otro departamento?", "Registrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialog2 == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        this.Close();
                    }
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
