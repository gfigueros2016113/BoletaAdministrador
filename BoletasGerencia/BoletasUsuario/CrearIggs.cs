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
    public partial class CrearIggs : Form
    {
        public CrearIggs()
        {
            InitializeComponent();
        }
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
        public string fecha;
        public string desc;
        public string horaI = "NULL";
        public string horaF = "NULL";
        public string nivel;

        private void CrearIggs_Load(object sender, EventArgs e)
        {
            label4.Text = nombre;
            label7.Text = puesto;
            label5.Text = empresa;
            llenarCB();
            horas1.Visible = false;
            sql.ObtenerNivel(id, departamentoPrincipal);
            nivel = sql.nivel;
        }

        public void llenarCB()
        {
            HI.DataSource = sql.MostrarHorarios();
            HI.DisplayMember = "nombre";
            HI.ValueMember = "valor";

            HF.DataSource = sql.MostrarHorarios();
            HF.DisplayMember = "nombre";
            HF.ValueMember = "valor";

            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("8", "8");
            test.Add("9", "9");

            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Value";
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

        private void p1_Leave(object sender, EventArgs e)
        {
            try
            {
                int horario = Int32.Parse(comboBox1.SelectedValue.ToString());
                contador = 0;
                if (Ta1.Checked == true)
                {
                    contador = contador + horario;
                    label56.Text = contador.ToString();
                }
                else
                {
                    //if ((Double.Parse(HF.SelectedValue.ToString())) < (Double.Parse(HI.SelectedValue.ToString())))
                    //{
                    //    MessageBox.Show("Rango de horas invalido en Fecha 1 de Ausencia. La hora final no puede ser menor a la hora inicial. Vuelva a intentarlo...");
                    //}
                    //else
                    //{
                    //  contador = contador + ((Double.Parse(HF.SelectedValue.ToString())) - (Double.Parse(HI.SelectedValue.ToString())));
                    //}
                    label56.Text = contador.ToString();
                }

                    button1.Enabled = true;

            }catch(Exception a)
            {

            }
        }

        private void CrearIggs_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void label57_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void label56_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void label30_Click(object sender, EventArgs e)
        {
            p1_Leave(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DialogResult dialog = MessageBox.Show("¿Esta segur@ de que desea enviar la solicitud?", "Enviar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                obs = textBox1.Text;
                fecha = Fa1.Value.ToShortDateString();
                if(Ta1.Checked == true)
                {
                    desc = "1";
                }
                else
                {
                    desc = "3";
                    horaI = HI.SelectedValue.ToString();
                    horaF = HF.SelectedValue.ToString();
                    
                }
                if (sql.CrearConsultaIgss(obs,fecha,horaI,horaF,desc,label56.Text,id,departamentoPrincipal,Int32.Parse(nivel)))
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
    }
}
