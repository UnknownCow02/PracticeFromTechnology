using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace PracticeFromTechnology_WebApi_
{
    public class RandomizerApi
    {
        private readonly string _baseUrl;
        private readonly Random _random;
        public RandomizerApi(IOptions<ApiSettings> apiSettings)
        {
            _baseUrl = apiSettings.Value.RandomApiUrl;
            _random = new Random();
        }

        public async Task<int> GetRandomIndexAsync(int max)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var requestUrl = $"http://www.randomnumberapi.com/api/v1.0/random?min=0&max={max}";
                    var response = await client.GetAsync(requestUrl);

                    if(response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var randomNumbers = JsonConvert.DeserializeObject<List<int>>(jsonString);

                        if(randomNumbers != null)
                        {
                        return randomNumbers.First();
                        }
                    }
                    else
                    {
                        throw new Exception("Failed to connection to API");
                    }
                }
            }
            catch
            {
                return _random.Next(0, max);
            }
            return 0;
        }
    }
}
