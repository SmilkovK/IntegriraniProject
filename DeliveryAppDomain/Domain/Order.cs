using DeliveryAppDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Domain
{
    public class Order : BaseEntity
    {
        public string? userId { get; set; }
        public DeliveryUser? Owner { get; set; }
        public IEnumerable<FoodsInOrder>? FoodsInOrder { get; set; }
    }
}
