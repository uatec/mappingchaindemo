using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MappingChainDemo.Models.V3;
using Microsoft.AspNetCore.Mvc;

namespace MappingChainDemo.Controllers
{
    [Route("api/{version}/[controller]")]
    public class OrderController : Controller
    {
        Dictionary<string, Order> DataSet = new Dictionary<string, Order>
        {
            { "order_001", new Order 
                {
                    Id = "order_001",
                    CreatedDate = DateTimeOffset.UtcNow,
                    Items = new [] 
                    {
                        new Item 
                        {
                            Id = "item_001",
                            Name = "Toy Car"
                        },
                        new Item
                        {
                            Id = "item_002",
                            Name = "4x AA Batteries"
                        }
                    },
                    PaymentDetails = new PaymentDetails
                    {
                        Method = "VISA",
                        Amount = 14.98,
                        Date = DateTimeOffset.UtcNow
                    }
                }
            },
            { "order_002", new Order
                {
                    Id = "order_002",
                    CreatedDate = DateTimeOffset.UtcNow,
                    Items = new [] 
                    {
                        new Item
                        {
                            Id = "item_002",
                            Name = "4x AA Batteries"
                        },
                        new Item
                        {
                            Id = "item_003",
                            Name = "Torch"
                        }
                    },
                    PaymentDetails = new PaymentDetails
                    {
                        Method = "VISA",
                        Amount = 12.43,
                        Date = DateTimeOffset.UtcNow
                    }
                }
            }
        };

        // GET api/values
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return DataSet.Values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Order Get(string id)
        {
            if ( DataSet.TryGetValue(id, out Order order) ) return order;

            return null; 
        }
    }
}
