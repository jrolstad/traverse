namespace traverse.onebusaway.models
{
    public class Route
    {
        public string Id { get; set; }
 
        public string ShortName { get; set; }

        public string LongName { get; set; }

        public string Description { get; set; }

        public int? Type { get; set; }

        public string Url { get; set; }

        public string Color { get; set; }

        public string TextColor { get; set; }

        public string AgencyId { get; set; }
    }
}