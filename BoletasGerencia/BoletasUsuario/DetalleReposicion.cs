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
    public partial class DetalleReposicion : Form
    {
        public DetalleReposicion()
        {
            InitializeComponent();
        }
        ConsultasSQL sql = new ConsultasSQL();
        public string idBoleta;
        public string correlativo;
        public string observaciones1;
        public string observaciones2;
        public string observaciones3;
        public string observaciones4;
        public string fechaSolicitud;
        public string obs;
      
        public string Estado;
        public string id;
        public string nivel;
        public string nombre;
        public string puesto;
        public string dias;
        public string empresa;
        public string permiso;
        public string diasSolicitados;
        public string departamentoPrincipal;
        public int opcion;

        ReposicionesSQL Rsql = new ReposicionesSQL();
        private void DetalleReposicion_Load(object sender, EventArgs e)
        {
            llenarCB();
            Rsql.ObtenerReposicion(idBoleta);
            correlativo = Rsql.correlativo;
            observaciones1 = Rsql.observaciones1;
            observaciones2 = Rsql.observaciones2;
            observaciones3 = Rsql.observaciones3;
            observaciones4 = Rsql.observaciones4;
            if (observaciones1 == "")
            {
                button5.Visible = false;
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
            sql.BuscarUsuario(Rsql.idSolicitante);
            nombre = sql.nombre;
            puesto = sql.puesto;
            empresa = sql.empresa;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            #region Validaciones y asiganaciones de valor en ausencias
            label16.Text = Rsql.fechaSolicitud;
            label54.Text = Rsql.totalH;
            label56.Text = Rsql.totalHR;

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

            switch (Rsql.desc1R)
            {
                case "1":
                    Fa6.Value = Convert.ToDateTime(Rsql.fecha1R);
                    Ta6.Checked = true;
                    horas6.Visible = false;
                    break;
                case "3":
                    Fa6.Value = Convert.ToDateTime(Rsql.fecha1R);
                    Ta6.Checked = false;
                    horas6.Visible = true;
                    HIa6.SelectedValue = Rsql.horaI1R;
                    HFa6.SelectedValue = Rsql.horaF1R;
                    break;
                case "2":
                    Fa6.Value = Convert.ToDateTime(Rsql.fecha1R);
                    Ta6.Checked = false;
                    horas6.Visible = true;
                    HIa6.SelectedValue = Rsql.horaI1R;
                    HFa6.SelectedValue = Rsql.horaF1R;
                    break;
                default:
                    p6.Visible = false;
                    break;
            }

            switch (Rsql.desc2R)
            {
                case "1":
                    Fa7.Value = Convert.ToDateTime(Rsql.fecha2R);
                    Ta7.Checked = true;
                    horas7.Visible = false;
                    break;
                case "3":
                    Fa7.Value = Convert.ToDateTime(Rsql.fecha2R);
                    Ta7.Checked = false;
                    horas7.Visible = true;
                    HIa7.SelectedValue = Rsql.horaI2R;
                    HFa7.SelectedValue = Rsql.horaF2R;
                    break;
                case "2":
                    Fa7.Value = Convert.ToDateTime(Rsql.fecha2R);
                    Ta7.Checked = false;
                    horas7.Visible = true;
                    HIa7.SelectedValue = Rsql.horaI2R;
                    HFa7.SelectedValue = Rsql.horaF2R;
                    break;
                default:
                    p7.Visible = false;
                    break;
            }

            switch (Rsql.desc3R)
            {
                case "1":
                    Fa8.Value = Convert.ToDateTime(Rsql.fecha3R);
                    Ta8.Checked = true;
                    horas8.Visible = false;
                    break;
                case "3":
                    Fa8.Value = Convert.ToDateTime(Rsql.fecha3R);
                    Ta8.Checked = false;
                    horas8.Visible = true;
                    HIa8.SelectedValue = Rsql.horaI3R;
                    HFa8.SelectedValue = Rsql.horaF3R;
                    break;
                case "2":
                    Fa8.Value = Convert.ToDateTime(Rsql.fecha3R);
                    Ta8.Checked = false;
                    horas8.Visible = true;
                    HIa8.SelectedValue = Rsql.horaI3R;
                    HFa8.SelectedValue = Rsql.horaF3R;
                    break;
                default:
                    p8.Visible = false;
                    break;
            }

            switch (Rsql.desc4R)
            {
                case "1":
                    Fa9.Value = Convert.ToDateTime(Rsql.fecha4R);
                    Ta9.Checked = true;
                    horas9.Visible = false;
                    break;
                case "3":
                    Fa9.Value = Convert.ToDateTime(Rsql.fecha4R);
                    Ta9.Checked = false;
                    horas9.Visible = true;
                    HIa9.SelectedValue = Rsql.horaI4R;
                    HFa9.SelectedValue = Rsql.horaF4R;
                    break;
                case "2":
                    Fa9.Value = Convert.ToDateTime(Rsql.fecha4R);
                    Ta9.Checked = false;
                    horas9.Visible = true;
                    HIa9.SelectedValue = Rsql.horaI4R;
                    HFa9.SelectedValue = Rsql.horaF4R;
                    break;
                default:
                    p9.Visible = false;
                    break;
            }

            switch (Rsql.desc5R)
            {
                case "1":
                    Fa10.Value = Convert.ToDateTime(Rsql.fecha5R);
                    Ta10.Checked = true;
                    horas10.Visible = false;
                    break;
                case "3":
                    Fa10.Value = Convert.ToDateTime(Rsql.fecha5R);
                    Ta10.Checked = false;
                    horas10.Visible = true;
                    HIa10.SelectedValue = Rsql.horaI5R;
                    HFa10.SelectedValue = Rsql.horaF5R;
                    break;
                case "2":
                    Fa10.Value = Convert.ToDateTime(Rsql.fecha5R);
                    Ta10.Checked = false;
                    horas10.Visible = true;
                    HIa10.SelectedValue = Rsql.horaI5R;
                    HFa10.SelectedValue = Rsql.horaF5R;
                    break;
                default:
                    p10.Visible = false;
                    break;
            }
            #endregion
            this.Size = new Size(1260, 511);

            //if (opcion == 1)
            //{
            //    this.Size = new Size(1260, 616);
            //    panel4.Visible = true;
            //    button7.Visible = true;
            //    button1.Visible = true;
            //    checkBox1.Visible = false;
            //}
            //nivel = "1";
            //if (Rsql.idEstado == "1" || Rsql.idEstado == "2" || Rsql.idEstado == "3" || Rsql.idEstado == "8")
            //{
            //    this.Size = new Size(1260, 616);
            //    panel4.Visible = true;
            //    button7.Visible = true;
            //    button1.Visible = true;
            //    checkBox1.Visible = false;
            //}
        }
        public void llenarCB()
        {
            HIa1.DataSource = sql.MostrarHorarios();
            HIa1.DisplayMember = "nombre";
            HIa1.ValueMember = "valor";

            HFa1.DataSource = sql.MostrarHorarios();
            HFa1.DisplayMember = "nombre";
            HFa1.ValueMember = "valor";

            HIa2.DataSource = sql.MostrarHorarios();
            HIa2.DisplayMember = "nombre";
            HIa2.ValueMember = "valor";

            HFa2.DataSource = sql.MostrarHorarios();
            HFa2.DisplayMember = "nombre";
            HFa2.ValueMember = "valor";

            HIa3.DataSource = sql.MostrarHorarios();
            HIa3.DisplayMember = "nombre";
            HIa3.ValueMember = "valor";

            HFa3.DataSource = sql.MostrarHorarios();
            HFa3.DisplayMember = "nombre";
            HFa3.ValueMember = "valor";

            HIa4.DataSource = sql.MostrarHorarios();
            HIa4.DisplayMember = "nombre";
            HIa4.ValueMember = "valor";

            HFa4.DataSource = sql.MostrarHorarios();
            HFa4.DisplayMember = "nombre";
            HFa4.ValueMember = "valor";

            HIa5.DataSource = sql.MostrarHorarios();
            HIa5.DisplayMember = "nombre";
            HIa5.ValueMember = "valor";

            HFa5.DataSource = sql.MostrarHorarios();
            HFa5.DisplayMember = "nombre";
            HFa5.ValueMember = "valor";

            HIa6.DataSource = sql.MostrarHorarios();
            HIa6.DisplayMember = "nombre";
            HIa6.ValueMember = "valor";

            HFa6.DataSource = sql.MostrarHorarios();
            HFa6.DisplayMember = "nombre";
            HFa6.ValueMember = "valor";

            HIa7.DataSource = sql.MostrarHorarios();
            HIa7.DisplayMember = "nombre";
            HIa7.ValueMember = "valor";

            HFa7.DataSource = sql.MostrarHorarios();
            HFa7.DisplayMember = "nombre";
            HFa7.ValueMember = "valor";

            HIa8.DataSource = sql.MostrarHorarios();
            HIa8.DisplayMember = "nombre";
            HIa8.ValueMember = "valor";

            HFa8.DataSource = sql.MostrarHorarios();
            HFa8.DisplayMember = "nombre";
            HFa8.ValueMember = "valor";

            HIa9.DataSource = sql.MostrarHorarios();
            HIa9.DisplayMember = "nombre";
            HIa9.ValueMember = "valor";

            HFa9.DataSource = sql.MostrarHorarios();
            HFa9.DisplayMember = "nombre";
            HFa9.ValueMember = "valor";

            HIa10.DataSource = sql.MostrarHorarios();
            HIa10.DisplayMember = "nombre";
            HIa10.ValueMember = "valor";

            HFa10.DataSource = sql.MostrarHorarios();
            HFa10.DisplayMember = "nombre";
            HFa10.ValueMember = "valor";
        }
      

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
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
                    if (sql.AutorizarReposicion(obs, id, idBoleta, Int32.Parse(nivel)))
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
                    if (sql.enviaraGGReposicion(obs, id, idBoleta))
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea denegar la solicitud?", "Denegar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                obs = textBox1.Text;
                if (sql.DenegarReposicion(obs, id, idBoleta, Int32.Parse(nivel)))
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
