using GES_COM_2.Models;
using GES_COM_2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GES_COM_2.Views
{
    /// <summary>
    /// Interaction logic for ApprovisionnementView.xaml
    /// </summary>
    public partial class ApprovisionnementView : UserControl
    { private ObservableCollection<Article> allArticles;
        public ApprovisionnementView()
        {
            InitializeComponent();
           
        }
        private double CalculTotal()
        {
            double total = 0;
            foreach (PanierApproItem item in ApprovisionnementVM._panierA)
            {
                total += item.SousTotal;
            }
            ApprovisionnementVM.TotalGlobal= total;
            return total;
        }
        private void listePanier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (listeArticle.SelectedItem != null)
            {
                Image img = sender as Image;
                PanierItem panierItem = img.DataContext as PanierItem;
                Article article = panierItem.Article;
                ApprovisionnementVM.EnleverDuPanier(article);
                TextBoxTotal.Text = CalculTotal().ToString();
                TextBoxMontantVers.Text = CalculTotal().ToString();
            }
        }

        private void listeArticle_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
      
        }
  
        private void listeArticle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (listeArticle.SelectedItem != null)
            {
                Article article = listeArticle.SelectedItem as Article;
                ApprovisionnementVM.AjouterAuPanierAppro(article);
                TextBoxTotal.Text = CalculTotal().ToString();
                TextBoxMontantVers.Text = CalculTotal().ToString();
            }
            listeArticle.SelectedItem = null;
        }

        private void listeArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listePanier_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void listePanier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listePanier.SelectedItem != null)
            {
                PanierApproItem article = listePanier.SelectedItem as PanierApproItem;
                ApprovisionnementVM.EnleverDuPanier(article.Article);
                TextBoxTotal.Text = CalculTotal().ToString();
                TextBoxMontantVers.Text = CalculTotal().ToString();
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxTotal.Text = CalculTotal().ToString();
            TextBoxMontantVers.Text = CalculTotal().ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void TextBoxRecher_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApprovisionnementVM vm = new ApprovisionnementVM();
            ObservableCollection<Article> articles = vm.FilterArticles(TextBoxRecher.Text);
            listeArticle.ItemsSource = articles;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBoxTotal.Text = CalculTotal().ToString();
            TextBoxMontantVers.Text = CalculTotal().ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxMontantVers.Text = "";
            TextBoxTotal.Text = "";
            TextBoxReste.Text = "";
        }

        private void TextBoxMontantVers_TextChanged(object sender, TextChangedEventArgs e)
        {
            double total = 0;
            double mtVerse = 0;
            double reste = 0;
            try
            {
                total = Convert.ToDouble(TextBoxTotal.Text);
            }
            catch (Exception ex) { }
            try
            {
                mtVerse = Convert.ToDouble(TextBoxMontantVers.Text);
            }
            catch (Exception ex) { }
            reste = total - mtVerse;
            TextBoxReste.Text = reste.ToString();
            ApprovisionnementVM.MtVerse = mtVerse;
        }
    }
   
}