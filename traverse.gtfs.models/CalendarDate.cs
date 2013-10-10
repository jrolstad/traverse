using System;

namespace traverse.gtfs.models
{
    public class CalendarDate
    {
        public string ServiceId { get; set; }

        public DateTime Date { get; set; }

        public ExceptionType ExceptionType { get; set; }
    }

    public enum ExceptionType
    {
        ServiceAddedForTheSpecifiedDate = 1,
        ServiceRemovedForTheSpecifiedDate = 2
    }
}