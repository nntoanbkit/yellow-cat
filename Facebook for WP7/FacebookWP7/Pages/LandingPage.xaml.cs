using System;
using System.Collections.Generic;
using System.Linq;
using Facebook;
using Microsoft.Phone.Controls;
using System.Windows;

namespace FacebookWP7.Pages
{
    public partial class LandingPage : PhoneApplicationPage
    {
        #region //--------- Public Constructors ---------//
        
        /// <summary>
        /// Initializes a new instance of the <see cref="LandingPage" /> class.
        /// </summary>
        public LandingPage()
        {
            InitializeComponent();
            LoadUserInfo();
        }
        
        #endregion
        
        #region //--------- Public Methods --------------//
        
        /// <summary>
        /// Loads the user info.
        /// </summary>
        private void LoadUserInfo()
        {
            var fb = new FacebookClient(App.AccessToken);
            
            fb.GetCompleted += (sender, args) =>
            {
                if (args.Error != null)
                {
                    Dispatcher.BeginInvoke(() => MessageBox.Show(args.Error.Message));
                    return;
                }
                
                var result = args.GetResultData<IDictionary<string, object>>();
                
                Dispatcher.BeginInvoke(() =>
                {
                    FacebookData.Me.Name = String.Format(
                        "{0} {1}",
                        (string)result["first_name"],
                        (string)result["last_name"]);
                    
                    FacebookData.Me.PictureUri = new Uri(String.Format(
                        "https://graph.facebook.com/{0}/picture?type={1}&access_token={2}",
                        App.FacebookId,
                        "square",
                        App.AccessToken));
                });

                fb.GetAsync("me");
            };
        }
    
        #endregion
    }
}