using CsvHelper.Configuration;
using traverse.domain.services.gtfs.class_maps.converters;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class StopTimeClassMap:CsvClassMap<StopTime>
    {
        public override void CreateMap()
        {
            Map(t => t.ArrivalTime).Name("arrival_time");
            Map(t => t.DepartureTime).Name("departure_time");
            Map(t => t.DropOffType).Name("drop_off_type");
            Map(t => t.PickupType).Name("pickup_type");
            Map(t => t.ShapeDistanceTraveled).Name("shape_dist_traveled");
            Map(t => t.StopHeadsign).Name("stop_headsign");
            Map(t => t.StopId).Name("stop_id");
            Map(t => t.StopSequence).Name("stop_sequence");
            Map(t => t.TripId).Name("trip_id");
        }
    }
}