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
    public class Ligneachat : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int _n_ligneA;
        public int N_ligneA
        {
            get { return _n_ligneA; }
            set
            {
                if (_n_ligneA != value)
                {
                    _n_ligneA = value;
                    OnPropertyChanged(nameof(N_ligneA));
                }
            }
        }

        public int _n_art;
        public int N_art
        {
            get { return _n_art; }
            set
            {
                if (_n_art != value)
                {
                    _n_art = value;
                    OnPropertyChanged(nameof(N_art));
                }
            }
        }
        public int _n_achat;
        public int N_achat
        {
            get { return _n_achat; }
            set
            {
                if (_n_achat != value)
                {
                    _n_achat = value;
                    OnPropertyChanged(nameof(N_achat));
                }
            }
        }

        private int _quantiteLAC;
        public int QuantiteLAC
        {
            get { return _quantiteLAC; }
            set
            {
                if (_quantiteLAC != value)
                {
                    _quantiteLAC = value;
                    OnPropertyChanged(nameof(QuantiteLAC));
                }
            }
        }
        private double _totaux;
        public double Totaux
        {
            get { return _totaux; }
            set
            {
                if (_totaux != value)
                {
                    _totaux = value;
                    OnPropertyChanged(nameof(Totaux));
                }
            }
        }
        private double _prixU;
        public double PrixU
        {
            get { return _prixU; }
            set
            {
                if (_prixU != value)
                {
                    _prixU = value;
                    OnPropertyChanged(nameof(PrixU));
                }
            }
        }


        public static List<Ligneachat> GetLigneachat(int _idligneA = 0, int _nArt = 0, int _nAchat = 0 )
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from Ligneachat", con);
            if (_idligneA != 0)
            {
                cmd.CommandText = "select * from ligneachat where n_ligneA = @id";
                cmd.Parameters.AddWithValue("@id", _idligneA);
            }
            if (_nAchat!= 0)
            {
                cmd.CommandText = "select * from ligneachat where N_Achat= @id";
                cmd.Parameters.AddWithValue("@id", _idligneA);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            List<Ligneachat> liste = new List<Ligneachat>();
            foreach (DataRow item in data.Rows)
            {
                Ligneachat lign = new Ligneachat()
                {
                    N_ligneA = Convert.ToInt32(item["n_ligneA"].ToString()),
                    N_art = Convert.ToInt32(item["N_Art"].ToString()),
                    N_achat = Convert.ToInt32(item["n_achat"].ToString()),
                    QuantiteLAC = Convert.ToInt32(item["QuantiteLAC"].ToString()),
                    Totaux = Convert.ToDouble(item["MontantAPP"].ToString()),
                    PrixU = Convert.ToDouble(item["PrixU"].ToString())
                };
                liste.Add(lign);
            };
            con.Close();
            return liste;
        }
    }
}

