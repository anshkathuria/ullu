using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ullu.Constants;
using ullu.Dto;

namespace ullu.Services
{
    public sealed class GoogleMapsService
    {
        private string GoogleMapsApiBaseAddress = "https://maps.googleapis.com/maps/api/";

        private static readonly GoogleMapsService instance = new GoogleMapsService();
        static GoogleMapsService()
        {
        }
        public static GoogleMapsService Instance
        {
            get
            {
                return instance;
            }
        }

        private HttpClient GetClient(HttpClientHandler handler = null)
        {
            var client = handler == null ? new HttpClient() : new HttpClient(handler, true);

            client.BaseAddress = new Uri(GoogleMapsApiBaseAddress);
            client.Timeout = TimeSpan.FromSeconds(20);

            return client;
        }
        private Task<HttpResponseMessage> RequestAsync(HttpMethod method, string path, object payload = null)
        {
            try
            {
                var request = PrepareRequest(method, path, payload);
                return GetClient().SendAsync(request, HttpCompletionOption.ResponseContentRead);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
        private HttpRequestMessage PrepareRequest(HttpMethod method, string path, object payload)
        {
            var uri = PrepareUri(path);

            var request = new HttpRequestMessage(method, uri);

            if (payload != null)
            {
                var json = JsonConvert.SerializeObject(payload);
                request.Content = new StringContent(json);
            }
            return request;
        }
        private Uri PrepareUri(string path)
        {
            var queryPath = string.Format("{0}&key={1}", path, AppConstants.GOOGLE_MAPS_API_KEY);
            var basePath = GoogleMapsApiBaseAddress;
            var url = string.Format("{0}{1}", basePath, queryPath);
            return new Uri(url);
        }

        public async Task<Location> GetLocationFromAddress(string address)
        {
            try
            {
                string geocodePath = String.Format("{0}{1}", "geocode/json?address=", address);
                HttpResponseMessage response = RequestAsync(HttpMethod.Get, geocodePath).Result;
                string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Geocoding g = JsonConvert.DeserializeObject<Geocoding>(content);
                    if(g.results.Count > 0)
                    {
                        return g.results[0].geometry.location;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }
    }
}
