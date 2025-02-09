using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    public class Fusion: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string _libelle;
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
        public int _codeFUSION;
        public int CodeFUSION
        {
            get { return _codeFUSION; }
            set
            {
                if (_codeFUSION != value)
                {
                    _codeFUSION = value;
                    OnPropertyChanged(nameof(CodeFon));
                }
            }
        }
        public int _etat;
        public int Etat
        {
            get { return _etat; }
            set
            {
                if (_etat != value)
                {
                    _etat = value;
                    OnPropertyChanged(nameof(Etat));
                }
            }
        }


        public static List<Fusion> GetFusion(int _idFUSION = 0, string _libelle="", int _codeFon = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from fusion", con);
            if (_idFUSION != 0)
            {
                cmd.CommandText = "select * from fusion where CodeFUSION = @id";
                cmd.Parameters.AddWithValue("@id", _idFUSION);
            }
            if (_codeFon != 0 && _libelle!="")
            {
                cmd.CommandText = "select * from fusion where codeFon = @codeF and libelle = @lib";
                cmd.Parameters.AddWithValue("@codeF", _codeFon);
                cmd.Parameters.AddWithValue("@lib", _libelle);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            List<Fusion> liste = new List<Fusion>();
            foreach (DataRow item in data.Rows)
            {
                Fusion fusion = new Fusion()
                {
                    CodeFUSION = Convert.ToInt32(item["codeFUSION"].ToString()),
                    Libelle = item["Libelle"].ToString(),
                    CodeFon = Convert.ToInt32(item["codefon"].ToString()),
                    Etat = Convert.ToInt32(item["Etat"].ToString())
                };
                liste.Add(fusion);
            }
            con.Close();
            return liste;
        }
    }
}
