using System;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;

namespace FacebookWP7
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region //--------- Public Constructors ---------//
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region //--------- Event Handlers --------------//
        
        /// <summary>
        /// Called when [facebook login button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void OnFacebookLoginButtonClick(object sender, RoutedEventArgs args)
        {
            NavigationService.Navigate(new Uri("/Pages/FacebookLoginPage.xaml", UriKind.Relative));
        }
    
        #endregion
    }
}