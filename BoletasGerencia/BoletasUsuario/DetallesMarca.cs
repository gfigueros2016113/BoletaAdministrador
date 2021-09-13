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
    public partial class DetallesMarca : Form
    {
        #region Variables
        public string nombre_usuario;
        public string depto;
        public string hora;
        public string fecha;
        public string tipo;
        public string idUsuario;
        public DateTime horaSinFormato;
        ConsultasSQL sql = new ConsultasSQL();
        #endregion
        #region Constructor
        public DetallesMarca()
        {
            InitializeComponent();
        }
        #endregion
        #region Load
        private void DetallesMarca_Load(object sender, EventArgs e)
        {
            nombre_var_lbl.Text = nombre_usuario;
            depto_var_lbl.Text = depto;
            hora_var_lbl.Text = hora;
            fecha_var_lbl.Text = fecha;
            tipo_var_lbl.Text = tipo;
            string horaFormateada = horaSinFormato.ToString("yyyy-MM-dd HH:mm:ss");
            foto_dgv.DataSource = sql.ObtenerFotoMarca(idUsuario, horaFormateada);
        }
        #endregion
    }
}