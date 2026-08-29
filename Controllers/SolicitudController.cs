using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecnoGasHogar.Data;
using TecnoGasHogar.Models;
using System.Threading.Tasks;

namespace TecnoGasHogar.Controllers
{
    public class SolicitudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SolicitudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Solicitud/Registrar
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        // POST: Solicitud/Registrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(SolicitudServicio solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                
                TempData["MensajeExito"] = "¡Solicitud registrada correctamente en TecnoGas Hogar!";
                return RedirectToAction(nameof(Registrar));
            }
            
            return View(solicitud);
        }
    }
}
