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
    public partial class CrearVacaciones : Form
    {
        public CrearVacaciones()
        {
            InitializeComponent();
        }
        public double contador;
        public string id;
        public string nivel;
        public string nombre;
        public string puesto;
        public string dias;
        public string empresa;
        public string permiso;
        public string diasSolicitados;
        public string departamentoPrincipal;
        public string obs;
        public string fecha1 = "NULL";
        public string fecha2 = "NULL";
        public string fecha3 = "NULL";
        public string fecha4 = "NULL";
        public string fecha5 = "NULL";
        public string fecha6 = "NULL";
        public string fecha7 = "NULL";
        public string fecha8 = "NULL";
        public string fecha9 = "NULL";
        public string fecha10 = "NULL";
        public string desc1 = "NULL";
        public string desc2 = "NULL";
        public string desc3 = "NULL";
        public string desc4 = "NULL";
        public string desc5 = "NULL";
        public string desc6 = "NULL";
        public string desc7 = "NULL";
        public string desc8 = "NULL";
        public string desc9 = "NULL";
        public string desc10 = "NULL";
        public int filas = 0;
        ConsultasSQL sql = new ConsultasSQL();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel4.Visible = true;
                d2.SelectedIndex = 0;
                checkBox2.Visible = true;
            }
            else
            {
                panel4.Visible = false;
                d2.SelectedItem = null;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox9.Visible = false;
                checkBox8.Visible = false;
                checkBox7.Visible = false;
                checkBox6.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("cambio 3");
            if (checkBox2.Checked == true)
            {
                panel6.Visible = true;
                d3.SelectedIndex = 0;
                checkBox3.Visible = true;
            }
            else
            {
                panel6.Visible = false;
                d3.SelectedItem = null;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox9.Visible = false;
                checkBox8.Visible = false;
                checkBox7.Visible = false;
                checkBox6.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("cambio 4");
            if (checkBox3.Checked == true)
            {
                panel7.Visible = true;
                d4.SelectedIndex = 0;
                checkBox4.Visible = true;
            }
            else
            {
                panel7.Visible = false;
                d4.SelectedItem = null;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox9.Visible = false;
                checkBox8.Visible = false;
                checkBox7.Visible = false;
                checkBox6.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("cambio 5");
            if (checkBox4.Checked == true)
            {
                panel8.Visible = true;
                d5.SelectedIndex = 0;
                checkBox5.Visible = true;
            }
            else
            {
                panel8.Visible = false;
                d5.SelectedItem = null;
                checkBox5.Visible = false;
                checkBox9.Visible = false;
                checkBox8.Visible = false;
                checkBox7.Visible = false;
                checkBox6.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("cambio 6");
            if (checkBox5.Checked == true)
            {
                panel9.Visible = true;
                d6.SelectedIndex = 0;
                checkBox9.Visible = true;
            }
            else
            {
                panel9.Visible = false;
                d6.SelectedItem = null;
                checkBox9.Visible = false;
                checkBox8.Visible = false;
                checkBox7.Visible = false;
                checkBox6.Visible = false;

            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("cambio 7");
            if (checkBox9.Checked == true)
            {
                panel13.Visible = true;
                d7.SelectedIndex = 0;
                checkBox8.Visible = true;
            }
            else
            {
                panel13.Visible = false;
                d7.SelectedItem = null;
                checkBox8.Visible = false;
                checkBox7.Visible = false;
                checkBox6.Visible = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("cambio 8");
            if (checkBox8.Checked == true)
            {
                panel12.Visible = true;
                d8.SelectedIndex = 0;
                checkBox7.Visible = true;
            }
            else
            {
                panel12.Visible = false;
                d8.SelectedItem = null;
                checkBox7.Visible = false;
                checkBox6.Visible = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("cambio 9");
            if (checkBox7.Checked == true)
            {
                panel11.Visible = true;
                d9.SelectedIndex = 0;
                checkBox6.Visible = true;
            }
            else
            {
                panel11.Visible = false;
                d9.SelectedItem = null;
                checkBox6.Visible = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("cambio 10");
            if (checkBox6.Checked == true)
            {
                panel10.Visible = true;
                d10.SelectedIndex = 0;
            }
            else
            {
                panel10.Visible = false;
                d10.SelectedItem = null;
            }
        }

        private void CrearVacaciones_Load(object sender, EventArgs e)
        {
            LlenarCB();
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;
            panel13.Visible = false;
            panel9.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel6.Visible = false;
            panel4.Visible = false;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            label11.Text = dias;
            label9.Text = "0";
            sql.ObtenerNivel(id, departamentoPrincipal);
            nivel = sql.nivel;
            label14.Text = nivel;
        }
        private void LlenarCB()
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("Todo el día.", "Todo el día.");
            test.Add("Medio día (por la mañana).", "Medio día (por la mañana).");
            test.Add("Medio día (por la tarde).", "Medio día (por la tarde).");

            d1.DataSource = new BindingSource(test, null);
            d1.DisplayMember = "Value";
            d1.ValueMember = "Value";

            d2.DataSource = new BindingSource(test, null);
            d2.DisplayMember = "Value";
            d2.ValueMember = "Value";
            d2.SelectedItem = null;

            d3.DataSource = new BindingSource(test, null);
            d3.DisplayMember = "Value";
            d3.ValueMember = "Value";
            d3.SelectedItem = null;

            d4.DataSource = new BindingSource(test, null);
            d4.DisplayMember = "Value";
            d4.ValueMember = "Value";
            d4.SelectedItem = null;

            d5.DataSource = new BindingSource(test, null);
            d5.DisplayMember = "Value";
            d5.ValueMember = "Value";
            d5.SelectedItem = null;

            d6.DataSource = new BindingSource(test, null);
            d6.DisplayMember = "Value";
            d6.ValueMember = "Value";
            d6.SelectedItem = null;

            d7.DataSource = new BindingSource(test, null);
            d7.DisplayMember = "Value";
            d7.ValueMember = "Value";
            d7.SelectedItem = null;

            d8.DataSource = new BindingSource(test, null);
            d8.DisplayMember = "Value";
            d8.ValueMember = "Value";
            d8.SelectedItem = null;

            d9.DataSource = new BindingSource(test, null);
            d9.DisplayMember = "Value";
            d9.ValueMember = "Value";
            d9.SelectedItem = null;

            d10.DataSource = new BindingSource(test, null);
            d10.DisplayMember = "Value";
            d10.ValueMember = "Value";
            d10.SelectedItem = null;
        }

        private void d1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void d10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Leave(object sender, EventArgs e)
        {
            contador = 0;
            if (d1.SelectedValue.ToString() == "Todo el día.")
            {
                contador = contador + 1;
            }
            else if (d1.SelectedValue.ToString() == "Medio día (por la mañana).")
            {
                contador = contador + 0.5;
            }
            else if (d1.SelectedValue.ToString() == "Medio día (por la tarde).")
            {
                contador = contador + 0.5;
            }
            if (d2.SelectedItem != null)
            {
                if (d2.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d2.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d2.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }

            if (d3.SelectedItem != null)
            {
                if (d3.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d3.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d3.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }

            if (d4.SelectedItem != null)
            {
                if (d4.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d4.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d4.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }

            if (d5.SelectedItem != null)
            {
                if (d5.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d5.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d5.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }
            if (d6.SelectedItem != null)
            {
                if (d6.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d6.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d6.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }
            if (d7.SelectedItem != null)
            {
                if (d7.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d7.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d7.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }

            if (d8.SelectedItem != null)
            {
                if (d8.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d8.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d8.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }

            if (d9.SelectedItem != null)
            {
                if (d9.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d9.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d9.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }
            }
            if (d10.SelectedItem != null)
            {
                if (d10.SelectedValue.ToString() == "Todo el día.")
                {
                    contador = contador + 1;
                }
                else if (d10.SelectedValue.ToString() == "Medio día (por la mañana).")
                {
                    contador = contador + 0.5;
                }
                else if (d10.SelectedValue.ToString() == "Medio día (por la tarde).")
                {
                    contador = contador + 0.5;
                }

            }
            label9.Text = contador.ToString();
        }

        private void CrearVacaciones_Click(object sender, EventArgs e)
        {
            panel3_Leave(sender, e);
        }

        private void label9_TextChanged(object sender, EventArgs e)
        {
            double solicitado;
            double.TryParse(label9.Text, out solicitado);
            double disponible;
            double.TryParse(dias, out disponible);
            if (solicitado > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea enviar la solicitud?", "Enviar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                fecha1 = f1.Value.ToShortDateString();
                desc1 = d1.SelectedValue.ToString();
                filas = filas + 1;
                if (checkBox1.Checked == true)
                {
                    fecha2 = f2.Value.ToShortDateString();
                    desc2 = d2.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox2.Checked == true)
                {
                    fecha3 = f3.Value.ToShortDateString();
                    desc3 = d3.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox3.Checked == true)
                {
                    fecha4 = f4.Value.ToShortDateString();
                    desc4 = d4.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox4.Checked == true)
                {
                    fecha5 = f5.Value.ToShortDateString();
                    desc5 = d5.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox5.Checked == true)
                {
                    fecha6 = f6.Value.ToShortDateString();
                    desc6 = d6.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox9.Checked == true)
                {
                    fecha7 = f7.Value.ToShortDateString();
                    desc7 = d7.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox8.Checked == true)
                {
                    fecha8 = f8.Value.ToShortDateString();
                    desc8 = d8.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox7.Checked == true)
                {
                    fecha9 = f9.Value.ToShortDateString();
                    desc9 = d9.SelectedValue.ToString();
                    filas = filas + 1;
                }
                if (checkBox6.Checked == true)
                {
                    fecha10 = f10.Value.ToShortDateString();
                    desc10 = d10.SelectedValue.ToString();
                    filas = filas + 1;
                }
                MessageBox.Show(filas.ToString());
                obs = textBox1.Text;
                diasSolicitados = contador.ToString();

                if (nivel == "4")
                {
                    if (sql.CrearVacacionesNivel4(obs,
                    fecha1, desc1,
                    fecha2, desc2,
                    fecha3, desc3,
                    fecha4, desc4,
                    fecha5, desc5,
                    fecha6, desc6,
                    fecha7, desc7,
                    fecha8, desc8,
                    fecha9, desc9,
                    fecha10, desc10, id, id, departamentoPrincipal, label9.Text, filas
                    ))
                    {
                        MessageBox.Show("Solicitud enviada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al agregar solicitud)");
                    }
                }
                else if (nivel == "3")
                {
                    if (sql.CrearVacacionesNivel3(obs,
                    fecha1, desc1,
                    fecha2, desc2,
                    fecha3, desc3,
                    fecha4, desc4,
                    fecha5, desc5,
                    fecha6, desc6,
                    fecha7, desc7,
                    fecha8, desc8,
                    fecha9, desc9,
                    fecha10, desc10, id, id, departamentoPrincipal, label9.Text, filas
                    ))
                    {
                        MessageBox.Show("Solicitud enviada correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al agregar solicitud)");
                    }
                }
                else if (nivel == "2")
                {
                    if (sql.CrearVacacionesNivel2(obs,
                    fecha1, desc1,
                    fecha2, desc2,
                    fecha3, desc3,
                    fecha4, desc4,
                    fecha5, desc5,
                    fecha6, desc6,
                    fecha7, desc7,
                    fecha8, desc8,
                    fecha9, desc9,
                    fecha10, desc10, id, id, departamentoPrincipal, label9.Text, filas
                    ))
                    {
                        MessageBox.Show("Solicitud enviada correctamente.");
                        filas = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error, comuniquese con Harim Palma por favor. (error al agregar solicitud)");
                    }
                }



            }
            else
            {
                MessageBox.Show("La solicitud ha sido Cancelada", "Solicitud Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            panel3_Leave(sender, e);
        }

        private void checkBox2_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox2.Visible == true)
            {

            }
            else
            {
                panel6.Visible = false;
                checkBox2.Checked = false;
            }
        }

        private void checkBox3_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox3.Visible == true)
            {

            }
            else
            {
                panel7.Visible = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox4_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox4.Visible == true)
            {

            }
            else
            {
                panel8.Visible = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox5_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox5.Visible == true)
            {

            }
            else
            {
                panel9.Visible = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox9_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox9.Visible == true)
            {

            }
            else
            {
                panel13.Visible = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox8_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox8.Visible == true)
            {

            }
            else
            {
                panel12.Visible = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox7_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox7.Visible == true)
            {

            }
            else
            {
                panel11.Visible = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox6_VisibleChanged(object sender, EventArgs e)
        {
            if (checkBox6.Visible == true)
            {

            }
            else
            {
                panel10.Visible = false;
                checkBox6.Checked = false;
            }
        }
    }
}
