namespace traverse.gtfs.models
{
    public class Stop
    {
        public string StopId { get; set; }

        public string StopCode { get; set; }

        public string StopName { get; set; }

        public string StopDescription { get; set; }

        public decimal StopLatitude { get; set; }

        public decimal StopLongitude { get; set; }

        public string ZoneId { get; set; }

        public string StopUrl { get; set; }

        public StopLocationType? LocationType { get; set; }

        public string ParentStation { get; set; }

        public string StopTimeZone { get; set; }

        public WheelchairAccessible? WheelchairBoarding { get; set; }


    }

    public enum StopLocationType
    {
        Stop = 0,
        Station = 1
    }

    public enum WheelchairAccessible
    {
        NoAccessibilityInformation = 0,
        SomeAccessibility = 1,
        NoAccessibility = 2
    }
}