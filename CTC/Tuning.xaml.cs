using Mysqlx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using static Mysqlx.Datatypes.Scalar.Types;

namespace CTC
{
    /// <summary>
    /// Interaction logic for Tuning.xaml
    /// </summary>
    public partial class Tuning : Window
    {
        private TuningController tuningcontroller;
        private ObservableCollection<string> items;
        Car car;
        Car modifiedCar;

        internal Tuning(TuningController tuningController, Car car)
        {
            InitializeComponent();
            clearStats();

            // Set Icon
            string iconPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images/car_icon.ico");
            Uri iconUri = new Uri(iconPath);
            this.Icon = BitmapFrame.Create(iconUri);


            tuningcontroller = tuningController;
            this.car = car;
            modifiedCar = car;
            this.tuningcontroller = tuningController;

            exteriorBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(car.ColourOutside));
            interiorBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(car.TrimColour));
        }

        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            //buy the tuning part
            tuningcontroller.UpdateCar(modifiedCar);
            car = (Car)modifiedCar.Clone();
            clearStats();


            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Tuning Parts";
            tuningpartLV.ItemsSource = null;


        }

        private void tuningpartLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tuningpartLV.SelectedItem != null)
            {
                modifiedCar = (Car)car.Clone();

                switch (tuningpartLV.SelectedItem.GetType().Name)
                {
                    case "Break":
                        modifiedCar.Break = (Break)tuningpartLV.SelectedItem;
                        modifiedCar.BreakId = modifiedCar.Break.BreakId;
                        break;
                    case "Bumper":
                        modifiedCar.Bumper = (Bumper)tuningpartLV.SelectedItem;
                        modifiedCar.BumperId = modifiedCar.Bumper.BumperId;
                        break;
                    case "Engine":
                        modifiedCar.Engine = (Engine)tuningpartLV.SelectedItem;
                        modifiedCar.EngineId = modifiedCar.Engine.EngineId;
                        break;
                    case "Exhaust":
                        modifiedCar.Exhaust = (Exhaust)tuningpartLV.SelectedItem;
                        modifiedCar.ExhaustId = modifiedCar.Exhaust.ExhaustId;
                        break;
                    case "Nitro":
                        modifiedCar.Nitro = (Nitro)tuningpartLV.SelectedItem;
                        modifiedCar.NitroId = modifiedCar.Nitro.NitroId;
                        break;
                    case "RearSpoiler":
                        modifiedCar.RearSpoiler = (RearSpoiler)tuningpartLV.SelectedItem;
                        modifiedCar.RearSpoilerId = modifiedCar.RearSpoiler.RearSpoilerId;
                        break;
                    case "Rim":
                        modifiedCar.Rim = (Rim)tuningpartLV.SelectedItem;
                        modifiedCar.RimId = modifiedCar.Rim.RimId;
                        break;
                    case "Tyre":
                        modifiedCar.Tyre = (Tyre)tuningpartLV.SelectedItem;
                        modifiedCar.TyreId = modifiedCar.Tyre.TyreId;
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
                modifiedCar = (Car)car.Clone();

            }
        }


        private async void engineBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Engines";


            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadEngine();

            Engine matchingItem = tuningpartLV.Items.Cast<Engine>().FirstOrDefault(x => x.EngineId == car.EngineId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
        }

        private async void bumperBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Bumpers";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadBumpers();

            Bumper matchingItem = tuningpartLV.Items.Cast<Bumper>().FirstOrDefault(x => x.BumperId == car.BumperId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
        }

        private async void tyreBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Tyres";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadTyre();

            Tyre matchingItem = tuningpartLV.Items.Cast<Tyre>().FirstOrDefault(x => x.TyreId == car.TyreId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
        }

        private async void brakesBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Brakes";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadBreak();

            Break matchingItem = tuningpartLV.Items.Cast<Break>().FirstOrDefault(x => x.BreakId == car.BreakId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
        }

        private async void rimBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Rims";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadRim();

            Rim matchingItem = tuningpartLV.Items.Cast<Rim>().FirstOrDefault(x => x.RimId == car.RimId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
        }

        private async void exhaustBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Exhausts";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadExhaust();

            Exhaust matchingItem = tuningpartLV.Items.Cast<Exhaust>().FirstOrDefault(x => x.ExhaustId == car.ExhaustId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
        }

        private async void nitroBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Nitro";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadNitro();

            Nitro matchingItem = tuningpartLV.Items.Cast<Nitro>().FirstOrDefault(x => x.NitroId == car.NitroId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
        }

        private async void spoilerBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Spoilers";

            //Sets the Content of the ListView
            tuningpartLV.ItemsSource = tuningcontroller.ReadRearSpoiler();

            RearSpoiler matchingItem = tuningpartLV.Items.Cast<RearSpoiler>().FirstOrDefault(x => x.RearSpoilerId == car.RearSpoilerId);

            // Wait for the container elements to be generated
            await Task.Delay(1);

            // Get the container element for the matching item and set its foreground color
            if (matchingItem != null && tuningpartLV.ItemContainerGenerator.ContainerFromItem(matchingItem) is ListViewItem listViewItem)
            {
                listViewItem.Foreground = Brushes.LightGreen;
            }
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

                    car.TrimColour=colourHexInterior;
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

                    car.ColourOutside = colourHexExterior;
                }
            }
        }

        private void infoboxBtn_Click(object sender, RoutedEventArgs e)
        {
            string currentNitro;
            if (tuningpartLV.SelectedItem != null && tuningpartLV.SelectedItem.GetType().Name.Equals("Nitro"))
            {
                if(modifiedCar.NitroId != null)
                {
                    //Nitro is Selected and is set
                    currentNitro =
                    "Currently Selected Nitro: " + modifiedCar.Nitro.Type + Environment.NewLine +
                    "Acceleration Increase: +" + modifiedCar.Nitro.

                    TempAccelerationImpact + Environment.NewLine +
                    "Recharge Time: " + modifiedCar.Nitro.RechargeTime + " seconds" + Environment.NewLine +
                    "Charges: +" + modifiedCar.Nitro.Charges + Environment.NewLine;
                }
                else
                {
                    //No Nitro is set
                    currentNitro = "Car has no Nitro attached!";
                }
            }
            else
            {
                //No Nitro is Selected
                currentNitro = "No Nirto is Selected!";
            }
            MessageBox.Show("Acceleration: Time needed to go from 0-100 km/h" + Environment.NewLine +
            "Topspeed: Km/h" + Environment.NewLine +
            "Brakeforce: Brakeforce in Newton" + Environment.NewLine +
            "Handling Range: The Handling rated on a scale of 0-50" + Environment.NewLine +
            "Horsepower: PS" + Environment.NewLine +
            "Weight: Kg" + Environment.NewLine +
            "Value: In DKK" + Environment.NewLine + Environment.NewLine +
            "Nitro is an ingame Consumable!" + Environment.NewLine +
            "Current Nitro: " + car.Nitro.Type + Environment.NewLine + 
            "Acceleration Increase: +" + car.Nitro.TempAccelerationImpact + Environment.NewLine +
            "Recharge Time: " + car.Nitro.RechargeTime +" seconds"+ Environment.NewLine +
            "Charges: +" + car.Nitro.Charges + Environment.NewLine + Environment.NewLine + currentNitro, "Information", MessageBoxButton.OK);




        }

        private void SortListView(string by)
        {
            try
            {
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(tuningpartLV.ItemsSource);
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription(by, System.ComponentModel.ListSortDirection.Ascending));
            }
            catch(Exception ex)
            {

            }
        }

        void Header_Click(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;

            if (headerClicked != null)
            {
                if(headerClicked.Content.Equals("Price"))
                {
                    SortListView("Price");
                }
                else
                {
                    SortListView("Type");
                }
            }
        }
    }
}
