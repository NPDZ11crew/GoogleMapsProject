namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IGeocodingService
    {
        Task<(double Latitude, double Longitude, float RadiusMeters)?> GetCoordinatesAsync(string address);
        
    }
}
