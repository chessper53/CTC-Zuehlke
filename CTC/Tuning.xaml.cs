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

namespace CTC
{
    /// <summary>
    /// Interaction logic for Tuning.xaml
    /// </summary>
    public partial class Tuning : Window
    {
        private TuningController tuningcontroller;


        internal Tuning(TuningController tuningController, Car car)
        {
            InitializeComponent();
            this.tuningcontroller = tuningController;
        }

        private void purchaseBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tuningpartLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            // Checks each Element in the sencond column and colours it based on it's size
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
    }
}
