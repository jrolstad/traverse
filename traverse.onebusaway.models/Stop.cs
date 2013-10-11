using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class Stop
    {
        public string Id { get; set; }
 
        public decimal? Lat { get; set; }

        public decimal? Lon { get; set; }

        public string Direction { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int? LocationType { get; set; }

        public string WheelchairBoarding { get; set; }

        public List<string> RouteIds { get; set; } 
    }
}