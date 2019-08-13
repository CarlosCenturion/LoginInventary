using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Controlador
{
    public class CC_Productos
    {
        CD_ConeccionSQL con = new CD_ConeccionSQL();
        CD_CSQL_Producto prod = new CD_CSQL_Producto();           

       

        public void EliminarProducto(string id)
        {
            prod.Delete(Convert.ToInt32(id));
        }

        public void AgregarProducto(string product, string description, string marca, string precio, string cantidad)
        {
            prod.Insert(product, description,marca,Convert.ToDouble(precio),Convert.ToInt32(cantidad));
        }

        public DataTable LogIn(string user, string pass)
        {
            DataTable dt = prod.LogIn(user, pass);
            return dt;
        }

        public DataTable RefrescarProductos()
        {
            DataTable dt = prod.Refrescar();
            return dt;
        }

        public void EditarProducto(string name, string desc, string marca, string prize, string cant, string id)
        {
            prod.Editar(name, desc, marca, Convert.ToDouble(prize), Convert.ToInt32(cant), Convert.ToInt32(id));
            
        }





    }
}
