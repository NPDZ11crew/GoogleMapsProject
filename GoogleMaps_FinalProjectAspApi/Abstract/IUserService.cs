using GoogleMaps_FinalProjectAspApi.Models;

namespace GoogleMaps_FinalProjectAspApi.Abstract
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task AddAsync(UserDto user);
        Task UpdateAsync(UserDto user);
        Task DefaultDeleteAsync(Guid id);
    }
}
