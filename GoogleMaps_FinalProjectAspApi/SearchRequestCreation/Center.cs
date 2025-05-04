namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class Center
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Center(double Latitude, double Longitude)
        {
            latitude = Latitude;
            longitude = Latitude;
        }
        public Center()
        {

        }

    }
}
