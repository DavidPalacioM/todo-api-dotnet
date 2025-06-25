using api_ToDo.Models;
namespace api_ToDo.Services
{
    public class TareaService
    {
        private readonly List<Tarea> _tareas = new();

        // El "=>" es igual a "{ return }"
        public List<Tarea> ObtenerTodas() => _tareas;

        public Tarea? ObtenerPorId(int id) => _tareas.FirstOrDefault(t => t.Id == id);

        public void Agregar(Tarea nuevaTarea)
        {
            _tareas.Add(nuevaTarea);
        }

        public bool Actualizar(int id, Tarea tareaEditada)
        {
            var tareaExistente = _tareas.FirstOrDefault(t => t.Id == id);
            if (tareaExistente == null)
                return false;

            tareaExistente.Titulo = tareaEditada.Titulo;
            tareaExistente.Completada = tareaEditada.Completada;
            return true;
        }

        public bool Eliminar(int id)
        {
            var tarea = _tareas.FirstOrDefault(t => t.Id == id);
            if (tarea == null)
                return false;

            _tareas.Remove(tarea);
            return true;
        }
    }
}
