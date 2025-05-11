using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;

namespace GoogleMaps_FinalProjectAspApi.Models
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string? TelegramId { get; set; }
        public string? LastCity { get; set; }
        public Center? ActualLatLng { get; set; }
    }
}
