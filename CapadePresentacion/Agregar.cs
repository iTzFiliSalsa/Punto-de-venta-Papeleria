using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapadeNegocio;

namespace CapadePresentacion
{
    public partial class Agregar : Form
    {
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        CN_Productos objetoCN = new CN_Productos();
        public Agregar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProd();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if((txtNombre.Text=="")||(txtMarca.Text =="")|| (txtDescripcion.Text =="")|| (txtStock.Text =="")|| (txtPrecio.Text == "") || (txtPrecio.Text == ".")) {
                    MessageBox.Show("Favor de llenar todos los campos");

                }
                else {
                    objetoCN.InsertarPRod(txtNombre.Text, txtDescripcion.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se inserto Correctamente");
                    txtNombre.Text = "";
                    txtDescripcion.Text = "";
                    txtMarca.Text = "";
                    txtPrecio.Text = "";
                    txtStock.Text = "";
                    txtNombre.Focus();
                    MostrarProductos();
                }
                
            }
            catch (Exception ex) {
                MessageBox.Show(""+ex);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros2(Convert.ToInt32(e.KeyChar));
        }
    

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
