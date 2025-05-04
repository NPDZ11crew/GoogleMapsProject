using GoogleMaps_FinalProjectAspApi.Models;

namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IPlaceService
    {
        Task<List<PlaceDto>> GetAllAsync();
        Task AddAsync(PlaceDto book);
        Task UpdateAsync(PlaceDto book);
        Task DefaultDeleteAsync(Guid id);
    }
}
