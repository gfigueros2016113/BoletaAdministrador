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
    public partial class CrearSuspensionIGSS : Form
    {
        public string id;
        public string nombre;
        public string puesto;
        public string dias;
        public string empresa;
        public string permiso;
        public double contador;
        public string departamentoPrincipal;
        ConsultasSQL sql = new ConsultasSQL();
        public string obs;
        public string fechaI;
        public string fechaF;
        public int totalD;
        public string nivel;
        public CrearSuspensionIGSS()
        {
            InitializeComponent();
        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void Fa1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void CrearSuspensionIGSS_Load(object sender, EventArgs e)
        {
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            sql.ObtenerNivel(id, departamentoPrincipal);
            nivel = sql.nivel;
            Fa2.Enabled = true;
        }

        private void Fa2_ValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void p1_Leave(object sender, EventArgs e)
        {
            if(Fa2.Value >= Fa1.Value)
            {
                totalD = (int)(Fa2.Value - Fa1.Value).TotalDays;
                label56.Text = totalD.ToString();
            }
            else
            {
                MessageBox.Show("Rango de fechas invalido...");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea enviar la solicitud?", "Enviar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                fechaI = Fa1.Value.ToShortDateString();
                fechaF = Fa2.Value.ToShortDateString();
                obs = textBox1.Text;
                if (sql.CrearSuspensionIgss(obs, fechaI, fechaF, id, departamentoPrincipal, label56.Text, Int32.Parse(nivel)))
                {
                    MessageBox.Show("Solicitud Enviada Correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                }
            }
            else
            {
                MessageBox.Show("La solicitud ha sido Cancelada", "Solicitud Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void CrearSuspensionIGSS_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void label57_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void label56_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }
    }
}
