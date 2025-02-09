using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    public class Profil : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _libelle;
        public string Libelle
        {
            get { return _libelle; }
            set
            {
                if (_libelle != value)
                {
                    _libelle = value;
                    OnPropertyChanged(nameof(Libelle));
                }
            }
        }
        public static List<Profil> GetLibelle(int _idLibelle = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from profil", con);
            if (_idLibelle != 0)
            {
                cmd.CommandText = "select * from profil where libelle = @id";
                cmd.Parameters.AddWithValue("@id", _idLibelle);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            List<Profil> liste = new List<Profil>();
            foreach (DataRow item in data.Rows)
            {
                Profil profil = new Profil()
                {
                    Libelle = item["Libelle"].ToString(),

                };
                liste.Add(profil);
            };
            con.Close();
            return liste;
        }
    }
}
