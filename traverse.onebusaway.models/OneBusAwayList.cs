using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class OneBusAwayList<T>
    {
        public bool LimitExceeded { get; set; } 

        public List<T> List { get; set; } 
    }
}