using CrudNet7MVC.Datos;
using CrudNet7MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudNet7MVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        
        //INYECTAR DEPENDENCIA

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext contexto)
        {
           _context = contexto;
        }
        [Httpget]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacto.ToListAsync());
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
    }
}