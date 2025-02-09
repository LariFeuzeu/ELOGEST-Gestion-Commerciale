using GES_COM_2.Models;
using GES_COM_2.ViewModels;
using GES_COM_2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GES_COM_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double initialHeight;
        private double initialWidth;
        //private Client _viewModel = new Client();
        public MainWindow()
        {
            InitializeComponent();
            //_viewModel = new Client();
            //_viewModel.Client = new Client();
            //DataContext = _viewModel;
            foreach (Control item in stackPanelMenu.Children)
            {
                RadioButton btn = item as RadioButton;
                string[] items = btn.Tag.ToString().Split(',');
                foreach (string str in items)
                {
                    if(str.ToLower().Trim() == App.profilUtilisateur.ToLower().Trim() || str == "all")
                    {
                        btn.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void Border_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ResizeLeftTop(object sender, DragDeltaEventArgs e)
        {
            double w = this.Width - e.HorizontalChange;
            double h = this.Height - e.VerticalChange;
            double l = this.Left + e.HorizontalChange;
            double t = this.Top + e.VerticalChange;
            if (w >= this.MinWidth && h >= this.MinHeight)
            {
                this.Width = w;
                this.Height = h;
                this.Left = l;
                this.Top = t;
            }
        }

        private void ResizeRightTop(object sender, DragDeltaEventArgs e)
        {
            double w = this.Width + e.HorizontalChange;
            double h = this.Height - e.VerticalChange;
            double t = this.Top + e.VerticalChange;
            if (w >= this.MinWidth && h >= this.MinHeight)
            {
                this.Width = w;
                this.Height = h;
                this.Top = t;
            }
        }

        private void ResizeLeftBottom(object sender, DragDeltaEventArgs e)
        {
            double w = this.Width - e.HorizontalChange;
            double h = this.Height + e.VerticalChange;
            double l = this.Left + e.HorizontalChange;
            if (w >= this.MinWidth && h >= this.MinHeight)
            {
                this.Width = w;
                this.Height = h;
                this.Left = l;
            }
        }

        private void ResizeRightBottom(object sender, DragDeltaEventArgs e)
        {
            double w = this.Width + e.HorizontalChange;
            double h = this.Height + e.VerticalChange;
            if (w >= this.MinWidth && h >= this.MinHeight)
            {
                this.Width = w;
                this.Height = h;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            initialHeight = this.ActualHeight;
            initialWidth = this.ActualWidth;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

            Fenetrelogin f = new Fenetrelogin();
            f.Show(); // Affiche la fenêtre de connexion

            this.Hide();
        }
    }
}
