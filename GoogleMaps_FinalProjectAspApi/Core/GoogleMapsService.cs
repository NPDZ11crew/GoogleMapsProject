using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text;
using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Optimization;
using GoogleMaps_FinalProjectAspApi.Models;
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
        

        public async Task<PlaceDetails?> GetPlaceDetailsFromJsonNode(JsonNode node)
        {

			var photoLinks = new List<string>();
            var weekdayDescription = new List<string>();

			foreach (var photo in node["photos"].AsArray())
			{
				var uri = photo?["googleMapsUri"]?.ToString();
				if (!string.IsNullOrWhiteSpace(uri))
					photoLinks.Add(uri);
			}

			foreach (var weekday in node["regularOpeningHours"]["weekdayDescriptions"].AsArray())
			{
				var day = weekday?.ToString();
				if (!string.IsNullOrWhiteSpace(day))
					weekdayDescription.Add(day);
			}

			var details = new PlaceDetails
			{
				Name = node["displayName"]?["text"]?.ToString() ?? "",
				Rating = node["rating"]?.GetValue<double>() ?? 0,
				RatingsCount = node["userRatingCount"]?.GetValue<int>() ?? 0,
				Address = node["formattedAddress"]?.ToString() ?? "",
				WeekdayDescriptions = weekdayDescription,
				Photos = photoLinks
			};

            return details;
		}

        public async Task<string> SearchIdGetAsync(string id)
        {
			var requestBody = SearchTextModel.GetRequestBody(id);
			return await SendGoogleMapsRequestAsync("RequestUriDetails", requestBody, id);
		}

        public async Task<string> SearchTextPostAsync(string text)
        {
            var requestBody = SearchTextModel.GetRequestBody(text);
            return await SendGoogleMapsRequestAsync("RequestUriSearchText", requestBody);
        }

        public async Task<string> SearchNearbyPostAsync(int groupOfFacility, List<int> types, double lat, double lng, float rad = 500f)
        {
            var requestBody = SearchNearbyModel.GetRequestBody(groupOfFacility, types, lat, lng, rad);
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

        public async Task<string> SendGoogleMapsRequestAsync<T>(string uriKey, T requestBody, string id)
        {
			var requestUri = _configuration.GetValue<string>($"RequestData:{uriKey}");
			var authorization = GoogleMapsAuthorization.GetAuthorization(_configuration);
			var headers = MapsHeaders.CreateGetIdHeaders();
			var request = RequestManager.CreateGetRequest($"{requestUri}{id}", headers, authorization, requestBody);
			var response = await RequestManager.SendRequest(request, _httpClient);
			return response;
		}
    }
}
