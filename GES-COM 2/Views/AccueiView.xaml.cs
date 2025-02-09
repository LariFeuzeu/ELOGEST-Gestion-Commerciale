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
using System.Windows.Threading;

namespace GES_COM_2.Views
{
    /// <summary>
    /// Logique d'interaction pour AccueiView.xaml
    /// </summary>
    public partial class AccueiView : UserControl
    {
        private int seuil = 5;
        public static ObservableCollection<Article> Articles = new ObservableCollection<Article>();
        public static ObservableCollection<Article> ArticlesInsuffisants = new ObservableCollection<Article>();
        public static ObservableCollection<Article> ArticlesPerimes = new ObservableCollection<Article>();
        private DispatcherTimer timer;
        public AccueiView()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            Articles = ArticleVM.GetArticles();
            ArticlesInsuffisants = new ObservableCollection<Article>(Articles.Where(a => a.Qte <= seuil));
            listeArticlesInsuffisants.ItemsSource = ArticlesInsuffisants; 
            if(ArticlesInsuffisants.Count <= 0)
            {
                borderStocksInsuffisants.Visibility = Visibility.Hidden;
            }

            ArticlesPerimes = new ObservableCollection<Article>(Articles.Where(a => a.QtePerimee > 0));
            listeArticlesPerimes.ItemsSource = ArticlesPerimes; 
            if(ArticlesPerimes.Count <= 0)
            {
                borderArticlesPerimes.Visibility = Visibility.Hidden;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string date = DateTime.Now.ToString("ddd dd MMMM yyyy");
            timerTextb.Text = time;
            dateTextb.Text = date;
        }
    }
}
