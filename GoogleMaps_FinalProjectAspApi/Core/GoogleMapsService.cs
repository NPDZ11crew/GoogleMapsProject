using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using GoogleMaps_FinalProjectAspApi.Abstract;
using System.Net;
using GoogleMaps_FinalProjectAspApi.Optimization;
using Microsoft.Extensions.Configuration;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace GoogleMaps_FinalProjectAspApi.Core
{
    public class GoogleMapsService:IGoogleMapsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GoogleMapsService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        

        public async Task<string> SearchTextPostAsync(string text)
        {
            var requestBody = SearchTextModel.GetRequestBody(text);
            return await SendGoogleMapsRequestAsync("RequestUriSearchText", requestBody);
        }

        public async Task<string> SearchNearbyPostAsync(double lat, double lng)
        {
            var requestBody = SearchNearbyModel.GetRequestBody( lat, lng);
            return await SendGoogleMapsRequestAsync("RequestUriSearchNearby", requestBody);
        }
        public async Task<string> SearchNearbyPostAsync(double lat, double lng, float rad)
        {
            var requestBody = SearchNearbyModel.GetRequestBody(lat, lng, rad);
            return await SendGoogleMapsRequestAsync("RequestUriSearchNearby", requestBody);
        }
        public async Task<string> SendGoogleMapsRequestAsync<T>(string uriKey, T requestBody)
        {
            var requestUri = _configuration.GetValue<string>($"RequestData:{uriKey}");
            var authorization = GoogleMapsAuthorization.GetAuthorization(_configuration);
            var headers = MapsHeaders.CreateHeaders();
            var request = RequestManager.CreateRequest(requestUri, headers, authorization, requestBody);
            var response = await RequestManager.SendRequest(request, _httpClient);
            return response;
        }   
    }
}
