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
    public partial class DetalleSancion : Form
    {
        public DetalleSancion()
        {
            InitializeComponent();
        }
        SancionSql Rsql = new SancionSql();
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
        public int opcion;
        public string obs;
        private void DetalleSancion_Load(object sender, EventArgs e)
        {
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            Rsql.ObtenerSancion(idBoleta);
            correlativo = Rsql.correlativo;
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

            //  Fa1.Value = DateTime.Parse(Rsql.fechaInicio, new CultureInfo("ES-ES", true));
            //Fa2.Value = DateTime.Parse(Rsql.fechaFinal, new CultureInfo("ES-ES", true));
            label9.Text = Rsql.totalD;
            label17.Text = Rsql.fechaSolicitud;
            label11.Text = Rsql.tipo;
            if (Rsql.fecha1 != "1/01/2000 00:00:00")
            {
                f1.Value = Convert.ToDateTime(Rsql.fecha1);
            }
            else
            {
                p1.Visible = false;
            }
            if (Rsql.fecha2 != "1/01/2000 00:00:00")
            {
                f2.Value = Convert.ToDateTime(Rsql.fecha2);
            }
            else
            {
                p2.Visible = false;
            }
            if (Rsql.fecha3 != "1/01/2000 00:00:00")
            {
                f3.Value = Convert.ToDateTime(Rsql.fecha3);
            }
            else
            {
                p3.Visible = false;
            }
            if (Rsql.fecha4 != "1/01/2000 00:00:00")
            {
                f4.Value = Convert.ToDateTime(Rsql.fecha4);
            }
            else
            {
                p4.Visible = false;
            }
            if (Rsql.fecha5 != "1/01/2000 00:00:00")
            {
                f5.Value = Convert.ToDateTime(Rsql.fecha5);
            }
            else
            {
                p5.Visible = false;
            }
            if (Rsql.fecha6 != "1/01/2000 00:00:00")
            {
                f6.Value = Convert.ToDateTime(Rsql.fecha6);
            }
            else
            {
                p6.Visible = false;
            }
            if (Rsql.fecha7 != "1/01/2000 00:00:00")
            {
                f7.Value = Convert.ToDateTime(Rsql.fecha7);
            }
            else
            {
                p7.Visible = false;
            }
            if (Rsql.fecha8 != "1/01/2000 00:00:00")
            {
                f8.Value = Convert.ToDateTime(Rsql.fecha8);
            }
            else
            {
                p8.Visible = false;
            }
            if (Rsql.fecha9 != "1/01/2000 00:00:00")
            {
                f9.Value = Convert.ToDateTime(Rsql.fecha9);
            }
            else
            {
                p9.Visible = false;
            }
            if (Rsql.fecha10 != "1/01/2000 00:00:00")
            {
                f10.Value = Convert.ToDateTime(Rsql.fecha10);
            }
            else
            {
                p10.Visible = false;
            }

            Csql.BuscarUsuario(Rsql.idSolicitante);
            nombre = Csql.nombre;
            puesto = Csql.puesto;
            empresa = Csql.empresa;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            this.Size = new Size(810, 462);
            //if (opcion == 1)
            //{
            //    this.Size = new Size(810, 577);
            //    panel4.Visible = true;
            //    button6.Visible = true;
            //    button8.Visible = true;
            //}
            //nivel = "1";
            //if (Rsql.idEstado == "1" || Rsql.idEstado == "2" || Rsql.idEstado == "3" || Rsql.idEstado == "8")
            //{
            //    this.Size = new Size(810, 577);
            //    panel4.Visible = true;
            //    button6.Visible = true;
            //    button8.Visible = true;
            //}
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

        private void button8_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            if (checkBox1.Checked == false)
            {
                DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea autorizar la solicitud?", "Autorizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    obs = textBox2.Text;
                    if (Csql.AutorizarSansion(obs, id, idBoleta, Int32.Parse(nivel)))
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
                    obs = textBox2.Text;
                    if (Csql.enviaraGGSansion(obs, id, idBoleta))
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

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea denegar la solicitud?", "Denegar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                obs = textBox2.Text;
                if (Csql.DenegarSansion(obs, id, idBoleta, Int32.Parse(nivel)))
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
