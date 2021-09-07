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
    public partial class Pregunta : Form
    {
        public Pregunta()
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerBoletas menu = new VerBoletas();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.opcion = 1;
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerBoletas menu = new VerBoletas();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.opcion = 2;
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerBoletas menu = new VerBoletas();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.opcion = 4;
            menu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VerBoletas menu = new VerBoletas();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.opcion = 3;
            menu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CrearFalta menu = new CrearFalta();
            menu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VerBoletas menu = new VerBoletas();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.opcion = 6;
            menu.Show();
        }

        private void Pregunta_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            VerBoletas menu = new VerBoletas();
            menu.nombre = nombre;
            menu.id = id;
            menu.dias = dias;
            menu.puesto = puesto;
            menu.empresa = empresa;
            menu.departamentoPrincipal = departamentoPrincipal;
            menu.opcion = 5;
            menu.Show();
        }
    }
}
