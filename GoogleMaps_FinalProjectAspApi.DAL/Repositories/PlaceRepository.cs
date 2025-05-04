using GoogleMaps_FinalProjectAspApi.DAL.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace GoogleMaps_FinalProjectAspApi.DAL.Repositories
{
    public class PlaceRepository:IPlaceRepository
    {
        private readonly GMDbContext _dbContext;
        public PlaceRepository(GMDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(Place place)
        {
            await _dbContext.Places.AddAsync(place);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DefaultDeleteAsync(Guid id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place != null)
            {
                _dbContext.Places.Remove(place);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Place>> GetAllAsync()
        {
            return await _dbContext.Places.ToListAsync();
        }

        public async Task<Place> GetByIdAsync(Guid id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place == null)
            {
                place = new Place();
            }
            return place;
        }

        public async Task UpdateAsync(Place place)
        {
            _dbContext.Places.Update(place);
            await _dbContext.SaveChangesAsync();
        }

    }
}
