using Bauen.DAL;
using Bauen.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bauen.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext db;

        public HomeController(AppDbContext database)
        {
            this.db = database;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.banners = await db.Banners.ToListAsync();
            hvm.about = await db.Abouts.FirstOrDefaultAsync();
            hvm.projects = await db.Projects.ToListAsync();

            return View(hvm);
        }

    }
}
