using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context){

            _context = context;
        }

        public async Task<IActionResult> Index(){

            return View(await _context.Especialidad.ToListAsync());
        }
        
        /*Iniciamos el proceso de editar en forma GET*/
        public async Task<IActionResult> Edit(int? id){
            
            if(id == null){
                return NotFound();
            }

            var especialidad =await _context.Especialidad.FindAsync(id);

            if(especialidad == null){
                return NotFound();
            }

            return View(especialidad);
        }
        /*------------------- FINALIZAMOS el proceso de editar en forma GET --------------------*/

        /*Iniciamos el proceso de editar en forma POST*/
        [HttpPost]//Esto hace diferencia el metodo Edit que graba del Edit de vista
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad","Descripcion")]Especialidad especialidad){
            if(id != especialidad.IdEspecialidad){
                return NotFound();
            }
            if(ModelState.IsValid){
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
        /*------------------- FINALIZAMOS el proceso de editar en forma POST --------------------*/

        /*Iniciamos el proceso de eliminar en forma GET*/
        public async Task<IActionResult> Delete(int? id){
            if(id == null){
                return NotFound();
            }
            var especialidad = await  _context.Especialidad.FirstOrDefaultAsync(e => e.IdEspecialidad == id);
            if(especialidad == null){
                return NotFound();
            }
            return View(especialidad);
        }
        /*------------------- FINALIZAMOS el proceso de eliminar en forma GET --------------------*/

        /*Iniciamos el proceso de eliminar en forma POST*/
        [HttpPost]
        public async Task<IActionResult> Delete (int id){
            var especialidad =await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /*------------------- FINALIZAMOS el proceso de eliminar en forma POST --------------------*/

        /*Iniciamos el proceso de crear*/
        public IActionResult Create(){
            return View();
        }
        /*------------------- FINALIZAMOS el proceso de crear --------------------*/

        /*Iniciamos el proceso de crear en forma POST*/

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad, Descripcion")] Especialidad especialidad){
            if(ModelState.IsValid){
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        /*------------------- FINALIZAMOS el proceso de crear en forma POST --------------------*/
    }
}