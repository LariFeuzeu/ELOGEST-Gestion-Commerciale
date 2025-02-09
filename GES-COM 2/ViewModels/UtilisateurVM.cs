using GES_COM_2.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GES_COM_2.Views;
using GES_COM_2.Helpers;

namespace GES_COM_2.ViewModels
{
    class UtilisateurVM:ViewModelBase
    {
        private static ObservableCollection<Utilisateur> _utilisateurs = new ObservableCollection<Utilisateur>();
        public ObservableCollection<Utilisateur> Utilisateurs
        {
            get
            {
                return _utilisateurs;
            }
            set
            {
                if (_utilisateurs != value)
                {
                    _utilisateurs = value;
                  OnPropertyChanged(nameof(Utilisateurs));
                }
            }
        }

        private static ObservableCollection<Utilisateur> _filteredUsers = new ObservableCollection<Utilisateur>();
        public ObservableCollection<Utilisateur> FilteredUsers
        {
            get
            {
                return _filteredUsers;
            }
            set
            {
                if (_filteredUsers != value)
                {
                    _filteredUsers = value;
                    OnPropertyChanged(nameof(FilteredUsers));
                }
            }
        }
        public ObservableCollection<Utilisateur> FilterUsers(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                FilteredUsers = Utilisateurs;
                return FilteredUsers;
            }
            FilteredUsers = new ObservableCollection<Utilisateur>(Utilisateurs.Where(u => u.Nom.ToLower().Contains(txt.ToLower()) || u.Prenom.ToLower().Contains(txt.ToLower())));
            return FilteredUsers;  



        }

        public static ObservableCollection<Utilisateur> GetUtilisateur(string _Idutili ="?")
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from utilisateur", con);
            if (_Idutili != "?")
            {
                cmd.CommandText = "select * from fournisseur where Idutili = @id";
                cmd.Parameters.AddWithValue("@id", _Idutili);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            ObservableCollection<Utilisateur> liste = new ObservableCollection<Utilisateur>();
            foreach (DataRow item in data.Rows)
            {
                Utilisateur utili = new Utilisateur()
                {
                    Idutili = Convert.ToInt32(item["idutili"].ToString()),
                    Libelle = item["Libelle"].ToString(),
                    Nom = item["Nom"].ToString(),
                    Prenom = item["prenom"].ToString(),
                    TelUT = item["TelUT"].ToString(),
                    Motdepasse = item["Motdepasse"].ToString()
                };
                liste.Add(utili);
            }
            con.Close();
            return liste;
        }
        public static int SaveUtilisateur(Utilisateur _Utilisateur)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into Utilisateur (Idutili,Libelle,Nom,TelUT,Motdepasse) values (@Idutili,@Libelle,@Nom,@TelUT,@Motdepasse)", con);
            cmd.Parameters.AddWithValue("@Nom", _Utilisateur.Nom);
            cmd.Parameters.AddWithValue("@Idutili", _Utilisateur.Idutili);
            /*cmd.Parameters.AddWithValue("@Prenom", _Utilisateur.Prenom)*/
            cmd.Parameters.AddWithValue("@Libelle", _Utilisateur.Libelle);
            cmd.Parameters.AddWithValue("@TelUT", _Utilisateur.TelUT);
            cmd.Parameters.AddWithValue("@Motdepasse", _Utilisateur.Motdepasse);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            _utilisateurs.Add(_Utilisateur);
            return result;
        }
        public static int ModifUtilisateur(Utilisateur _Utilisateur)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update Utilisateur set Nom=@Nom,Libelle=@Libelle,TelUT=@TelUT,Motdepasse=@Motdepasse where Idutili=@Idutili", con);
            cmd.Parameters.AddWithValue("@Nom", _Utilisateur.Nom);
            //cmd.Parameters.AddWithValue("@Prenom", _Utilisateur.Prenom);
            cmd.Parameters.AddWithValue("@Libelle", _Utilisateur.Libelle);
            cmd.Parameters.AddWithValue("@TelUT", _Utilisateur.TelUT);
            cmd.Parameters.AddWithValue("@Idutili", _Utilisateur.Idutili);
            cmd.Parameters.AddWithValue("@Motdepasse", _Utilisateur.Motdepasse);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public static int SupUtilisateur(Utilisateur _Utilisateur)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from Utilisateur where Idutili=@Idutili", con);
            cmd.Parameters.AddWithValue("@Idutili", _Utilisateur.Idutili);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            _utilisateurs.Remove(_Utilisateur);
            return result;
        }
        public UtilisateurVM()
        {
            Utilisateurs = GetUtilisateur();
            FilteredUsers = Utilisateurs;
            SupprimerUticommand = new RelayCommand(ExecuteSupprimerUticommand);
            //EnregistrerCommand = new RelayCommand(ExecuteEnregistrerUtilisateurCommand);
        }
        //private Utilisateur _selectedUtilisateur;
        //public Utilisateur SelectedUtilisateur
        //{
        //    get
        //    {
        //        return _selectedUtilisateur;
        //    }
        //    set
        //    {
        //        if (_selectedUtilisateur != value)
        //        {
        //            _selectedUtilisateur = value;
        //            OnPropertyChanged(nameof(SelectedUtilisateur));
        //        }
        //    }
        //}
        //public ICommand _enregistrerCommand;
        //public ICommand EnregistrerCommand
        //{
        //    get
        //    {
        //        return _enregistrerCommand;
        //    }
        //    set
        //    {
        //        if (_enregistrerCommand != value)
        //        {
        //            _enregistrerCommand = value;
        //            OnPropertyChanged(nameof(EnregistrerCommand));
        //        }
        //    }
        //}
        //public void ExecuteEnregistrerUtilisateurCommand(object obj)
        //{
        //    SaveUtilisateur(SelectedUtilisateur);

        //    Message_Box box = new Message_Box("Utilisateur Enregistrer avec succés");
        //    box.ShowDialog();

        private Utilisateur _SelectedUti;

        public Utilisateur   SelectedUti
        {
            get
            {
                return _SelectedUti;
            }

            set
            {
                if (_SelectedUti != value)
                {
                    _SelectedUti = value;
                    OnPropertyChanged(nameof(SelectedUti));
                }
            }
        }
        public ICommand _supprimerUticommand;
        public ICommand SupprimerUticommand
        {
            get
            {
                return _supprimerUticommand;
            }
            set
            {
                _supprimerUticommand = value;
                OnPropertyChanged(nameof(SupprimerUticommand));
            }
        }

        private void ExecuteSupprimerUticommand(object obj)
        {

            if (SelectedUti == null)
            {
                Message_Box box = new Message_Box("Erreur de Suppression");
                box.ShowDialog();
            }
            else
            {
                SupUtilisateur(SelectedUti);
                Utilisateurs.Remove(SelectedUti);
                Message_Box box = new Message_Box("Utilisateur Supprimé avec succès");
                box.ShowDialog();
            }
        }
    }
   }
                
