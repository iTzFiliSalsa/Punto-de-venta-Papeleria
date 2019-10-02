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
namespace CapadePresentacion
{
    public partial class Cuentas : Form
    {
        public SqlConnection Conexion = new SqlConnection("Server=LAPTOP-KF9P88JK\\SQLEXPRESS;DataBase=Papeleria;Integrated Security=true");
        SqlCommand global;
        DateTime fechaactual = DateTime.Today;
        SqlDataReader lectura;
        public Cuentas()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ganancias.Text.Equals("GANANCIAS DEL MES") && producto.Text.Equals("PRODUCTO DEL MES") && empleada.Text.Equals("EMPLEADA DEL MES"))
            {
                this.pictureBox4.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\gandia.png");
                this.pictureBox3.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\prodia.png");
                this.pictureBox5.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\empdia.png");
                int mes = timeventas.Value.Month;
                int dia = timeventas.Value.Day;
                int año = timeventas.Value.Year;
                string elm = "";
                string eld = "";
                if (mes < 10)
                {
                    elm = "0" + mes;
                }
                else
                {
                    elm = "" + mes;
                }
                if (dia < 10)
                {
                    eld = "0" + dia;
                }
                else
                {
                    eld = "" + dia;
                }
                ganancias.Text = "GANANCIAS DEL DIA";
                producto.Text = "PRODUCTO DEL DIA";
                empleada.Text = "EMPLEADA DEL DIA";
                Conexion.Open();
                SqlCommand max = new SqlCommand("select sum(total) from ventas where (Fecha like '" + año + "-" + elm + "-" + eld + "')", Conexion);
                string idventa = Convert.ToString(max.ExecuteScalar());
                SqlCommand emp = new SqlCommand("select MAX(empleada) from ventas where (Fecha like '" + año + "-" + elm + "-" + eld + "')", Conexion);
                string empm = Convert.ToString(emp.ExecuteScalar());
                SqlCommand mv = new SqlCommand("select TOP 1 nombre from ventas where  total = (select MAX(total) from ventas where Fecha ='" + año + "-" + elm + "-" + eld + "')", Conexion);
                string cmv = (string)mv.ExecuteScalar();
                label2.Text = "$ " + idventa;
                label7.Text = empm;
                label4.Text = "" + cmv;
                SqlCommand cm = new SqlCommand("Select * from Ventas where fecha=" + "'" + timeventas.Value.ToString("yyyyMMdd") + "'", Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                Conexion.Close();
            }
            else
            {
                try
                {
                    Conexion.Open();
                    // ganancias.Text = "" + fechaactual.Month;
                    int mes = timeventas.Value.Month;
                    int dia = timeventas.Value.Day;
                    int año = timeventas.Value.Year;
                    string elm = "";
                    string eld = "";
                    if (mes < 10)
                    {
                        elm = "0" + mes;
                    }
                    else
                    {
                        elm = "" + mes;
                    }
                    if (dia < 10)
                    {
                        eld = "0" + dia;
                    }
                    else
                    {
                        eld = "" + dia;
                    }
                    //ganancias.Text = "" + mes;

                    //ganancias.Text = h+ "";
                    SqlCommand cm = new SqlCommand("select * from Ventas where(Fecha like '%-" + elm + "-%')", Conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    SqlCommand max = new SqlCommand("select sum(total) from ventas where (Fecha like '%-" + elm + "-%')", Conexion);
                    string idventa = Convert.ToString(max.ExecuteScalar());
                    SqlCommand emp = new SqlCommand("select MAX(empleada) from ventas where (Fecha like '%-" + elm + "-%')", Conexion);
                    string empm = Convert.ToString(emp.ExecuteScalar());
                    SqlCommand mv = new SqlCommand("select TOP 1 nombre from ventas where  total = (select MAX(total) from ventas where Fecha like '%-" + elm + "-%')", Conexion);
                    string cmv = (string)mv.ExecuteScalar();
                    label2.Text = "$ " + idventa;
                    label7.Text = empm;
                    label4.Text = "" + cmv;
                    Conexion.Close();
                    this.pictureBox4.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\ganmes.png");
                    this.pictureBox3.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\promes.png");
                    this.pictureBox5.Image = System.Drawing.Image.FromFile("C:\\Users\\filis\\Pictures\\Proyectos\\Sistema Papeleria\\empmes.png");
                    ganancias.Text = "GANANCIAS DEL MES";
                    producto.Text = "PRODUCTO DEL MES";
                    empleada.Text = "EMPLEADA DEL MES";
                }
                catch (Exception o)
                {
                    MessageBox.Show("" + o);
                }
            }
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {
            try
            {

                Conexion.Open();
                SqlCommand cm = new SqlCommand("Select * from Ventas where fecha=" + "'" + DateTime.Now.ToString("yyyyMMdd") + "'", Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                int mes = timeventas.Value.Month;
                int dia = timeventas.Value.Day;
                int año = timeventas.Value.Year;
                string elm = "";
                string eld = "";
                if (mes < 10)
                {
                    elm = "0" + mes;
                }
                else
                {
                    elm = "" + mes;
                }
                if (dia < 10)
                {
                    eld = "0" + dia;
                }
                else
                {
                    eld = "" + dia;
                }
                SqlCommand max = new SqlCommand("select sum(total) from ventas where (Fecha like '" + año + "-" + elm + "-" + eld + "')", Conexion);
                string idventa = Convert.ToString(max.ExecuteScalar());
                SqlCommand emp = new SqlCommand("select MAX(empleada) from ventas where (Fecha like '" + año + "-" + elm + "-" + eld + "')", Conexion);
                string empm = Convert.ToString(emp.ExecuteScalar());
                SqlCommand mv = new SqlCommand("select TOP 1 nombre from ventas where  total = (select MAX(total) from ventas where Fecha ='" + año + "-" + elm + "-" + eld + "')", Conexion);
                    string cmv = (string)mv.ExecuteScalar();
                    label2.Text = "$ " + idventa;
                    label7.Text = empm;
                    label4.Text = "" + cmv;
                Conexion.Close();
            }catch(Exception i)
            {
                MessageBox.Show(""+i);
            }
        }

        private void timeventas_ValueChanged(object sender, EventArgs e)
        {
            actualizar();
        }
        private void actualizar()
        {
            if (ganancias.Text.Equals("GANANCIAS DEL MES") && producto.Text.Equals("PRODUCTO DEL MES") && empleada.Text.Equals("EMPLEADA DEL MES"))
            {

                
                //////////////////////////////////////////////
                ///
                Conexion.Open();
                // ganancias.Text = "" + fechaactual.Month;
                int mes = timeventas.Value.Month;
                int dia = timeventas.Value.Day;
                int año = timeventas.Value.Year;
                string elm = "";
                string eld = "";
                if (mes < 10)
                {
                    elm = "0" + mes;
                }
                else
                {
                    elm = "" + mes;
                }
                if (dia < 10)
                {
                    eld = "0" + dia;
                }
                else
                {
                    eld = "" + dia;
                }
                //ganancias.Text = "" + mes;

                //ganancias.Text = h+ "";
                SqlCommand cm = new SqlCommand("select * from Ventas where(Fecha like '%-" + elm + "-%')", Conexion);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                SqlCommand max = new SqlCommand("select sum(total) from ventas where (Fecha like '%-" + elm + "-%')", Conexion);
                string idventa = Convert.ToString(max.ExecuteScalar());
                SqlCommand emp = new SqlCommand("select MAX(empleada) from ventas where (Fecha like '%-" + elm + "-%')", Conexion);
                string empm = Convert.ToString(emp.ExecuteScalar());
                SqlCommand mv = new SqlCommand("select TOP 1 nombre from ventas where  total = (select MAX(total) from ventas where Fecha like '%-" + elm + "-%')", Conexion);
                string cmv = (string)mv.ExecuteScalar();
                label2.Text = "$ " + idventa;
                label7.Text = empm;
                label4.Text = "" + cmv;
                Conexion.Close();

            }
            else
            {
                try
                {
                    int mes = timeventas.Value.Month;
                    int dia = timeventas.Value.Day;
                    int año = timeventas.Value.Year;
                    string elm = "";
                    string eld = "";
                    if (mes < 10)
                    {
                        elm = "0" + mes;
                    }
                    else
                    {
                        elm = "" + mes;
                    }
                    if (dia < 10)
                    {
                        eld = "0" + dia;
                    }
                    else
                    {
                        eld = "" + dia;
                    }
                    Conexion.Open();
                    SqlCommand max = new SqlCommand("select sum(total) from ventas where (Fecha like '" + año + "-" + elm + "-" + eld + "')", Conexion);
                    string idventa = Convert.ToString(max.ExecuteScalar());
                    SqlCommand emp = new SqlCommand("select MAX(empleada) from ventas where (Fecha like '" + año + "-" + elm + "-" + eld + "')", Conexion);
                    string empm = Convert.ToString(emp.ExecuteScalar());
                    SqlCommand mv = new SqlCommand("select TOP 1 nombre from ventas where  total = (select MAX(total) from ventas where Fecha ='" + año + "-" + elm + "-" + eld + "')", Conexion);
                    string cmv = (string)mv.ExecuteScalar();
                    label2.Text = "$ " + idventa;
                    label7.Text = empm;
                    label4.Text = "" + cmv;
                    SqlCommand cm = new SqlCommand("Select * from Ventas where fecha=" + "'" + timeventas.Value.ToString("yyyyMMdd") + "'", Conexion);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    Conexion.Close();
                }
                catch (Exception o)
                {
                    MessageBox.Show("" + o);
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
           // actualizar();
        }
    }
}
