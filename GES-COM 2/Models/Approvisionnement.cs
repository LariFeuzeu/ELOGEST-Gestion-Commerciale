using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GES_COM_2.Models
{
  public  class Approvisionnement : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Ligneappro> _lignes;

        public List<Ligneappro> Lignes
        {
            get
            {
                return _lignes;
            }
            set
            {
                if(_lignes != value)
                {
                    _lignes = value;
                    OnPropertyChanged(nameof(Lignes));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int _n_appro;
        public int N_appro
        {
            get { return _n_appro; }
            set
            {
                if (_n_appro != value)
                {
                    _n_appro = value;
                    OnPropertyChanged(nameof(N_appro));
                }
            }
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
        private int _idfourni;
        public int Idfourni
        {
            get { return _idfourni; }
            set
            {
                if (_idfourni != value)
                {
                    _idfourni = value;
                    OnPropertyChanged(nameof(Idutili));
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

        public string DateStr
        {
            get
            {
                return Date.ToLongDateString();
            }
            set { }
        }
        private double _montantTotalAPP;
        public double MontantTotalAPP
        {
            get { return _montantTotalAPP; }
            set
            {
                if (_montantTotalAPP != value)
                {
                    _montantTotalAPP = value;
                    OnPropertyChanged(nameof(MontantTotalAPP));
                }
            }
        }

        public static List<Ligneappro> GetLignes(int _nAppro)//retourner la liste d, un approvisionnement.
        {
            List<Ligneappro> _liste = new List<Ligneappro>();

            Ligneappro _ligne = Ligneappro.GetLigneappro(0, 0, _nAppro)[0];
            _liste.Add(_ligne);

            return _liste;
        }
        public Approvisionnement()
        {
            MontantTotalAPP = 0;
            Lignes = new List<Ligneappro>();
            this.N_appro = GetNewAppro();
        }
        public static int GetNewAppro()
        {
            int res = 1;
            //MySqlConnection con = BD.InitConnexion();
            if (BD.con.State != ConnectionState.Open)
                BD.con.Open();
            MySqlCommand cmd = new MySqlCommand("select max(n_appro) from approvisionnement", BD.con);
            try
            {
                res = Convert.ToInt32(cmd.ExecuteScalar());
                BD.con.Close();
                return res;
            }
            catch(Exception ex)
            {
            BD.con.Close();
                return 1;
            }

        }

        public static void SaveLigne(Ligneappro _ligne)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into LigneAppro (n_appro,n_art,QuantiteApp,MontantApp,DateP) values (@nAppro,@nArt,@qte,@mt,@DateP)", con);
            cmd.Parameters.AddWithValue("@nAppro", _ligne.N_appro);
            cmd.Parameters.AddWithValue("@nArt", _ligne.N_art);
            cmd.Parameters.AddWithValue("@DateP", _ligne.date_de_peremtion);
            cmd.Parameters.AddWithValue("@qte", _ligne.QuantiteAPP);
            cmd.Parameters.AddWithValue("@mt", _ligne.MontantAPP);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static ObservableCollection<Approvisionnement> GetApprovisionnement(int _idappro = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from Approvisionnement", con);
            if (_idappro != 0)
            {
                cmd.CommandText = "select * from Approvisionnement where N_appro = @id";
                cmd.Parameters.AddWithValue("@id", _idappro);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            ObservableCollection<Approvisionnement> liste = new ObservableCollection<Approvisionnement>();
            foreach (DataRow item in data.Rows)
            {
                Approvisionnement appro = new Approvisionnement()
                {
                    N_appro = Convert.ToInt32(item["N_appro"].ToString()),
                    Idutili = Convert.ToInt32(item["idutili"].ToString()),
                    Idfourni = Convert.ToInt32(item["idfourni"].ToString()),
                    Date = Convert.ToDateTime(item["date"].ToString()),
                    MontantTotalAPP = Convert.ToDouble(item["MontantTotalAPP"].ToString())
                };
                liste.Add(appro);
            }
            con.Close();
            return liste;
        }
 
    }
   
}
