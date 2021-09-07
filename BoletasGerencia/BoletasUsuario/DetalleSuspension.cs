using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoletasUsuario
{
    public partial class DetalleSuspension : Form
    {
        public DetalleSuspension()
        {
            InitializeComponent();
        }
        SuspensionSql Rsql = new SuspensionSql();
        ConsultasSQL Csql = new ConsultasSQL();
        public double contadorRep;
        public string id;
        public string nivel;
        public string nombre;
        public string puesto;
        public string empresa;
        public string permiso;
        public string diasSolicitados;
        public string departamentoPrincipal;
        public string idBoleta;
        public string correlativo;
        public string observaciones1;
        public string observaciones2;
        public string observaciones3;
        public string observaciones4;
        public string fechaSolicitud;
        public int opcion;
        public string obs;
        private void DetalleSuspension_Load(object sender, EventArgs e)
        {
            Rsql.ObtenerSuspension(idBoleta);
            observaciones1 = Rsql.observaciones1;
            observaciones2 = Rsql.observaciones2;
            observaciones3 = Rsql.observaciones3;
            observaciones4 = Rsql.observaciones4;
            if (observaciones1 == "")
            {
                button1.Visible = false;
            }
            if (observaciones2 == "")
            {
                button2.Visible = false;
            }
            if (observaciones3 == "")
            {
                button3.Visible = false;
            }
            if (observaciones4 == "")
            {
                button4.Visible = false;
            }
            Fa1.Value = Convert.ToDateTime(Rsql.fechaInicio);
            Fa2.Value = Convert.ToDateTime(Rsql.fechaFinal);
            label56.Text = Rsql.totalD;
            label17.Text = Rsql.fechaSolicitud;


            Csql.BuscarUsuario(Rsql.idSolicitante);
            nombre = Csql.nombre;
            puesto = Csql.puesto;
            empresa = Csql.empresa;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            this.Size = new Size(835, 396);

            if (opcion == 1)
            {
                this.Size = new Size(835, 498);
                panel14.Visible = true;
                button7.Visible = true;
                button5.Visible = true;
            }

            nivel = "1";
            if (Rsql.idEstado == "1" || Rsql.idEstado == "2" || Rsql.idEstado == "3" || Rsql.idEstado == "8")
            {
                this.Size = new Size(835, 498);
                panel14.Visible = true;
                button7.Visible = true;
                button5.Visible = true;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(observaciones1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(observaciones2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(observaciones3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(observaciones4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            if (checkBox1.Checked == false)
            {
                DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea autorizar la solicitud?", "Autorizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    obs = textBox1.Text;
                    if (Csql.AutorizarSuspencionIGSS(obs, id, idBoleta, Int32.Parse(nivel)))
                    {
                        MessageBox.Show("Solicitud Autorizada Correctamente.");
                        AutorizarBoletas menu = new AutorizarBoletas();
                        menu.nombre = nombre;
                        menu.id = id;
                        menu.departamentoPrincipal = departamentoPrincipal;
                        menu.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                    }
                }
                else
                {
                    MessageBox.Show("La Autorización ha sido Cancelada", "Solicitud Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea autorizar y enviar a Gerencia General la solicitud?", "Autorizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    obs = textBox1.Text;
                    if (Csql.enviaraGGSuspencionIGSS(obs, id, idBoleta))
                    {
                        MessageBox.Show("Solicitud Autorizada Correctamente.");
                        AutorizarBoletas menu = new AutorizarBoletas();
                        menu.nombre = nombre;
                        menu.id = id;
                        menu.departamentoPrincipal = departamentoPrincipal;
                        menu.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                    }
                }
                else
                {
                    MessageBox.Show("La Autorización ha sido Cancelada", "Solicitud Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea denegar la solicitud?", "Denegar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                obs = textBox1.Text;
                if (Csql.DenegarSuspencionIGSS(obs, id, idBoleta, Int32.Parse(nivel)))
                {
                    MessageBox.Show("Solicitud Denegada Correctamente.");
                    AutorizarBoletas menu = new AutorizarBoletas();
                    menu.nombre = nombre;
                    menu.id = id;
                    menu.departamentoPrincipal = departamentoPrincipal;
                    menu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al enviar la información a la base de datos. No cierre esta ventana y contacte a Harim Palma");
                }
            }
            else
            {
                MessageBox.Show("La Autorización ha sido Cancelada", "Solicitud Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
