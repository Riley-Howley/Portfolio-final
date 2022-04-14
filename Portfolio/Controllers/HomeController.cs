using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortfolioContext _context;

        public HomeController(ILogger<HomeController> logger, PortfolioContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ListModel();
            model.AboutModel = await _context.About.ToListAsync();
            model.ServiceModel = await _context.Services.ToListAsync();
            model.TechnicalSkillsModel = await _context.TechnicalSkills.ToListAsync();
            model.SoftSkillsModel = await _context.SoftSkills.ToListAsync();
            model.ExperienceModel = await _context.Experience.ToListAsync();
            model.ProjectsModel = await _context.Projects.ToListAsync();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}