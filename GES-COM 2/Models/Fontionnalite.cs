using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    public class Fontionnalite: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int _codeFon;
        public int CodeFon
        {
            get { return _codeFon; }
            set
            {
                if (_codeFon != value)
                {
                    _codeFon = value;
                    OnPropertyChanged(nameof(CodeFon));
                }
            }
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

        public static List<Fontionnalite> GetFonctionnalite(int _IdFon = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from Fonctionnalite", con);
            if (_IdFon != 0)
            {
                cmd.CommandText = "select * from fontionnalite where CodeFon = @id";
                cmd.Parameters.AddWithValue("@id", _IdFon);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            List<Fontionnalite> liste = new List<Fontionnalite>();
            foreach (DataRow item in data.Rows)
            {
                Fontionnalite Fon = new Fontionnalite()
                {
                    CodeFon = Convert.ToInt32(item["CodeFon"].ToString()),
                    Libelle = item["Libelle"].ToString(),

                };
                liste.Add(Fon);
            };
            con.Close();
            return liste;
        }
    }
}
