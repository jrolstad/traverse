using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class RouteList
    {
        public bool LimitExceeded { get; set; }

        public List<Route> Routes { get; set; }  
    }
}