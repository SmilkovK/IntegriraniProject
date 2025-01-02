using DeliveryAppDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.DTO
{
    public class CartDTO : BaseEntity
    {
        public List<FoodsInCart>? Products { get; set; }
        public double TotalPrice { get; set; }
    }
}
