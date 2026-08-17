using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PreProjectDemo.Data;
using PreProjectDemo.ViewModel;

namespace PreProjectDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: /Users
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();

            var model = new List<UserVM>();

            foreach (var user in users)
            {
                var roles = _userManager
                    .GetRolesAsync(user)
                    .GetAwaiter()
                    .GetResult();

                model.Add(new UserVM
                {
                    //Id = user.Id, 
                    UserName = user.UserName,
                    Role = roles.FirstOrDefault() ?? ""
                });
            }

            return View(model);
        }

        // GET: /Users/Create
        public IActionResult Create()
        {
            var model = new UserVM
            {
                Roles = _roleManager.Roles
                        .Select(r => r.Name)
                        .ToList()
            };

            return View(model);
        }

        // POST: /Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check whether username already exists
            var existingUser = _userManager
                .FindByNameAsync(model.UserName)
                .GetAwaiter()
                .GetResult();

            if (existingUser != null)
            {
                ModelState.AddModelError(
                    "UserName",
                    "Username already exists.");

                return View(model);
            }

            // Check that the selected role exists
            var roleExists = _roleManager
                .RoleExistsAsync(model.Role)
                .GetAwaiter()
                .GetResult();

            if (!roleExists)
            {
                ModelState.AddModelError(
                    "Role",
                    "Invalid role.");

                return View(model);
            }

            // Create user
            var user = new ApplicationUser
            {
                UserName = model.UserName
            };

            var result = _userManager
                .CreateAsync(user, model.Password)
                .GetAwaiter()
                .GetResult();

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            // Assign role
            _userManager
                .AddToRoleAsync(user, model.Role)
                .GetAwaiter()
                .GetResult();

            return RedirectToAction(nameof(Index));
        }

    }
}
