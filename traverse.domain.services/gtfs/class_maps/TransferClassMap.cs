using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class TransferClassMap:CsvClassMap<Transfer>
    {
        public override void CreateMap()
        {
            Map(t => t.FromStopId).Name("from_stop_id");
            Map(t => t.MinimumTransferTime).Name("min_transfer_time");
            Map(t => t.ToStopId).Name("to_stop_id");
            Map(t => t.TransferType).Name("transfer_type");
        }
    }
}