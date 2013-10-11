namespace traverse.onebusaway.models
{
    public class VehicleStatus
    {
        public string VehicleId { get; set; }

        public long? LastUpdateTime { get; set; }

        public long? LastLocationUpdateTime { get; set; }

        public Position Location { get; set; }

        public string TripId { get; set; }

        public TripStatus TripStatus { get; set; }
    }
}