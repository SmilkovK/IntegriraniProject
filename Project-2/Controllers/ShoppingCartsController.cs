﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryAppDomain.Domain;
using DeliveryAppRepository;
using DeliveryAppService.Interface;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Project_2.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartsController(IShoppingCartService _shoppingCartService)
        {
            this._shoppingCartService = _shoppingCartService;
        }

        // GET: ShoppingCarts
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dto = _shoppingCartService.getShoppingCartInfo(userId);
            return View(dto);
            //return (IActionResult)dto;
        }


        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _shoppingCartService.deleteProductFromShoppingCart(userId, id);

            return RedirectToAction("Index");

        }


        public IActionResult order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.order(userId);
            //if (result == true)
            return RedirectToAction("Index", "ShoppingCarts");


        }

        public IActionResult SuccessPayment()
        {
            return View();
        }

        

    }
}
