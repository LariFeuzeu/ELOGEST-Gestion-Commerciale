using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace GES_COM_2.Models
{
    public class Ligneappro: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int _designation;
        public int Designation
        {
            get { return _designation; }
            set
            {
                if (_designation != value)
                {
                    _designation = value;
                    OnPropertyChanged(nameof(Designation));
                }
            }
        }
        private double _pu;
        public double Pu
        {
            get { return _pu; }
            set
            {
                if (_pu != value)
                {
                    _pu = value;
                    OnPropertyChanged(nameof(Pu));
                }
            }
        }
        private int _quantiteAPP;
        public int QuantiteAPP
        {
            get { return _quantiteAPP; }
            set
            {
                if (_quantiteAPP != value)
                {
                    _quantiteAPP = value;
                    OnPropertyChanged(nameof(QuantiteAPP));
                }
            }
        }
        private double _montantAPP;
        public double MontantAPP
        {
            get { return _montantAPP; }
            set
            {
                if (_montantAPP != value)
                {
                    _montantAPP = value;
                    OnPropertyChanged(nameof(MontantAPP));
                }
            }
        }

        public int _n_ligne;
        public int N_ligne
        {
            get { return _n_ligne; }
            set
            {
                if (_n_ligne != value)
                {
                    _n_ligne = value;
                    OnPropertyChanged(nameof(N_ligne));
                }
            }
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
        private DateTime _date_de_peremtion;
        public DateTime date_de_peremtion
        {
            get { return _date_de_peremtion; }
            set
            {
                if (_date_de_peremtion != value)
                {
                    _date_de_peremtion = value;
                    OnPropertyChanged(nameof(_date_de_peremtion));
                }
            }
        }


        public static void SaveLigne(Ligneappro _ligne)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into LigneAppro (n_appro,n_art,QuantiteApp,MontantApp,DateP) values (@nAppro,@nArt,@qte,@mt,@DateP)", con);
            cmd.Parameters.AddWithValue("@nAppro", _ligne.N_appro);
            cmd.Parameters.AddWithValue("@nArt", _ligne.N_art);
            cmd.Parameters.AddWithValue("@DateP", _ligne.date_de_peremtion.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@qte", _ligne.QuantiteAPP);
            cmd.Parameters.AddWithValue("@mt", _ligne.MontantAPP);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static List<Ligneappro> GetLigneappro(int _idligne = 0, int _nArt = 0, int _nAppro = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from Ligneappro", con);
            if (_idligne != 0)
            {
                cmd.CommandText = "select * from ligne where n_ligne = @id";
                cmd.Parameters.AddWithValue("@id", _idligne);
            }
            if (_nAppro != 0)
            {
                cmd.CommandText = "select * from ligneappro where N_Appro = @id";
                cmd.Parameters.AddWithValue("@id", _nAppro);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            List<Ligneappro> liste = new List<Ligneappro>();
            foreach (DataRow item in data.Rows)
            {
                Ligneappro ligneappro = new Ligneappro()
                {
                    N_ligne = Convert.ToInt32(item["n_ligne"].ToString()),
                    N_appro = Convert.ToInt32(item["n_appro"].ToString()),
                    N_art = Convert.ToInt32(item["n_art"].ToString()),
                    date_de_peremtion = Convert.ToDateTime(item["DateP"].ToString()),
                    QuantiteAPP = Convert.ToInt32(item["QuantiteAPP"].ToString()),
                    MontantAPP = Convert.ToDouble(item["MontantAPP"].ToString())
                };
                liste.Add(ligneappro);
            };
            con.Close();
            return liste;
        }
    }
}
  