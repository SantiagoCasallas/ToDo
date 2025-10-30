using System;
using System.Linq;

namespace Proyecto1.Controller
{
    internal class Delete
    {
        public static bool EliminarID(int idEliminar)
        {
            string contenido = FileHelper.LeerTodo(out string error);

            if (string.IsNullOrWhiteSpace(contenido))
            {
                View.Vista.print("El archivo está vacío o no se pudo leer.");
                return false;
            }

            // Dividir por líneas válidas
            var lineas = contenido.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList();

            bool encontrado = false;

            // Crear nueva lista reconstruida
            List<string> nuevasLineas = new List<string>();
            int nuevoId = 1;

            foreach (var linea in lineas)
            {
                string[] partes = linea.Split(',');
                int idActual = int.Parse(partes[0].Trim());

                if (idActual == idEliminar)
                {
                    encontrado = true;
                    continue; // SALTAMOS esta línea para eliminarla
                }

                // Reconstruimos línea con el nuevo ID y la descripción original
                string descripcion = partes[1].Trim();
                nuevasLineas.Add($"{nuevoId}, {descripcion}");
                nuevoId++;
            }

            if (!encontrado)
            {
                View.Vista.print("No existe una tarea con ese ID.");
                return false;
            }

            // Escribir todo nuevamente al archivo
            string nuevoContenido = string.Join("\n", nuevasLineas);
            FileHelper.EscribirTodo(nuevoContenido, out string guardarErr);

            if (guardarErr != null)
            {
                View.Vista.print("Error guardando archivo:");
                View.Vista.print(guardarErr);
                return false;
            }

            View.Vista.print("Tarea eliminada y IDs actualizados.");
            return true;
        }

    }
}
