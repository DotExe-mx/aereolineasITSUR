using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineasITSUR
{
    public partial class frmAsientosEstandar : Form
    {
        Double subtotal = 0;
        Double costeadicional = 110.00;
        StreamWriter escribirEstandar;
        StreamReader lectorArchivo;
        String asientosyacomprados;
        String[] numeroAsientosComprados;
        String lectura;
        public frmAsientosEstandar()

        {
            InitializeComponent();
            lblAsientoSeleccionado.Text = "";
            

        }

        private void frmAsientosEstandar_Load(object sender, EventArgs e)
        {

        }
        public void cargarSeleccion(String horasalida, String horallegada, String origen, String destino)
        {
            lblHoraSalida.Text = horasalida;
            lblHoraLlegada.Text = horallegada;
            lblOrigen.Text = origen;
            lblDestino.Text = destino;

            try
            {
                leerArchivo();
            }
            catch (Exception ew)
            {
                MessageBox.Show(ew + "");
            }
            finally
            {
                
            }


        }


        private void btn14A_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            lblAsientoSeleccionado.Text += temp.Text.Trim() + ",";
            temp.ForeColor = Color.Green;
            temp.BackgroundImage = Properties.Resources.PAL;
            temp.BackgroundImageLayout = ImageLayout.Stretch;
            temp.Enabled = false;

            if (temp.Text.EndsWith("A"))
            {
                lblBloque.Text = "A";
                if (temp.Name.EndsWith("c"))
                {
                    subtotal += costeadicional;
                    lblSubtotal.Text =subtotal.ToString();
                }
                else
                {
                    subtotal += 100;
                    lblSubtotal.Text =subtotal.ToString();
                }
            }
            if (temp.Text.EndsWith("B"))
            {
                lblBloque.Text = "B";
                if (temp.Name.EndsWith("c"))
                {

                    subtotal += costeadicional;
                    lblSubtotal.Text = subtotal.ToString();
                }
                else
                {
                    subtotal += 100;
                    lblSubtotal.Text = subtotal.ToString();



                }




            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            
           
            numeroAsientosComprados = lblAsientoSeleccionado.Text.Split(',');
            
            if (subtotal == 0)
            {
                MessageBox.Show("Selecciona un asiento!!","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Vuelo nuevoVuelo = new Vuelo(lblTipoVuelo.Text.Trim(), lblHoraLlegada.Text.Trim(), lblHoraSalida.Text.Trim(), numeroAsientosComprados.Length - 1, Convert.ToDouble(lblSubtotal.Text), lblOrigen.Text, lblDestino.Text, numeroAsientosComprados);
                    for (int i = 0; i < numeroAsientosComprados.Length-1; i++)
                    {
                        asientosyacomprados += numeroAsientosComprados[i] + "-";
                    }
                    escribirVuelo(nuevoVuelo);

                }
                catch (Exception ew )
                {
                    MessageBox.Show(ew+"");
                }
                finally
                {
                    frmAgradecimientos agra = new frmAgradecimientos();
                    agra.ShowDialog();
                }


            }
        }

        public void escribirVuelo(Vuelo nvuelo)
        {
            
            
                escribirEstandar = File.AppendText("Estandar.txt");


                escribirEstandar.WriteLine(nvuelo.getTipoVuelo() + "-" + nvuelo.getHoraSalida() + "-" + nvuelo.getHoraLlegada() + "-" + nvuelo.getNumAsientos() + "-" + nvuelo.getTotal() + "-" + nvuelo.getOrigen() + "-" + nvuelo.getDestino()+"-"+asientosyacomprados);

                escribirEstandar.Close();

            
        }
        public void leerArchivo()
        {
            lectorArchivo = File.OpenText("Estandar.txt");
            lectura = lectorArchivo.ReadLine();
          
            
            while (lectura!=null)
            {
                capturarAsientos(lectura.Split('-'));
                lectura = lectorArchivo.ReadLine();
                
                
            }
            lectorArchivo.Close();
           

        }
        public void capturarAsientos(String[] capturados)
        {

            foreach (Button boton in groupBox1.Controls)
            {
                for (int i = 7; i < capturados.Length; i++)
                {
                    if (boton.Text.Equals(capturados[i]))
                    {
                        boton.BackgroundImage = Properties.Resources.x_30465_960_720;
                        boton.Enabled = false;
                    }
                }
                

            }
            
                

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}

