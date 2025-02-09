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
    /// Logique d'interaction pour UtilisateurView.xaml
    /// </summary>
    public partial class UtilisateurView : UserControl
    {

        Utilisateur Utili = new Utilisateur();
        public UtilisateurView()
        {
            InitializeComponent();
            //this.DataContext = vm;
        }

        private void listeUtiilisateur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listeUtiilisateur.SelectedItem != null)
                {
                    //Utili = listeUtiilisateur.SelectedItem as Utilisateur;
                    //string Idutili = Utili.Idutili.ToString();
                    //TextboxNutili.Text = Idutili;
                    //TextboxNom.Text = Utili.Nom;
                    //TextboxTelephone.Text = Utili.TelUT;
                    //TextboxLibelle.Text = Utili.Libelle;
                    //TextboxMotdePasse.Text = Utili.Motdepasse;
                }
            }
            catch { }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur Utili = new Utilisateur();
            Utili.Idutili = Convert.ToInt32(TextboxNutili.Text);
            Utili.Nom  = TextboxNom.Text;
            Utili.TelUT = TextboxTelephone.Text;
            Utili.Libelle = TextboxLibelle.Text;
            Utili.Motdepasse = TextboxMotdePasse.Text;
            UtilisateurVM.SaveUtilisateur(Utili);
            Message_Box box = new Message_Box("Utilisateur Enregistré avec succès");
            box.ShowDialog();
            TextboxNutili.Text = string.Empty;
            TextboxNom.Text = string.Empty;
            TextboxTelephone.Text = string.Empty;
            TextboxLibelle.Text = string.Empty;
            TextboxMotdePasse.Text = string.Empty;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Utilisateur Utili = new Utilisateur();
            Utili.Idutili = Convert.ToInt32(TextboxNutili.Text);
            Utili.Nom = TextboxNom.Text;
            Utili.TelUT = TextboxTelephone.Text;
            Utili.Libelle = TextboxLibelle.Text;
            Utili.Motdepasse = TextboxMotdePasse.Text;
            UtilisateurVM.ModifUtilisateur(Utili);
            UtilisateurVM vm = this.DataContext as UtilisateurVM;
            vm.Utilisateurs = UtilisateurVM.GetUtilisateur();
            Message_Box box = new Message_Box("Utilisateur Modifié avec succès");
            box.ShowDialog();
            TextboxNutili.Text = string.Empty;
            TextboxNom.Text = string.Empty;
            TextboxTelephone.Text = string.Empty;
            TextboxLibelle.Text = string.Empty;
            TextboxMotdePasse.Text = string.Empty;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Utilisateur Utili = new Utilisateur();
            Utili.Idutili = Convert.ToInt32(TextboxNutili.Text);
            Utili.Nom = TextboxNom.Text;
            Utili.TelUT = TextboxTelephone.Text;
            Utili.Libelle = TextboxLibelle.Text;
            Utili.Motdepasse = TextboxMotdePasse.Text;

            //int res =
            UtilisateurVM.SupUtilisateur(Utili);


            TextboxNutili.Text = string.Empty;
            TextboxNom.Text = string.Empty;
            TextboxTelephone.Text = string.Empty;
            TextboxLibelle.Text = string.Empty;
            TextboxMotdePasse.Text = string.Empty;

            //if (res == 0)
            //{
            //    Message_Box box = new Message_Box("Une erreur s'est produite");
            //    box.ShowDialog();
            //}
            //else
            //{
            //    Message_Box box = new Message_Box("Utilisateur Supprimé avec succès");
            //    box.ShowDialog();
            //}
        }

        private void TextboxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxRecher_TextChanged(object sender, TextChangedEventArgs e)
        {
            UtilisateurVM vm = new UtilisateurVM();
            ObservableCollection<Utilisateur> users = vm.FilterUsers(TextBoxRecher.Text);
            listeUtiilisateur.ItemsSource = users;
        }
    }
}
