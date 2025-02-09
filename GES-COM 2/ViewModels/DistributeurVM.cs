using GES_COM_2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GES_COM_2.ViewModels
{
    class DistributeurVM : ViewModelBase
    {
        public static ObservableCollection<Fournisseur> _fournisseurs = new ObservableCollection<Fournisseur>();
        public ObservableCollection<Fournisseur> Fournisseurs
        {
            get { return _fournisseurs; }
            set
            {
                if (_fournisseurs != value) 
                {
                    _fournisseurs = value;
                    OnPropertyChanged(nameof(Fournisseur));
                }
            }

        }
        private static ObservableCollection<Fournisseur> _filteredFournisseurs = new ObservableCollection<Fournisseur>();
        public ObservableCollection<Fournisseur> FilteredFournisseurs
        {
            get
            {
                return _filteredFournisseurs;
            }
            set
            {
                if (_filteredFournisseurs != value)
                {
                    _filteredFournisseurs = value;
                    OnPropertyChanged(nameof(FilteredFournisseurs));
                }
            }
        }
        public ObservableCollection<Fournisseur> FilterFournisseurs(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                FilteredFournisseurs = Fournisseurs;
                return FilteredFournisseurs;
            }
            FilteredFournisseurs = new ObservableCollection<Fournisseur>(Fournisseurs.Where(a => a.Nom.ToLower().Contains(txt.ToLower())));
            return FilteredFournisseurs;
        }
        public static ObservableCollection<Fournisseur> GetFournisseur(int _Idfourni = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from fournisseur", con);
            if (_Idfourni != 0)
            {
                cmd.CommandText = "select * from fournisseur where idfourni = @id";
                cmd.Parameters.AddWithValue("@id", _Idfourni);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            ObservableCollection<Fournisseur> liste = new ObservableCollection<Fournisseur>();
            foreach (DataRow item in data.Rows)
            {
                Fournisseur fourni = new Fournisseur()
                {
                    idfourni = Convert.ToInt32(item["idfourni"].ToString()),
                    Nom = item["Nom"].ToString(),
                    Adresse = item["Adresse"].ToString(),
                    // Prenom = item["prenom"].ToString(),
                    TelFOURNI = item["TelFOURNI"].ToString(),
                };
                liste.Add(fourni);
            }
            con.Close();
            return liste;
        }
        public static int SaveFournisseur(Fournisseur _Fournisseur)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into Fournisseur (idfourni,Nom,TelFOURNI,Adresse) values (@idfourni,@Nom,@Telfourni,@Adresse)", con);
            cmd.Parameters.AddWithValue("@idfourni", _Fournisseur.idfourni);
            cmd.Parameters.AddWithValue("@Nom", _Fournisseur.Nom);
            cmd.Parameters.AddWithValue("@Adresse", _Fournisseur.Adresse);
            // cmd.Parameters.AddWithValue("@Prenom", _Fournisseur.Prenom);
            cmd.Parameters.AddWithValue("@Telfourni", _Fournisseur.TelFOURNI);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            _fournisseurs.Add(_Fournisseur);
            return result;
        }
        public static int ModifFournisseur(Fournisseur _Fournisseur)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update Fournisseur set Nom=@Nom,TelFOURNI=@TelFOURNI where idfourni=@idfourni ", con);
            cmd.Parameters.AddWithValue("@Nom", _Fournisseur.Nom);
            // cmd.Parameters.AddWithValue("@Prenom", _Fournisseur.Prenom);
            cmd.Parameters.AddWithValue("@TelFOURNI", _Fournisseur.TelFOURNI);
            cmd.Parameters.AddWithValue("@idfourni", _Fournisseur.idfourni);
            cmd.Parameters.AddWithValue("@Adresse", _Fournisseur.Adresse);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public static int SupFournisseur(Fournisseur _Fournisseur)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from Fournisseur where idfourni=@idfourni", con);
            cmd.Parameters.AddWithValue("@idfourni", _Fournisseur.idfourni);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            _fournisseurs.Remove(_Fournisseur);
            return result;
        }
        public DistributeurVM()
        {
            Fournisseurs = GetFournisseur();
            FilteredFournisseurs = Fournisseurs;
        }
        
    }
}

