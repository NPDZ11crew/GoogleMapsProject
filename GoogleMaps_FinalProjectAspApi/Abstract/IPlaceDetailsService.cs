using GoogleMaps_FinalProjectAspApi.Models;

namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IPlaceDetailsService
    {
        Task<List<PlaceDetailsDto>> GetAllAsync();
        Task AddAsync(PlaceDetailsDto placeDetails);
        Task UpdateAsync(PlaceDetailsDto placeDetails);
        Task DefaultDeleteAsync(Guid id);
    }
}
