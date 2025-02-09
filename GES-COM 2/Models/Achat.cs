using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GES_COM_2.Models
{
    public class Achat : INotifyPropertyChanged
    {
        public Achat()
        {
            this.Lignes = new List<Ligneachat>();
            this.N_achat = App.LastId("achat", "N_achat");
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

        public string DateStr
        {
            get
            {
                return Date.ToLongDateString();
            }
            set { }
        }

        private int _idutili;
        public int Idutili
        {
            get { return _idutili; }
            set
            {
                if (_idutili != value)
                {
                    _idutili = value;
                    OnPropertyChanged(nameof(Idutili));
                }
            }
        }
        private int _idclient;
        public int Idclient
        {
            get { return _idclient; }
            set
            {
                if (_idclient != value)
                {
                    _idclient = value;
                    OnPropertyChanged(nameof(Idclient));
                }
            }
        }
        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        private double _montantTotalAc;
        public double MontantTotalAc
        {
            get { return _montantTotalAc; }
            set
            {
                if (_montantTotalAc != value)
                {
                    _montantTotalAc = value;
                    OnPropertyChanged(nameof(MontantTotalAc));
                }
            }
        }

        private double _montantVerse;
        public double MontantVerse
        {
            get { return _montantVerse; }
            set
            {
                if (_montantVerse != value)
                {
                    _montantVerse = value;
                    OnPropertyChanged(nameof(MontantVerse));
                }
            }
        }

        private List<Ligneachat> _lignes;
        public List<Ligneachat> Lignes
        {
            get {
                return _lignes;
            }
            set
            {
                if (_lignes != value)
                {
                    _lignes = value;
                    OnPropertyChanged(nameof(Lignes));
                }
            }
        }

        public static List<Ligneachat> GetLignes(int id )
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * From ligneachat where N_achat = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            List<Ligneachat> liste = new List<Ligneachat>();
            foreach (DataRow item in data.Rows)
            {
                Ligneachat ach = new Ligneachat()
                {
                    N_achat = Convert.ToInt32(item["n_achat"].ToString()),
                    N_ligneA = Convert.ToInt32(item["N_ligneA"].ToString()),
                    PrixU = Convert.ToInt32(item["PrixU"].ToString()),
                    QuantiteLAC = Convert.ToInt32(item["QuantiteLAC"].ToString()),
                    Totaux = Convert.ToDouble(item["MontantTotalLAc"].ToString()),
                    N_art = Convert.ToInt32(item["n_art"].ToString())
                };
                liste.Add(ach);
            };
            con.Close();
            return liste;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<Achat> GetAchat(int _idAchat = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from achat", con);
            if (_idAchat != 0)
            {
                cmd.CommandText = "select * from achat where n_achat = @id";
                cmd.Parameters.AddWithValue("@id", _idAchat);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            ObservableCollection<Achat> liste = new ObservableCollection<Achat>();
            foreach (DataRow item in data.Rows)
            {
                Achat ach = new Achat()
                {
                    N_achat = Convert.ToInt32(item["n_achat"].ToString()),
                    Idutili = Convert.ToInt32(item["idutili"].ToString()),
                    Idclient = Convert.ToInt32(item["idclient"].ToString()),
                    Date = Convert.ToDateTime(item["Date"].ToString()),
                    MontantTotalAc = Convert.ToDouble(item["MontantTotalAc"].ToString())
                };
                liste.Add(ach);
            };
            con.Close();
            return liste;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

      