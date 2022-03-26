using Bauen.DAL;
using Bauen.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bauen.Controllers
{
    public class ProjectController : Controller
    {

        private readonly AppDbContext db;

        public ProjectController(AppDbContext database)
        {
            this.db = database;
        }

        public async Task<IActionResult> Index(int? id)
        {
        
            if (id==0 || id==null)
            {
                return RedirectToAction("Index", "Home");
            }


            Project proj = await db.Projects.Include(project=>project.ProjectImages).FirstOrDefaultAsync(x => x.Id == id);

            return View(proj);
        }
    }
}
