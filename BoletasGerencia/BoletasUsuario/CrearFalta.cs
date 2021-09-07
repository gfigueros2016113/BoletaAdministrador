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
    public partial class CrearFalta : Form
    {
        public CrearFalta()
        {
            InitializeComponent();
        }

        public int contador;
        public string id;
        public string nivel;
        public string nombre;
        public string puesto;
        public string empresa;
        public string permiso;
        public string departamentoPrincipal;
        public string obs;
        public string fecha1 = "01/01/2000";
        public string fecha2 = "01/01/2000";
        public string fecha3 = "01/01/2000";
        public string fecha4 = "01/01/2000";
        public string fecha5 = "01/01/2000";
        public string fecha6 = "01/01/2000";
        public string fecha7 = "01/01/2000";
        public string fecha8 = "01/01/2000";
        public string fecha9 = "01/01/2000";
        public string fecha10 = "01/01/2000";
        public string tipo;
        public string totalDias;
        ConsultasSQL sql = new ConsultasSQL();
        private void CrearFalta_Load(object sender, EventArgs e)
        {
            sql.ObtenerNivel(id, departamentoPrincipal);
            nivel = sql.nivel;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            p8.Visible = false;
            p9.Visible = false;
            p10.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region asignacion de valores
            if(radioButton1.Checked == true)
            {
                tipo = "FALTA INJUSTIFICADA";
            }else if (radioButton2.Checked == true)
            {
                tipo = "SUSPENSIÓN";
            }

            obs = textBox1.Text;

            fecha1 = f1.Value.ToShortDateString();
            if(c2.Checked == true)
            {
                fecha2 = f2.Value.ToShortDateString();
            }
            if (c3.Checked == true)
            {
                fecha3 = f3.Value.ToShortDateString();
            }
            if (c4.Checked == true)
            {
                fecha4 = f4.Value.ToShortDateString();
            }
            if (c5.Checked == true)
            {
                fecha5 = f5.Value.ToShortDateString();
            }
            if (c6.Checked == true)
            {
                fecha6 = f6.Value.ToShortDateString();
            }
            if (c7.Checked == true)
            {
                fecha7 = f7.Value.ToShortDateString();
            }
            if (c8.Checked == true)
            {
                fecha8 = f8.Value.ToShortDateString();
            }
            if (c9.Checked == true)
            {
                fecha9 = f9.Value.ToShortDateString();
            }
            if (c10.Checked == true)
            {
                fecha10 = f10.Value.ToShortDateString();
            }
            totalDias = label9.Text;
            #endregion
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea enviar la solicitud?", "Enviar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (sql.CrearSansion(obs,fecha1,fecha2,fecha3,fecha4,fecha5,fecha6,fecha7,fecha8,fecha9,fecha10,totalDias,id,departamentoPrincipal,Int32.Parse(nivel),tipo))
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

        private void c2_CheckedChanged(object sender, EventArgs e)
        {
            if(c2.Checked == true)
            {
                p2.Visible = true;
            }
            else
            {
                p2.Visible = false;
            }
        }

        private void c3_CheckedChanged(object sender, EventArgs e)
        {
            if (c3.Checked == true)
            {
                p3.Visible = true;
            }
            else
            {
                p3.Visible = false;
            }
        }

        private void c4_CheckedChanged(object sender, EventArgs e)
        {
            if (c4.Checked == true)
            {
                p4.Visible = true;
            }
            else
            {
                p4.Visible = false;
            }
        }

        private void c5_CheckedChanged(object sender, EventArgs e)
        {
            if (c5.Checked == true)
            {
                p5.Visible = true;
            }
            else
            {
                p5.Visible = false;
            }
        }

        private void c6_CheckedChanged(object sender, EventArgs e)
        {
            if (c6.Checked == true)
            {
                p6.Visible = true;
            }
            else
            {
                p6.Visible = false;
            }
        }

        private void c7_CheckedChanged(object sender, EventArgs e)
        {
            if (c7.Checked == true)
            {
                p7.Visible = true;
            }
            else
            {
                p7.Visible = false;
            }
        }

        private void c8_CheckedChanged(object sender, EventArgs e)
        {
            if (c8.Checked == true)
            {
                p8.Visible = true;
            }
            else
            {
                p8.Visible = false;
            }
        }

        private void c9_CheckedChanged(object sender, EventArgs e)
        {
            if (c9.Checked == true)
            {
                p9.Visible = true;
            }
            else
            {
                p9.Visible = false;
            }
        }

        private void c10_CheckedChanged(object sender, EventArgs e)
        {
            if (c10.Checked == true)
            {
                p10.Visible = true;
            }
            else
            {
                p10.Visible = false;
            }
        }

        private void panel3_Leave(object sender, EventArgs e)
        {
            contador = 1;
            if (c2.Checked == true)
            {
                contador = contador + 1; 
            }
            if (c3.Checked == true)
            {
                contador = contador + 1;
            }
            if (c4.Checked == true)
            {
                contador = contador + 1;
            }
            if (c5.Checked == true)
            {
                contador = contador + 1;
            }
            if (c6.Checked == true)
            {
                contador = contador + 1;
            }
            if (c7.Checked == true)
            {
                contador = contador + 1;
            }
            if (c8.Checked == true)
            {
                contador = contador + 1;
            }
            if (c9.Checked == true)
            {
                contador = contador + 1;
            }
            if (c10.Checked == true)
            {
                contador = contador + 1;
            }
            label9.Text = contador.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
