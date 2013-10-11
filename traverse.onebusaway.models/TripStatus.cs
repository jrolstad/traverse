using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class TripStatus
    {
        public string ActiveTripId { get; set; }

        public int? BlockTripSequence { get; set; }

        public long? ServiceDate { get; set; }

        public decimal? ScheduledDistanceAlongTrip { get; set; }

        public decimal? TotalDistanceAlongTrip { get; set; }

        public Position Position { get; set; }

        public decimal? Orientation { get; set; }

        public string ClosestStop { get; set; }

        public int? ClosestStopTimeOffset { get; set; }

        public string NextStop { get; set; }

        public int? NextStopTimeOffset { get; set; }

        public string Phase { get; set; }

        public string Status { get; set; }

        public bool Predicted { get; set; }

        public long? LastUpdateTime { get; set; }

        public long? LastLocationUpdateTime { get; set; }

        public Position LastKnownLocation { get; set; }

        public decimal? LastKnownOrientation { get; set; }

        public decimal? DistanceAlongTrip { get; set; }

        public int? ScheduleDeviation { get; set; }

        public string VehicleId { get; set; }

        public List<string> SituationIds { get; set; } 
    }
}