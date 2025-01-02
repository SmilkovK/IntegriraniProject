using DeliveryAppDomain.Domain;
using DeliveryAppDomain.DTO;
using DeliveryAppRepository.Interface;
using DeliveryAppService.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAppService.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<FoodsInCart> _foodsInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<FoodsInOrder> _foodInOrderRepository;


        public ShoppingCartService(IRepository<FoodsInOrder> _foodInOrderRepository, IRepository<Order> _orderRepository, IUserRepository userRepository, IRepository<ShoppingCart> shoppingCartRepository, IRepository<FoodsInCart> foodInShoppingCartRepository)
        {
            this._foodInOrderRepository = _foodInOrderRepository;
            this._orderRepository = _orderRepository;
            _userRepository = userRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _foodsInShoppingCartRepository = foodInShoppingCartRepository;
        }
        public bool AddToShoppingConfirmed(FoodsInCart model, string userId)
        {

            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser.ShoppingCart;

            if (userShoppingCart.FoodsInCarts == null)
                userShoppingCart.FoodsInCarts = new List<FoodsInCart>(); ;

            userShoppingCart.FoodsInCarts.Add(model);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }



        public bool deleteProductFromShoppingCart(string userId, Guid foodId)
        {
            if (foodId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.ShoppingCart;
                var food = userShoppingCart.FoodsInCarts.Where(x => x.FoodId == foodId).FirstOrDefault();

                userShoppingCart.FoodsInCarts.Remove(food);

                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            }
            return false;

        }

        public CartDTO getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.ShoppingCart;
            var allFoods = userShoppingCart?.FoodsInCarts?.ToList();

            var totalPrice = allFoods.Select(x => (x.Foods.Price * x.Quantity)).Sum();

            CartDTO dto = new CartDTO
            {
                Products = allFoods,
                TotalPrice = (double)totalPrice
            };
            return dto;
        }

        public bool order(string userId)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.ShoppingCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    userId = userId,
                    Owner = loggedInUser
                };

                _orderRepository.Insert(order);

                List<FoodsInOrder> productInOrder = new List<FoodsInOrder>();

                var lista = userShoppingCart.FoodsInCarts.Select(
                    x => new FoodsInOrder
                    {
                        Id = Guid.NewGuid(),
                        FoodId = x.Foods.Id,
                        Foods = x.Foods,
                        OrderId = order.Id,
                        Order = order,
                        Quantity = x.Quantity
                    }
                    ).ToList();


                StringBuilder sb = new StringBuilder();

                var totalPrice = 0.0;

                sb.AppendLine("Your order is completed. The order conatins: ");

                for (int i = 1; i <= lista.Count(); i++)
                {
                    var currentItem = lista[i - 1];
                    totalPrice += (double) (currentItem.Quantity * currentItem.Foods.Price);
                    sb.AppendLine(i.ToString() + ". " + currentItem.Foods.Name + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Foods.Price);
                }

                sb.AppendLine("Total price for your order: " + totalPrice.ToString());;

                productInOrder.AddRange(lista);

                foreach (var product in productInOrder)
                {
                    _foodInOrderRepository.Insert(product);
                }

                loggedInUser.ShoppingCart.FoodsInCarts.Clear();
                _userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }

    }
}
