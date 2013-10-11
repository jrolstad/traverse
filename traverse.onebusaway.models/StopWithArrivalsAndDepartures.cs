using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class StopWithArrivalsAndDepartures
    {
        public Stop Stop { get; set; } 

        public List<ArrivalAndDeparture> ArrivalsAndDepartures { get; set; }

        public List<Stop> NearbyStops { get; set; } 
    }
}