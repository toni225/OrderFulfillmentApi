using OrderFulfillment.Shared;

namespace OrderApi.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerEmail { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public DateTime PlacedAtUtc { get; set; } = DateTime.UtcNow;
        public string? FailureReason { get; set; }
    }
}
