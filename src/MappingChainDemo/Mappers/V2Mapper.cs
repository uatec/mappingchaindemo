using System;
using MappingChainDemo.Models.V1;
using MappingChainDemo.Models.V2;
using MappingChainDemo.VersionChain;

namespace MappingChainDemo.Mappers
{
    public class V2Mapper : VersionChainLinkMapper<Models.V2.Order, Models.V1.Order>, IVersionChainLinkMapper
    {
        public override Models.V1.Order Downgrade(Models.V2.Order upperVersion)
        {
            return new Models.V1.Order 
            {
                Id = upperVersion.Id,
                CreatedDate = upperVersion.CreatedDate,
                Items = upperVersion.Items,
                PaymentDetails = downgradePayments(upperVersion.Payments),
                PaymentTotal = upperVersion.Payments.Amount
            };
        }

        private Models.V1.PaymentDetail[] downgradePayments(PaymentInfo payments)
        {
            return new [] 
            {
                new Models.V1.PaymentDetail
                {
                    Method = payments.Method,
                    Date = payments.Date
                }
            };
        }
    }
}