using GES_COM_2.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GES_COM_2.Views
{
    /// <summary>
    /// Logique d'interaction pour Fenetrelogin.xaml
    /// </summary>
    public partial class Fenetrelogin : Window
    {
      
        public Fenetrelogin()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool auth = LoginVM.Authentification(TextBoxLogin.Text, PassWordTextBox.Password);
            if (auth)
            {

                new MainWindow().Show();

            }
            else
            {
                Message_Box box = new Message_Box("Erreur");

                box.ShowDialog();
            }
            CloseFenetrelogin();
        }
        private void CloseFenetrelogin()
        {
            Window Fenetrelogin = System.Windows.Application.Current.Windows.OfType<Fenetrelogin>().FirstOrDefault();
            Fenetrelogin?.Close();
        }
    }
}
