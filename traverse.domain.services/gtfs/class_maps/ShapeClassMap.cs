using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class ShapeClassMap:CsvClassMap<Shape>
    {
        public override void CreateMap()
        {
            Map(s => s.ShapeDistanceTraveled).Name("shape_dist_traveled");
            Map(s => s.ShapeId).Name("shape_id");
            Map(s => s.ShapePointLatitude).Name("shape_pt_lat");
            Map(s => s.ShapePointLongitude).Name("shape_pt_lon");
            Map(s => s.ShapePointSequence).Name("shape_pt_sequence");
        }
    }
}