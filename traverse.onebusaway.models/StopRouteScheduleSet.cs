using System.Collections.Generic;

namespace traverse.onebusaway.models
{
    public class StopRouteScheduleSet
    {
        public string StopId { get; set; }

        public long? Date { get; set; }

        public List<StopRouteSchedule> StopRouteSchedules { get; set; }
    }

    public class StopRouteSchedule  
    {
        public string RouteId { get; set; }

        public List<StopRouteDirectionSchedule> StopRouteDirectionSchedules { get; set; }
    }

    public class StopRouteDirectionSchedule
    {
        public List<ArrivalAndDeparture> ScheduleStopTimes { get; set; }
    }
}