using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using GES_COM_2.Models;
using System.Collections.ObjectModel;
using System.Data;

namespace GES_COM_2.ViewModels
{
    class ArticleVM:ViewModelBase
    {
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

        public static ObservableCollection<Article> GetArticles(int _idArt = 0)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from article", con);
            if (_idArt != 0)
            {
                cmd.CommandText = "select * from article where N_Art = @id";
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
        public static int ModifArticle(Article _article)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update article set PrixU=@PrixU,NomA=@nomA where N_art=@N_art ", con);
            cmd.Parameters.AddWithValue("@nomA", _article.NomA);
            cmd.Parameters.AddWithValue("@prixU", _article.PrixU);
            cmd.Parameters.AddWithValue("@N_art", _article.N_art);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public static int SupArticle(Article _article)
        {
            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from article where N_art=@N_art", con);
            cmd.Parameters.AddWithValue("@N_art", _article.N_art);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            _articles.Remove(_article);
            return result;
        }
        public ArticleVM()
        {
            Articles = GetArticles();
            FilteredArticles = Articles;
        }
    }
}
