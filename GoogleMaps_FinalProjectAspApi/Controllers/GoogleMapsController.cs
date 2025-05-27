using GoogleMaps_FinalProjectAspApi.Abstract;
using GoogleMaps_FinalProjectAspApi.Core;
using GoogleMaps_FinalProjectAspApi.Models;
using GoogleMaps_FinalProjectAspApi.Optimization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;



namespace GoogleMaps_FinalProjectAspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleMapsController : ControllerBase
    {
        private readonly ILogger<GoogleMapsController> _logger;
        private readonly IGoogleMapsService _googleMapService;
        private readonly IPlaceService _placeService;
        private readonly IGeocodingService _geocodingService;

        public GoogleMapsController(ILogger<GoogleMapsController> logger, IGoogleMapsService googleMapService, IPlaceService placeService, IGeocodingService geocodingService)
        {
            _logger = logger;
            _googleMapService = googleMapService;
            _placeService = placeService;
            _geocodingService = geocodingService;
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
        public async Task<IActionResult> NearbySearch(int groupOfFacility, List<int> types, double lat, double lng, float rad = 500f)
        {
            
            var responseResult = await _googleMapService.SearchNearbyPostAsync(groupOfFacility, types , lat, lng, rad);

            if (responseResult == null)
            {
                return NotFound();
            }
            var places = JsonSerializer.Deserialize<PlaceApiResponse>(responseResult).Places.OrderBy(p => p.Rating).ToList();
            foreach (PlaceDto place in places)
            {
                await _placeService.AddAsync(place);
            }
            return Ok(places);
        }

        [HttpPost("NearbySearchByCity")]
        public async Task<IActionResult> NearbySearchByCity(int groupOfFacility, List<int> types, string city)
        {

            var coordinates = await _geocodingService.GetCoordinatesAsync(city);
            if (coordinates == null)
            {
                return NotFound("City not found or geocoding error.");
            }

            var (lat, lng, rad) = coordinates.Value;

            //return Ok($"{lat}, {lng}, {rad}");

            var responseResult = await _googleMapService.SearchNearbyPostAsync( groupOfFacility, types,lat, lng, rad);
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

		[HttpPost("SearchPlaceDetailsById")]
		public async Task<IActionResult> SearchPlaceDetailsById(string id)
		{
			var node = JsonNode.Parse(await _googleMapService.SearchIdGetAsync(id));

			if (node == null)
			{
				return null;
			}

			var details = await _googleMapService.GetPlaceDetailsFromJsonNode(node);
        
			return Ok(details);
		}
	}
}
