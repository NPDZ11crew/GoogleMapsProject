using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Abstract;
using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using GoogleMaps_FinalProjectAspApi.Models;
using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;

namespace GoogleMaps_FinalProjectAspApi.Core
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _repository;
        public PlaceService(IPlaceRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(PlaceDto place)
        {
            place.Id = Guid.NewGuid();
            var result = new Place
            {
                Id = place.Id,
                PlaceId = place.PlaceId,
                Name = place.Name.text,
                NationalPhoneNumber = place.NationalPhoneNumber,
                Latitude = place.Location.latitude,
                Longitude = place.Location.longitude,
                FormattedAddress = place.FormattedAddress,
                Rating = place.Rating,
                GoogleMapsUri = place.GoogleMapsUri
            };
            await _repository.AddAsync(result);
        }

        public async Task DefaultDeleteAsync(Guid id)
        {
            await _repository.DefaultDeleteAsync(id);
        }

        public async Task<List<PlaceDto>> GetAllAsync()
        {
            var placesDto = new List<PlaceDto>();

            var result = await _repository.GetAllAsync();

            foreach (var place in result)
            {
                placesDto.Add(new PlaceDto
                {
                    Id = place.Id,
                    PlaceId = place.PlaceId,
                    Name = new LocalizedText { text = place.Name, languageCode = "unknown"},
                    NationalPhoneNumber = place.NationalPhoneNumber,
                    Location = new Center
                    {
                        latitude = place.Latitude, 
                        longitude = place.Longitude
                    },
                    FormattedAddress = place.FormattedAddress,
                    Rating = place.Rating,
                    GoogleMapsUri = place.GoogleMapsUri
                });
            }

            return placesDto;
        }

        public async Task UpdateAsync(PlaceDto place)
        {
            place.Id = Guid.NewGuid();
            var result = new Place
            {
                Id = place.Id,
                PlaceId = place.PlaceId,
                Name = place.Name.text,
                NationalPhoneNumber = place.NationalPhoneNumber,
                Latitude = place.Location.latitude,
                Longitude = place.Location.longitude,
                FormattedAddress = place.FormattedAddress,
                Rating = place.Rating,
                GoogleMapsUri = place.GoogleMapsUri
            };
            await _repository.UpdateAsync(result);
        }
    }


}
