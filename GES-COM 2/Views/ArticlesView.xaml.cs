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
    /// Interaction logic for ArticlesView.xaml
    /// </summary>
    public partial class ArticlesView : UserControl
    {

        //private List<string> dataList;


        Article articleCourant = new Article();
        public ArticlesView()
        {
            InitializeComponent();
            //dataList = new List<string>
            //{ 


            //};
            //UpdatelisteArticle(dataList);
        }

        private void ButtonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Article art = new Article();
            art.NomA = LabelNomA.Text;
            art.PrixU = Convert.ToInt32((LabelPrixU.Text));
            ArticleVM.SaveArticle(art);
            Message_Box box = new Message_Box("Article Enregistré avec succès");
            box.ShowDialog();
            LabelNomA.Text = string.Empty;
            LabelPrixU.Text = string.Empty;
        } 

        private void listeArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              try
            {
                if (listeArticle.SelectedItem != null)
                {
                    articleCourant = listeArticle.SelectedItem as Article;
                    LabelNomA.Text = articleCourant.NomA;
                    LabelPrixU.Text = articleCourant.PrixU.ToString();
                }
            }
            catch
            {

            }
        }

        private void ButtonModifier_Click(object sender, RoutedEventArgs e)
        {

            //Article art = new Article();
            Article art = listeArticle.SelectedItem as Article;
            articleCourant.NomA = LabelNomA.Text;
            articleCourant.PrixU = Convert.ToInt32((LabelPrixU.Text));
            ArticleVM.ModifArticle(articleCourant);
            Message_Box box = new Message_Box("Article Modifié avec succès");
            box.ShowDialog();
            LabelNomA.Text = string.Empty;
            LabelPrixU.Text = string.Empty;
        }

        private void ButtonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            ArticleVM.SupArticle(articleCourant);
            Message_Box box = new Message_Box("Article Supprimé avec succès");
            box.ShowDialog();
            LabelNomA.Text = string.Empty;
            LabelPrixU.Text = string.Empty;
        }
    
        private void TextBoxRecher_TextChanged(object sender, TextChangedEventArgs e)
        {
            ArticleVM vm = new ArticleVM();
            ObservableCollection<Article> articles = vm.FilterArticles(TextBoxRecher.Text);
            listeArticle.ItemsSource = articles;
        }

        private void listeArticle_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void LabelNomA_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LabelPrixU_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
  }
