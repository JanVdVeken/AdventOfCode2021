using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class InputGetter
    {
        private HttpClient _client;
        private Uri baseAddress = new Uri("https://adventofcode.com/2021/");
        private string CurrentTest = "day/2/input";

        public InputGetter()
        { 
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() {CookieContainer = cookieContainer};
            _client = new HttpClient(handler) {BaseAddress = baseAddress};
            cookieContainer.Add(baseAddress, new Cookie("Session", "53616c7465645f5fc5265fe863b6fc15b92f11f5b9ace22410ed8c4abfd66997429eee01543629390b58aea9a59f83b7"));
        }


        public async Task GetInput()
        {
            try
            {
                var result = await _client.GetAsync(CurrentTest);

                var encoding = ASCIIEncoding.ASCII;
                using (var reader = new System.IO.StreamReader(result.Content.ReadAsStream(), encoding))
                {
                    string responseText = reader.ReadToEnd();
                    Console.WriteLine(responseText);
                }
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
    }
}