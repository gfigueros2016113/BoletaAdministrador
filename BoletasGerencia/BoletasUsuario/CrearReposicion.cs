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
    public partial class CrearReposicion : Form
    {
        public CrearReposicion()
        {
            InitializeComponent();
        }
        public double contador;
        public double contadorRep;
        public string id;
        public string nivel;
        public string nombre;
        public string puesto;
        public string empresa;
        public string permiso;
        public string diasSolicitados;
        public string departamentoPrincipal;
        public string obs;
        public string fecha1A = "NULL";
        public string fecha2A = "NULL";
        public string fecha3A = "NULL";
        public string fecha4A = "NULL";
        public string fecha5A = "NULL";
        public string fecha1R = "NULL";
        public string fecha2R = "NULL";
        public string fecha3R = "NULL";
        public string fecha4R = "NULL";
        public string fecha5R = "NULL";

        public string desc1A = "NULL";
        public string desc2A = "NULL";
        public string desc3A = "NULL";
        public string desc4A = "NULL";
        public string desc5A = "NULL";
        public string desc1R = "NULL";
        public string desc2R = "NULL";
        public string desc3R = "NULL";
        public string desc4R = "NULL";
        public string desc5R = "NULL";

        public string HoraI1A = "NULL";
        public string HoraI2A = "NULL";
        public string HoraI3A = "NULL";
        public string HoraI4A = "NULL";
        public string HoraI5A = "NULL";
        public string HoraI1R = "NULL";
        public string HoraI2R = "NULL";
        public string HoraI3R = "NULL";
        public string HoraI4R = "NULL";
        public string HoraI5R = "NULL";

        public string HoraF1A = "NULL";
        public string HoraF2A = "NULL";
        public string HoraF3A = "NULL";
        public string HoraF4A = "NULL";
        public string HoraF5A = "NULL";
        public string HoraF1R = "NULL";
        public string HoraF2R = "NULL";
        public string HoraF3R = "NULL";
        public string HoraF4R = "NULL";
        public string HoraF5R = "NULL";

        public string HorasA = "0";
        public string HorasR = "0";


        ConsultasSQL sql = new ConsultasSQL();

        private void CrearReposicion_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            sql.ObtenerNivel(id, departamentoPrincipal);
            nivel = sql.nivel;
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p7.Visible = false;
            p8.Visible = false;
            p9.Visible = false;
            p10.Visible = false;
            horas1.Visible = false;
            horas2.Visible = false;
            horas3.Visible = false;
            horas4.Visible = false;
            horas5.Visible = false;
            horas6.Visible = false;
            horas7.Visible = false;
            horas8.Visible = false;
            horas9.Visible = false;
            horas10.Visible = false;
            llenarCB();
            this.Visible = true;
            //backgroundWorker1.RunWorkerAsync();
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

            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("8", "8");
            test.Add("9", "9");

            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Value";
        }
        #region DESAPARECER PANELES
        private void Ca2_CheckedChanged(object sender, EventArgs e)
        {
            if(Ca2.Checked == true)
            {
                p2.Visible = true;
            }
            else
            {
                p2.Visible = false;
            }
        }

        private void Ca3_CheckedChanged(object sender, EventArgs e)
        {
            if (Ca3.Checked == true)
            {
                p3.Visible = true;
            }
            else
            {
                p3.Visible = false;
            }
        }

        private void Ca4_CheckedChanged(object sender, EventArgs e)
        {
            if (Ca4.Checked == true)
            {
                p4.Visible = true;
            }
            else
            {
                p4.Visible = false;
            }
        }

        private void Ca5_CheckedChanged(object sender, EventArgs e)
        {
            if (Ca5.Checked == true)
            {
                p5.Visible = true;
            }
            else
            {
                p5.Visible = false;
            }
        }

        private void Ca7_CheckedChanged(object sender, EventArgs e)
        {
            if (Ca7.Checked == true)
            {
                p7.Visible = true;
            }
            else
            {
                p7.Visible = false;
            }
        }

        private void Ca8_CheckedChanged(object sender, EventArgs e)
        {
            if (Ca8.Checked == true)
            {
                p8.Visible = true;
            }
            else
            {
                p8.Visible = false;
            }
        }

        private void Ca9_CheckedChanged(object sender, EventArgs e)
        {
            if (Ca9.Checked == true)
            {
                p9.Visible = true;
            }
            else
            {
                p9.Visible = false;
            }
        }

        private void Ca10_CheckedChanged(object sender, EventArgs e)
        {
            if (Ca10.Checked == true)
            {
                p10.Visible = true;
            }
            else
            {
                p10.Visible = false;
            }
        }

        private void Ta1_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta1.Checked == false)
            {
                horas1.Visible = true;
            }
            else
            {
                horas1.Visible = false;
            }
        }

        private void Ta2_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta2.Checked == false)
            {
                horas2.Visible = true;
            }
            else
            {
                horas2.Visible = false;
            }
        }

        private void Ta3_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta3.Checked == false)
            {
                horas3.Visible = true;
            }
            else
            {
                horas3.Visible = false;
            }
        }

        private void Ta4_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta4.Checked == false)
            {
                horas4.Visible = true;
            }
            else
            {
                horas4.Visible = false;
            }
        }

        private void Ta5_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta5.Checked == false)
            {
                horas5.Visible = true;
            }
            else
            {
                horas5.Visible = false;
            }
        }

        private void Ta7_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta7.Checked == false)
            {
                horas7.Visible = true;
            }
            else
            {
                horas7.Visible = false;
            }
        }

        private void Ta6_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta6.Checked == false)
            {
                horas6.Visible = true;
            }
            else
            {
                horas6.Visible = false;
            }
        }

        private void Ta8_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta8.Checked == false)
            {
                horas8.Visible = true;
            }
            else
            {
                horas8.Visible = false;
            }
        }

        private void Ta9_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta9.Checked == false)
            {
                horas9.Visible = true;
            }
            else
            {
                horas9.Visible = false;
            }
        }

        private void Ta10_CheckedChanged(object sender, EventArgs e)
        {
            if (Ta10.Checked == false)
            {
                horas10.Visible = true;
            }
            else
            {
                horas10.Visible = false;
            }
        }
        #endregion

        private void panel3_Leave(object sender, EventArgs e)
        {
            try
            {

                int horario = Int32.Parse(comboBox1.SelectedValue.ToString());
                contador = 0;
                if (Ta1.Checked == true)
                {
                    contador = contador + horario;
                }
                else
                {
                    if ((Double.Parse(HFa1.SelectedValue.ToString())) < (Double.Parse(HIa1.SelectedValue.ToString())))
                    {
                        MessageBox.Show("Rango de horas invalido en Fecha 1 de Ausencia. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                    }
                    else
                    {
                        contador = contador + ((Double.Parse(HFa1.SelectedValue.ToString())) - (Double.Parse(HIa1.SelectedValue.ToString())));
                        if (Pan1.Checked == true)
                        {
                            contador = contador - 1;
                        }
                    }
                }
                if (Ca2.Checked == true)
                {
                    if (Ta2.Checked == true)
                    {
                        contador = contador + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa2.SelectedValue.ToString())) < (Double.Parse(HIa2.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 2 de Ausencia. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contador = contador + ((Double.Parse(HFa2.SelectedValue.ToString())) - (Double.Parse(HIa2.SelectedValue.ToString())));
                            if (pan2.Checked == true)
                            {
                                contador = contador - 1;
                            }
                        }

                    }
                }
                if (Ca3.Checked == true)
                {
                    if (Ta3.Checked == true)
                    {
                        contador = contador + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa3.SelectedValue.ToString())) < (Double.Parse(HIa3.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 3 de Ausencia. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contador = contador + ((Double.Parse(HFa3.SelectedValue.ToString())) - (Double.Parse(HIa3.SelectedValue.ToString())));
                            if (pan3.Checked == true)
                            {
                                contador = contador - 1;
                            }
                        }

                    }
                }
                if (Ca4.Checked == true)
                {
                    if (Ta4.Checked == true)
                    {
                        contador = contador + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa4.SelectedValue.ToString())) < (Double.Parse(HIa4.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 4 de Ausencia. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contador = contador + ((Double.Parse(HFa4.SelectedValue.ToString())) - (Double.Parse(HIa4.SelectedValue.ToString())));
                            if (pan4.Checked == true)
                            {
                                contador = contador - 1;
                            }
                        }

                    }
                }

                if (Ca5.Checked == true)
                {
                    if (Ta5.Checked == true)
                    {
                        contador = contador + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa5.SelectedValue.ToString())) < (Double.Parse(HIa5.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 5 de Ausencia. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contador = contador + ((Double.Parse(HFa5.SelectedValue.ToString())) - (Double.Parse(HIa5.SelectedValue.ToString())));
                            if (pan5.Checked == true)
                            {
                                contador = contador - 1;
                            }
                        }
                    }
                }

                label54.Text = contador.ToString();
            }catch(Exception a)
            {

            }
           
            //------------------------------------------
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region asignacionDeValores
            obs = textBox1.Text;
            fecha1A = Fa1.Value.ToShortDateString();
            if (Ta1.Checked == true)
            {
                desc1A = "1";
            }
            else
            {
                HoraI1A = HIa1.SelectedValue.ToString();
                HoraF1A = HFa1.SelectedValue.ToString();
                if (Pan1.Checked == true)
                {
                    desc1A = "2";
                }
                else
                {
                    desc1A = "3";
                }
            }

            if (Ca2.Checked == true)
            {
                fecha2A = Fa2.Value.ToShortDateString();
                if (Ta2.Checked == true)
                {
                    desc2A = "1";
                }
                else
                {
                    HoraI2A = HIa2.SelectedValue.ToString();
                    HoraF2A = HFa2.SelectedValue.ToString();
                    if (pan2.Checked == true)
                    {
                        desc2A = "2";
                    }
                    else
                    {
                        desc2A = "3";
                    }
                }
            }
            else
            {
                fecha2A = "01/01/2000";
                desc2A = "4";
            }

            if (Ca3.Checked == true)
            {
                fecha3A = Fa3.Value.ToShortDateString();
                if (Ta3.Checked == true)
                {
                    desc3A = "1";
                }
                else
                {
                    HoraI3A = HIa3.SelectedValue.ToString();
                    HoraF3A = HFa3.SelectedValue.ToString();
                    if (pan3.Checked == true)
                    {
                        desc3A = "2";
                    }
                    else
                    {
                        desc3A = "3";
                    }
                }
            }

            else
            {
                fecha3A = "01/01/2000";
                desc3A = "4";
            }

            if (Ca4.Checked == true)
            {
                fecha4A = Fa4.Value.ToShortDateString();
                if (Ta4.Checked == true)
                {
                    desc4A = "1";
                }
                else
                {
                    HoraI4A = HIa4.SelectedValue.ToString();
                    HoraF4A = HFa4.SelectedValue.ToString();
                    if (pan4.Checked == true)
                    {
                        desc4A = "2";
                    }
                    else
                    {
                        desc4A = "3";
                    }
                }
            }
            else
            {
                fecha4A = "01/01/2000";
                desc4A = "4";
            }

            if (Ca5.Checked == true)
            {
                fecha5A = Fa5.Value.ToShortDateString();
                if (Ta5.Checked == true)
                {
                    desc5A = "1";
                }
                else
                {
                    HoraI5A = HIa5.SelectedValue.ToString();
                    HoraF5A = HFa5.SelectedValue.ToString();
                    if (pan5.Checked == true)
                    {
                        desc5A = "2";
                    }
                    else
                    {
                        desc5A = "3";
                    }
                }
            }
            else
            {
                fecha5A = "01/01/2000";
                desc5A = "4";
            }

            fecha1R = Fa6.Value.ToShortDateString();
            if (Ta6.Checked == true)
            {
                desc1R = "1";
            }
            else
            {
                desc1R = "3";
                HoraI1R = HIa6.SelectedValue.ToString();
                HoraF1R = HFa6.SelectedValue.ToString();
            }

            if (Ca7.Checked == true)
            {
                fecha2R = Fa7.Value.ToShortDateString();
                if (Ta7.Checked == true)
                {
                    desc2R = "1";
                }
                else
                {
                    desc2R = "3";
                    HoraI2R = HIa7.SelectedValue.ToString();
                    HoraF2R = HFa7.SelectedValue.ToString();
                }
            }
            else
            {
                fecha2R = "01/01/2000";
                desc2R = "4";
            }

            if (Ca8.Checked == true)
            {
                fecha3R = Fa8.Value.ToShortDateString();
                if (Ta8.Checked == true)
                {
                    desc3R = "1";
                }
                else
                {
                    desc3R = "3";
                    HoraI3R = HIa8.SelectedValue.ToString();
                    HoraF3R = HFa8.SelectedValue.ToString();
                }
            }
            else
            {
                fecha3R = "01/01/2000";
                desc3R = "4";
            }

            if (Ca9.Checked == true)
            {
                fecha4R = Fa9.Value.ToShortDateString();
                if (Ta9.Checked == true)
                {
                    desc4R = "1";
                }
                else
                {
                    desc4R = "3";
                    HoraI4R = HIa9.SelectedValue.ToString();
                    HoraF4R = HFa9.SelectedValue.ToString();
                }
            }
            else
            {
                fecha4R = "01/01/2000";
                desc4R = "4";
            }

            if (Ca10.Checked == true)
            {
                fecha5R = Fa10.Value.ToShortDateString();
                if (Ta10.Checked == true)
                {
                    desc5R = "1";
                }
                else
                {
                    desc5R = "3";
                    HoraI5R = HIa10.SelectedValue.ToString();
                    HoraF5R = HFa10.SelectedValue.ToString();
                }
            }
            else
            {
                fecha5R = "01/01/2000";
                desc5R = "4";
            }


            HorasA = label54.Text;
            HorasR = label56.Text;

#endregion

            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea enviar la solicitud?", "Enviar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (sql.CrearReposicion(obs,
                    fecha1A,HoraI1A, HoraF1A,
                    fecha2A, HoraI2A, HoraF2A,
                    fecha3A, HoraI3A, HoraF3A,
                    fecha4A, HoraI4A, HoraF4A,
                    fecha5A, HoraI5A, HoraF5A,
                    
                    fecha1R, HoraI1R, HoraF1R,
                    fecha2R, HoraI2R, HoraF2R,
                    fecha3R, HoraI3R, HoraF3R,
                    fecha4R, HoraI4R, HoraF4R,
                    fecha5R, HoraI5R, HoraF5R,
                    HorasA, HorasR,id,departamentoPrincipal,desc1A,desc2A,desc3A,desc4A,desc5A,desc1R,desc2R,desc3R,desc4R,desc5R,Int32.Parse(nivel)))
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

        private void panel14_Leave(object sender, EventArgs e)
        {
            try
            {


                int horario = Int32.Parse(comboBox1.SelectedValue.ToString());
                contadorRep = 0;
                if (Ta6.Checked == true)
                {
                    contadorRep = contadorRep + horario;
                }
                else
                {
                    if ((Double.Parse(HFa6.SelectedValue.ToString())) < (Double.Parse(HIa6.SelectedValue.ToString())))
                    {
                        MessageBox.Show("Rango de horas invalido en Fecha 1 de Reposición. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                    }
                    else
                    {
                        contadorRep = contadorRep + ((Double.Parse(HFa6.SelectedValue.ToString())) - (Double.Parse(HIa6.SelectedValue.ToString())));
                    }
                }
                if (Ca7.Checked == true)
                {
                    if (Ta7.Checked == true)
                    {
                        contadorRep = contadorRep + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa7.SelectedValue.ToString())) < (Double.Parse(HIa7.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 2 de Reposición. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contadorRep = contadorRep + ((Double.Parse(HFa7.SelectedValue.ToString())) - (Double.Parse(HIa7.SelectedValue.ToString())));

                        }

                    }
                }
                if (Ca8.Checked == true)
                {
                    if (Ta8.Checked == true)
                    {
                        contadorRep = contadorRep + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa8.SelectedValue.ToString())) < (Double.Parse(HIa8.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 3 de Reposición. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contadorRep = contadorRep + ((Double.Parse(HFa8.SelectedValue.ToString())) - (Double.Parse(HIa8.SelectedValue.ToString())));

                        }

                    }
                }
                if (Ca9.Checked == true)
                {
                    if (Ta9.Checked == true)
                    {
                        contadorRep = contadorRep + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa9.SelectedValue.ToString())) < (Double.Parse(HIa9.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 4 de Reposición. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contadorRep = contadorRep + ((Double.Parse(HFa9.SelectedValue.ToString())) - (Double.Parse(HIa9.SelectedValue.ToString())));

                        }

                    }
                }

                if (Ca10.Checked == true)
                {
                    if (Ta10.Checked == true)
                    {
                        contadorRep = contadorRep + horario;
                    }
                    else
                    {
                        if ((Double.Parse(HFa10.SelectedValue.ToString())) < (Double.Parse(HIa10.SelectedValue.ToString())))
                        {
                            MessageBox.Show("Rango de horas invalido en Fecha 5 de Reposición. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                        }
                        else
                        {
                            contadorRep = contadorRep + ((Double.Parse(HFa10.SelectedValue.ToString())) - (Double.Parse(HIa10.SelectedValue.ToString())));
                        }
                    }
                }

                label56.Text = contadorRep.ToString();
            }catch(Exception a)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Fa10.Value.ToShortDateString());
        }

        private void CrearReposicion_Click(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }

        private void label56_Click(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }

        private void label57_Click(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }

        private void label54_Click(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }

        private void label55_Click(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel14_Leave(sender, e);
            panel3_Leave(sender, e);
        }


    }
}
