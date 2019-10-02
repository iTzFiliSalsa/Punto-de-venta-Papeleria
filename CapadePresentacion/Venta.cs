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
using CapadeDatos;
using System.Data.SqlClient;
using DGVPrinterHelper;

namespace CapadePresentacion
{
    public partial class Venta : Form
    {
        public static double ctotal = 0.00;
        public SqlConnection Conexion = new SqlConnection("Server=LAPTOP-KF9P88JK\\SQLEXPRESS;DataBase=Papeleria;Integrated Security=true");
        MessageBoxSuficientes mbs = new MessageBoxSuficientes();
        MessageBoxNoProducto mbn = new MessageBoxNoProducto();
        Cancelar can = new Cancelar();
        SqlCommand global;
        SqlDataReader lectura;
        public Venta()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Open();
            try
            {
                SqlDataReader leer;
                DataGridViewRow fila = new DataGridViewRow();
                String cadena = "select * from PRODUCTOS where Nombre='" + txtNombre.Text + "';";
                fila.CreateCells(dataGridView1);
                SqlCommand da = new SqlCommand(cadena, Conexion);
                leer = da.ExecuteReader();
                int cantidadd = Convert.ToInt32(textBox2.Text);
                Boolean verificar = false;
                String prueba = Convert.ToString(textBox2.Text);
                int to = 0;
                while (leer.Read())
                {
                    int tot = Convert.ToInt32(leer.GetValue(5));
                    if (Convert.ToString(leer.GetValue(1)).Equals(txtNombre.Text))
                    {
                        verificar = true;
                    }
                    if (cantidadd == 0||textBox2.Text.Equals(""))
                    {
                        MessageBox.Show("Inserte una cantidad");
                        button2.Enabled = false;
                        button3.Enabled = false;
                    }
                    else
                    {
                        if (tot < cantidadd)
                        {
                            DialogResult resultado = new DialogResult();
                            resultado = mbs.ShowDialog();
                            textBox2.Text = "";
                            button2.Enabled = false;
                            button3.Enabled = false;
                        }
                        else
                        {
                            fila.Cells[0].Value = textBox2.Text;
                            fila.Cells[1].Value = leer.GetValue(1);
                            fila.Cells[2].Value = leer.GetValue(4);
                            double cantidad = Convert.ToDouble(fila.Cells[0].Value);
                            double precio = Convert.ToDouble(fila.Cells[2].Value);
                            double total = cantidad * precio;
                            fila.Cells[3].Value = total;
                            dataGridView1.Rows.Add(fila);
                            txtNombre.Text = "";
                            textBox2.Text = "";
                            ctotal = ctotal + total;
                            String temporal = ctotal.ToString("00.00");
                            txtTotal.Text = "$ " + temporal;
                            txtNombre.Focus();
                            button2.Enabled = true;
                            button3.Enabled = true;
                        }
                    }
                }
                if (verificar == false)
                {
                    button2.Enabled = false;
                    button3.Enabled = false;
                    DialogResult resultado = new DialogResult();
                    resultado = mbn.ShowDialog();
                    textBox2.Text = "";
                    txtNombre.Text = "";
                    txtNombre.Focus();
                }
            }
            catch (Exception Ex)
            {
                DialogResult resultado = new DialogResult();
                resultado = mbn.ShowDialog();
                textBox2.Text = "";
                txtNombre.Text = "";
                txtNombre.Focus();
                button2.Enabled = false;
                button3.Enabled = false;
            }
            Conexion.Close();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            textBox2.Text = "";
            Conexion.Open();
            CD_Productos c = new CD_Productos();
            c.autocompletar(txtNombre);
            String cadena = "select * from usuarios";
            global = new SqlCommand(cadena, Conexion);
            lectura=global.ExecuteReader();
            while (lectura.Read())
            {
                comboBox1.Items.Add(lectura.GetString(1));
            }
            string nombre = Program.nombre;
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedItem = Program.nombre;
            button2.Enabled = false;
            button3.Enabled = false;
            Conexion.Close();
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            resultado = can.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                ctotal = 0.00;
                String temporal = ctotal.ToString("00.00");
                txtTotal.Text = "$ " + temporal;
                txtNombre.Text = "";
                textBox2.Text = "";
                txtNombre.Focus();
                textBox1.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                button2.Enabled = false;
                button3.Enabled = false;
            }
            else
            {

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Open();
            
            SqlCommand Agregar = new SqlCommand("insert into ventas values(@idventa,@cantidad,@nombre,@total,@fecha,@comentario,@empleada)",Conexion);
            SqlCommand Editar = new SqlCommand("update productos set Stock =@operacion where nombre=@nombre",Conexion);
            SqlCommand max = new SqlCommand("select MAX(idventa) from Ventas;", Conexion);
            int idventa = (int)max.ExecuteScalar();
            DateTime hoy = DateTime.Now;
            string fecha = /*hoy.ToString("dd/MM/yyyy");*/"getdate()";
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    SqlCommand num = new SqlCommand("select Stock from productos where nombre='"+Convert.ToString(row.Cells["Nombre"].Value)+"'", Conexion);
                    int contar = (int)num.ExecuteScalar();
                    Agregar.Parameters.Clear();
                    Editar.Parameters.Clear();
                    Agregar.Parameters.AddWithValue("@idventa", (idventa+1));
                    Agregar.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells["Cantidad"].Value));
                    Agregar.Parameters.AddWithValue("@nombre", Convert.ToString(row.Cells["Nombre"].Value));
                    Agregar.Parameters.AddWithValue("@total", Convert.ToDouble(row.Cells["Total"].Value));
                    Agregar.Parameters.AddWithValue("@fecha", DateTime.Now);
                    Agregar.Parameters.AddWithValue("@comentario", Convert.ToString(textBox1.Text));
                    Agregar.Parameters.AddWithValue("@empleada", Convert.ToString(comboBox1.SelectedItem));
                    Editar.Parameters.AddWithValue("@operacion",contar-(Convert.ToInt32(row.Cells["Cantidad"].Value)));
                    Editar.Parameters.AddWithValue("@nombre", Convert.ToString(row.Cells["Nombre"].Value));
                    Agregar.ExecuteNonQuery();
                    Editar.ExecuteNonQuery();
                }
                if (checkBox1.Checked == true)
                {
                    Crystal c = new Crystal();
                    DialogResult resultado = new DialogResult();
                    resultado = c.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                    }
                    else
                    {

                    }
                }
                checkBox1.Checked = false;
                ctotal = 0.00;
                txtTotal.Text = "$ 00.00";
                textBox1.Text = "";
                button2.Enabled = false;
                button3.Enabled = false;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }
            Conexion.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String temporal = dataGridView1.CurrentRow.Cells["Total"].Value.ToString();
                double menos = Convert.ToDouble(temporal);
                ctotal = ctotal - menos;
                String temp = ctotal.ToString("00.00");
                txtTotal.Text = "$ " + temp;
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch (Exception m)
            {

            } 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
