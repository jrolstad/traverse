namespace traverse.onebusaway.models
{
    public class ArrivalAndDeparture
    {
        public string RouteId { get; set; }
 
        public string TripId { get; set; }

        public long? ServiceDate { get; set; }

        public string StopId { get; set; }

        public int? StopSequence { get; set; }

        public int? BlockTripSequence { get; set; }

        public string RouteShortName { get; set; }

        public string RouteLongName { get; set; }

        public string TripHeadsign { get; set; }

        public bool? ArrivalEnabled { get; set; }

        public bool? DepartureEnabled { get; set; }

        public long? ScheduledArrivalTime { get; set; }

        public long? ScheduledDepartureTime { get; set; }

        public Frequency Frequency { get; set; }

        public bool? Predicted { get; set; }

        public long? PredictedArrivalTime { get; set; }

        public long? PredictedDepartureTime { get; set; }

        public decimal? DistanceFromStop { get; set; }

        public int? NumberOfStopsAway { get; set; }

        public TripStatus TripStatus { get; set; }
    }
}