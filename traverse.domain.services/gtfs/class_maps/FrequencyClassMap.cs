using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class FrequencyClassMap:CsvClassMap<Frequency>
    {
        public override void CreateMap()
        {
            Map(f => f.EndTime).Name("end_time");
            Map(f => f.ExactTime).Name("exact_times");
            Map(f => f.HeadwaySeconds).Name("headway_secs");
            Map(f => f.StartTime).Name("start_time");
            Map(f => f.TripId).Name("trip_id");
        }
    }
}