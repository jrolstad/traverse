using System;

namespace traverse.gtfs.models
{
    public class FeedInfo
    {
        public string FeedPublisherName { get; set; }

        public string FeedPublisherUrl { get; set; }

        public string FeedLanguage { get; set; }

        public DateTime? FeedStartDate { get; set; }

        public DateTime? FeedEndDate { get; set; }

        public string FeedVersion { get; set; }
    }
}