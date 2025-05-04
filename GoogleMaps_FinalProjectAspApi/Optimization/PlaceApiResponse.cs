using GoogleMaps_FinalProjectAspApi.Models;
using System.Text.Json.Serialization;

namespace GoogleMaps_FinalProjectAspApi.Optimization
{
    public class PlaceApiResponse
    {
        [JsonPropertyName("places")]
        public List<PlaceDto> Places { get; set; }
    }
}
