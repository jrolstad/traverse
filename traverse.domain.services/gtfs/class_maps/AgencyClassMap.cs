using CsvHelper.Configuration;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class AgencyClassMap:CsvClassMap<Agency>
    {
        public override void CreateMap()
        {

            Map(a => a.AgencyFareUrl).Name("agency_fare_url");
            Map(a => a.AgencyId).Name("agency_id");
            Map(a => a.AgencyLanguage).Name("agency_lang");
            Map(a => a.AgencyName).Name("agency_name");
            Map(a => a.AgencyPhone).Name("agency_phone");
            Map(a => a.AgencyTimeZone).Name("agency_timezone");
            Map(a => a.AgencyUrl).Name("agency_url");
        }
    }
}