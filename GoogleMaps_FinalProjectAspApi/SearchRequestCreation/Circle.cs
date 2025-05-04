namespace GoogleMaps_FinalProjectAspApi.SearchRequestCreation
{
    public class Circle
    {
        public Center center { get; set; } 
        public float radius { get; set; }

        public Circle(double longitude, double latitude, float Radius)
        {
            center = new Center(latitude, longitude);
            radius = Radius;
        }
        public Circle()
        {
            
        }
    }
}
