using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;
using System.Text.Json.Serialization;
namespace GoogleMaps_FinalProjectAspApi.Models
{
    public class PlaceDto
    {
        [JsonPropertyName("internalId")]
        public Guid Id { get; set; }

        [JsonPropertyName("id")]
        public string PlaceId { get; set; }

        [JsonPropertyName("displayName")]
        public LocalizedText Name { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; set; }

        [JsonPropertyName("nationalPhoneNumber")]
        public string? NationalPhoneNumber { get; set; }

        [JsonPropertyName("location")]
        public Center Location { get; set; }

        [JsonPropertyName("formattedAddress")]
        public string FormattedAddress { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("googleMapsUri")]
        public string GoogleMapsUri { get; set; }

        [JsonPropertyName("photos")]
        public List<Photo> Photos { get; set; }
        public DateTime DateOfRequest { get; set; }
    }
}
