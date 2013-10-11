using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class TripClassMap:CsvClassMap<Trip>
    {
        public override void CreateMap()
        {
            Map(t => t.BlockId).Name("block_id");
            Map(t => t.DirectionId).Name("direction_id");
            Map(t => t.RouteId).Name("route_id");
            Map(t => t.ServiceId).Name("service_id");
            Map(t => t.ShapeId).Name("shape_id");
            Map(t => t.TripHeadsign).Name("trip_headsign");
            Map(t => t.TripId).Name("trip_id");
            Map(t => t.TripShortName).Name("trip_short_name");
            Map(t => t.WheelchairAccessible).Name("wheelchair_accessible");
        }
    }
}