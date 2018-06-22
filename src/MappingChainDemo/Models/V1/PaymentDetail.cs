using System;

namespace MappingChainDemo.Models.V1
{
    public class PaymentDetail 
    {
        public string Method { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
