using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAPIConsoleApp
{
    class WeatherAPIView
    {
        public static async Task DisplayPastSevenDayHighTemps(WeatherAPIModels weatherList)
        {
            // Data source
            //int[] scores = new int[] { 97, 92, 81, 60 };
            List<WeatherAPIModels.Forecastday> day = new List<WeatherAPIModels.Forecastday>();
            foreach (var i in weatherList.forecast.forecastday)
            {
                day.Add(i);
            }

            // Query1
            IEnumerable<WeatherAPIModels.Forecastday> highTempQuery =
                from temp in day
                where temp.day.maxtemp_f >= 90
                orderby temp.day.maxtemp_f ascending
                select temp;
            Console.Write($"High Temps in {weatherList.location.name} over 70 degrees Farenheit for the last seven days were:\n");
            foreach (var i in highTempQuery)
            {
                Console.WriteLine($"{i.date}: {i.day.maxtemp_f}\n");
            }

        }
    }
}
