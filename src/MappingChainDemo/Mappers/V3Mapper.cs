using System;
using System.Linq;
using MappingChainDemo.Models.V2;
using MappingChainDemo.Models.V3;

namespace MappingChainDemo.Mappers
{
    public class V3Mapper : VersionChainLinkMapper<Models.V3.Order, Models.V2.Order>
    {
        public override Models.V2.Order Downgrade(Models.V3.Order upperVersion)
        {
            return new Models.V2.Order
            {
                Id = upperVersion.Id,
                Items = upperVersion.Items.Select(i => i.Id).ToArray(),
                Payments = downgradePayments(upperVersion.PaymentDetails),
                CreatedDate = upperVersion.CreatedDate
            };
        }

        private Models.V2.PaymentInfo downgradePayments(PaymentDetails paymentDetails)
        {
            return new Models.V2.PaymentInfo
            {
                Amount = paymentDetails.Amount,
                Date = paymentDetails.Date,
                Method = paymentDetails.Method
            };
        }
    }
}