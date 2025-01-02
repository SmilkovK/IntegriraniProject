using DeliveryAppDomain.Domain;
using DeliveryAppDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppService.Interface
{
    public interface IShoppingCartService
    {
        CartDTO getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, Guid foodId);
        bool order(string userId);
        bool AddToShoppingConfirmed(FoodsInCart model, string userId);
    }
}
