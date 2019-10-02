using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapadeNegocio;

namespace CapadePresentacion
{
    public partial class Eliminar : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        public Eliminar()
        {
            InitializeComponent();
        }
        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Eliminar_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            txtNombre.Enabled = false;
            txtMarca.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            btnGuardar.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnGuardar.Enabled = true;
            txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            idProducto = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objetoCN.EliminarProd(idProducto);
            MessageBox.Show("Se Elimino Correctamente");
            MostrarProductos();
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtDescripcion.Text = "";
            idProducto = null;
            btnGuardar.Enabled = false;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.CurrentCell = null;
                foreach(DataGridViewRow r in dataGridView1.Rows)
                {
                    r.Visible = false;
                }
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell c in r.Cells)
                    {
                        if ((c.Value.ToString().ToUpper()).IndexOf(textBox1.Text.ToUpper()) == 0)
                        {
                            r.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                CN_Productos xd = new CN_Productos();
                dataGridView1.DataSource = xd.MostrarProd();
            }
        }
    }
}
