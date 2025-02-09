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
using MySql.Data.MySqlClient;
using GES_COM_2.Models;
using System.Data;
using System.Windows.Forms;
using GES_COM_2.Reports;
using CrystalDecisions.CrystalReports.Engine;

namespace GES_COM_2.Views
{
    /// <summary>
    /// Logique d'interaction pour FenetreEtats.xaml
    /// </summary>
    public partial class FenetreEtats : Window
    {
        public FenetreEtats(ReportClass etat, object _data)
        {
            InitializeComponent();
            etat.SetDataSource(_data);
            reportViewer.ViewerCore.ReportSource = etat;
        }
    }
}
