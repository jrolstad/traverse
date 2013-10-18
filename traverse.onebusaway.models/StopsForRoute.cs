using System.Collections.Generic;
using System.Security.Policy;

namespace traverse.onebusaway.models
{
    public class StopsForRoute
    {
        public List<Stop> Stops { get; set; }
  
        public Route Route { get; set; }

        public List<StopGrouping> StopGroupings { get; set; }
    }

    public class StopGrouping
    {
        public List<StopGroup> StopGroups { get; set; }

        public string Type { get; set; }

        public bool Ordered { get; set; }
    }

    public class StopGroup
    {
        public string Id { get; set; }

        public List<string> StopIds { get; set; }

        public StopGroupName Name { get; set; }
    }

    public class StopGroupName
    {
        public List<string> Names { get; set; }
 
        public string Name { get; set; }

        public string Type { get; set; }
    }
}