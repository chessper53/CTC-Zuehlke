using Mysqlx;
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
using System.Windows.Shapes;
using static Mysqlx.Datatypes.Scalar.Types;

namespace CTC
{
    /// <summary>
    /// Interaction logic for Tuning.xaml
    /// </summary>
    public partial class Tuning : Window
    {
        private TuningController tuningcontroller;
        Car car;

        internal Tuning(TuningController tuningController, Car car)
        {
            InitializeComponent();
            clearStats();

            string iconPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/car_icon.ico");
            Uri iconUri = new Uri(iconPath);
            this.Icon = BitmapFrame.Create(iconUri);


            tuningcontroller = tuningController;
            this.car = car;
            this.tuningcontroller = tuningController;
        }

        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void tuningpartLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tuningpartLV.SelectedItem != null)
            {
                Car modifiedCar = (Car)car.Clone();

                switch (tuningpartLV.SelectedItem.GetType().Name)
                {
                    case "Break":
                        modifiedCar.Break = (Break)tuningpartLV.SelectedItem;
                        break;
                    case "Bumper":
                        modifiedCar.Bumper = (Bumper)tuningpartLV.SelectedItem;
                        break;
                    case "Engine":
                        modifiedCar.Engine = (Engine)tuningpartLV.SelectedItem;
                        break;
                    case "Exhaust":
                        modifiedCar.Exhaust = (Exhaust)tuningpartLV.SelectedItem;
                        break;
                    case "Nitro":
                        modifiedCar.Nitro = (Nitro)tuningpartLV.SelectedItem;
                        break;
                    case "RearSpoiler":
                        modifiedCar.RearSpoiler = (RearSpoiler)tuningpartLV.SelectedItem;
                        break;
                    case "Rim":
                        modifiedCar.Rim = (Rim)tuningpartLV.SelectedItem;
                        break;
                    case "Tyre":
                        modifiedCar.Tyre = (Tyre)tuningpartLV.SelectedItem;
                        break;
                    default:
                        break;
                }

                oldAcceleratonLbl.Content = car.GetCalcAcceleration();
                oldTopSpeedLbl.Content = car.GetCalcTopSpeedInKmh();
                oldBrakeForceLbl.Content = car.GetCalcBreakingForce();
                oldHandlingRangeLbl.Content = car.GetCalcHandlingRange();
                oldHorsePowerLbl.Content = car.GetCalcPowerInH();
                oldWeightLbl.Content = car.GetCalcWeight();
                oldRatingLbl.Content = car.GetCalcRating();

                newAcceleratonLbl.Content = modifiedCar.GetCalcAcceleration() - car.GetCalcAcceleration();
                newTopSpeedLbl.Content = modifiedCar.GetCalcTopSpeedInKmh() - car.GetCalcTopSpeedInKmh();
                newBrakeForceLbl.Content = modifiedCar.GetCalcBreakingForce() - car.GetCalcBreakingForce();
                newHandlingRangeLbl.Content = modifiedCar.GetCalcHandlingRange() - car.GetCalcHandlingRange();
                newHorsePowerLbl.Content = modifiedCar.GetCalcPowerInH() - car.GetCalcPowerInH();
                newWeightLbl.Content = modifiedCar.GetCalcWeight() - car.GetCalcWeight();
                newRatingLbl.Content = modifiedCar.GetCalcRating() - car.GetCalcRating();

                acceleratonLbl.Content = modifiedCar.GetCalcAcceleration();
                topSpeedLbl.Content = modifiedCar.GetCalcTopSpeedInKmh();
                brakeForceLbl.Content = modifiedCar.GetCalcBreakingForce();
                handlingRangeLbl.Content = modifiedCar.GetCalcHandlingRange();
                horsePowerLbl.Content = modifiedCar.GetCalcPowerInH();
                weightLbl.Content = modifiedCar.GetCalcWeight();
                ratingLbl.Content = modifiedCar.GetCalcRating();

                labelColouring();
            }
            else
            {
                clearStats();
            }
        }

        private void engineBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Engines";


            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadEngine();
        }

        private void bumperBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Bumpers";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadBumpers();
        }

        private void tyreBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Tyres";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadTyre();
        }

        private void brakesBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Brakes";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadBreak();
        }

        private void rimBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Rims";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadRim();
        }

        private void exhaustBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Exhausts";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadExhaust();
        }

        private void nitroBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Nitro";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadNitro();
        }

        private void spoilerBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Spoilers";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadRearSpoiler();
        }

        private void labelColouring()
        {
            // Checks each Element in the sencond column and colours it based on it's Value
            foreach (UIElement element in specificationGridTune.Children)
            {
                int columnIndex = System.Windows.Controls.Grid.GetColumn(element);
                if (columnIndex == 2)
                {
                    if (element is Label)
                    {
                        var label = (Label)element;
                        var labelContent = label.Content;
                        int contentasint = Int32.Parse(labelContent.ToString());
                        if (contentasint > 0)
                        {
                            // If the Stat is greater than 0 the foreground gets painted green
                            label.Foreground = System.Windows.Media.Brushes.Green;
                            // Adds a + infront of a positive Numbers
                            string labelContentNew = "+" + labelContent.ToString();
                            label.Content = labelContentNew;
                        }
                        else if (contentasint < 0)
                        {
                            // If the Stat is lesser than 0 the foreground gets painted red
                            label.Foreground = System.Windows.Media.Brushes.Red;
                        }
                        else
                        {
                            // If the Stat is anything else the foreground gets painted white
                            label.Foreground = System.Windows.Media.Brushes.White;
                        }
                    }
                }
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void clearStats()
        {
            oldAcceleratonLbl.Content = null;
            oldTopSpeedLbl.Content = null;
            oldBrakeForceLbl.Content = null;
            oldHandlingRangeLbl.Content = null;
            oldHorsePowerLbl.Content = null;
            oldWeightLbl.Content = null;
            oldRatingLbl.Content = null;

            newAcceleratonLbl.Content = null;
            newTopSpeedLbl.Content = null;
            newBrakeForceLbl.Content = null;
            newHandlingRangeLbl.Content = null;
            newHorsePowerLbl.Content = null;
            newWeightLbl.Content = null;
            newRatingLbl.Content = null;

            acceleratonLbl.Content = null;
            topSpeedLbl.Content = null;
            brakeForceLbl.Content = null;
            handlingRangeLbl.Content = null;
            horsePowerLbl.Content = null;
            weightLbl.Content = null;
            ratingLbl.Content = null;
        }
        private void interiorBtn_Click(object sender, RoutedEventArgs e)
        {
            string colourHexInterior = "";
            while (string.IsNullOrEmpty(colourHexInterior))
            {
                colourHexInterior = Microsoft.VisualBasic.Interaction.InputBox("Please enter the desired colour (HEX):", "Colour", "");

                if (colourHexInterior.StartsWith("#"))
                {
                }
                else
                {
                    colourHexInterior = "#" + colourHexInterior;
                }

                Regex hexColorRegex = new Regex(@"^#?([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$");
                bool isValidHexColor = hexColorRegex.IsMatch(colourHexInterior);
                if (isValidHexColor)
                {
                    interiorBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colourHexInterior));
                } 

            }
        }

        private void exteriorBtn_Click(object sender, RoutedEventArgs e)
        {
            string colourHexExterior = "";
            while (string.IsNullOrEmpty(colourHexExterior))
            {
                colourHexExterior = Microsoft.VisualBasic.Interaction.InputBox("Please enter the desired colour (HEX):", "Colour", "");

                if (colourHexExterior.StartsWith("#"))
                {
                }
                else
                {
                    colourHexExterior = "#" + colourHexExterior;
                }

                Regex hexColorRegex = new Regex(@"^#?([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$");
                bool isValidHexColor = hexColorRegex.IsMatch(colourHexExterior);
                if (isValidHexColor)
                {
                    exteriorBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colourHexExterior));
                }
            }
        }

        private void infoboxBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Acceleration: Time needed to go from 0-100 km/h" + Environment.NewLine +
                "Topspeed: Km/h" + Environment.NewLine +
                "Brakeforce: Brakeforce in Newton" + Environment.NewLine +
                "Handling Range: The Handling rated on a scale of 0-50" + Environment.NewLine +
                "Horsepower: PS" + Environment.NewLine +
                "Weight: Kg" + Environment.NewLine +
                "Value: In DKK", "Information", MessageBoxButton.OK);
        }
    }
}
