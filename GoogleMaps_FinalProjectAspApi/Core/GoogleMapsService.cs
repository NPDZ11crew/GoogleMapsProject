using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;
using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Optimization;

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
