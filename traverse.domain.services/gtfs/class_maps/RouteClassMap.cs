using CsvHelper.Configuration;
using traverse.domain.services.gtfs.class_maps.converters;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class RouteClassMap:CsvClassMap<Route>
    {
        public override void CreateMap()
        {
            Map(r => r.AgencyId).Name("agency_id");
            Map(r => r.RouteColor).Name("route_color").TypeConverter<HexadecimalColorConverter>();
            Map(r => r.RouteDescription).Name("route_desc");
            Map(r => r.RouteId).Name("route_id");
            Map(r => r.RouteLongName).Name("route_long_name");
            Map(r => r.RouteShortName).Name("route_short_name");
            Map(r => r.RouteTextColor).Name("route_text_color").TypeConverter<HexadecimalColorConverter>();
            Map(r => r.RouteType).Name("route_type");
            Map(r => r.RouteUrl).Name("route_url");
        }
    }
}