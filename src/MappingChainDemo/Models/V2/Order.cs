using System;

namespace MappingChainDemo.Models.V2
{
    public class Order
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string[] Items { get; set; }
        public PaymentInfo Payments { get; set; }
    }
}
