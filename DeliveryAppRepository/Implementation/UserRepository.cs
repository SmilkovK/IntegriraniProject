﻿using DeliveryAppDomain.Identity;
using DeliveryAppRepository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryAppRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<DeliveryUser> entities;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<DeliveryUser>();
        }

        public IEnumerable<DeliveryUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public DeliveryUser Get(string id)
        {
            return entities
                .Include(z => z.ShoppingCart)
                .ThenInclude(sc => sc.FoodsInCarts)
                .ThenInclude(fc => fc.Foods)
                .SingleOrDefault(s => s.Id == id);
        }

        public void Insert(DeliveryUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(DeliveryUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(DeliveryUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}