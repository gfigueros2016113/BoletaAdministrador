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
    public partial class DetalleEspecial : Form
    {
        public DetalleEspecial()
        {
            InitializeComponent();
        }
        ConsultasSQL Csql = new ConsultasSQL();
        EspecialesSQL Rsql = new EspecialesSQL();
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
        private void DetalleEspecial_Load(object sender, EventArgs e)
        {
            llenarCB();
            Rsql.ObtenerEspecial(idBoleta);
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
            label54.Text = Rsql.totalH;
            label17.Text = Rsql.fechaSolicitud;

            Csql.BuscarUsuario(Rsql.idSolicitante);
            nombre = Csql.nombre;
            puesto = Csql.puesto;
            empresa = Csql.empresa;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            switch (Rsql.desc1A)
            {
                case "1":
                    Fa1.Value = Convert.ToDateTime(Rsql.fecha1);
                    Ta1.Checked = true;
                    horas1.Visible = false;
                    break;
                case "3":
                    Fa1.Value = Convert.ToDateTime(Rsql.fecha1);
                    Ta1.Checked = false;
                    horas1.Visible = true;
                    HIa1.SelectedValue = Rsql.horaI1;
                    HFa1.SelectedValue = Rsql.horaF1;
                    Pan1.Checked = false;
                    break;
                case "2":
                    Fa1.Value = Convert.ToDateTime(Rsql.fecha1);
                    Ta1.Checked = false;
                    horas1.Visible = true;
                    HIa1.SelectedValue = Rsql.horaI1;
                    HFa1.SelectedValue = Rsql.horaF1;
                    Pan1.Checked = true;
                    break;
                default:
                    p1.Visible = false;
                    break;
            }

            switch (Rsql.desc2A)
            {
                case "1":
                    Fa2.Value = Convert.ToDateTime(Rsql.fecha2);
                    Ta2.Checked = true;
                    horas2.Visible = false;
                    break;
                case "3":
                    Fa2.Value = Convert.ToDateTime(Rsql.fecha2);
                    Ta2.Checked = false;
                    horas2.Visible = true;
                    HIa2.SelectedValue = Rsql.horaI2;
                    HFa2.SelectedValue = Rsql.horaF2;
                    pan2.Checked = false;
                    break;
                case "2":
                    Fa2.Value = Convert.ToDateTime(Rsql.fecha2);
                    Ta2.Checked = false;
                    horas2.Visible = true;
                    HIa2.SelectedValue = Rsql.horaI2;
                    HFa2.SelectedValue = Rsql.horaF2;
                    pan2.Checked = true;
                    break;
                default:
                    p2.Visible = false;
                    break;
            }


            switch (Rsql.desc3A)
            {
                case "1":
                    Fa3.Value = Convert.ToDateTime(Rsql.fecha3);
                    Ta3.Checked = true;
                    horas3.Visible = false;
                    break;
                case "3":
                    Fa3.Value = Convert.ToDateTime(Rsql.fecha3);
                    Ta3.Checked = false;
                    horas3.Visible = true;
                    HIa3.SelectedValue = Rsql.horaI3;
                    HFa3.SelectedValue = Rsql.horaF3;
                    pan3.Checked = false;
                    break;
                case "2":
                    Fa3.Value = Convert.ToDateTime(Rsql.fecha3);
                    Ta3.Checked = false;
                    horas3.Visible = true;
                    HIa3.SelectedValue = Rsql.horaI3;
                    HFa3.SelectedValue = Rsql.horaF3;
                    pan3.Checked = true;
                    break;
                default:
                    p3.Visible = false;
                    break;
            }


            switch (Rsql.desc4A)
            {
                case "1":
                    Fa4.Value = Convert.ToDateTime(Rsql.fecha4);
                    Ta4.Checked = true;
                    horas4.Visible = false;
                    break;
                case "3":
                    Fa4.Value = Convert.ToDateTime(Rsql.fecha4);
                    Ta4.Checked = false;
                    horas4.Visible = true;
                    HIa4.SelectedValue = Rsql.horaI4;
                    HFa4.SelectedValue = Rsql.horaF4;
                    pan4.Checked = false;
                    break;
                case "2":
                    Fa4.Value = Convert.ToDateTime(Rsql.fecha4);
                    Ta4.Checked = false;
                    horas4.Visible = true;
                    HIa4.SelectedValue = Rsql.horaI4;
                    HFa4.SelectedValue = Rsql.horaF4;
                    pan4.Checked = true;
                    break;
                default:
                    p4.Visible = false;
                    break;
            }

            switch (Rsql.desc5A)
            {
                case "1":
                    Fa5.Value = Convert.ToDateTime(Rsql.fecha5);
                    Ta5.Checked = true;
                    horas5.Visible = false;
                    break;
                case "3":
                    Fa5.Value = Convert.ToDateTime(Rsql.fecha5);
                    Ta5.Checked = false;
                    horas5.Visible = true;
                    HIa5.SelectedValue = Rsql.horaI5;
                    HFa5.SelectedValue = Rsql.horaF5;
                    pan5.Checked = false;
                    break;
                case "2":
                    Fa5.Value = Convert.ToDateTime(Rsql.fecha5);
                    Ta5.Checked = false;
                    horas5.Visible = true;
                    HIa5.SelectedValue = Rsql.horaI5;
                    HFa5.SelectedValue = Rsql.horaF5;
                    pan5.Checked = true;
                    break;
                default:
                    p5.Visible = false;
                    break;
            }




            this.Size = new Size(1060, 432);

            //if (opcion == 1)
            //{
            //    this.Size = new Size(1060, 544);
            //    panel14.Visible = true;
            //    button7.Visible = true;
            //    button5.Visible = true;
            //}
            //nivel = "1";
            //if (Rsql.idEstado == "1" || Rsql.idEstado == "2" || Rsql.idEstado == "3" || Rsql.idEstado == "8")
            //{
            //    this.Size = new Size(1060, 544);
            //    panel14.Visible = true;
            //    button7.Visible = true;
            //    button5.Visible = true;
            //}
        }

        public void llenarCB()
        {
            HIa1.DataSource = Csql.MostrarHorarios();
            HIa1.DisplayMember = "nombre";
            HIa1.ValueMember = "valor";

            HFa1.DataSource = Csql.MostrarHorarios();
            HFa1.DisplayMember = "nombre";
            HFa1.ValueMember = "valor";

            HIa2.DataSource = Csql.MostrarHorarios();
            HIa2.DisplayMember = "nombre";
            HIa2.ValueMember = "valor";

            HFa2.DataSource = Csql.MostrarHorarios();
            HFa2.DisplayMember = "nombre";
            HFa2.ValueMember = "valor";

            HIa3.DataSource = Csql.MostrarHorarios();
            HIa3.DisplayMember = "nombre";
            HIa3.ValueMember = "valor";

            HFa3.DataSource = Csql.MostrarHorarios();
            HFa3.DisplayMember = "nombre";
            HFa3.ValueMember = "valor";

            HIa4.DataSource = Csql.MostrarHorarios();
            HIa4.DisplayMember = "nombre";
            HIa4.ValueMember = "valor";

            HFa4.DataSource = Csql.MostrarHorarios();
            HFa4.DisplayMember = "nombre";
            HFa4.ValueMember = "valor";

            HIa5.DataSource = Csql.MostrarHorarios();
            HIa5.DisplayMember = "nombre";
            HIa5.ValueMember = "valor";

            HFa5.DataSource = Csql.MostrarHorarios();
            HFa5.DisplayMember = "nombre";
            HFa5.ValueMember = "valor";
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
            if (checkBox1.Checked == false)
            {
                DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea autorizar la solicitud?", "Autorizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    obs = textBox1.Text;
                    if (Csql.AutorizarEspecial(obs, id, idBoleta, Int32.Parse(nivel)))
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
                    if (Csql.enviaraGGEspecial(obs, id, idBoleta))
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
                if (Csql.DenegarEspecial(obs, id, idBoleta, Int32.Parse(nivel)))
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
