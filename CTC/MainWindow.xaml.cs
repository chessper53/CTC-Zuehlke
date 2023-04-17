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
        CarController carController;
        TuningController tuningController;

        public MainWindow()
        {
            InitializeComponent();
            placeImage("/Images/placeholder_image.jpg");
            colorLabels();

            carController = new CarController();
            tuningController = new TuningController();

            //set cars as source for view
            vehicleselectLV.ItemsSource = carController.ReadCars();
        }

        private void placeImage(String imagelink)
        {
            imageHolder.Source = new BitmapImage(new Uri(imagelink, UriKind.Relative));
        }

        private void tuneVehiclebtn_Click(object sender, RoutedEventArgs e)
        {
            Car car = vehicleselectLV.SelectedItem as Car;
            if(car != null)
            {
                Tuning tuningWindow = new Tuning(tuningController, car);
                tuningWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("No car selected");
            }
        }

        private void backtoGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void vehicleselectLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Car car = vehicleselectLV.SelectedItem as Car;

            accelerationLbl.Content = car.GetCalcAcceleration();
            topspeedLbl.Content = car.GetCalcTopSpeedInKmh();
            breakforceLbl.Content = car.GetCalcBreakingForce();
            handlingRangeLbl.Content = car.GetCalcHandlingRange();
            horsepowerLbl.Content = car.GetCalcPowerInH();
            weightLbl.Content = car.GetCalcWeight();
            ratingLbl.Content = car.GetCalcRating();
            ValueLbl.Content = car.GetCalcValue();
            brandLbl.Content = car.Brand;
            modelLbl.Content = car.Model;

            placeImage("/Images/" + car.Image);

            colorLabels();


        }
        private void colorLabels()
        {
            extcolorLbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(extcolorLbl.Content.ToString()));

            intcolorLbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(intcolorLbl.Content.ToString()));
        }
    }
}
