namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class MapsHeaders
    {
        public Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();

        public static MapsHeaders CreateHeaders()
        {
            var headers = new MapsHeaders();
            headers.RequestHeaders.Add("X-Goog-FieldMask", "places.id,places.displayName,places.nationalPhoneNumber,places.formattedAddress,places.rating,places.googleMapsUri,places.location,places.types");
            return headers;
        }
        public static MapsHeaders CreateHeaders(List<string> keys, List<string> values)
        {
            var headers = new MapsHeaders();
            for (int i = 0; i < keys.Count; i++)
            {
                headers.RequestHeaders[keys[i]] = values[i];
            }
            return headers;
        }
    }
}
