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
    public partial class VerHorario : Form
    {
        public VerHorario()
        {
            InitializeComponent();
        }

        public string valorHorario;
        ConsultasSQL SQL = new ConsultasSQL();
        
        private void VerHorario_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SQL.MostrarDias(valorHorario);
        }
    }
}
