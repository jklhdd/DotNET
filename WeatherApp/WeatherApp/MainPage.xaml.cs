using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WeatherApp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherApp
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

        private async void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var position = await LocationManager.GetPosition();
                Root myWeather = await OpenWeatherMapProxy.GetWeather(position.Coordinate.Point.Position.Latitude, position.Coordinate.Point.Position.Longitude);
                GetResultBlock.Text = myWeather.name + " - " + ((int)myWeather.main.temp - 273.15).ToString();
                string icon = string.Format($"http://openweathermap.org/img/w/{myWeather.weather[0].icon}.png");
                ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            }
            catch (Exception ex)
            {

                GetResultBlock.Text = "Error: " + ex.Message;
            }
        }
    }
}
