using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class TripSchedule   
    {
        public string TimeZone { get; set; }

        public List<TripStopTime> StopTimes { get; set; } 

        public string PreviousTripId { get; set; }

        public string NextTripId { get; set; }
    }
}