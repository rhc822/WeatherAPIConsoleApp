using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherAPIConsoleApp
{
    class WeatherAPIController
    {

        private static readonly HttpClient client = new HttpClient();

        public static async Task<WeatherAPIModels> GetPastSevenDayWeather()
        //public static async Task<List<float>> GetPastSevenDayWeather()
        {
            Console.WriteLine("Enter a location");
            string location = Console.ReadLine();
            string endDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string startDate = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "3a62bb364emshfe24fb90cd88c07p1f19bejsn24d536260e98");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "weatherapi-com.p.rapidapi.com");

            var streamTask = client.GetStreamAsync($"https://weatherapi-com.p.rapidapi.com/history.json?q={location}&dt={startDate}&lang=en&end_dt={endDate}");
            var repositories = await JsonSerializer.DeserializeAsync<WeatherAPIModels>(await streamTask);
            return repositories;

            // API CALL, RETURN STRING INSTEAD OF STREAM 
            //var stringTask = client.GetStringAsync($"https://weatherapi-com.p.rapidapi.com/history.json?q={location}&dt={startDate}&lang=en&end_dt={endDate}");
            //var msg = await stringTask;
            //Console.WriteLine(msg);
            //var repositories = JsonSerializer.Deserialize<WeatherAPIRepo>(msg);
            //Console.WriteLine(repositories.location.name);
            //return repositories;

        }
    }
}
