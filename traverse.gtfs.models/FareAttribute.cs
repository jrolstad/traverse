namespace traverse.gtfs.models
{
    public class FareAttribute
    {
        public string FareId { get; set; }

        public decimal Price { get; set; }

        public string CurrencyType { get; set; }

        public FarePaymentMethod PaymentMethod { get; set; }

        public FareTransfer? Transfers { get; set; }

        public int? TransferDuration { get; set; }
    }

    public enum FarePaymentMethod
    {
        PaidOnBoard = 0,
        PaidBeforeBoarding = 1
    }

    public enum FareTransfer
    {
        NoTransfersPermitted = 0,
        PassengerMayTransferOnce = 1,
        PassengerMayTransferTwice = 2
    }
}