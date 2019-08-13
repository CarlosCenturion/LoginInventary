using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
    



namespace Datos
{
  public class CD_CSQL_Usuarios
    {
        CD_ConeccionSQL con = new CD_ConeccionSQL();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlDataReader dr;



        public void Insert(string user,string password)
        {

            cmd.Connection = con.SQLOn(); 
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Insertar";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", password);
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
            cmd.CommandText = "Eliminar";
            cmd.Parameters.AddWithValue("@userid", id);           
            cmd.ExecuteNonQuery();
            con.SQLOff();
            cmd.Parameters.Clear();
        }

        public DataTable RefrescarUsuarios()
        {          
           
            cmd.Connection = con.SQLOn();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "RefrescarUsuarios";
            dr = cmd.ExecuteReader(); ;
            dt.Load(dr);
            con.SQLOff();
            return dt;            

        }


    }
}
