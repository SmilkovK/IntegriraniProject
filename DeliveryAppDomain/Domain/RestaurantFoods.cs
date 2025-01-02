using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Domain
{
    public class RestaurantFoods : BaseEntity
    {
        public Guid RestaurantId { get; set; }
        public Restaurant? Restaurant { get; set; }

        public Guid FoodId { get; set; }
        public Food? Food { get; set; }

    }
}
