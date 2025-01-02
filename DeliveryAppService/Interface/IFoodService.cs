using DeliveryAppDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppService.Interface
{
    public interface IFoodService
    {
        List<Food> GetAllFoods();
        Food GetDetailsForFood(Guid? id);
        void CreateNewFood(Food f);
        void UpdateExistingFood(Food f);
        void DeleteFood(Guid id);
    }
}
