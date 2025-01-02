using DeliveryAppDomain;
using DeliveryAppDomain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Identity
{
    public class DeliveryUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Order>? Order { get; set; }
    }
}
