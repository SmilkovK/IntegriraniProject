using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppDomain.Domain
{
    public class AddFoodViewModel : BaseEntity
    {
        public Guid SelectedRestaurantId { get; set; }
        public List<Restaurant>? Restaurants { get; set; }
        public List<Food>? Foods { get; set; }
        public List<Guid>? SelectedFoodIds { get; set; }
    }

}
