
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    
  public  class BD
    {
        public static MySqlConnection con = new MySqlConnection();
        public static MySqlConnection InitConnexion(string _user="root", string _password="", string _server="localhost", uint _port = 3306)
        {
            //Methode qui initialise la connexion a la bd
            MySqlConnectionStringBuilder bld = new MySqlConnectionStringBuilder();
            bld.Server=_server;
            bld.Password = _password;
            bld.UserID = _user;
            bld.Port = _port;
            bld.Database = "Elogest";
            bld.ConvertZeroDateTime = true;
            con.Close();
            con.ConnectionString = bld.ConnectionString;
            return con;
        }
    }
 }

