using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapadePresentacion
{
    public partial class Botones : Form
    {
        public Botones()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            abrirForm2(new Venta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirForm2(new Cuentas());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            abrirForm2(new Servicios());
        }

        private void Botones_Load(object sender, EventArgs e)
        {
            Menu m = new Menu();
            if (Program.cargo == "Empleada")
            {
                this.button2.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\Botones\\botoningl.png");
                this.button3.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\Botones\\botoningl.png");
                button2.Enabled=false;
                button3.Enabled = false;

            }
        }
    }
}
