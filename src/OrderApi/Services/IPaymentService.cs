namespace OrderApi.Services
{
    public interface IPaymentService
    {
        Task<bool> ChargeAsync(decimal amoung, string customerEmail);
    }
}
