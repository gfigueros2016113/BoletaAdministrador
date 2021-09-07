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
    public partial class AutorizarBoletas : Form
    {
        public AutorizarBoletas()
        {
            InitializeComponent();
        }
        public string id;
        public string nombre;
        public string puesto;
        public string dias;
        public string empresa;
        public string permiso;
        public string contador;
        public string departamentoPrincipal;
        public string inicioLabores;
        public string nivel;
        public int opcion;
        ConsultasSQL sql = new ConsultasSQL();
        public string dep = "4";

        private void AutorizarBoletas_Load(object sender, EventArgs e)
        {

            DataGridViewCheckBoxColumn CheckBoxColumn = new DataGridViewCheckBoxColumn();
            CheckBoxColumn.HeaderText = "✓";
            dataGridView1.Columns.Add(CheckBoxColumn);
            label1.Text = sql.MostrarPendientesVacaciones("4", "1").Rows.Count.ToString();
            label2.Text = sql.MostrarPendientesReposiciones("4", "1").Rows.Count.ToString();
            label3.Text = sql.MostrarPendientesEspeciales("4", "1").Rows.Count.ToString();
            label5.Text = sql.MostrarPendientesConsultasIGGS("4", "1").Rows.Count.ToString();
            label6.Text = sql.MostrarPendientesSuspencionesIGGS("4", "1").Rows.Count.ToString();
            label7.Text = sql.MostrarPendientesSanciones("4", "1").Rows.Count.ToString();


            /* if(opcion == 1)
             {
                 button2_Click(sender, e);
             }
             else if (opcion == 2)
             {
                 button1_Click(sender, e);
             }
             else if (opcion == 3)
             {
                 button2_Click(sender, e);
             }
             else if (opcion == 4)
             {
                 button2_Click(sender, e);
             }
             else if (opcion == 5)
             {
                 button2_Click(sender, e);
             }
             else if (opcion == 6)
             {
                 button2_Click(sender, e);
             }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "Vacaciones";
            dataGridView1.DataSource = sql.MostrarPendientesVacaciones("4", "1");
            
            opcion = 1;
            button2.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "Reposiciones";         
            dataGridView1.DataSource = sql.MostrarPendientesReposiciones("4", "1");
            opcion = 2;
            button1.BackColor = System.Drawing.Color.MidnightBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "Falta Justificada";
            opcion = 3;
            dataGridView1.DataSource = sql.MostrarPendientesEspeciales("4", "1");
            int test = sql.MostrarPendientesEspeciales("4", "1").Rows.Count;
          //  MessageBox.Show(test.ToString());
            button4.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Text = "Consultas al IGGS";
            opcion = 4;
            dataGridView1.DataSource = sql.MostrarPendientesConsultasIGGS("4", "1");
            button5.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = "Suspensiones IGGS";
            opcion = 5;
            dataGridView1.DataSource = sql.MostrarPendientesSuspencionesIGGS("4", "1");
            button3.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
            button6.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label4.Text = "Sanciones";
            dataGridView1.DataSource = sql.MostrarPendientesSanciones("4", "1");
            //dataGridView1.DataSource = sql.MostrarPendientesSuspencionesIGGS("4", "1");
            opcion = 6;
            button6.BackColor = System.Drawing.Color.MidnightBlue;
            button1.BackColor = System.Drawing.Color.RoyalBlue;
            button4.BackColor = System.Drawing.Color.RoyalBlue;
            button5.BackColor = System.Drawing.Color.RoyalBlue;
            button3.BackColor = System.Drawing.Color.RoyalBlue;
            button2.BackColor = System.Drawing.Color.RoyalBlue;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            string idBoleta = Convert.ToString(fila.Cells[1].Value);

            if (opcion == 1)
            {
                DetalleVacaciones menu = new DetalleVacaciones();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
                menu.opcion = 1;
                menu.Show();
                this.Close();
            }
            else if (opcion == 2)
            {
                DetalleReposicion menu = new DetalleReposicion();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
                menu.opcion = 1;
                menu.Show();
                this.Close();
            }
            else if (opcion == 3)
            {
                DetalleEspecial menu = new DetalleEspecial();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
                menu.opcion = 1;
                menu.Show();
                this.Close();
            }
            else if (opcion == 4)
            {
                DetalleConsulta menu = new DetalleConsulta();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
                menu.opcion = 1;
                menu.Show();
                this.Close();
            }
            else if (opcion == 5)
            {
                DetalleSuspension menu = new DetalleSuspension();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
                menu.opcion = 1;
                menu.Show();
                this.Close();
            }
            else if (opcion == 6)
            {
                DetalleSancion menu = new DetalleSancion();
                menu.idBoleta = idBoleta;
                menu.id = id;
                menu.departamentoPrincipal = departamentoPrincipal;
                menu.opcion = 1;
                menu.Show();
                this.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string prueba = "";
            int contador = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (contador == 0)
                    {
                        prueba = row.Cells[1].Value.ToString();
                    }
                    else
                    {
                        prueba = prueba + "," + row.Cells[1].Value.ToString();
                    }
                    contador++;
                }

            }

            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea autorizar las solicitudes con los ID :"+prueba+" ?", "Autorizar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                string nivel = "1";
                string dep = "4";
                if (opcion == 1)
                {
                    if(sql.AutorizarVacacionesM(id, prueba, 1))
                    {
                        MessageBox.Show("Solicitudes autorizadas correctamente.");
                        dataGridView1.DataSource = sql.MostrarPendientesVacaciones(dep, nivel);
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al autorizar solicitud)");
                    } 
                }
                else if (opcion == 2)
                {
                    if (sql.AutorizarReposicionM(id, prueba, 1))
                    {
                        MessageBox.Show("Solicitudes autorizadas correctamente.");
                        dataGridView1.DataSource = sql.MostrarPendientesReposiciones(dep, nivel);
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al autorizar solicitud)");
                    }
                }
                else if (opcion == 3)
                {
                    if (sql.AutorizarEspecialM(id, prueba, 1))
                    {
                        MessageBox.Show("Solicitudes autorizadas correctamente.");
                        dataGridView1.DataSource = sql.MostrarPendientesEspeciales(dep, nivel);
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al autorizar solicitud)");
                    }
                }
                else if (opcion == 4)
                {
                    if (sql.AutorizarConsultaIGSSM(id, prueba, 1))
                    {
                        MessageBox.Show("Solicitudes autorizadas correctamente.");
                        dataGridView1.DataSource = sql.MostrarPendientesConsultasIGGS(dep, nivel);
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al autorizar solicitud)");
                    }
                }
                else if (opcion == 5)
                {
                    if (sql.AutorizarSuspencionIGSSM(id, prueba, 1))
                    {
                        MessageBox.Show("Solicitudes autorizadas correctamente.");
                        dataGridView1.DataSource = sql.MostrarPendientesSuspencionesIGGS(dep, nivel);
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al autorizar solicitud)");
                    }
                }
                else if (opcion == 6)
                {
                    if (sql.AutorizarSansionM(id, prueba, 1))
                    {
                        MessageBox.Show("Solicitudes autorizadas correctamente.");
                        dataGridView1.DataSource = sql.MostrarPendientesSanciones(dep, nivel);
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al autorizar solicitud)");
                    }
                }
            }
            else
            {
                MessageBox.Show("La Autorización ha sido Cancelada", "Solicitud Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            label1.Text = sql.MostrarPendientesVacaciones("4", "1").Rows.Count.ToString();
            label2.Text = sql.MostrarPendientesReposiciones("4", "1").Rows.Count.ToString();
            label3.Text = sql.MostrarPendientesEspeciales("4", "1").Rows.Count.ToString();
            label5.Text = sql.MostrarPendientesConsultasIGGS("4", "1").Rows.Count.ToString();
            label6.Text = sql.MostrarPendientesSuspencionesIGGS("4", "1").Rows.Count.ToString();
            label7.Text = sql.MostrarPendientesSanciones("4", "1").Rows.Count.ToString();


        }
    }
}
