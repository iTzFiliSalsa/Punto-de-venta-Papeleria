using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace CapadeDatos
{
    public class CD_Productos
    {
        private CDConexion conexion = new CDConexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        public DataTable MostrarVenta()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarVenta";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable MostrarServicios()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarServices";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void autocompletar(TextBox cajatexto)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "Select * from Productos";
                comando.CommandType = CommandType.Text;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    cajatexto.AutoCompleteCustomSource.Add(dr["Nombre"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public void total(Label txtTotal,string nombre)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "Select precio from Productos where nombre='"+nombre+"';";
                comando.CommandType = CommandType.Text;
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    
                    txtTotal.Text = dr.GetValue(4).ToString();
                    String precio = dr.ToString();

                }
                dr.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public void Insertar(string nombre, string descripcion,string marca, double precio, int STOCK)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",nombre);
            comando.Parameters.AddWithValue("@desc", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", STOCK);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void InsertarServicio(string nombre, string Comentario, double total)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarSer";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@comentario", Comentario);
            comando.Parameters.AddWithValue("@total", total);
            comando.Parameters.AddWithValue("@fecha", DateTime.Now);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Editar(string nombre, string descripcion, string marca, double precio, int STOCK, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", descripcion);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", STOCK);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Eliminar( int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
