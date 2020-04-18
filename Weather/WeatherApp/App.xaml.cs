using WeatherApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: ExportFont(fontFileName: "BebasNeue-Regular.ttf", Alias = "Bebas")]
namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        // Handle when your app starts
        protected override void OnStart() { }

        // Handle when your app sleeps
        protected override void OnSleep() { }

        // Handle when your app resumes
        protected override void OnResume() { }
    }
}
