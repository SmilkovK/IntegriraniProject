using DeliveryAppDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppService.Interface
{
    public interface IRestaurantService
    {
        List<Restaurant> GetAllRest();
        Restaurant GetDetailsForRest(Guid? id);
        void CreateNewRest(Restaurant r);
        void UpdateExistingRest(Restaurant r);
        void DeleteRest(Guid id);
        void AddFoodsToRestaurant(Guid restaurantId, List<Guid> foodIds);
    }

}
