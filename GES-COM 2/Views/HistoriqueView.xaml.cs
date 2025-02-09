using GES_COM_2.Models;
using GES_COM_2.Reports;
using GES_COM_2.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour HistoriqueView.xaml
    /// </summary>
    public partial class HistoriqueView : System.Windows.Controls.UserControl
    {
        public HistoriqueView()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void PrintInscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = startDatePickerAchats.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = endDatePickerAchats.SelectedDate ?? DateTime.MaxValue;
            RapportVentes rpt = new RapportVentes();

            MySqlConnection con = BD.InitConnexion();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from historiqueachats where date BETWEEN @1 and @2", con);
            cmd.Parameters.AddWithValue("@1", startDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@2", endDate.ToString("yyyy-MM-dd"));
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adp.Fill(data);
            BindingSource bs = new BindingSource();
            bs.DataSource = data;

            FenetreEtats f = new FenetreEtats(rpt, bs.List);
            f.ShowDialog();
        }

        private void FilterApprosButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = startDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = endDatePicker.SelectedDate ?? DateTime.MaxValue;

            // Filtrer les abonnements en fonction des dates sélectionnées
            HistoriqueVM viewModel = DataContext as HistoriqueVM;
            viewModel.FilterApprovisionnements(startDate, endDate);
        }

        private void PrintApprosButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DateTime startDate = startDatePicker.SelectedDate ?? DateTime.MinValue;
                DateTime endDate = endDatePicker.SelectedDate ?? DateTime.MaxValue;
                RapportAppros rpt = new RapportAppros();

                MySqlConnection con = BD.InitConnexion();
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from historiqueapppro where date BETWEEN @1 and @2", con);
                cmd.Parameters.AddWithValue("@1", startDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@2", endDate.ToString("yyyy-MM-dd"));
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adp.Fill(data);
                BindingSource bs = new BindingSource();
                bs.DataSource = data;

                FenetreEtats f = new FenetreEtats(rpt, bs.List);
                f.ShowDialog();
            }
            catch
            {

            }
        }

        private void FilterVentesButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime _startDatePickerAchats = startDatePickerAchats.SelectedDate ?? DateTime.MinValue;
            DateTime _endDatePickerAchats = endDatePickerAchats.SelectedDate ?? DateTime.MaxValue;

            // Filtrer les abonnements en fonction des dates sélectionnées
            HistoriqueVM viewModel = DataContext as HistoriqueVM;
            viewModel.FilterAchats(_startDatePickerAchats, _endDatePickerAchats);
        }
    }
}
