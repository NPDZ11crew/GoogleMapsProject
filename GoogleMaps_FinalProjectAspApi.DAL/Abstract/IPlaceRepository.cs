using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps_FinalProjectAspApi.DAL.Abstract
{
    public interface IPlaceRepository
    {
        Task AddAsync(Place place);
        Task DefaultDeleteAsync(Guid id);
        Task<Place> GetByIdAsync(Guid id);
        Task<IEnumerable<Place>> GetAllAsync();
        Task UpdateAsync(Place place);
    }
}
