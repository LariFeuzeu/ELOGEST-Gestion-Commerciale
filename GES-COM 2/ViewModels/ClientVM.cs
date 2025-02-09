using GES_COM_2.Helpers;
using GES_COM_2.Models;
using GES_COM_2.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GES_COM_2.ViewModels
{
    class ClientVM : ViewModelBase
    {
        private ObservableCollection<Client> _clients;

        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }

            set {
                if (_clients != value)
                {
                    _clients = value;
                    OnPropertyChanged(nameof(Clients));
                }
            }
        }
        private static ObservableCollection<Client> _filteredClients = new ObservableCollection<Client>();
        public ObservableCollection<Client> FilteredClients
        {
            get
            {
                return _filteredClients;
            }
            set
            {
                if (_filteredClients != value)
                {
                    _filteredClients = value;
                    OnPropertyChanged(nameof(FilteredClients));
                }
            }
        }
        public ObservableCollection<Client> FilterClients(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                FilteredClients = Clients;
                return FilteredClients;
            }
            FilteredClients = new ObservableCollection<Client>(Clients.Where(a => a.NomCl.ToLower().Contains(txt.ToLower())));
            return FilteredClients;
        }
        public static ObservableCollection<Client> GetClient(string _Idclient = "?")//methode qui permet de recuperer le element d'un client dans une base de donnee.
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from client", con);

            if (_Idclient != "?")
            {
                cmd.CommandText = "select * from client where Idclient = @id";
                cmd.Parameters.AddWithValue("@id", _Idclient);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            ObservableCollection<Client> liste = new ObservableCollection<Client>();
            foreach (DataRow item in data.Rows)
            {
                Client client = new Client()
                {
                    Idclient = Convert.ToInt32(item["idclient"].ToString()),
                    NomCl = item["NomCL"].ToString(),
                    AdresseCL = item["AdresseCL"].ToString(),
                    TelCL = item["TelCL"].ToString(),
                };
                liste.Add(client);
            }
            con.Close();
            return liste;
        }
        public static int ModifClient(Client _Client) // methode qui permet de modifier un element dans une base de donne.
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update client set NomCL=@NomCL,AdresseCL=@AdresseCL,TelCL=@TelCL where Idclient=@Idclient  ", con);
            cmd.Parameters.AddWithValue("@NomCL", _Client.NomCl);
            cmd.Parameters.AddWithValue("AdresseCL", _Client.AdresseCL);
            cmd.Parameters.AddWithValue("@TelCL", _Client.TelCL);
            cmd.Parameters.AddWithValue("@Idclient", _Client.Idclient);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        private int SupClient(Client _Client)// methode qui permet de supprimer un element de la liste.
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from Client where Idclient=@Idclient", con);
            cmd.Parameters.AddWithValue("@Idclient", _Client.Idclient);
            int result = cmd.ExecuteNonQuery();
            con.Close();
           _clients.Remove(_Client);
            return result;
        }
        public ClientVM()
        {
            Clients = GetClient();
            Supprimerclientcommand = new RelayCommand(ExecuteSupprimerclientcommand);
            FilteredClients = Clients;

        }
        private Client _Selectedclient;

        public Client Selectedclient
         {
            get
            {
                return _Selectedclient;
            }

            set
            {
                if (_Selectedclient != value)
                {
                    _Selectedclient = value;
                    OnPropertyChanged(nameof(Selectedclient));
                 }
             }
        }
        public ICommand _supprimerclientcommand;
        public ICommand Supprimerclientcommand
        {
            get
            {
                return _supprimerclientcommand;
            }
            set
            {
                _supprimerclientcommand = value;
                OnPropertyChanged(nameof(Supprimerclientcommand));
            }
        }

        private void ExecuteSupprimerclientcommand(object obj)
        {
           
            if (Selectedclient == null)
            {
                Message_Box box = new Message_Box("Erreur de Suppression");
                box.ShowDialog();
            }
            else
            {
                SupClient(Selectedclient);
                Clients.Remove(Selectedclient);
                Message_Box box = new Message_Box("Client Supprimé avec succès");
                box.ShowDialog();
            }
        }  
    }
}




