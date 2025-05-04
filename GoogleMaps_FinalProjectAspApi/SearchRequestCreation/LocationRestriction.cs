namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class LocationRestriction
    {
        public Circle circle { get; set; }

        public LocationRestriction(double longitude, double latitude, float radius)
        {
            circle = new Circle(longitude, latitude, radius);
        }
        public LocationRestriction()
        {
            
        }
    }
}
