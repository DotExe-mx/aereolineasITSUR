using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineasITSUR
{
    public partial class frmPrincipal : Form
    {
        TabControl tbcManejoPrincipal = new TabControl();
        Timer timerhora = new Timer();
        Timer timerhora2 = new Timer();
        PictureBox picPresiona = new PictureBox();
        Label lblFecha,lblFecha2,lblOrigen,lblDestino;
        ComboBox cboOrigenes, cboDestinos;
        GroupBox gpbHorariosDisponibles;
        Panel tapa = new Panel();
        LinkLabel linkRegresar, linkSiguiente;
        ErrorProvider errorRadio = new ErrorProvider();

        RadioButton rbtEstandar;


        public frmPrincipal()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(this.frmPrincipal_Load);
        }


        

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Text = "AerolineasITSUR®";
            lblFecha = new Label();
            cargarTimer(timerhora, 0);

            lblFecha.Font = new Font("New Amsterdam", 30);
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Location = new Point(this.Width - 330, this.Height - 300);
            lblFecha.AutoSize = true;



            this.Controls.Add(tapa);
            this.Controls.Add(tbcManejoPrincipal);

            for (int i = 0; i < 3; i++)
            {
                tbcManejoPrincipal.TabPages.Add(new TabPage().Text = "tabPage" + i);
            }
            tbcManejoPrincipal.SelectedIndex = 0;
            tbcManejoPrincipal.TabPages[0].Controls.Add(lblFecha);


            tbcManejoPrincipal.TabPages[0].Click += new EventHandler(this.cambiarPantalla_Click);
            picPresiona.Click += new EventHandler(this.cambiarPantalla_Click);
            lblFecha.Click += new EventHandler(this.cambiarPantalla_Click);

            tapa.Dock = DockStyle.Top;
            tapa.Size = new Size(284, 28);

            tapa.BackColor = this.BackColor;
            tbcManejoPrincipal.TabPages[0].BackgroundImage = Properties.Resources.PortadaBienvenido;
            tbcManejoPrincipal.TabPages[0].BackgroundImageLayout = ImageLayout.Stretch;

            tbcManejoPrincipal.TabPages[0].Controls.Add(picPresiona);

            picPresiona.Width = 100;
            picPresiona.Height = 100;
            picPresiona.BackgroundImage = Properties.Resources.presiona_aki0_1;
            picPresiona.BackgroundImageLayout = ImageLayout.Stretch;
            picPresiona.Anchor = (AnchorStyles.Left | AnchorStyles.Top);
            picPresiona.Location = new Point(tbcManejoPrincipal.Width + 130, tbcManejoPrincipal.Height + 400);

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            tbcManejoPrincipal.Width = this.Width - 16;
            tbcManejoPrincipal.Height = this.Height - 38;
            pantalla2();

        }
        private void pantalla2()
        {
            linkRegresar = new LinkLabel();
            linkSiguiente = new LinkLabel();
            gpbHorariosDisponibles = new GroupBox();
            
            lblOrigen = new Label();
            lblDestino = new Label();
            cboOrigenes = new ComboBox();
            cboDestinos = new ComboBox();
            lblFecha2 = new Label();

            RadioButton rbtPlus = new RadioButton();
            RadioButton rbtMega = new RadioButton();
            cargarTimer(timerhora2, 1);
            
            lblFecha2.Font = new Font("New Amsterdam", 30);
            lblFecha2.BackColor = Color.Transparent;
            lblFecha2.AutoSize = true;
            tbcManejoPrincipal.TabPages[1].Controls.Add(lblFecha2);

            cboOrigenes.Name = "cboOrigenes";
            cboDestinos.Name = "cboDestinos";

            cboOrigenes.Items.Add("Moroléon");
            cboOrigenes.Items.Add("Uriangato");
            cboOrigenes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrigenes.SelectedIndex = 0;


            cboDestinos.Items.Add("Moroléon");
            cboDestinos.Items.Add("Uriangato");
            cboDestinos.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDestinos.SelectedIndex = 1;


            tbcManejoPrincipal.TabPages[1].Controls.Add(cboOrigenes);
            tbcManejoPrincipal.TabPages[1].Controls.Add(cboDestinos);

            cboOrigenes.Location = new Point(tbcManejoPrincipal.Width - 610, tbcManejoPrincipal.Height - 490);
            cboDestinos.Location = new Point(tbcManejoPrincipal.Width - 380, tbcManejoPrincipal.Height - 490);

            cboOrigenes.SelectedValueChanged += new EventHandler(OrigenDestino_ValueChanged);
            cboDestinos.SelectedValueChanged += new EventHandler(DestinoOrigen_ValueChanged);





            lblOrigen.Font = new Font("New Amsterdam", 15);
            lblOrigen.Text = "Origen:";
            lblOrigen.BackColor = Color.Transparent;
            lblDestino.Font = new Font("New Amsterdam", 15);
            lblDestino.Text = "Destino:";
            lblDestino.BackColor = Color.Transparent;


           

            linkRegresar.Click += new EventHandler(this.regresarAtras_Click);
            linkRegresar.Font = new Font("New Amsterdam", 30);
            linkRegresar.AutoSize = true;
            linkSiguiente.AutoSize = true;
            linkRegresar.Text = "Regresar";
            linkSiguiente.Text = "Siguiente";
            linkSiguiente.Font = new Font("New Amsterdam",30);
            linkRegresar.BackColor = Color.Transparent;
            linkSiguiente.BackColor = Color.Transparent;
            

            tbcManejoPrincipal.TabPages[1].Controls.Add(linkRegresar);
            tbcManejoPrincipal.TabPages[1].Controls.Add(linkSiguiente);
            tbcManejoPrincipal.TabPages[1].Controls.Add(lblOrigen);
            tbcManejoPrincipal.TabPages[1].Controls.Add(lblDestino);

            lblDestino.Location = new Point(tbcManejoPrincipal.Width - 350, tbcManejoPrincipal.Height - 520);
            lblOrigen.Location = new Point(tbcManejoPrincipal.Width - 580, tbcManejoPrincipal.Height - 520);



            linkRegresar.Location = new Point(tbcManejoPrincipal.Width - 630, tbcManejoPrincipal.Height - 190);
            linkSiguiente.Location = new Point(tbcManejoPrincipal.Width - 360, tbcManejoPrincipal.Height - 190);




            tbcManejoPrincipal.TabPages[1].BackgroundImage = Properties.Resources.estas_a_punto_de_viajar;
            tbcManejoPrincipal.TabPages[1].BackgroundImageLayout = ImageLayout.Stretch;
            

            lblFecha2.Location = new Point(this.Width - 1250, this.Height - 700);
            gpbHorariosDisponibles.Size = new Size(tbcManejoPrincipal.Width-690,tbcManejoPrincipal.Height-466);
            gpbHorariosDisponibles.Text = "Horarios Disponibles:";
            gpbHorariosDisponibles.BackColor = Color.Transparent;

            tbcManejoPrincipal.TabPages[1].Controls.Add(gpbHorariosDisponibles);
            gpbHorariosDisponibles.Location = new Point(tbcManejoPrincipal.Width - 700, tbcManejoPrincipal.Height - 450);

            //
            String []estandar = { "3:00 - 5:00 Estandar", "9:00 - 11:00 Plus", "15:00 - 17:00 Estandar "};
            int x = 54, y = 50;
            for (int i = 0; i < 3; i++)
            {
                rbtEstandar = new RadioButton();
                rbtEstandar.AutoSize = true;
                rbtEstandar.Text = estandar[i];
                if (x>=gpbHorariosDisponibles.Width-rbtEstandar.Width)
                {
                    x = 54;
                    y += 25;
                }
                rbtEstandar.Left = x;
                rbtEstandar.Top = y;
                x += 150;
                gpbHorariosDisponibles.Controls.Add(rbtEstandar);

            }

            String[] mega = { "19:00 - 21:00 Mega", "5:00 - 7:00 Mega", "11:00 - 13:00 Plus", "17:00 - 19:00 Mega" };

            for (int i = 0; i < 4; i++)
            {
                rbtEstandar = new RadioButton();
                rbtEstandar.AutoSize = true;
                rbtEstandar.Text = mega[i];
                if (x >= gpbHorariosDisponibles.Width - rbtEstandar.Width)
                {
                    x = 54;
                    y += 25;
                }
                rbtEstandar.Left = x;
                rbtEstandar.Top = y;
                x += 150;
                gpbHorariosDisponibles.Controls.Add(rbtEstandar);

            }
            String[] plus = { "21:00 - 23:00 Plus ", "7:00 - 9:00 Mega", "13:00 - 15:00 Estandar" };
            for (int i = 0; i < 3; i++) 
            {
                rbtEstandar = new RadioButton();
                rbtEstandar.AutoSize = true;
                rbtEstandar.Text = plus[i];
                if (x >= gpbHorariosDisponibles.Width - rbtEstandar.Width)
                {
                    x = 54;
                    y += 25;
                }
                rbtEstandar.Left = x;
                rbtEstandar.Top = y;
                x += 150;
                gpbHorariosDisponibles.Controls.Add(rbtEstandar);

            }

            linkSiguiente.Click += new EventHandler(this.clickSiguiente_Click);





        }

        private void cambiarPantalla_Click(object sender, EventArgs e)
        {
            tbcManejoPrincipal.SelectedIndex = 1;
            
        }
        


        private void timerhoraHoja1(object sender, EventArgs e)
        {
            
            lblFecha.Text = DateTime.Now.ToString();
            

        }
        private void clickSiguiente_Click(object sender, EventArgs e)
        {
            frmAsientosEstandar asientosEstandar = new frmAsientosEstandar();
            frmAsientosPlus asientosplus = new frmAsientosPlus();
            frmAsientosMega asientomega = new frmAsientosMega();
            foreach (RadioButton radio in gpbHorariosDisponibles.Controls)
            {
                if (radio.Checked == true)
                {
                    if (radio.Text.Trim().Contains("Estandar"))
                    {
                        String[] datosEstandar = radio.Text.Split(' ');
                        asientosEstandar.cargarSeleccion(datosEstandar[0].ToString(),datosEstandar[2],cboOrigenes.Text,cboDestinos.Text);
                        asientosEstandar.ShowDialog();
                    }
                    if (radio.Text.Trim().Contains("Plus"))
                    {
                        String[] datosEstandar = radio.Text.Split(' ');
                        asientosplus.cargarSeleccion(datosEstandar[0].ToString(), datosEstandar[2], cboOrigenes.Text, cboDestinos.Text);
                        asientosplus.ShowDialog();

                    }
                    if (radio.Text.Trim().Contains("Mega"))
                    {
                        String[] datosEstandar = radio.Text.Split(' ');
                        asientomega.cargarSeleccion(datosEstandar[0].ToString(), datosEstandar[2], cboOrigenes.Text, cboDestinos.Text);
                        asientomega.ShowDialog();

                    }
                }
            }
        }

        private void frmPrincipal_Load_1(object sender, EventArgs e)
        {

        }

        private void OrigenDestino_ValueChanged(object sender, EventArgs e)
        {
            if (cboOrigenes.SelectedIndex==0)
            {
                cboDestinos.SelectedIndex = 1;
                cboDestinos.SelectedValueChanged += new EventHandler(this.DestinoOrigen_ValueChanged);
            }else if(cboOrigenes.SelectedIndex == 1)
            {
                cboDestinos.SelectedIndex = 0;
                cboDestinos.SelectedValueChanged += new EventHandler(this.DestinoOrigen_ValueChanged);
            }


        }
        private void DestinoOrigen_ValueChanged(object sender, EventArgs e)
        {
            if (cboDestinos.SelectedIndex == 1)
            {
                cboOrigenes.SelectedIndex = 0;
                cboOrigenes.SelectedValueChanged += new EventHandler(this.OrigenDestino_ValueChanged);

            }
            else if (cboDestinos.SelectedIndex == 0)
            {
                cboOrigenes.SelectedIndex = 1;
                cboOrigenes.SelectedValueChanged += new EventHandler(this.OrigenDestino_ValueChanged);
            }


        }

        private void timerhoraHoja2(object sender, EventArgs e)
        {
            
            lblFecha2.Text = DateTime.Now.ToString();


        }


        private void regresarAtras_Click(Object sender, EventArgs e)
        {
            tbcManejoPrincipal.SelectedIndex = 0;
        }

        private void cargarTimer(Timer timerhora,int hoja)
        {
            timerhora.Enabled = false;
            timerhora2.Enabled = false;
            if (hoja==0)
            {
                timerhora.Enabled = true;
                timerhora.Tick += new EventHandler(this.timerhoraHoja1);
            }else if (hoja==1)
            {
                timerhora2.Enabled = true;
                timerhora2.Tick += new EventHandler(this.timerhoraHoja2);
            }
            

        }



    }
}
