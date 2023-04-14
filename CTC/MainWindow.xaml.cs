using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CTC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            placeImage("/Images/placeholder_image.jpg");


        }

        private void placeImage(String imagelink)
        {
            imageHolder.Source = new BitmapImage(new Uri(imagelink, UriKind.Relative));
        }

        private void tuneVehiclebtn_Click(object sender, RoutedEventArgs e)
        {
            Tuning tuningWindow = new Tuning();
            tuningWindow.ShowDialog();
        }

        private void backtoGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
