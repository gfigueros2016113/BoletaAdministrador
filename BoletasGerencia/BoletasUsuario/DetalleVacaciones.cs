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
    public partial class DetalleVacaciones : Form
    {
        public DetalleVacaciones()
        {
            InitializeComponent();
        }
        VacacionesSQL sql = new VacacionesSQL();
        public string idBoleta;
        public string correlativo;
        public string obs1;
        public string obs2;
        public string obs3;
        public string obs4;
        public string fechaSolicitud;
        public string obs;
        public string fecha1;
        public string fecha2;
        public string fecha3;
        public string fecha4;
        public string fecha5;
        public string fecha6;
        public string fecha7;
        public string fecha8;
        public string fecha9;
        public string fecha10;
        public string desc1;
        public string desc2;
        public string desc3;
        public string desc4;
        public string desc5;
        public string desc6;
        public string desc7;
        public string desc8;
        public string desc9;
        public string desc10;
        public string totalD;
        public string creador;
        public string departamento;
        public string jefe;
        public string gerente;
        public string RH;
        public string estado;


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
        ConsultasSQL Csql = new ConsultasSQL();
        private void DetalleVacaciones_Load(object sender, EventArgs e)
        {
            sql.ObtenerVacaciones(idBoleta);
            correlativo = sql.correlativo;
            obs1 = sql.obs1;           
            obs2 = sql.obs2;
            obs3 = sql.obs3;
            obs4 = sql.obs4;
            if(obs1 == "")
            {
                button1.Visible = false;
            }
            if (obs2 == "")
            {
                button2.Visible = false;
            }
            if (obs3 == "")
            {
                button3.Visible = false;
            }
            if (obs4 == "")
            {
                button4.Visible = false;
            }
            label24.Text = sql.fechaSolicitud;
            #region Validaciones y asiganaciones de valor en ausencias
            if (sql.desc1 != "")
            {
                f1.Value = Convert.ToDateTime(sql.fecha1);
                d1.Text = sql.desc1;
            }
            else
            {
                panel5.Visible = false;
            }

            if (sql.desc2 != "")
            {
                f2.Value = Convert.ToDateTime(sql.fecha2);
                d2.Text = sql.desc2;
            }
            else
            {
                panel4.Visible = false;
            }

            if (sql.desc3 != "")
            {
                f3.Value = Convert.ToDateTime(sql.fecha3);
                d3.Text = sql.desc3;
            }
            else
            {
                panel6.Visible = false;
            }

            if (sql.desc4 != "")
            {
                f4.Value = Convert.ToDateTime(sql.fecha4);
                d4.Text = sql.desc4;
            }
            else
            {
                panel7.Visible = false;
            }

            if (sql.desc5 != "")
            {
                f5.Value = Convert.ToDateTime(sql.fecha5);
                d5.Text = sql.desc5;
            }
            else
            {
                panel8.Visible = false;
            }

            if (sql.desc6 != "")
            {
                f6.Value = Convert.ToDateTime(sql.fecha6);
                d6.Text = sql.desc6;
            }
            else
            {
                panel9.Visible = false;
            }

            if (sql.desc7 != "")
            {
                f7.Value = Convert.ToDateTime(sql.fecha7);
                d7.Text = sql.desc7;
            }
            else
            {
                panel13.Visible = false;
            }

            if (sql.desc8 != "")
            {
                f8.Value = Convert.ToDateTime(sql.fecha8);
                d8.Text = sql.desc8;
            }
            else
            {
                panel12.Visible = false;
            }

            if (sql.desc9 != "")
            {
                f9.Value = Convert.ToDateTime(sql.fecha9);
                d9.Text = sql.desc9;
            }
            else
            {
                panel11.Visible = false;
            }
            if (sql.desc10 != "")
            {
                f10.Value = Convert.ToDateTime(sql.fecha10);
                d10.Text = sql.desc9;
            }
            else
            {
                panel10.Visible = false;
            }

            #endregion
            label9.Text = sql.totalD;

            Csql.BuscarUsuario(sql.idSolicitante);
            nombre = Csql.nombre;
            puesto = Csql.puesto;
            empresa = Csql.empresa;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            this.Size = new Size(1038, 419);

            if (opcion == 1)
            {
                this.Size = new Size(1038, 545);
                panel14.Visible = true;
                button7.Visible = true;
                button5.Visible = true;
            }

            nivel = "1";
            if (sql.idEstado == "1" || sql.idEstado == "2" || sql.idEstado == "3" || sql.idEstado == "8")
            {
                this.Size = new Size(1038, 545);
                panel14.Visible = true;
                button7.Visible = true;
                button5.Visible = true;

            }
            if (sql.idEstado == "4" || sql.idEstado == "9")
            {
                Size = new Size(1038, 545);
                groupBox1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obs1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obs2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obs3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(obs4);
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
                    if (Csql.AutorizarVacaciones(obs, id, idBoleta, Int32.Parse(nivel)))
                    {
                        Csql.RestarVacaciones(sql.totalD, sql.idSolicitante);
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
                    if (Csql.enviaraGGVacaciones(obs, id, idBoleta))
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
                if (Csql.DenegarVacaciones(obs, id, idBoleta, Int32.Parse(nivel)))
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

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta boleta ya fue autorizada, aún así desea anularla?, esto devolverá los días descontados al usuario.", "Anular Boleta Autorizada", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string dias = sql.totalD;
                string idUsuario = sql.idSolicitante;
                try
                {
                    sql.sumarDias(dias, idUsuario);
                    sql.anularBoleta(idBoleta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            MessageBox.Show("Boleta anulada exitosamente", "Boleta Anulada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
