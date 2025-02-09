using GES_COM_2.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GES_COM_2.Views
{
    /// <summary>
    /// Interaction logic for ArticleView.xaml
    /// </summary>
    public partial class ArticleView : Window
    {
        public ArticleView()
        {
            InitializeComponent();
            
        }

        private void ButtonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Article art = new Article();
            art.NomA = LabelNomA.Text;
            art.N_art = Convert.ToInt32((LabelNumeroA.Text));
            art.N_art = Convert.ToInt32((LabelPrixU.Text));
            Article.SaveArticle(art);
        }
    }
}
