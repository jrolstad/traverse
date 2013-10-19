using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class TripDetails
    {
        public string TripId { get; set; }

        public long? ServiceDate { get; set; }

        public Frequency Frequency { get; set; }

        public TripStatus Status { get; set; }

        public TripSchedule Schedule { get; set; }

        public List<string> SituationIds { get; set; } 
    }
}