using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MuhasebeApp.Libs
{
    public  class ApiServices
    {
       
        private static  HttpClient _httpClient;
        private readonly static string _baseUrl = "www.......";
        public   ApiServices()
        {
            _httpClient = new HttpClient();
        }


        public static async Task<T> GetData<T>(string url)
        {

            var convertUrl = _baseUrl + url;
            var request = new HttpRequestMessage(HttpMethod.Get,convertUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

             var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // var readData = await response.Content.ReadFromJsonAsync<T>();
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }

            throw new Exception($"HATA: {response.StatusCode}");
        }

        public static async Task<T> PostData<T>(string url,T data)
        {
            var converUrl = _baseUrl + url;
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, converUrl);
            request.Content = content;
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
            }
            throw new Exception($"HATA: {response.StatusCode}");

        }

    }
}
