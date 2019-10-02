using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapadeDatos;
using System.Data.SqlClient;
using System.Data;

namespace CapadeNegocio
{
    public class CNEmpleado
    {
        private CDEmpleados objDato = new CDEmpleados();
        private String _Usuario;
        private String _Contraseña;
        //
        public String Usuario
        {
            set
            {
                if (value == "Usuario")
                {
                    _Usuario = "No ha ingresado usuario";
                }
                else
                {
                    _Usuario = value;
                }
            }
            get { return _Usuario; }
        }
        public String Contraseña
        {
            set { _Contraseña = value; }
            get { return _Contraseña; }
        }
        public CNEmpleado()
        {

        }
        public SqlDataReader IniciarSesion()
        {
            SqlDataReader Loguear;
            Loguear = objDato.iniciarSesion(Usuario, Contraseña);
            return Loguear;
        }
    }
}
