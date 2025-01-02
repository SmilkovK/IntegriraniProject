using DeliveryAppDomain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Domain
{
    public class ShoppingCart : BaseEntity
    {
        public string? OwnerId { get; set; }
        public DeliveryUser? Owner { get; set; }
        public virtual ICollection<FoodsInCart>? FoodsInCarts { get; set; }

    }
}
