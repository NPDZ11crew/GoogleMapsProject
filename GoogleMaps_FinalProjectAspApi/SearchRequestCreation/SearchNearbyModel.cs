namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class SearchNearbyModel
    {
        public List<string> includedTypes { get; set; }
        public int maxResultCount { get; set; }
        public LocationRestriction locationRestriction { get; set; }


        public static SearchNearbyModel GetRequestBody(double lat, double lng, float rad)
        {
            var requestBody = new SearchNearbyModel
            {
                includedTypes = new List<string> { "restaurant" },
                maxResultCount = 10,
                locationRestriction = new LocationRestriction
                {
                    circle = new Circle
                    {
                        center = new Center
                        {
                            latitude = lat,
                            longitude = lng,
                        },
                        radius = rad,
                    }
                }
            };
            return requestBody;
        }

        public static SearchNearbyModel GetRequestBody(List<string> types)
        {
            var requestBody = new SearchNearbyModel
            {
                includedTypes = types,
                maxResultCount = 10,
                locationRestriction = new LocationRestriction
                {
                    circle = new Circle
                    {
                        center = new Center
                        {
                            latitude = 37.7937,
                            longitude = -122.3965,
                        },
                        radius = 500f,
                    }
                }
            };
            return requestBody;
        }

        public static SearchNearbyModel GetRequestBody(int groupOfFacility, List<int> types, double lat, double lng, float rad = 500f)
        {
            var strTypes = new List<string>();

            foreach (var type in types)
            {
                strTypes.Add(GoogleMapsTypes.Types[groupOfFacility][type]);
            }

            var requestBody = new SearchNearbyModel
            {
                includedTypes = strTypes,
                maxResultCount = 10,
                locationRestriction = new LocationRestriction
                {
                    circle = new Circle
                    {
                        center = new Center
                        {
                            latitude = lat,
                            longitude = lng,
                        },
                        radius = rad,
                    }
                }
            };
            return requestBody;
        }
    }
}
