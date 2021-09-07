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
    public partial class Marcas : Form
    {
        #region Constructor
        public Marcas()
        {
            InitializeComponent();
        }
        #endregion
        #region Variables
        ConsultasSQL sql = new ConsultasSQL();
        #endregion
        #region Load
        private void Marcas_Load(object sender, EventArgs e)
        {
            marcas_dgv.DataSource = sql.ObtenerMarcas();
        }
        #endregion
    }
}
