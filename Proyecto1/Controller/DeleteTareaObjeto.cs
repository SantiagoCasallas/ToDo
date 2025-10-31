using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto1.Modelo;

namespace Proyecto1.Controller
{
    internal class DeleteTareaObjeto
    {
        /// <summary>
        /// Elimina la tarea con el Id indicado, reindexa los Ids en forma consecutiva
        /// y guarda el archivo con el formato "Id, Descripcion, Estado;" por línea.
        /// </summary>
        public static bool EliminarPorId(int idEliminar)
        {
            // Obtener la lista de tareas como objetos
            var lector = new LeerTareas();
            List<Tarea> lista;
            try
            {
                lista = lector.LeerTareasObjeto();
            }
            catch (Exception ex)
            {
                View.Vista.print("Error al leer tareas: " + ex.Message);
                return false;
            }

            if (lista == null || lista.Count == 0)
            {
                View.Vista.print("El archivo está vacío o no hay tareas.");
                return false;
            }

            // Buscar la tarea por id
            var tareaAEliminar = lista.FirstOrDefault(t => t.Id == idEliminar);
            if (tareaAEliminar == null)
            {
                View.Vista.print("No existe una tarea con ese ID.");
                return false;
            }

            // Eliminarla
            lista.Remove(tareaAEliminar);

            // Reindexar IDs comenzando en 1, manteniendo el orden actual
            var reindexadas = lista
                .OrderBy(t => t.Id)   // asegura orden por id anterior
                .Select((t, index) =>
                {
                    t.Id = index + 1;
                    return t;
                })
                .ToList();

            // Reconstruir el contenido a escribir en el archivo
            var lineas = new List<string>();
            foreach (var t in reindexadas)
            {
                // Aseguramos que descripcion y estado no contengan saltos de línea ni ; al final
                var desc = (t.Descripcion ?? string.Empty).Replace("\r", " ").Replace("\n", " ").Trim();
                var estado = (t.Estado ?? "Pendiente").Replace("\r", " ").Replace("\n", " ").Trim();

                lineas.Add($"{t.Id}, {desc}, {estado};");
            }

            string nuevoContenido = string.Join(Environment.NewLine, lineas);

            // Escribir el archivo
            bool ok = FileHelper.EscribirTodo(nuevoContenido, out string guardarErr);
            if (!ok)
            {
                View.Vista.print("Error guardando archivo: " + guardarErr);
                return false;
            }

            View.Vista.print("Tarea eliminada y IDs actualizados.");
            return true;
        }
    }
}
