using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Data;
using GES_COM_2.Models;
using System.Text;
using System.Threading.Tasks;
using GES_COM_2.Helpers;
using System.Windows.Input;
using GES_COM_2.Views;
using System.Windows;

namespace GES_COM_2.ViewModels
{
    class LoginVM:ViewModelBase
    {
        private string _nom;
        private string _motdepasse;

        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                _nom = value;
                OnPropertyChanged(nameof(Nom));
            }
        }
        public string Motdepasse
        {
            get
            {
                return _motdepasse;
            }
            set
            {
                _motdepasse = value;
                OnPropertyChanged(nameof(Motdepasse));

            }
        }
        public static bool Authentification(string nom, string motdepasse)
        {


            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select *,COUNT(*) as nbre From Utilisateur WHERE nom=@nom AND motdepasse=@motdepasse", con);
            //cmd.CommandText = "select COUNT(*) from Utilisateur where nom=@nom AND motdepasse=@motdepasse";
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@motdepasse", motdepasse);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            int count = Convert.ToInt32(data.Rows[0]["nbre"].ToString());
            con.Close();
            try
            {
                App.profilUtilisateur = data.Rows[0]["libelle"].ToString();
                App.idUtilisateur = Convert.ToInt32(data.Rows[0]["Idutili"].ToString());
            }
            catch (Exception)
            {

             
            }
            return count > 0;
            

        }
        public ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand;
            }
            set
            {
                _loginCommand = value;
                OnPropertyChanged(nameof(LoginCommand));
            }
        }
        public ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand;
            }
            set
            {
                _cancelCommand = value;
                OnPropertyChanged(nameof(CancelCommand));
            }
        }
        public LoginVM()
        {
            LoginCommand = new RelayCommand(ExecuteLoginCommand);
            CancelCommand = new RelayCommand(ExecuteCancelCommand);
        }

        private void ExecuteCancelCommand(object obj)
        {
            Application.Current.Shutdown();
        }

        private void ExecuteLoginCommand(object obj)
        {
            bool ath = Authentification(Nom, Motdepasse);
            if(ath) {
                
                new MainWindow().Show();
                
            }
            else
            {
                Message_Box box = new Message_Box("Erreur");
                
                box.ShowDialog();
            }
            CloseFenetrelogin();
        }
        private void CloseFenetrelogin()
        {
            Window Fenetrelogin = Application.Current.Windows.OfType<Fenetrelogin>().FirstOrDefault();
            Fenetrelogin?.Close();
        }
    }
  }

   

