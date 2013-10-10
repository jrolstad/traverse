using System;

namespace traverse.gtfs.models
{
    public class Frequency
    {
         public string TripId { get; set; }

         public DateTime StartTime { get; set; }

         public DateTime EndTime { get; set; }

         public int HeadwaySeconds { get; set; }

         public ExactTime? ExactTime { get; set; }
    }

    public enum ExactTime
    {
        NotExactlyScheduled=0,
        ExactlyScheduled=1
    }
}