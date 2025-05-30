using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Core;
using GoogleMaps_FinalProjectAspApi.DAL.Entities;
using GoogleMaps_FinalProjectAspApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoogleMaps_FinalProjectAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceDetailsController : ControllerBase
    {
        private readonly IPlaceDetailsService _placeDetailsService;

        public PlaceDetailsController(IPlaceDetailsService placeDetailsService)
        {
            _placeDetailsService = placeDetailsService;
        }

        [HttpPost("AddPlaceDetailsAsync")]
        public async Task AddPlaceDetailsAsync(PlaceDetailsDto placeDetails)
        {
            await _placeDetailsService.AddAsync(placeDetails);
        }

        [HttpGet("GetPlaceDetailsByIdAsync")]
        public async Task<PlaceDetailsDto> GetPlaceByIdAsync(Guid Id)
        {
            var placesDetails = _placeDetailsService.GetAllAsync().Result;
            foreach (var placeDetails in placesDetails)
            {
                if (placeDetails.Id == Id)
                {
                    return placeDetails;
                }
            }
            return new PlaceDetailsDto();
        }

        [HttpGet("GetPlaceDetailsByNameAsync")]
        public async Task<List<PlaceDetailsDto>> GetPlacesByNameAsync(string placeName)
        {
            var placesDetails = await _placeDetailsService.GetAllAsync();
            var resultPlacesDetails = new List<PlaceDetailsDto>();
            foreach (var placeDetails in placesDetails)
            {
                if (placeDetails.Name.Contains(placeName))
                {
                    resultPlacesDetails.Add(placeDetails);
                }
            }
            return resultPlacesDetails;
        }



        [HttpGet("GetAllAsync")]
        public async Task<List<PlaceDetailsDto>> GetAllPlacesDetailsAsync()
        {
            return _placeDetailsService.GetAllAsync().Result;
        }

        [HttpDelete("DeletePlaceDetailsByNameAsync")]
        public async Task<PlaceDetailsDto> DeletePlaceByNameAsync(string placeName)
        {
            var placesDetails = _placeDetailsService.GetAllAsync().Result;
            var resultPlaceDetails = new PlaceDetailsDto();
            foreach (var placeDetails in placesDetails)
            {
                if (placeDetails.Name.ToLower().Contains(placeName.ToLower()))
                {
                    await _placeDetailsService.DefaultDeleteAsync(placeDetails.Id);
                    resultPlaceDetails = placeDetails;
                    return resultPlaceDetails;
                }
            }
            return resultPlaceDetails;
        }

        [HttpDelete("DeleteLastResultsAsync")]
        public async Task<string> DeleteFiveOldestAsync(int count)
        {
            var placesDetails = _placeDetailsService.GetAllAsync().Result.OrderByDescending(placeDetails => placeDetails.Id).Take(count).ToList();

            foreach (var placeDetails in placesDetails)
            {
                await _placeDetailsService.DefaultDeleteAsync(placeDetails.Id);
            }
            return $"{count} elements deleted Successfully!";

        }

        [HttpDelete("DeleteAllAsync")]
        public async Task<string> DeleteAllAsync()
        {
            var placesDetails = _placeDetailsService.GetAllAsync().Result;
            foreach (var placeDetails in placesDetails)
            {
                await _placeDetailsService.DefaultDeleteAsync(placeDetails.Id);
            }
            return "Deleted Successfully!";
        }
    }
}
