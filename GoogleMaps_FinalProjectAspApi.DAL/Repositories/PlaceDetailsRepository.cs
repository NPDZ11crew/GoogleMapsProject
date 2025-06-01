using GoogleMaps_FinalProjectAspApi.DAL.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps_FinalProjectAspApi.DAL.Repositories
{
    public class PlaceDetailsRepository : IPlaceDetailsRepository
    {
        private readonly GMDbContext _dbContext;
        public PlaceDetailsRepository(GMDbContext context)
        {
            _dbContext = context;
        }
        public async Task AddAsync(PlaceDetails placeDetails)
        {
            await _dbContext.PlacesDetails.AddAsync(placeDetails);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DefaultDeleteAsync(Guid id)
        {
            var placeDetails = await _dbContext.PlacesDetails.FindAsync(id);
            if (placeDetails != null)
            {
                _dbContext.PlacesDetails.Remove(placeDetails);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PlaceDetails>> GetAllAsync()
        {
            return await _dbContext.PlacesDetails.ToListAsync();
        }

        public async Task<PlaceDetails> GetByIdAsync(Guid id)
        {
            var placeDetails = await _dbContext.PlacesDetails.FindAsync(id);
            if (placeDetails == null)
            {
                placeDetails = new PlaceDetails();
            }
            return placeDetails;
        }

        public async Task UpdateAsync(PlaceDetails placeDetails)
        {
            _dbContext.PlacesDetails.Update(placeDetails);
            await _dbContext.SaveChangesAsync();
        }
    }
}
