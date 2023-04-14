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
        public Tuning()
        {
            InitializeComponent();

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

        }

        private void bumperBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Bumpers";
        }

        private void tyreBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Tyres";
        }

        private void brakesBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Brakes";
        }

        private void rimBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Rims";
        }

        private void exhaustBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Exhausts";
        }

        private void nitroBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Nitro";
        }

        private void spoilerBtn_Click(object sender, RoutedEventArgs e)
        {
            // Changes the Header of tuningpartLV to its new content
            var column = tuningpartLV.FindName("selectedPartHdr") as GridViewColumn;
            column.Header = "Spoilers";
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
