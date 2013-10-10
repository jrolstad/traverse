using System.Globalization;
using CsvHelper.Configuration;
using traverse.domain.services.gtfs.class_maps.converters;
using Calendar = traverse.gtfs.models.Calendar;

namespace traverse.domain.services.gtfs.class_maps
{
    public class CalendarClassMap : CsvClassMap<Calendar>
    {
        public override void CreateMap()
        {
            Map(c => c.ServiceId).Name("service_id");
            Map(c => c.Monday).Name("monday").TypeConverterOption(true,"1").TypeConverterOption(false,"0");
            Map(c => c.Tuesday).Name("tuesday").TypeConverterOption(true, "1").TypeConverterOption(false, "0");
            Map(c => c.Wednesday).Name("wednesday").TypeConverterOption(true, "1").TypeConverterOption(false, "0");
            Map(c => c.Thursday).Name("thursday").TypeConverterOption(true, "1").TypeConverterOption(false, "0");
            Map(c => c.Friday).Name("friday").TypeConverterOption(true, "1").TypeConverterOption(false, "0");
            Map(c => c.Saturday).Name("saturday").TypeConverterOption(true, "1").TypeConverterOption(false, "0");
            Map(c => c.Sunday).Name("sunday").TypeConverterOption(true, "1").TypeConverterOption(false, "0");
            Map(c => c.StartDate).Name("start_date").TypeConverter<YyyymmddDateConverter>();
            Map(c => c.EndDate).Name("end_date").TypeConverter<YyyymmddDateConverter>();
        }
    }
}