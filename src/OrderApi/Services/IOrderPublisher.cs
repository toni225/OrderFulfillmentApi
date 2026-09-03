using OrderFulfillment.Shared;

namespace OrderApi.Services
{
    public interface IOrderPublisher
    {
        Task Publish(OrderMessage message);
    }
}
