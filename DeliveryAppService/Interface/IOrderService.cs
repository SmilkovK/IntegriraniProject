using DeliveryAppDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppService.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetDetailsForOrder(BaseEntity id);
    }
}
