namespace traverse.onebusaway.models
{
    public class Trip
    {
        public string Id { get; set; } 

        public string RouteId { get; set; } 

        public string TripShortName { get; set; }

        public string TripHeadsign { get; set; }

        public string ServiceId { get; set; }

        public string ShapeId { get; set; }

        public int? DirectionId { get; set; }
    }
}