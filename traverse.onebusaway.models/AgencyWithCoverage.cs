namespace traverse.onebusaway.models
{
    public class AgencyWithCoverage
    {
        public Agency Agency { get; set; }
 
        public decimal? Lat { get; set; }

        public decimal? Lon { get; set; }

        public decimal? LatSpan { get; set; }

        public decimal? LonSpan { get; set; }
    }
}