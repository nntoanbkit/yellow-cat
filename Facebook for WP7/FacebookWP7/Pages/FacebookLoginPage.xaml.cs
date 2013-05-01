using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Facebook.Client;
using Microsoft.Phone.Controls;

namespace FacebookWP7.Pages
{
    public partial class FacebookLoginPage : PhoneApplicationPage
    {
        #region //--------- Private Fields --------------//
        
        private FacebookSession _session;
        
        #endregion
        
        #region //--------- Public Constructors ---------//
        
        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookLoginPage" /> class.
        /// </summary>
        public FacebookLoginPage()
        {
            InitializeComponent();
        }
        
        #endregion
        
        #region //--------- Event Handlers --------------//
        
        /// <summary>
        /// Called when [page loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private async void OnPageLoaded(object sender, RoutedEventArgs args)
        {
            if (!App.IsAuthenticated)
            {
                App.IsAuthenticated = true;
                await Authenticate();
            }
        }
        
        #endregion
        
        #region //--------- Private Methods -------------//
        
        private async Task Authenticate()
        {
            string message = String.Empty;
            
            try
            {
                _session = await App.FacebookSessionClient.LoginAsync("user_about_me,read_stream");
                App.AccessToken = _session.AccessToken;
                App.FacebookId = _session.FacebookId;
                
                Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/Pages/LandingPage.xaml", UriKind.Relative)));
            }
            catch (InvalidOperationException ex)
            {
                message = "Login failed! Exception details: " + ex.Message;
                MessageBox.Show(message);
            }
        }
    
        #endregion
    }
}