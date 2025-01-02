using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Domain
{
    public class Restaurant : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Raiting { get; set; }
        public string? ImageUrl { get; set; }
        public virtual ICollection<RestaurantFoods>? RestaurantFoods { get; set; }
    }
}
