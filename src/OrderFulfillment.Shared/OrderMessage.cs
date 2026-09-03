using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFulfillment.Shared
{
    public record OrderMessage(
        Guid OrderId,
        string CustomerEmail,
        decimal Amount,
        DateTime PlacedAtUtc
        );
}
