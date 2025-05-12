using System.Text.Json.Serialization;

namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class Photo
    {
        [JsonPropertyName("name")]
        public string? PhotoName { get; set; }
        [JsonPropertyName("googleMapsUri")]
        public string? PhotoUri { get; set; }
    }
}
