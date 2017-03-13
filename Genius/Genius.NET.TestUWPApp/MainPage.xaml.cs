using System;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Genius.NET.TestUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Authenticator.ClientId = "<Client ID>";
            Authenticator.RedirectUri = "https://genius.com";
            Authenticator.Scope = "me create_annotation manage_annotation vote";
            Authenticator.State = "default_state";
            Authenticator.ClientSecret = "<Client Secret>";
            var url = Authenticator.GetAuthenticationUrl();
            var unescapedUrl = Uri.EscapeUriString(url.ToString());
            WebView1.FrameContentLoading += web_FrameContentLoading;
            WebView1.NavigationCompleted += web_NavigationCompleted;
            WebView1.NavigateToString(unescapedUrl);
        }

        private static void web_FrameContentLoading(WebView sender, WebViewContentLoadingEventArgs args)
        {
            Debug.WriteLine("Yo");
        }

        private static async void web_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            try
            {
                if (args.Uri != null)
                {
                    var uri = args.Uri.ToString();
                    if (uri.Contains("code="))
                    {
                        await Authenticator.GetAccessToken(args.Uri);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
