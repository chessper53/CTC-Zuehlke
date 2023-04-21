using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            PlaceImage("/Images/placeholder_image.jpg");
            ColorLabels();

            carController = new CarController();
            tuningController = new TuningController();

            // Set Icon
            string iconPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/car_icon.ico");
            Uri iconUri = new Uri(iconPath);
            this.Icon = BitmapFrame.Create(iconUri);

            //set cars as source for view
            vehicleselectLV.ItemsSource = carController.ReadCars();
        }

        private void PlaceImage(String imagelink)
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
                carController.ReloadCars();
                vehicleselectLV.ItemsSource = carController.ReadCars();

                ClearStats();
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
            if(vehicleselectLV.SelectedItem != null)
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
                brandLbl.Content = car.Brand.Name;
                modelLbl.Content = car.Model;
                extcolorLbl.Content = car.ColourOutside;
                intcolorLbl.Content = car.TrimColour;

                PlaceImage("/Images/" + car.Image);

                ColorLabels();
            }
        }
        private void ColorLabels()
        {
            extcolorLbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(extcolorLbl.Content.ToString()));

            intcolorLbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(intcolorLbl.Content.ToString()));
        }

        private void infoboxBtn_Click(object sender, RoutedEventArgs e)
        {
            string currentNitro = "";
            string currentEngine = "";
            if (vehicleselectLV.SelectedItem != null)
            {
                Car car = vehicleselectLV.SelectedItem as Car;
                if(car.NitroId != null)
                {
                    //Car is Selected and has Nitro
                    currentNitro =
                    "Currently Selected Nitro: " + car.Nitro.Type + Environment.NewLine +
                    "Acceleration Increase: +" + car.Nitro.

                    TempAccelerationImpact + Environment.NewLine +
                    "Recharge Time: " + car.Nitro.RechargeTime + " seconds" + Environment.NewLine +
                    "Charges: +" + car.Nitro.Charges + Environment.NewLine;
                }
                else
                {
                    //No Nitro is set
                    currentNitro = "Car has no Nitro attached!";
                }

                //Engine fuel
                currentEngine = Environment.NewLine + Environment.NewLine + "Attached Engine: Is powered by " + car.Engine.Fuel;
            }
            else
            {
                //No Nitro is Selected
                currentNitro = "No Car is Selected!";
            }

            MessageBox.Show("Acceleration: Constant acceleration in m/s²" + Environment.NewLine +
            "Topspeed: Km/h" + Environment.NewLine +
            "Brakeforce: Brakeforce in Newton" + Environment.NewLine +
            "Handling Range: The Handling rated on a scale of 0-50" + Environment.NewLine +
            "Horsepower: PS" + Environment.NewLine +
            "Weight: Kg" + Environment.NewLine +
            "Value: In DKK"  +
            currentEngine + Environment.NewLine + Environment.NewLine +
            "Nitro is an ingame Consumable!" +
            Environment.NewLine + currentNitro, "Information", MessageBoxButton.OK);
        }
        private void ClearStats()
        {
            PlaceImage("/Images/placeholder_image.jpg");
            accelerationLbl.Content = "0";
            topspeedLbl.Content = "0";
            breakforceLbl.Content = "0";
            handlingRangeLbl.Content = "0";
            horsepowerLbl.Content = "0";
            weightLbl.Content = "0";
            ratingLbl.Content = "0";
            ValueLbl.Content = "0";
            brandLbl.Content = "[Brand]";
            modelLbl.Content = "[Model]";
            extcolorLbl.Content = "#FFFFFF";
            intcolorLbl.Content = "#FFFFFF";
            ColorLabels();
        } 
    }
}
