using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Controlador
{
    public class CC_Usuarios
    {
        CD_ConeccionSQL con = new CD_ConeccionSQL();
        CD_CSQL_Usuarios users = new CD_CSQL_Usuarios();

        public void SQLOn()
        {
            con.SQLOn();
        }

        public void SQLOff()
        {
            con.SQLOff();
        }

        public void EliminarUsuario(string id)
        {
            users.Delete(Convert.ToInt32(id));
        }

        public void AgregarUsuario(string user, string password)
        {
            users.Insert(user, password);
        }

        public DataTable LogIn(string user, string pass)
        {
            DataTable dt = users.LogIn(user, pass);
            return dt;
        }

        public DataTable RefrescarUsuarios()
        {
            DataTable dt = users.RefrescarUsuarios();
            return dt;
        }
                     
    }
}
