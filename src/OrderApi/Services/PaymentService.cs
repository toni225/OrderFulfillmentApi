namespace OrderApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IHttpClientFactory httpClientFactory, ILogger<PaymentService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<bool> ChargeAsync(decimal amount, string customerEmail)
        {
            var client = _httpClientFactory.CreateClient("PaymentApi");

            try
            {
                var response = await client.PostAsJsonAsync("/api/mock-payment/charge",
                    new { amount, customerEmail });
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Payment charge failed after retries for {Email}", customerEmail);
                return false;
            }
        }
    }
}
