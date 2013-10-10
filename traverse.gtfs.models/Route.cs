using System.Drawing;

namespace traverse.gtfs.models
{
    public class Route
    {
        public string RouteId { get; set; }

        public string AgencyId { get; set; }

        public string RouteShortName { get; set; }

        public string RouteLongName { get; set; }

        public string RouteDescription { get; set; }

        public RouteType RouteType { get; set; }

        public string RouteUrl { get; set; }

        public Color? RouteColor { get; set; }

        public Color? RouteTextColor { get; set; }
    }

    public enum RouteType
    {
        LightRail=0,
        Subway=1,
        Rail=2,
        Bus=3,
        Ferry=4,
        CableCar=5,
        Gondola=6,
        Funicular=7
    }
}