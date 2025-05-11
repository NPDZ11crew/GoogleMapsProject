using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps_FinalProjectAspApi.DAL.Abstract
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task DefaultDeleteAsync(Guid id);
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User user);
    }
}
