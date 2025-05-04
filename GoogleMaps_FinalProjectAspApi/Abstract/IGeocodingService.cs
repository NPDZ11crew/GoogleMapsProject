namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IGeocodingService
    {
        Task<(double Latitude, double Longitude, float RadiusMeters)?> GetCoordinatesAsync(string address);
        //Task<string> GetAddressAsync(double lat, double lng);
    }
}
