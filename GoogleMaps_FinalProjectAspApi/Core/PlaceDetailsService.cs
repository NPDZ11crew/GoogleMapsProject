using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using GoogleMaps_FinalProjectAspApi.Models;
using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;

namespace GoogleMaps_FinalProjectAspApi.Core
{
    public class PlaceDetailsService : IPlaceDetailsService
    {
        private readonly IPlaceDetailsRepository _repository;
        public PlaceDetailsService(IPlaceDetailsRepository repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(PlaceDetailsDto placeDetails)
        {
            placeDetails.Id = Guid.NewGuid();

            var result = new PlaceDetails
            {
                Id = placeDetails.Id,
                Name = placeDetails.Name,
                Rating = placeDetails.Rating,
                RatingsCount = placeDetails.RatingsCount,
                Address = placeDetails.Address,
                WeekdayDescriptions = placeDetails.WeekdayDescriptions,
                Photos = placeDetails.Photos
            };
            await _repository.AddAsync(result);
        }

        public async Task DefaultDeleteAsync(Guid id)
        {
            await _repository.DefaultDeleteAsync(id);
        }

        public async Task<List<PlaceDetailsDto>> GetAllAsync()
        {
            var placeDetailsDto = new List<PlaceDetailsDto>();

            var result = await _repository.GetAllAsync();

            foreach (var placeDetails in result)
            {
                placeDetailsDto.Add(new PlaceDetailsDto
                {
                    Id = placeDetails.Id,
                    Name = placeDetails.Name,
                    Rating = placeDetails.Rating,
                    RatingsCount = placeDetails.RatingsCount,
                    Address = placeDetails.Address,
                    WeekdayDescriptions = placeDetails.WeekdayDescriptions,
                    Photos = placeDetails.Photos
                });
                
            }

            return placeDetailsDto;
        }

        public async Task UpdateAsync(PlaceDetailsDto placeDetails)
        {
            placeDetails.Id = Guid.NewGuid();

            var result = new PlaceDetails
            {
                Id = placeDetails.Id,
                Name = placeDetails.Name,
                Rating = placeDetails.Rating,
                RatingsCount = placeDetails.RatingsCount,
                Address = placeDetails.Address,
                WeekdayDescriptions = placeDetails.WeekdayDescriptions,
                Photos = placeDetails.Photos
            };
            
            await _repository.UpdateAsync(result);
        }
    }
}
