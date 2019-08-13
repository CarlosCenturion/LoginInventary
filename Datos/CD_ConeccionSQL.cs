using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Datos
{
    public class CD_ConeccionSQL
    {
        // MODIFICA ESTA LINEA POR LA DE LAS PROPIEDADES DE CONECCION DE TU SQL
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Work\Documents\JuramentoDB.mdf;Integrated Security=True;Connect Timeout=30");
        

        
        public SqlConnection SQLOn()
        {           
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
            

                return con;        
        }
        public SqlConnection SQLOff()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return con;
        }

      



    }
}
