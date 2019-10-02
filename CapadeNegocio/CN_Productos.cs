using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapadeDatos;
namespace CapadeNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();
        public DataTable MostrarProdu()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarVenta();
            return tabla;
        }
        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public DataTable MostrarSer()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarServicios();
            return tabla;
        }
        public void InsertarServicio(string concepto, string comentario, string costo)
        {
            objetoCD.InsertarServicio(concepto,comentario, Convert.ToDouble(costo));
        }
        public void InsertarPRod(string nombre, string descripcion, string marca, string precio, string STOCK)
        {
            objetoCD.Insertar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(STOCK));
        }
        public void EditarProd(string nombre, string descripcion, string marca, string precio, string STOCK, string id)
        {
            objetoCD.Editar(nombre, descripcion, marca, Convert.ToDouble(precio), Convert.ToInt32(STOCK),Convert.ToInt32(id));
        }
        public void EliminarProd(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
