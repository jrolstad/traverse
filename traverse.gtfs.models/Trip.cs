namespace traverse.gtfs.models
{
    public class Trip
    {
        public string RouteId { get; set; }

        public string ServiceId { get; set; }

        public string TripId { get; set; }

        public string TripHeadsign { get; set; }

        public string TripShortName { get; set; }

        public TripDirection? DirectionId { get; set; }

        public string BlockId { get; set; }

        public string ShapeId { get; set; }

        public WheelchairAccessible? WheelchairAccessible { get; set; }
    }

    public enum TripDirection
    {
        OneDirection = 0,
        OppositeDirection = 1
    }
}