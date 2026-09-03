using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/mock-payment")]
    public class MockPaymentController : ControllerBase
    {
        public static readonly Random _random = new();
        public record ChargeRequest(decimal Amount, string CustomerEmail);
        public record ChargeResult(bool Success, string TransactionId);


        [HttpPost]
        public async Task<IActionResult> Charge(ChargeRequest request)
        {
            await Task.Delay(_random.Next(100,800));

            if (_random.Next(0, 100) < 300)
                return StatusCode(503, new {error = "Payment provider temporarily unavailable"});

            return Ok(new ChargeResult(true, Guid.NewGuid().ToString()));
        }
    }
}
