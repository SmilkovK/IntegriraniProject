    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using DeliveryAppDomain.Domain;
    using DeliveryAppRepository;
    using DeliveryAppService.Interface;
    using DeliveryAppService.Implementation;
using Microsoft.Build.Framework;

namespace Project_2.Controllers
    {
        public class RestaurantsController : Controller
        {
            private readonly IRestaurantService _restaurantService;
            private readonly IFoodService _foodService;

            public RestaurantsController(IRestaurantService restaurantService, IFoodService foodService)
            {
                _restaurantService = restaurantService;
                    _foodService = foodService;
            }

            // GET: Restaurants
            public IActionResult Index()
            {
                return View(_restaurantService.GetAllRest());
            }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = _restaurantService.GetDetailsForRest(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            var foods = restaurant.RestaurantFoods?.Select(rf => rf.Food).ToList();

            ViewData["Foods"] = foods;

            return View(restaurant);
        }

        public IActionResult AddFoodToRestaurant()
        {
            var restaurants = _restaurantService.GetAllRest(); // Get all restaurants
            var foods = _foodService.GetAllFoods(); // Get all available foods

            var viewModel = new AddFoodViewModel
            {
                Foods = foods,
                Restaurants = restaurants,  // Add list of restaurants
                SelectedFoodIds = new List<Guid>(),
                SelectedRestaurantId = Guid.Empty // Initially, no restaurant is selected
            };

            return View(viewModel);
        }

        // POST: Restaurants/AddFoodToRestaurant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFoodToRestaurant(AddFoodViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = _restaurantService.GetDetailsForRest(model.SelectedRestaurantId);
                if (restaurant != null)
                {
                    _restaurantService.AddFoodsToRestaurant(model.SelectedRestaurantId, model.SelectedFoodIds);

                    return RedirectToAction(nameof(Details), new { id = model.SelectedRestaurantId });
                }
                ModelState.AddModelError(string.Empty, "The selected restaurant does not exist.");
            }

            return View(model);
        }



        // POST: Restaurants/AddFoods
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFoods(Guid restaurantId, List<Guid> selectedFoodIds)
        {
            if (ModelState.IsValid)
            {
                _restaurantService.AddFoodsToRestaurant(restaurantId, selectedFoodIds); // Assuming you have this method
                return RedirectToAction(nameof(Details), new { id = restaurantId });
            }

            return BadRequest();
        }

        // GET: Restaurants/Create
        public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create([Bind("Name,Description,Raiting,ImageUrl,Id")] Restaurant restaurant)
            {
                if (ModelState.IsValid)
                {
                    restaurant.Id = Guid.NewGuid();
                    _restaurantService.CreateNewRest(restaurant);
                    return RedirectToAction(nameof(Index));
                }
                return View(restaurant);
            }

            // GET: Restaurants/Edit/5
            public IActionResult Edit(Guid? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
            
                var restaurant = _restaurantService.GetDetailsForRest(id);
                if (restaurant == null)
                {
                    return NotFound();
                }
                return View(restaurant);
            }

            // POST: Restaurants/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(Guid id, [Bind("Name,Description,Raiting,ImageUrl,Id")] Restaurant restaurant)
            {
                if (id != restaurant.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _restaurantService.UpdateExistingRest(restaurant);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(restaurant);
            }

        

            // GET: Restaurants/Delete/5
            public IActionResult Delete(Guid? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var restaurant = _restaurantService.GetDetailsForRest(id);
                if (restaurant == null)
                {
                    return NotFound();
                }

                return View(restaurant);
            }

            // POST: Restaurants/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(Guid id)
            {
                _restaurantService.DeleteRest(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
