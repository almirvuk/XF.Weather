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
                SetLoadingVisibility(true);

                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri());
                BindingContext = weatherData;

                SetLoadingVisibility(false);
            }
        }

        private string GenerateRequestUri()
        {
            string requestUri = Constants.OpenWeatherMapEndpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=metric"; 
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

        private void SetLoadingVisibility(bool isVisible)
        {
            isLoadingActivityIndicator.IsRunning = isLoadingActivityIndicator.IsVisible = isVisible;

            contentStackLayout.IsVisible = !isVisible;
        }
    }
}
