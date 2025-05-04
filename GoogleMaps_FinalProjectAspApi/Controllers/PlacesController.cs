using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoogleMaps_FinalProjectAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost("AddPlaceAsync")]
        public async Task AddPlaceAsync(PlaceDto place)
        {
            await _placeService.AddAsync(place);
        }

        [HttpGet("GetPlaceByIdAsync")]
        public async Task<PlaceDto> GetPlaceByIdAsync(Guid Id)
        {
            var places = _placeService.GetAllAsync().Result;
            foreach (var place in places)
            {
                if (place.Id == Id)
                {
                    return place;
                }
            }
            return new PlaceDto();
        }

        [HttpGet("GetPlacesByNameAsync")]
        public async Task<List<PlaceDto>> GetPlacesByNameAsync(string placeName)
        {
            var places = _placeService.GetAllAsync().Result;
            var resultPlaces = new List<PlaceDto>();
            foreach (var place in places)
            {
                if (place.Name.text.Contains(placeName))
                {
                    resultPlaces.Add(place);
                }
            }
            return resultPlaces;
        }

        [HttpGet("GetAllAsync")]
        public async Task<List<PlaceDto>> GetAllPlacesAsync()
        {
            return _placeService.GetAllAsync().Result;
        }

        [HttpDelete("DeletePlaceByNameAsync")]
        public async Task<PlaceDto> DeletePlaceByNameAsync(string placeName)
        {
            var places = _placeService.GetAllAsync().Result;
            var resultPlace = new PlaceDto();
            foreach (var place in places)
            {
                if (place.Name.text.ToLower().Contains(placeName.ToLower()))
                {
                    await _placeService.DefaultDeleteAsync(place.Id);
                    resultPlace = place;
                    return resultPlace;
                }
            }
            return resultPlace;
        }

        [HttpDelete("DeleteLastResultsAsync")]
        public async Task<string> DeleteFiveOldestAsync(int count)
        {
            var places = _placeService.GetAllAsync().Result.OrderByDescending(place => place.Id).Take(count).ToList();

            foreach (var place in places)
            {
                await _placeService.DefaultDeleteAsync(place.Id);
            }
            return $"{count} elements deleted Successfully!";

        }

        [HttpDelete("DeleteAllAsync")]
        public async Task<string> DeleteAllAsync()
        {
            var places = _placeService.GetAllAsync().Result;
            foreach (var place in places)
            {
                await _placeService.DefaultDeleteAsync(place.Id);
            }
            return "Deleted Successfully!";
        }



    }
}
