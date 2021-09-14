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
    public partial class Biometricos : Form
    {
        public Biometricos()
        {
            InitializeComponent();
        }
        private void marcas_btn_Click(object sender, EventArgs e)
        {
            Marcas marcas = new Marcas();
            marcas.Show();
        }

        private void Biometricos_Load(object sender, EventArgs e)
        {

        }



        private void ausencia_Click(object sender, EventArgs e)
        {
            ausencia aus = new ausencia();
            aus.Show();
        }

        private void jIncompleta_Click(object sender, EventArgs e)
        {
            jIncompleta j = new jIncompleta();
            j.Show();
        }

        private void precencia_Click(object sender, EventArgs e)
        {
            presencia pres = new presencia();
            pres.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReportePresencia rpre = new ReportePresencia();
            rpre.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReporteAusencia rep = new ReporteAusencia();
            rep.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReporteJornadaIncompleta rep = new ReporteJornadaIncompleta();
            rep.Show();
            this.Hide();
        }
    }
}
