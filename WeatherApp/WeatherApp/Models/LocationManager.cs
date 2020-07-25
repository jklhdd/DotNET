using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace WeatherApp.Models
{
    public class LocationManager
    {
        public async static Task<Geoposition> GetPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus != GeolocationAccessStatus.Allowed) 
            {
                var message = new MessageDialog("Not allowed");
                await message.ShowAsync();
            }

            var geolocator = new Geolocator() { DesiredAccuracyInMeters = 0 };
            return await geolocator.GetGeopositionAsync();
        }
    }
}
