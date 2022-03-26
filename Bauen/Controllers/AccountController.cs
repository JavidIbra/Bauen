using Bauen.Models.Entities;
using Bauen.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bauen.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Content("Not logged in");
            }

            AppUser loggedUser = await userManager.FindByNameAsync(User.Identity.Name);

            return Json(loggedUser);
        }

        public IActionResult Login()
        {
            //Javid17
            //Password:Cavid1995@
            //Neriman27
            //Password:Neriman1995@

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {

            if (!ModelState.IsValid) return View();

            AppUser loggingUser = await userManager.FindByNameAsync(lvm.UserName);

            if (loggingUser == null)
            {
                ModelState.AddModelError("", "Email or password is wrong");
                return View(lvm);

            }

            var signInResult = await signInManager.PasswordSignInAsync(loggingUser, lvm.Password, true, true);

            if (signInResult.IsLockedOut)
            {

                ModelState.AddModelError("", "You are locked out");

                return View(lvm);
            }

            if (!signInResult.Succeeded)
            {

                ModelState.AddModelError("", "Email or password is wrong");

                return View(lvm);
            }

            return RedirectToAction("index", "home");

        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (!ModelState.IsValid) return View();

            AppUser newUser = new AppUser
            {
                FullName = rvm.Name + " " + rvm.Surname,
                Email = rvm.Email,
                UserName = rvm.UserName

            };

            IdentityResult identityResult = await userManager.CreateAsync(newUser, rvm.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(rvm);
            }

            await signInManager.SignInAsync(newUser, true);

            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> InitRoles()
        //{
        //    await roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await roleManager.CreateAsync(new IdentityRole("Member"));
        //    return Content("Okay");
        //}

    }
}
