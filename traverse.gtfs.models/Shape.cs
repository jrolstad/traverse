namespace traverse.gtfs.models
{
    public class Shape
    {
        public string ShapeId { get; set; }

        public decimal ShapePointLatitude { get; set; }

        public decimal ShapePointLongitude { get; set; }

        public int ShapePointSequence { get; set; }

        public decimal ShapeDistanceTraveled { get; set; }
    }
}