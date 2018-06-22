using System;

namespace MappingChainDemo.Models.V3
{
    public class PaymentDetails 
    {
        public string Method { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Amount { get; set; }
    }
}
