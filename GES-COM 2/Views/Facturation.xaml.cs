using GES_COM_2.Models;
using GES_COM_2.Reports;
using GES_COM_2.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GES_COM_2.Views
{
    /// <summary>
    /// Interaction logic for Facturation.xaml
    /// </summary>
    public partial class Facturation : System.Windows.Controls.UserControl
    {

        public Facturation()
        {
            InitializeComponent();
        }


        private void listeArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
        }

        private void
        listePanier_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void listePanier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listePanier.SelectedItem != null)
            {
                PanierItem article = listePanier.SelectedItem as PanierItem;
                FacturationVM.EnleverDuPanier(article.Article);
                TextBoxTotal.Text = CalculTotal().ToString();
                TextBoxMontantVerse.Text = CalculTotal().ToString();
            }
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (listeArticle.SelectedItem != null)
            {
                Image img = sender as Image;
                PanierItem panierItem = img.DataContext as PanierItem;
                Article article = panierItem.Article;
                FacturationVM.EnleverDuPanier(article);
                TextBoxTotal.Text = CalculTotal().ToString();
                TextBoxMontantVerse.Text = CalculTotal().ToString();
            }
        }
        private void listeArticle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
       
        }
        private double CalculTotal()
        {
            double total = 0;
            foreach (PanierItem item in FacturationVM._panier)
            {
                total += item.SousTotal;
            }
            FacturationVM.TotalGlobal = total;
            return total;
        }

        private void listeArticle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (listeArticle.SelectedItem != null)
            {
                Article article = listeArticle.SelectedItem as Article;
                if (article.Qte > 0)
                {
                    FacturationVM.AjouterAuPanier(article);
                    TextBoxTotal.Text = CalculTotal().ToString();
                    TextBoxMontantVerse.Text = CalculTotal().ToString();
                }
            }
            listeArticle.SelectedItem = null;
        }

        private void TextBoxIdcl_LostFocus(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Client> result = ClientVM.GetClient(TextBoxIdcl.Text);
            if (result.Count != 0)
            {
                foreach (Client _client in result)
                {
                  
                    //TextBoxIdcl.Text = _client.Idclient;
                    TextBoxNomcl.Text = _client.NomCl;
                    TextBoxNomcl.Focus();
                    TextBoxAdressecl.Text = _client.AdresseCL;
                    TextBoxTelephonecl.Text = _client.TelCL;
                    TextBoxTelephonecl.Focus();
                }
            }
        }

        private void listePanier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          

            TextBoxMontantVerse.Text = "";
            TextBoxReste.Text = "";
            TextBoxTotal.Text = "";
        }

        private void TextBoxNomcl_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxTotal.Text = CalculTotal().ToString();
            TextBoxMontantVerse.Text = CalculTotal().ToString();
        }

        private void btnHistorique_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxMontantVerse_TextChanged(object sender, TextChangedEventArgs e)
        {
            double total = 0;
            double mtVerse = 0;
            double reste = 0;
            try
            {
                total = Convert.ToDouble(TextBoxTotal.Text);
            }
            catch(Exception ex) { }
            try
            {
                mtVerse = Convert.ToDouble(TextBoxMontantVerse.Text);
            }
            catch(Exception ex) { }
            reste = total - mtVerse;
            TextBoxReste.Text = reste.ToString();
            FacturationVM.MtVerse = mtVerse;
        }

        private void TextBoxRecher_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApprovisionnementVM vm = new ApprovisionnementVM();
            ObservableCollection<Article> articles = vm.FilterArticles(TextBoxRecher.Text);
            listeArticle.ItemsSource = articles;
        }

        private void TextBoxIdcl_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}