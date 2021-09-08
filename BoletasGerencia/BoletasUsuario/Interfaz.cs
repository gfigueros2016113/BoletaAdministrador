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
    public partial class Interfaz : Form
    {
        public Interfaz()
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
        public string inicioLabores;      
        
        

        private void button3_Click(object sender, EventArgs e)
        {
            Pregunta menu = new Pregunta();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.permiso = permiso;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerEmpleados menu = new VerEmpleados();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            perfil menu = new perfil();
            menu.nombre = nombre;
          //  menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.inicioLabores = inicioLabores;
            menu.permiso = permiso;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.Show();
        }

        private void Interfaz_Load(object sender, EventArgs e)
        {
            label2.Text = nombre;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AutorizarBoletas menu = new AutorizarBoletas();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            //menu.inicioLabores = inicioLabores;
            menu.permiso = permiso;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Biometricos biometricos = new Biometricos();
            biometricos.Show();
        }
    }
}
