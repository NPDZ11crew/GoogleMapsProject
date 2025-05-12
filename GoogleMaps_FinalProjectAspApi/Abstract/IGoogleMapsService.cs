using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;

namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IGoogleMapsService
    {

        public Task<string> SearchIdGetAsync(string id);
		public Task<string> SearchTextPostAsync(string text);
        public Task<string> SearchNearbyPostAsync(int groupOfFacility, List<int> types, double lat, double lng, float rad);
    }
}
