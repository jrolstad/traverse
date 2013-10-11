using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class FareAttributeClassMap:CsvClassMap<FareAttribute>
    {
        public override void CreateMap()
        {
            Map(f => f.CurrencyType).Name("currency_type");
            Map(f => f.FareId).Name("fare_id");
            Map(f => f.PaymentMethod).Name("payment_method");
            Map(f => f.Price).Name("price");
            Map(f => f.TransferDuration).Name("transfer_duration");
            Map(f => f.Transfers).Name("transfers");
        }
    }
}