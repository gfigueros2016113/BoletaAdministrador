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
    public partial class Login : Form
    {
        ConsultasSQL SQL = new ConsultasSQL();

        public Login()
        {
            InitializeComponent();
            ToolTip tt = new ToolTip();
            tt.SetToolTip(label5, "Créditos");
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public string nombre;
        public string puesto;
        public string dias;
        public string contador;
        public string inicioLabores;
        public string permiso;
        public string empresa;
        public string departamentoPrincipal;
        private void button1_Click(object sender, EventArgs e)
        {
            if (SQL.Ingresar(textBox1.Text, textBox2.Text))
            {
                Interfaz menu = new Interfaz();
                SQL.ObtenerUsuario(textBox1.Text, textBox2.Text);
                menu.nombre = SQL.nombre;
                menu.id = SQL.id;
                menu.dias = SQL.dias;
                menu.puesto = SQL.puesto;
                menu.inicioLabores = SQL.inicioLabores;
                menu.permiso = SQL.permiso;
                menu.empresa = SQL.empresa;
                menu.departamentoPrincipal = SQL.departamentoPrincipal;
                menu.Show();
                this.Owner = menu;
                this.Hide();
            }
            else
            {
                MessageBox.Show("El usuario y/o contraseña son incorrectos", "LOGIN INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
