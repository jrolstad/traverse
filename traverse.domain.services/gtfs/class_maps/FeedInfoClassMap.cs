using CsvHelper.Configuration;
using traverse.domain.services.gtfs.class_maps.converters;
using traverse.gtfs.models;

namespace traverse.domain.services.gtfs.class_maps
{
    public class FeedInfoClassMap:CsvClassMap<FeedInfo>
    {
        public override void CreateMap()
        {
            Map(f => f.FeedEndDate).Name("feed_end_date").TypeConverter<YyyymmddDateConverter>();
            Map(f => f.FeedLanguage).Name("feed_lang");
            Map(f => f.FeedPublisherName).Name("feed_publisher_name");
            Map(f => f.FeedPublisherUrl).Name("feed_publisher_url");
            Map(f => f.FeedStartDate).Name("feed_start_date").TypeConverter<YyyymmddDateConverter>();
            Map(f => f.FeedVersion).Name("feed_version");
        }
    }
}