using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapadeDatos
{
    public class CDEmpleados
    {
        private CDConexion Conexion = new CDConexion();
        private SqlDataReader leer;
        public SqlDataReader iniciarSesion(String user, String pass)
        {
            String sql = "Select * from USUARIOS WHERE usuario='" + user + "' AND contraseña='" + pass+"';";
            SqlCommand comando = new SqlCommand("SPinicio",Conexion.AbrirConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", user);
            comando.Parameters.AddWithValue("@PassWord", pass);
            leer = comando.ExecuteReader();
            return leer;
        }
    }
}
