using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Models;
using GoogleMaps_FinalProjectAspApi.Optimization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;



namespace GoogleMaps_FinalProjectAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleMapsController : ControllerBase
    {
        private readonly ILogger<GoogleMapsController> _logger;
        private readonly IGoogleMapsService _googleMapService;
        private readonly IPlaceService _placeService;

        public GoogleMapsController(ILogger<GoogleMapsController> logger, IGoogleMapsService googleMapService, IPlaceService placeService)
        {
            _logger = logger;
            _googleMapService = googleMapService;
            _placeService = placeService;
        }

        [HttpPost("SearchText")]
        public async Task<IActionResult> TextSearch(string searchText)
        {
            var responseResult = await _googleMapService.SearchTextPostAsync(searchText);
            if (responseResult == null) 
            {
                return NotFound();
            }
            PlaceDto place = JsonSerializer.Deserialize<PlaceApiResponse>(responseResult).Places[0];
            await _placeService.AddAsync(place);
            return Ok(place);
        }

        [HttpPost("SearchNearby")]
        public async Task<IActionResult> NearbySearch(double lat, double lng)
        {
            var responseResult = await _googleMapService.SearchNearbyPostAsync();
            if (responseResult == null)
            {
                return NotFound();
            }
            var places = JsonSerializer.Deserialize<PlaceApiResponse>(responseResult).Places;
            foreach (PlaceDto place in places)
            {
                await _placeService.AddAsync(place);
            }
            return Ok(places);
        }

    }
}
