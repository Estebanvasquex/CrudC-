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

        [Httpget]
        public IActionResult Crear()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        { 
            if (ModelState.IsValid)
            {
                _context.Contacto.Add(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            return View();
        }


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            var contacto = _context.Contacto.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);

         

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contacto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            }

            return View();
        }



        [HttpGet]
        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var contacto = _context.Contacto.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);



        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var contacto = _context.Contacto.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);



        }


        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _context.Contacto.FindAsync(id);  
            if (contacto == null)
            {
                return View();

            }
            _context.Contacto.Remove(contacto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

 
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