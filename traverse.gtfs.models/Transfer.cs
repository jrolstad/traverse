namespace traverse.gtfs.models
{
    public class Transfer
    {
        public string FromStopId { get; set; } 

        public string ToStopId { get; set; } 

        public TransferType TransferType { get; set; }

        public int MinimumTransferTime { get; set; }
    }

    public enum TransferType
    {
        RecommendedTransferPointBetweenTwoRoutes = 0,
        TimedTransferPointBetweenTwoRoutes = 1,
        RequiresMinimumAmountOfTimeBetweenArrivalAndDeparture = 2,
        NoTransfersPossible = 3
    }
}