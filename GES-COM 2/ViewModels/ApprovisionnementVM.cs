using System;
using GES_COM_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel;
using GES_COM_2.Helpers;
using System.Windows.Input;

namespace GES_COM_2.ViewModels
{
    class ApprovisionnementVM : ViewModelBase
    {
        private Fournisseur selectedFournisseur;
        public Fournisseur SelectedFournisseur
        {
            get
            {
                return selectedFournisseur;
            }
            set
            {
                if (selectedFournisseur != value)
                {
                    selectedFournisseur = value;
                    OnPropertyChanged(nameof(SelectedFournisseur));
                }
            }
        }
        public static double TotalGlobal = 0;
        public static double MtVerse = 0;

        public static ObservableCollection<PanierApproItem> _panierA;
        public ObservableCollection<PanierApproItem> PanierA
        {
            get
            {
                return _panierA;
            }
            set
            {
                if (_panierA != value)
                {
                    _panierA = value;

                    OnPropertyChanged(nameof(PanierA));
                    double total = 0;
                    foreach (PanierApproItem item in PanierA)
                    {
                        total += item.SousTotal;
                    }

                    OnPropertyChanged(nameof(TotalGlobal));
                }
            }
           
        }
        private static ObservableCollection<Article> _filteredArticles = new ObservableCollection<Article>();
        public ObservableCollection<Article> FilteredArticles
        {
            get
            {
                return _filteredArticles;
            }
            set
            {
                if (_filteredArticles != value)
                {
                    _filteredArticles = value;
                    OnPropertyChanged(nameof(FilteredArticles));
                }
            }
        }
        public ObservableCollection<Article> FilterArticles(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                FilteredArticles = Articles;
                return FilteredArticles;
            }
            FilteredArticles = new ObservableCollection<Article>(Articles.Where(a => a.NomA.ToLower().Contains(txt.ToLower())));
            return FilteredArticles;
        }
        private void ExecuteAnnulerCommand(object obj)
        {
            _fournisseur = new Fournisseur();
            PanierA = new ObservableCollection<PanierApproItem>();
        }
        public ICommand AnnulerCommand { get; }
        public ICommand ValiderCommand { get; }
        private Fournisseur _fournisseur;
        public static ObservableCollection<Fournisseur> _fournisseurs;
        public ObservableCollection<Fournisseur> Fournisseurs
        {
            get { return _fournisseurs;
            }
            set
            {
                if (_fournisseurs != value)
                {
                    _fournisseurs = value;
                    OnPropertyChanged(nameof(Fournisseur));
                }
            }

        }

        public static ObservableCollection<Article> _articles = new ObservableCollection<Article>();
        public ObservableCollection<Article> Articles
        {
            get
            {
                return _articles;
            }
            set
            {
                if (_articles != value)
                {
                    _articles = value;
                    OnPropertyChanged(nameof(Articles));
                }
            }
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
        public static ObservableCollection<Article> GetArticles(int _idArt = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from article", con);
            if (_idArt != 0)
            {
                cmd.CommandText = "select * from article where NArt = @id";
                cmd.Parameters.AddWithValue("@id", _idArt);
            }
            DataTable data = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            ObservableCollection<Article> liste = new ObservableCollection<Article>();
            foreach (DataRow item in data.Rows)
            {
                Article art = new Article()
                {
                    N_art = Convert.ToInt32(item["N_Art"].ToString()),
                    NomA = item["nomA"].ToString(),
                    PrixU = Convert.ToDouble(item["prixU"].ToString())
                };
                liste.Add(art);
            }
            con.Close();
            return liste;
        }

        public static void SaveAppro(Approvisionnement _appro)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into approvisionnement (N_appro,idUtili,idFourni,Date,MontantTotalApp) values (@N_appro,@idUtili,@idfourni,@date,@mt)", con);
            cmd.Parameters.AddWithValue("@idUtili", _appro.Idutili);    
            cmd.Parameters.AddWithValue("@N_appro", _appro.N_appro);
            cmd.Parameters.AddWithValue("@idfourni", _appro.Idfourni);
            cmd.Parameters.AddWithValue("@date", _appro.Date.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@mt", _appro.MontantTotalAPP);
            cmd.ExecuteNonQuery();
            //foreach (Ligneappro item in _appro.Lignes)
            //{
            //    Ligneappro.SaveLigne(item);
            //}
            con.Close();
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

        public static int SaveArticle(Article _article)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into article (nomA,PrixU) values (@nom,@prix)", con);
            cmd.Parameters.AddWithValue("@nom", _article.NomA);
            cmd.Parameters.AddWithValue("@prix", _article.PrixU);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            _articles.Add(_article);
            return result;
        }
        public static void SaveLigne(Ligneappro _ligne)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into LigneAppro (N_appro,n_art,QuantiteApp,MontantApp,DateP) values (@nAppro,@nArt,@qte,@mt,@DateP)", con);
            cmd.Parameters.AddWithValue("@nAppro", _ligne.N_appro);
            cmd.Parameters.AddWithValue("@nArt", _ligne.N_art);
            cmd.Parameters.AddWithValue("@DateP", _ligne.date_de_peremtion.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@qte", _ligne.QuantiteAPP);
            cmd.Parameters.AddWithValue("@mt", _ligne.MontantAPP);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void EnleverDuPanier(Article _art)
        {
            foreach (PanierApproItem panierApproItem in _panierA)
            {
                if (panierApproItem.Article == _art)
                {
                    _panierA.Remove(panierApproItem);
                    break;
                }
            }
        }
        public static void AjouterAuPanierAppro(Article _art)
        {
            bool trouve = false;
            foreach(PanierApproItem panierApproItem in _panierA)
            {
                if (trouve)
                    break;
                if (panierApproItem.Article == _art)
                {
                    panierApproItem.QuantiteApp++;
                    panierApproItem.SousTotal = panierApproItem.QuantiteApp * panierApproItem.PrixU;

                    trouve = true;
               }
            }
            if(!trouve)
            {
                PanierApproItem item = new PanierApproItem();
                item.Article = _art;
                item.PrixU = _art.PrixU;
                item.QuantiteApp = 1;
                item.SousTotal = _art.PrixU;
                _panierA.Add(item);
            }
           
        }
        public ApprovisionnementVM()
        {
            PanierA = new ObservableCollection<PanierApproItem>();
            Articles = GetArticles();
            FilteredArticles = Articles;
            SelectedFournisseur = new Fournisseur();
            Fournisseurs = GetFournisseur();
            ValiderCommand = new RelayCommand(ExecuteValiderCommand);
            AnnulerCommand = new RelayCommand(ExecuteAnnulerCommand);
        }
        //private void ExecuteAnnulerCommand(object obj)
        //{
        //    SelectedFournisseur = new Fournisseur();
        //    PanierA = new ObservableCollection<PanierApproItem>();
        //}

        private void ExecuteValiderCommand(object obj)
        {
            if (!Fournisseur.fournisseurExiste(SelectedFournisseur))
            {
              SaveFournisseur(SelectedFournisseur);
            }

            Approvisionnement approvisionnement = new Approvisionnement();
            approvisionnement.Date = DateTime.Today;
            approvisionnement.Idfourni = SelectedFournisseur.idfourni;
            approvisionnement.Idutili = App.idUtilisateur;
            approvisionnement.MontantTotalAPP = TotalGlobal;
            approvisionnement.MontantVerse = MtVerse;
            
            approvisionnement.N_appro = App.LastId("approvisionnement", "N_appro")+1;
            SaveAppro (approvisionnement);
            Ligneappro ligne = new Ligneappro();
            ligne.N_appro = approvisionnement.N_appro;
            foreach (PanierApproItem item in PanierA)
            {
                //if (item.Quantite < 1)
                //{
                //    PanierA.Remove(item);
                //}
                //else
                //{
                    ligne.N_art = item.Article.N_art;
                    ligne.QuantiteAPP = item.QuantiteApp;
                    ligne.MontantAPP = item.SousTotal;
                    ligne.date_de_peremtion = item.DatePeremtion;
                    ligne.Pu = item.PrixU;
                    SaveLigne(ligne);
                //}
            }
            SelectedFournisseur = new Fournisseur();
            PanierA = new ObservableCollection<PanierApproItem>();
            Articles = GetArticles();
        }
     
    }
       
    }    