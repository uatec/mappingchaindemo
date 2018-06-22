using System;

namespace MappingChainDemo.Models.V3
{
    public class Order
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public Item[] Items { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}
