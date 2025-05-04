namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class GoogleMapsAuthorization
    {
        public string ApiKeyName { get; set; }
        public string ApiKeyValue { get; set; }

        public static GoogleMapsAuthorization GetAuthorization(IConfiguration _configuration)
        {
            return new GoogleMapsAuthorization
            {
                ApiKeyName = _configuration.GetValue<string>("RequestData:ApiKeyName"),
                ApiKeyValue = _configuration.GetValue<string>("RequestData:ApiKey")
            };
        }
    }
}
