using GES_COM_2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GES_COM_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static int idUtilisateur = 1;
        internal static string profilUtilisateur = "";
        public static int LastId(string tableName, string idName)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT MAX({idName}) from {tableName}", con);
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            String res = 1.ToString();
            if (data.Rows.Count == 1)
            {
                res = data.Rows[0][0].ToString();
            }
            else
            {
                res = "1";
            }
            con.Close();
            try
            {
                int x = Convert.ToInt32(res);
                x++;
                return x;
            }
            catch
            {
                return 1;
            }
        }
    }
}
