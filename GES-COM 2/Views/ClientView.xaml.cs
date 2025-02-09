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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
        
    {
        Client clientcourrant = new Client();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void listeClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void ButtonModifier_Click(object sender, RoutedEventArgs e)
        {
            Client cl = new Client();
            clientcourrant.Idclient = Convert.ToInt32((TextBoxIDc.Text));
            clientcourrant.NomCl = TextBoxNomc.Text;
            clientcourrant.AdresseCL = TextBoxAdresseC.Text;
            clientcourrant.TelCL = TextBoxTelephoneC.Text;
           ClientVM.ModifClient(clientcourrant);
            Message_Box box = new Message_Box("Client Modifié avec succès");
            box.ShowDialog();
            TextBoxNomc.Text = string.Empty;
            TextBoxAdresseC.Text = string.Empty;
            TextBoxTelephoneC.Text = string.Empty;
        }

        private void ButtonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            //ClientVM.SupClient(clientcourrant);
            //Message_Box box = new Message_Box("Client Supprimé avec succès");
            //box.ShowDialog();
            TextBoxNomc.Text = string.Empty;
            TextBoxAdresseC.Text = string.Empty;
            TextBoxTelephoneC.Text = string.Empty;
        }

        private void ButtonImprimer_Click(object sender, RoutedEventArgs e)
        {
            Message_Box box = new Message_Box("Client Imprimé avec succès");
            box.ShowDialog();
        }

        private void listeArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ListeClient.SelectedItem != null)
                {
                    //clientcourrant = ListeClient.SelectedItem as Client;
                    //TextBoxIDc.Text = clientcourrant.Idclient;
                    //TextBoxNomc.Text = clientcourrant.NomCl;
                    //TextBoxAdresseC.Text = clientcourrant.AdresseCL;
                    //TextBoxTelephoneC.Text = clientcourrant.TelCL;

                }
            }
            catch
            {

            }
        }

        private void TextBoxRecher_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClientVM vm = new ClientVM();
            ObservableCollection<Client> clients = vm.FilterClients(TextBoxRecher.Text);
            ListeClient.ItemsSource = clients;
        }
    }
}
