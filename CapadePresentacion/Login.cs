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
using System.Data.SqlClient;
using System.Data;

namespace CapadePresentacion

{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            CNEmpleado objEmpleado = new CNEmpleado();
            SqlDataReader Loguear;
            objEmpleado.Usuario = txtuser.Text;
            objEmpleado.Contraseña = txtpass.Text;
            if (objEmpleado.Usuario == txtuser.Text)
            {

                Loguear = objEmpleado.IniciarSesion();
                
                if (Loguear.Read() == true)
                {
                    Program.cargo = Loguear["cargo"].ToString();
                    Program.nombre = Loguear["nombre"].ToString();
                    Program.apellido = Loguear["apellido"].ToString();
                    if (Program.cargo != "Propietaria")
                    {
                        this.Hide();
                        Menu ObjFP = new Menu();
                        Program.cargo = Loguear["cargo"].ToString();
                        Program.nombre = Loguear["nombre"].ToString();
                        Program.apellido = Loguear["apellido"].ToString();
                        ObjFP.Show();
                    }
                    else {
                        this.Hide();
                        Menu ObjFP = new Menu();
                        Program.cargo = Loguear["cargo"].ToString();
                        Program.nombre = Loguear["nombre"].ToString();
                        Program.apellido = Loguear["apellido"].ToString();
                        ObjFP.Show();
                    }
                    
                }
                else
                {
                    btErrorLogin.Text = "Usuario o contraseña invalidas, intente de nuevo";
                    btErrorLogin.Visible = true;
                    txtpass.Text = "";
                }
            }
            else {
                MessageBox.Show(objEmpleado.Usuario);
            }

        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btErrorUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btErrorContraseña_Click(object sender, EventArgs e)
        {

        }

        private void btErrorLogin_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
