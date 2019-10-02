using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapadePresentacion
{
    public partial class Menu : Form
    {
        static Boolean Men=false;
        public Menu()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void privilegios()
        {
            if (Program.cargo != "Propietaria")
            {
                this.Hide();
                label2.Enabled = false;
                label3.Enabled = false;
                button2.Enabled = false;
            }
        }
        private void usuarioActivo()
        {
            lblCargo.Text = Program.cargo;
            lblNombre.Text = Program.nombre;
            lblApellido.Text=Program.apellido;
            //this.pictureBox5.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\empdia.png");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox3.Visible=false;
            pictureBox5.Visible = true;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBox5.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
           /* abrirForm2(new Form2());*/
        }

       
        

        private void button1_Click(object sender, EventArgs e)
        {
            abrirForm2(new Venta());
        }

        private void panelprincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
            Men = false;
            abrirForm2(new Botones());
            privilegios();
            usuarioActivo();
        }

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }
        private void abrirForm2(object Agregar)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form fh = Agregar as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(fh);
            this.panel2.Tag = fh;
            fh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirForm2(new MenuProductos());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            abrirForm2(new Venta());
        }

        private void pictureBox8_Click_2(object sender, EventArgs e)
        {
                abrirForm2(new Botones());
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            abrirForm2(new MenuProductos());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            abrirForm2(new Venta());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            abrirForm2(new Cuentas());
        }

        private void label4_Click(object sender, EventArgs e)
        {
            abrirForm2(new Servicios());
        }
    }
}
