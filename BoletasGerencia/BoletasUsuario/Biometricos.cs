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

        private void horario_btn_Click(object sender, EventArgs e)
        {
            ReporteHorario reporteHorario = new ReporteHorario();
            reporteHorario.Show();
        }

        private void tarde_btn_Click(object sender, EventArgs e)
        {
            ReporteEntradaTarde reporteEntradaTarde = new ReporteEntradaTarde();
            reporteEntradaTarde.Show();
        }

        private void previa_btn_Click(object sender, EventArgs e)
        {
            ReporteSalidaPrevia reporteSalidaPrevia = new ReporteSalidaPrevia();
            reporteSalidaPrevia.Show();
        }
    }
}
