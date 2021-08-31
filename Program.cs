using System;
using System.Threading.Tasks;

namespace WeatherAPIConsoleApp
{
    class Program
    {
        public static async Task Main()
        {
            // Weather API to get past seven day weather
            var a = await WeatherAPIController.GetPastSevenDayWeather();

            await WeatherAPIView.DisplayPastSevenDayHighTemps(a);

        }
    }
}
