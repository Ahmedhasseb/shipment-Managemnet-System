namespace Domain.Enums
{
    public enum ShipmentStatus
    {

        Draft = 0,
        Pending = 1,
        PickedUp = 2,
        AtBranch = 3,
        InTransit = 4,
        OutForDelivery = 5,
        Delivered = 6,
        FailedDelivery = 7,
        Returned = 8,
        Cancelled = 9
    }
}
