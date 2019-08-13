using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
    



namespace Datos
{
  public class CD_CSQL_Producto
    {
        CD_ConeccionSQL con = new CD_ConeccionSQL();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlDataReader dr;



        public void Insert(string product,string description,string marca,double precio,int cantidad)
        {

            cmd.Connection = con.SQLOn(); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertarProducto";
            cmd.Parameters.AddWithValue("@prod", product);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.Parameters.AddWithValue("@marca", marca);
            cmd.Parameters.AddWithValue("@price", precio);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.ExecuteNonQuery();
            con.SQLOff();
            cmd.Parameters.Clear();

        }

        public DataTable LogIn(string user,string pass)
        {
            cmd.Connection = con.SQLOn();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "chkUser";
            cmd.Parameters.AddWithValue("@userid", user);
            cmd.Parameters.AddWithValue("@userpassword", pass);
            dr = cmd.ExecuteReader();          
            DataTable dt = new DataTable();
            dt.Load(dr);
            con.SQLOff();
            cmd.Parameters.Clear();
            return dt;

        }

        public void Delete(int id)
        {
            cmd.Connection = con.SQLOn();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "EliminarProducto";
            cmd.Parameters.AddWithValue("@id", id);           
            cmd.ExecuteNonQuery();
            con.SQLOff();
            cmd.Parameters.Clear();
        }

        public DataTable Refrescar()
        {          
           
            cmd.Connection = con.SQLOn();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "RefrescarProductos";
            dr = cmd.ExecuteReader(); ;
            dt.Load(dr);
            con.SQLOff();
            return dt;            

        }

        public void Editar(string name,string desc,string marca,double prize,int cant,int id)
        {
            cmd.Connection = con.SQLOn();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EditarProducto";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@desc", desc);
            cmd.Parameters.AddWithValue("@marca", marca);
            cmd.Parameters.AddWithValue("@prize", prize);
            cmd.Parameters.AddWithValue("@cant", cant);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.SQLOff();
            cmd.Parameters.Clear();
        }


    }
}
