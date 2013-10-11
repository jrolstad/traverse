using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class FareRuleClassMap:CsvClassMap<FareRule>
    {
        public override void CreateMap()
        {
            Map(f => f.ContainsId).Name("contains_id");
            Map(f => f.DestinationId).Name("destination_id");
            Map(f => f.FareId).Name("fare_id");
            Map(f => f.OriginId).Name("origin_id");
            Map(f => f.RouteId).Name("route_id");
        }
    }
}