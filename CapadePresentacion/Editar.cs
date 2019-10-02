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
    public partial class Editar : Form
    {
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        private bool Edita = false;
        public Editar()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void Editar_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            txtNombre.Enabled = false;
            txtMarca.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            btnGuardar.Enabled = false;
        }
        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            if ((txtNombre.Text == "") || (txtMarca.Text == "") || (txtDescripcion.Text == "") || (txtStock.Text == "") || (txtPrecio.Text == "") || (txtPrecio.Text == "."))
            {
                MessageBox.Show("Favor de llenar todos los campos");

            }
            else
            {
                objetoCN.EditarProd(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                MessageBox.Show("Se inserto Correctamente");
                MostrarProductos();
                txtNombre.Text = "";
                txtMarca.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
                txtDescripcion.Text = "";
                idProducto = null;
                btnGuardar.Enabled = false;
                txtNombre.Enabled = false;
                txtMarca.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPrecio.Enabled = false;
                txtStock.Enabled = false;
                btnGuardar.Enabled = false;
                txtNombre.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
            txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
            txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
            txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            idProducto = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            txtNombre.Enabled = true;
            txtMarca.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.CurrentCell = null;
                foreach (DataGridViewRow r in dataGridView1.Rows)
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros2(Convert.ToInt32(e.KeyChar));
        }
        public bool solonumeros2(int code)
        {
            bool resultado;
            if (code == 46 && txtPrecio.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
            {
                resultado = true;
            }
            else if ((((code >= 48) && (code <= 57)) || (code == 8) || code == 46)) //se evaluan las teclas validas
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }

            return resultado;
        }
    }
}
