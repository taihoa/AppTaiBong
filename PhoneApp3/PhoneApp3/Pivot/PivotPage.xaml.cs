using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;

namespace PivotApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public string myDescription = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.";
      public string myTitle = " Câu ";

        public MainPage()
        {
            InitializeComponent(); 
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //loading bar
                myProgressBar.IsEnabled = true;
                myProgressBar.IsIndeterminate = true;
                myProgressBar.Visibility = System.Windows.Visibility.Visible;
 
                //title 
                titleToday.Header = "Các câu hỏi";
                //call dynamic pivots
                cmdDynamicPivotItems();

                //hide loading
                myProgressBar.IsEnabled = false;
                myProgressBar.IsIndeterminate = false;
                myProgressBar.Visibility = System.Windows.Visibility.Collapsed;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }


        public void cmdDynamicPivotItems()
        {
            try
            {
                //make a loop 

                for (int i = 1; i <= 10; i++)
                {
                    //add on the fly pivots
                    PivotItem myNewPivotItem = new PivotItem();
                    myNewPivotItem.Name = "piv_" + i;
                    //ID of the pivot 
                    myNewPivotItem.Header = "Câu " + i;
                    //title of the pivot to be shown in app

                    //add grids also 
                    Grid myNewGrid = new Grid();
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri("ApplicationIcon.png", UriKind.Relative));

                    img.MaxWidth = 170;
                    img.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                    img.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    TextBlock wdrTitle = new TextBlock();
                    wdrTitle.FontSize = 50;
                    wdrTitle.Text = myTitle + " here " + i;
                    TextBlock wdrDescr = new TextBlock();
                    wdrDescr.FontSize = 21;
                    wdrDescr.TextWrapping = TextWrapping.Wrap;
                    //      wdrDescr.TextAlignment = TextAlignment.Justify
                    wdrDescr.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    wdrDescr.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                    wdrDescr.Text = " in pivot " + i + myDescription;
                    myNewGrid.Children.Add(img);

                    myNewGrid.Children.Add(wdrDescr);
                    myNewPivotItem.Content = myNewGrid;

                    myNewGrid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    wdrDescr.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;

                    myNewGrid.Width = 410;
                    myNewGrid.Height = 425;

                    //add pivot to main list
                    pivotMainList.Items.Add(myNewPivotItem);

                    //shorten the text for front display
                    string shortDescr = " Mô tả: " + myDescription;
                    if (shortDescr.Length > 70)
                    {
                        shortDescr = shortDescr.Substring(0, 62) + "..";
                    }
                    //TOC -  add short descr with title on the main item from the list -
                    lstItemsToList.Items.Add(new ItemViewModel
                    {
                        LineOne = myTitle + " " + i,
                        LineTwo = shortDescr,
                        LineThree = "ApplicationIcon.png"
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

 
        private void lstItemsToList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //handle navigation from TOC to pivots
            pivotMainList.SelectedIndex = lstItemsToList.SelectedIndex + 1;
        }
    }
}