using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ListTasks.Models;
using Microsoft.EntityFrameworkCore;

namespace ListTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DbTasksContext dbContext;

        public TareaController(DbTasksContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Tarea> lista = dbContext.Tareas.OrderByDescending(t => t.IdTarea).ThenBy(t => t.FechaRegistro).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Tarea request)
        {

            await dbContext.Tareas.AddAsync(request);
            await dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Cerrar/{id:int}")]
        public async Task<IActionResult> Cerrar(int id)
        {
            Tarea tarea = dbContext.Tareas.Where(t => t.IdTarea == id).FirstOrDefault();

            dbContext.Tareas.Remove(tarea);
            await dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
