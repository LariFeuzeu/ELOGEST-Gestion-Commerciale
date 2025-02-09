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
    public class Client: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int _idclient;
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
        public string _nomCl;
        public string NomCl
        {
            get { return _nomCl; }
            set
            {
                if (_nomCl != value)
                {
                    _nomCl = value;
                    OnPropertyChanged(nameof(NomCl));
                }
            }
        }
        public string _adresseCL;
        public string AdresseCL
        {
            get { return _adresseCL; }
            set
            {
                if (_adresseCL != value)
                {
                    _adresseCL = value;
                    OnPropertyChanged(nameof(AdresseCL));
                }
            }
        }
        public string _telCL;
        //private string v1;
        //private string v2;
        //private string v3;

        //public Client(string v1, string v2, string v3)
        //{
        //    this.v1 = v1;
        //    this.v2 = v2;
        //    this.v3 = v3;
        //}

        public Client()
        {
            
        }

        public string TelCL
        {
            get { return _telCL; }
            set
            {
                if (_telCL != value)
                {
                    _telCL = value;
                    OnPropertyChanged(nameof(TelCL));
                }
            }
        }
       
        public static int SaveClient (Client _Client)
        {
            int clientid = -1; 
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into Client (Idclient,NomCL,AdresseCL,TelCL) values (@Idclient,@NomCL,@AdresseCL,@TelCL)", con);
            cmd.Parameters.AddWithValue("@NomCL", _Client.NomCl);
            cmd.Parameters.AddWithValue("@Idclient", _Client.Idclient);
            cmd.Parameters.AddWithValue("@AdresseCL", _Client.AdresseCL);
            cmd.Parameters.AddWithValue("@TelCL", _Client.TelCL);
            cmd.ExecuteNonQuery();
            int clientId = (int)cmd.LastInsertedId; // Récupérer l'identifiant généré par la base de données
            con.Close();
            return clientid;
        }

        public static bool ClientExiste(Client client)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from client where Idclient = @id", con);
            cmd.Parameters.AddWithValue("@id", client.Idclient);
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            return data.Rows.Count != 0;
        }


    //    public static string GenerateUniqueId()
    //{
    //    Guid guid = Guid.NewGuid();
    //    return guid.ToString();
    //}

    }
   

}