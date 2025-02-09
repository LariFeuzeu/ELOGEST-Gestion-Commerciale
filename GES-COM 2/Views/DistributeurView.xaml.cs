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
    /// Interaction logic for DistributeurView.xaml
    /// </summary>
    public partial class DistributeurView : UserControl
    {
        Fournisseur FournisseurCourrant = new Fournisseur();
        public DistributeurView()
        {
            InitializeComponent();
        }

        private void ButtonModifier_Click(object sender, RoutedEventArgs e)
        {
            Fournisseur fnr = new Fournisseur();
            FournisseurCourrant.Nom = TextBoxNom.Text;
            FournisseurCourrant.Adresse = TextBoxAdresseFr.Text;
            FournisseurCourrant.TelFOURNI = TextBoxTelephoneFr.Text;
            int x = DistributeurVM.ModifFournisseur(FournisseurCourrant);
            Message_Box box = new Message_Box("Fournisseur Modifié avec succès");
            box.ShowDialog();
            TextBoxIDFr.Text = string.Empty;
            TextBoxNom.Text = string.Empty;
            TextBoxAdresseFr.Text = string.Empty;
            TextBoxTelephoneFr.Text = string.Empty;
        }

        private void ButtonEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            Fournisseur fnr = new Fournisseur();
            fnr.idfourni = Convert.ToInt32((TextBoxIDFr.Text));
            fnr.Nom = TextBoxNom.Text;
            fnr.Adresse = TextBoxAdresseFr.Text;
            fnr.TelFOURNI = TextBoxTelephoneFr.Text;
            DistributeurVM.SaveFournisseur(fnr);

            Message_Box box = new Message_Box("Fournisseur Enregistré avec succès");
            box.ShowDialog();
            TextBoxIDFr.Text = string.Empty;
            TextBoxNom.Text= string.Empty;
            TextBoxAdresseFr.Text= string.Empty;
            TextBoxTelephoneFr.Text= string.Empty;
        }

        private void ButtonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            DistributeurVM.SupFournisseur(FournisseurCourrant);
            Message_Box box = new Message_Box("Fournisseur Supprimé avec succès");
            box.ShowDialog();
            TextBoxIDFr.Text = string.Empty;
            TextBoxNom.Text = string.Empty;
            TextBoxAdresseFr.Text = string.Empty;
            TextBoxTelephoneFr.Text = string.Empty;
        }

        private void ButtonImprimer_Click(object sender, RoutedEventArgs e)
        {
            Message_Box box = new Message_Box("Fournisseur Imprimé avec succès");
            box.ShowDialog();

        }

        private void ListViewFournisseur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ListeFournisseur.SelectedItem != null)
                {
                    FournisseurCourrant = ListeFournisseur.SelectedItem as Fournisseur;
                    string idfourni = FournisseurCourrant.idfourni.ToString();
                    TextBoxIDFr.Text = idfourni;
                    TextBoxNom.Text = FournisseurCourrant.Nom;
                    TextBoxAdresseFr.Text = FournisseurCourrant.Adresse;
                    TextBoxTelephoneFr.Text = FournisseurCourrant.TelFOURNI;
                }

            }
            catch
            {

            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBoxRecher_TextChanged(object sender, TextChangedEventArgs e)
        {
            DistributeurVM vm = new DistributeurVM();
            ObservableCollection<Fournisseur> fournisseurs = vm.FilterFournisseurs(TextBoxRecher.Text);
            ListeFournisseur.ItemsSource = fournisseurs;
        }
    }
}
