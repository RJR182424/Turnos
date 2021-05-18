using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context){

            _context = context;
        }

        public IActionResult Index(){

            return View(_context.Especialidad.ToList());
        }
        

        public IActionResult Edit(int id){

            var especialidad =_context.Especialidad.Find(id);

            return View();
        }
    }
}