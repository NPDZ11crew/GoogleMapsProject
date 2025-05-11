using GoogleMaps_FinalProjectAspApi.Models;

namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IPlaceService
    {
        Task<List<PlaceDto>> GetAllAsync();
        Task AddAsync(PlaceDto place);
        Task UpdateAsync(PlaceDto place);
        Task DefaultDeleteAsync(Guid id);
    }
}
