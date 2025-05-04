using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;

namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IGoogleMapsService
    {
        public Task<string> SearchTextPostAsync(string text);
        public Task<string> SearchNearbyPostAsync(double lat, double lng, float rad = 500f);
    }
}
