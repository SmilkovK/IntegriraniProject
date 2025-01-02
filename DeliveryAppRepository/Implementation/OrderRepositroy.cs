using DeliveryAppDomain.Domain;
using DeliveryAppRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppRepository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.FoodsInOrder)
                .Include(z => z.Owner)
                .Include("FoodsInOrder.Food")
                .ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return entities
                .Include(z => z.FoodsInOrder)
                .Include(z => z.Owner)
                .Include("FoodsInOrder.Food")
                .SingleOrDefaultAsync(z => z.Id == id.Id).Result;
        }
    }
}
