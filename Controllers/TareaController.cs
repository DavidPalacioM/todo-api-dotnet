using Microsoft.AspNetCore.Mvc;
using api_ToDo.Models;
using api_ToDo.Services;

namespace api_ToDo.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class TareaController : ControllerBase
    {
        private readonly TareaService _tareaService;

        public TareaController(TareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public ActionResult<List<Tarea>> Get()
        {
            return _tareaService.ObtenerTodas();
        }

        [HttpGet("{id}")]
        public ActionResult<Tarea> GetPorId(int id)
        {
            var tarea = _tareaService.ObtenerPorId(id);
            if (tarea == null)
                return NotFound();
            return tarea;
        }

        [HttpPost]
        public ActionResult<Tarea> Post(Tarea nuevaTarea)
        {
            _tareaService.Agregar(nuevaTarea);
            return CreatedAtAction(nameof(GetPorId), new { id = nuevaTarea.Id }, nuevaTarea);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Tarea tareaEditada)
        {
            var resultado = _tareaService.Actualizar(id, tareaEditada);
            if (!resultado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var eliminado = _tareaService.Eliminar(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}

