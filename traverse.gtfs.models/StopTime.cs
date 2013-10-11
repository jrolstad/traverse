using System;

namespace traverse.gtfs.models
{
    public class StopTime
    {
        public string TripId { get; set; }

        public string ArrivalTime { get; set; }

        public string DepartureTime { get; set; }

        public string StopId { get; set; }

        public int StopSequence { get; set; }

        public string StopHeadsign { get; set; }

        public StopPickupType? PickupType { get; set; }

        public StopDropOffType? DropOffType { get; set; }

        public decimal? ShapeDistanceTraveled { get; set; }
    }

    public enum StopPickupType
    {
        RegularlyScheduledPickup = 0,
        NoPickupAvailable = 1,
        MustPhoneAgencyToArrangePickup = 2,
        MustCoordinateWithDriverToArrangePickup = 3
    }

    public enum StopDropOffType
    {
        RegularlyScheduledDropOff = 0,
        NoDropOffAvailable = 1,
        MustPhoneAgencyToArrangeDropOff =2,
        MustCoordinateWithDriverToArrangeDropOff=3
    }
}