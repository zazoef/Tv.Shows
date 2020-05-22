using Newtonsoft.Json;

using Polly;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TvShows.Wrapper
{
    public class HttpClientWrapper
    {
       
        public async Task<T> GetWithPolly<T>(HttpClient httpClient,string url) where T : class
        {            
            var maxRetryAttempts = 3;
            var pauseBetweenFailures = TimeSpan.FromSeconds(10);

            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);

            var result = await retryPolicy.ExecuteAsync(async () =>
            {
                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiResponse);
            });
            return result;
        }
    }
}