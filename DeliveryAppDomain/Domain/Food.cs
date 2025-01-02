using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Domain
{
    public class Food : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float ? Price { get; set; }
        public string? Image {  get; set; }
        public virtual ICollection<RestaurantFoods>? RestaurantFoods { get; set; }
    }
}
