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
    public partial class Carga : Form
    {
        public Carga()
        {
            InitializeComponent();
        }
        int timeLeft;
        public string id;
        public string nivel;
        public string nombre;
        public string puesto;
        public string empresa;
        public string permiso;
        public string diasSolicitados;
        public string departamentoPrincipal;
        CrearReposicion Crep = new CrearReposicion();
        CrearEspecial Cesp = new CrearEspecial();
        public int opcion;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                progressBar1.Value = progressBar1.Value + 10;
            }
            else
            {
                timer1.Stop();
                if (opcion == 1)
                {
                    Crep.Show();
                }
                else if (opcion == 2)
                {
                    Cesp.Show();
                }
                this.Close();
            }
        }

        private void Carga_Load(object sender, EventArgs e)
        {
            timeLeft = 10;
            timer1.Start();
            if (opcion == 1)
            {
                Crep.nombre = nombre;
                Crep.id = id;
                Crep.puesto = puesto;
                Crep.empresa = empresa;
                Crep.departamentoPrincipal = departamentoPrincipal;
            }
            else if (opcion == 2)
            {
                Cesp.nombre = nombre;
                Cesp.id = id;
                Cesp.puesto = puesto;
                Cesp.empresa = empresa;
                Cesp.departamentoPrincipal = departamentoPrincipal;
            }
        }
    }
}
