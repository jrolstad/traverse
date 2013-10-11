using CsvHelper.Configuration;
using traverse.domain.services.gtfs.class_maps.converters;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class CalendarDateClassMap:CsvClassMap<CalendarDate>
    {
        public override void CreateMap()
        {
            Map(c => c.ServiceId).Name("service_id");
            Map(c => c.Date).Name("date").TypeConverter<YyyymmddDateConverter>();
            Map(c => c.ExceptionType).Name("exception_type");
        }
    }
}