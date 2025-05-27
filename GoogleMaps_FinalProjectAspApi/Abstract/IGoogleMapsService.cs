using GoogleMaps_FinalProjectAspApi.Models;
using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;
using System.Text.Json.Nodes;

namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IGoogleMapsService
    {

        public Task<string> SearchIdGetAsync(string id);
	    public Task<string> SearchTextPostAsync(string text);
        public Task<string> SearchNearbyPostAsync(int groupOfFacility, List<int> types, double lat, double lng, float rad);
        public Task<PlaceDetails> GetPlaceDetailsFromJsonNode(JsonNode node);
	}
}
