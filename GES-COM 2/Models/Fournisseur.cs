using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    public class Fournisseur : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int _idfourni;
        public int idfourni
        {
            get { return _idfourni; }
            set
            {
                if (_idfourni != value)
                {
                    _idfourni = value;
                    OnPropertyChanged(nameof(idfourni));
                }
            }
        }
        public string _nom;
        public string Nom
        {
            get { return _nom; }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged(nameof(Nom));
                }
            }
        }
        public string _telFOURNI;
        public string TelFOURNI
        {
            get { return _telFOURNI; }
            set
            {
                if (_telFOURNI != value)
                {
                    _telFOURNI = value;
                    OnPropertyChanged(nameof(TelFOURNI));
                }
            }
        }
        public string _adresse;
        public string Adresse
        {
            get { return _adresse; }
            set
            {
                if (_adresse != value)
                {
                    _adresse = value;
                    OnPropertyChanged(nameof(Adresse));
                }
            }
        }
        public static bool fournisseurExiste(Fournisseur fournisseur)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from fournisseur where Idfourni = @id", con);
            cmd.Parameters.AddWithValue("@id", fournisseur.idfourni);
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            return data.Rows.Count != 0;
        }
    }
}
