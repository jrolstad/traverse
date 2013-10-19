using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class StopClassMap:CsvClassMap<Stop>
    {
        public override void CreateMap()
        {
            Map(s => s.StopId).Name("stop_id");
            Map(s => s.StopCode).Name("stop_code");
            Map(s => s.StopName).Name("stop_name");
            Map(s => s.StopDescription).Name("stop_desc");
            Map(s => s.StopLatitude).Name("stop_lat");
            Map(s => s.StopLongitude).Name("stop_lon");
            Map(s => s.ZoneId).Name("zone_id");
            Map(s => s.StopUrl).Name("stop_url");
            Map(s => s.LocationType).Name("location_type");
            Map(s => s.ParentStation).Name("parent_station");
            Map(s => s.StopTimeZone).Name("stop_timezone");
            Map(s => s.WheelchairBoarding).Name("wheelchair_boarding");
        }
    }
}