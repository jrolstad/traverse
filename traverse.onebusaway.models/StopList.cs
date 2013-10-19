using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class StopList
    {
        public bool LimitExceeded { get; set; }

        public List<Stop> Stops { get; set; }  
    }
}