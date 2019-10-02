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
    public partial class Crystal : Form
    {
        public SqlConnection Conexion = new SqlConnection("Server=LAPTOP-KF9P88JK\\SQLEXPRESS;DataBase=Papeleria;Integrated Security=true");
        public Crystal()
        {
            InitializeComponent();
        }
        private void llenareporte()
        {
            var da = new SqlDataAdapter();
            var ds = new dsTallerCr();

            string sqlEmployees = "select * from ventas where idventa=(select max(idventa) from ventas)";
            //string sqlProducts = "select * from Products";
            //string sqlCustomers = "select * from Customers";

            var cmd = new SqlCommand("", Conexion);
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = sqlEmployees;
            da.SelectCommand = cmd;
            da.Fill(ds.Tables["Ventas"]);


            //cmd.CommandText = sqlProducts;
            //da.SelectCommand = cmd;
            //da.Fill(ds.Tables["Products"]);

            //cmd.CommandText = sqlCustomers;
            //da.SelectCommand = cmd;
            //da.Fill(ds.Tables["Customers"]);


            var rptPractica61 = new ReporteDeVenta();

            rptPractica61.SetDataSource(ds);

            //rptPractica61.Subreports[0].SetDataSource(ds);

            this.crystalReportViewer1.ReportSource = rptPractica61;

            this.crystalReportViewer1.Show();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            llenareporte();
        }
    }
}
