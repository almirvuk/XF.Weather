using System;
using WeatherApp.Helpers;
using WeatherApp.Models;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly RestService _restService;

        public MainPage()
        {
            InitializeComponent();

            _restService = new RestService();
        }

        private async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                isLoadingActivityIndicator.IsRunning = isLoadingActivityIndicator.IsVisible = true;

                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;

                isLoadingActivityIndicator.IsRunning = isLoadingActivityIndicator.IsVisible = false;
            }
        }

        private string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; 
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}
