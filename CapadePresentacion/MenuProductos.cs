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
    public partial class MenuProductos : Form
    {
        public MenuProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirForm2(new Agregar());
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
            button1.Hide();
            button2.Hide();
            button3.Hide();
            fh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirForm2(new Editar());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirForm2(new Eliminar());
        }

        private void MenuProductos_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
           
        }
    }
}
