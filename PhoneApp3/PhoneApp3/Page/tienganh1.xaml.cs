using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp3.Page
{
    public partial class tienganh1 : PhoneApplicationPage
    {
        public tienganh1()
        {
            InitializeComponent();
        }

        private void TA1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pivot/PivotPage.xaml", UriKind.Relative));
        }
    }
}