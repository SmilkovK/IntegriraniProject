using Microsoft.AspNetCore.Mvc;
using DeliveryAppDomain.Domain;
using System.Diagnostics;
using DeliveryAppDomain;
using DeliveryAppDomain.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using NuGet.Protocol;

namespace Project_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Microsoft.AspNetCore.Identity.UserManager<DeliveryUser> _userManager;
        private readonly List<string> _roles = new List<string> { "Administrator", "Editor", "User" };

        public HomeController(ILogger<HomeController> logger, Microsoft.AspNetCore.Identity.UserManager<DeliveryUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AddUserToRole()
        {
            var model = new ManageRoles { Roles = _roles };
            return View(model);
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(ManageRoles model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                    model.Roles = _roles; // Re-populate roles for the view
                    return View(model);
                }

                if (!_roles.Contains(model.SelectedRole))
                {
                    ModelState.AddModelError(string.Empty, "Role does not exist");
                    model.Roles = _roles; // Re-populate roles for the view
                    return View(model);
                }

                var result = await _userManager.AddToRoleAsync(user, model.SelectedRole);
                if (result.Succeeded)
                {
                    ViewBag.Message = "User added to role successfully";
                    return RedirectToAction("Index"); // Redirect to avoid re-submission
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            model.Roles = _roles; // Re-populate roles for the view
            return View(model);
        }
    }
}
