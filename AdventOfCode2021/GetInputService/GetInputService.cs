using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetInputService
{
    public static class GetInputService
    {
        public static async Task GetInputs()
        {
            var URL = new Uri("https://adventofcode.com/2021/day/");
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = URL;
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                cookieContainer.Add(URL, new Cookie("session",SessionParams.SessionKey));

                for (int dayNumber = 1; dayNumber <= CheckForFiles.GetMaxDayValue(); dayNumber++)
                {
                    var inputs = new DirectoryInfo(Directory.GetCurrentDirectory() + @"..\..\..\..\..\Inputs\");
                    var daynumberString = "00" + dayNumber;
                    daynumberString = ("00" + dayNumber).Substring(daynumberString.Length -2);
                    var inputFile = inputs.FullName + $"D{daynumberString}.txt";
                    if (File.Exists(inputFile)) continue;

                    var response = await client.GetStringAsync($"{dayNumber}/input");
                    
                    if (!response.Equals(string.Empty))
                    {
                        File.WriteAllText(inputFile,response);
                    }
                }
            }
        }
    }
    public class CheckForFiles
    {
        public static int GetMaxDayValue()
        {
            DateTime startdate = new DateTime(2021, 12, 1);
            int diff = Math.Min((DateTime.UtcNow - startdate).Days +1, 25); 
            return diff;
        }
    }
}