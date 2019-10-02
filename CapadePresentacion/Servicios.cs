using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapadeNegocio;

namespace CapadePresentacion
{
    public partial class Servicios : Form
    {
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        CN_Productos objetoCN = new CN_Productos();
        public SqlConnection Conexion = new SqlConnection("Server=LAPTOP-KF9P88JK\\SQLEXPRESS;DataBase=Papeleria;Integrated Security=true");
        SqlCommand global;
        DateTime fechaactual = DateTime.Today;
        SqlDataReader lectura;
        public Servicios()
        {
            InitializeComponent();
        }
        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarSer();
        }
        private void Servicios_Load(object sender, EventArgs e)
        {
            Conexion.Open();
            SqlCommand cm = new SqlCommand("Select * from servicios", Conexion);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            Conexion.Close();
            contar();
        }
        public void contar()
        {
            Conexion.Open();
            DateTime fechaActual = DateTime.Today;
            SqlCommand cm = new SqlCommand("select SUM(total) from servicios where Fecha like '%-"+fechaActual.Month+"-%'", Conexion);
            string egresos = Convert.ToString(cm.ExecuteScalar());
            txtTotal.Text = "$ " + egresos;
           Conexion.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
               
                    if ((Concepto.Text == "") || (Costo.Text == "") || (Comentario.Text == "") || (Costo.Text == "."))
                    {
                        MessageBox.Show("Llene correctamente los campos");
                    }
                    else
                    {
                        objetoCN.InsertarServicio(Concepto.Text, Comentario.Text, Costo.Text);
                        MessageBox.Show("Se inserto Correctamente");
                        MostrarProductos();
                        Concepto.Text = "";
                        Costo.Text = "";
                        Comentario.Text = "";
                        Concepto.Focus();
                        contar();
                    }
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
        public bool solonumeros2(int code)
        {
            bool resultado;
            if (code == 46 && Costo.Text.Contains("."))//se evalua si es punto y si es punto se rebiza si ya existe en el textbox
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                Conexion.Open();
                DateTime fechita = DateTime.Now;
                SqlCommand cm = new SqlCommand("Select * from Servicios where fecha like '" + fechita.Year + "-" + fechita.Month + "-" + fechita.Day + "'", Conexion);
                SqlCommand suma = new SqlCommand("Select sum(total) from Servicios where fecha like '" + fechita.Year + "-" + fechita.Month + "-" + fechita.Day + "'", Conexion);
                string tot = Convert.ToString(suma.ExecuteScalar());
                txtTotal.Text = "$ " + tot;
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                Conexion.Close();
                label1.Text = "EGRESOS DEL DIA";
            }
            else
            {
                Conexion.Open();
                SqlCommand cm = new SqlCommand("Select * from servicios", Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                Conexion.Close();
                contar();
                label1.Text = "EGRESOS DEL MES";
            }
            
        }

        private void Costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = solonumeros2(Convert.ToInt32(e.KeyChar));
        }
    }
}
