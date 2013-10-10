using System.Collections.Generic;

namespace traverse.gtfs.models
{
    public class GtfsSet
    {
        public List<Agency> Agencies { get; set; }  

        public List<Calendar> Calendars { get; set; }  

        public List<CalendarDate> CalendarDates { get; set; }  

        public List<FareAttribute> FareAttributes { get; set; }  

        public List<FareRule> FareRules { get; set; }  

        public List<FeedInfo> FeedInfo { get; set; }  

        public List<Frequency> Frequencies { get; set; }  

        public List<Route> Routes { get; set; }  

        public List<Shape> Shapes { get; set; }  

        public List<Stop> Stops { get; set; }  

        public List<StopTime> StopTimes { get; set; }  

        public List<Transfer> Transfers { get; set; }  

        public List<Trip> Trips { get; set; }  
    }
}