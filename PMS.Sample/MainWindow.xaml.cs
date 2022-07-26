using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace PMS.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpListener? httpListener;
        Process? browserProcess;
        readonly string clientId; // Fill in here
        readonly string clientSecret; // Fill in here

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (httpListener == null)
            {
                httpListener = new HttpListener();
            }
            else
            {
                if (httpListener.IsListening)
                {
                    httpListener.Stop();
                    httpListener.Abort();
                }
                httpListener = new HttpListener();
            }
            httpListener.Prefixes.Add("http://localhost:34567/");
            httpListener.Start();

            var ru = new RequestUrl("https://stageauth.infotrack.co.uk/connect/authorize");

            var url = ru.CreateAuthorizeUrl(
                clientId: clientId,
                responseType: "code",
                redirectUri: "http://localhost:34567",
                scope: "openid profile infsec:basic infsec:identity",
                responseMode: "query");

            browserProcess = new Process();
            browserProcess.StartInfo.FileName = url;
            browserProcess.StartInfo.UseShellExecute = true;
            browserProcess.StartInfo.Verb = "";
            browserProcess.Start();

            var context = httpListener.GetContext();
            var response=  context.Response;

            var code = context.Request.QueryString.Get("code");

            var authClient = new HttpClient();
            var authResponse = authClient.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
            {
                Address = "https://stageauth.infotrack.co.uk/connect/token",

                ClientId = clientId,
                ClientSecret = clientSecret,

                Code = code,
                RedirectUri = "http://localhost:34567",
            }).GetAwaiter().GetResult();

            var token = authResponse.AccessToken;

            var infotrackClient = new HttpClient();
            infotrackClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var mappingResponse = infotrackClient.PostAsync("https://stagesearch.infotrack.co.uk/secure/api/v1/mapping", new StringContent(JsonConvert.SerializeObject(PropertyMatterBuilder.Construct(txtMatter.Text, $"HOP_{txtMatter.Text}")), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();

            response.Redirect(mappingResponse.Headers.Location.AbsoluteUri);
            response.Close();
            httpListener.Stop();
        }
    }
}
