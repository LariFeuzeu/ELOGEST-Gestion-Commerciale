using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;


namespace GES_COM_2.Models
{
   public class Article: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                    this.GetQteEnStock();
                    this.GetQtePerimee();
                }
            }
        }
        public int _qte;
        public int Qte
        {
            get { return _qte; }
            set
            {
                if (_qte != value)
                {
                    _qte = value;
                    OnPropertyChanged(nameof(Qte));
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

        private double _qtePerimee;
        public double QtePerimee
        {
            get { return _qtePerimee; }
            set
            {
                if (_qtePerimee != value)
                {
                    _qtePerimee = value;
                    OnPropertyChanged(nameof(QtePerimee));
                }
            }
        }
        private double _soustotal;
        public double Soustotal
        {
            get { return _soustotal; }
            set
            {
                if (_soustotal != value)
                {
                    _soustotal = value;
                    OnPropertyChanged(nameof(Soustotal));
                }
            }
        }
        private string _nomA;
        public string NomA
        {
            get { return _nomA; }
            set
            {
                if (_nomA != value)
                {
                    _nomA = value;
                    OnPropertyChanged(nameof(NomA));
                }
            }
        }
        private void GetQtePerimee()
        {
            int qtePerimee = 0;
            int qteVendue = 0;
            string dateActuelle = DateTime.Today.ToString("yyyy-MM-dd");
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(QuantiteAPP) FROM ligneappro WHERE N_art=@id and dateP < @date", con);
            cmd.Parameters.AddWithValue("@id", this.N_art);
            cmd.Parameters.AddWithValue("@date", dateActuelle);
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            if (data.Rows.Count == 1)
            {
                string str = "0";
                try
                {
                    str = data.Rows[0][0].ToString();
                    qtePerimee = Convert.ToInt32(str);
                }
                catch (Exception ex)
                {
                    str = "0";
                    qtePerimee = Convert.ToInt32(str);
                }
            }

            cmd.CommandText = "SELECT SUM(QuantiteLAC) FROM ligneachat WHERE N_art=@id";
            data = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            if (data.Rows.Count == 1)
            {
                string str = "0";
                try
                {
                    str = data.Rows[0][0].ToString();
                    qteVendue = Convert.ToInt32(str);
                }
                catch (Exception ex)
                {
                    str = "0";
                    qteVendue = Convert.ToInt32(str);
                }
            }

            this.QtePerimee = qtePerimee - qteVendue;

            con.Close();
        }
        private void GetQteEnStock()
        {
            int qteVendue = 0;
            int qteAppro = 0;
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT SUM(QuantiteLAC) FROM ligneachat WHERE N_art=@id", con);
            cmd.Parameters.AddWithValue("@id", this.N_art);
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            if (data.Rows.Count == 1)
            {
                string str = "0";
                try
                {
                    str = data.Rows[0][0].ToString();
                    qteVendue = Convert.ToInt32(str);
                }
                catch(Exception ex)
                {
                    str = "0";
                    qteVendue = Convert.ToInt32(str);
                }
            }

            cmd.CommandText = "SELECT SUM(QuantiteAPP) FROM ligneappro WHERE N_art=@id";
            data = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            if (data.Rows.Count == 1)
            {
                string str = "0";
                try
                {
                    str = data.Rows[0][0].ToString();
                    qteAppro = Convert.ToInt32(str);
                }
                catch (Exception ex)
                {
                    str = "0";
                    qteAppro = Convert.ToInt32(str);
                }
            }

            this.Qte = qteAppro - qteVendue;

            con.Close();
        }
    }
}

