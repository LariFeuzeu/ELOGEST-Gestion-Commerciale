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
    /// Interaction logic for Message_Box.xaml
    /// </summary>
    public partial class Message_Box : Window
    {
        public Message_Box(string message)
        {
            InitializeComponent();
            labelMessage.Content = message;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
