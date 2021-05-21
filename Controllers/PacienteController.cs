using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Controllers{
    public class PacienteController : Controller{
        private readonly TurnosContext _context;
        
        public PacienteController(TurnosContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            return View(await _context.Paciente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id){
            if(id == null){
                return NotFound();
            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);
            if(paciente == null){
                return NotFound();
            }
            return View(paciente);
        }

        /*Iniciamos el proceso de crear*/
        public IActionResult Create(){
            return View();
        }
        /*------------------- FINALIZAMOS el proceso de crear --------------------*/

        /*Iniciamos el proceso de crear en forma POST*/

        [HttpPost]
        [ValidateAntiForgeryToken] /* Valida que el metodo create ha sido ejecutado desde el formulario */
        public async Task<IActionResult> Create([Bind("IdPaciente, Nombre, Apellidos, Direccion, Telefono, Email")] Paciente paciente){
            if(ModelState.IsValid){
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        /*------------------- FINALIZAMOS el proceso de crear en forma POST --------------------*/



        /*Iniciamos el proceso de editar en forma GET*/
        public async Task<IActionResult> Edit(int? id){
            
            if(id == null){
                return NotFound();
            }

            var paciente =await _context.Paciente.FindAsync(id);

            if(paciente == null){
                return NotFound();
            }

            return View(paciente);
        }
        /*------------------- FINALIZAMOS el proceso de editar en forma GET --------------------*/

        /*Iniciamos el proceso de editar en forma POST*/
        [HttpPost]//Esto hace diferencia el metodo Edit que graba del Edit de vista
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaciente, Nombre, Apellidos, Direccion, Telefono, Email")]Paciente paciente){
            if(id != paciente.IdPaciente){
                return NotFound();
            }
            if(ModelState.IsValid){
                _context.Update(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }
        /*------------------- FINALIZAMOS el proceso de editar en forma POST --------------------*/

        /*Iniciamos el proceso de eliminar en forma GET*/
        public async Task<IActionResult> Delete(int? id){
            if(id == null){
                return NotFound();
            }
            var paciente = await  _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);
            if(paciente == null){
                return NotFound();
            }
            return View(paciente);
        }
        /*------------------- FINALIZAMOS el proceso de eliminar en forma GET --------------------*/

        /*Iniciamos el proceso de eliminar en forma POST*/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (int id){
            var paciente =await _context.Paciente.FindAsync(id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /*------------------- FINALIZAMOS el proceso de eliminar en forma POST --------------------*/
    }
}