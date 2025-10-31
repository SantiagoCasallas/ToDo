using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1.Controller
{
    internal class DeleteObjeto
    {
        /// <summary>
        /// Elimina la tarea con el Id indicado y reindexa los Ids en forma consecutiva.
        /// Asume formato por línea: "Id, Descripcion, Estado" (el Estado puede terminar en ';' o no).
        /// </summary>
        public static bool EliminarPorId(int idEliminar)
        {
            string contenido = FileHelper.LeerTodo(out string error);

            if (string.IsNullOrWhiteSpace(contenido))
            {
                View.Vista.print("El archivo está vacío o no se pudo leer.");
                return false;
            }

            // Obtener líneas válidas (ignorar líneas vacías)
            var lineas = contenido
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            bool encontrado = false;

            // Lista que almacenará las tareas restantes (tuplas: descripcion, estado)
            var tareasRestantes = new List<(string descripcion, string estado)>();

            foreach (var linea in lineas)
            {
                // Separar en hasta 3 partes: Id, Descripcion, Estado
                var partes = linea.Split(new[] { ',' }, 3);

                if (partes.Length < 1)
                    continue;

                // Parsear Id
                string idTexto = partes[0].Trim();
                if (!int.TryParse(idTexto, out int idActual))
                    continue;

                // Obtener descripción y estado si existen
                string descripcion = partes.Length >= 2 ? partes[1].Trim() : "";
                string estado = partes.Length == 3 ? partes[2].Trim() : "";

                // Si el campo estado termina con ';', quitarlo
                if (estado.EndsWith(";"))
                    estado = estado.Substring(0, estado.Length - 1).Trim();

                if (idActual == idEliminar)
                {
                    // Saltamos esta tarea (la eliminamos)
                    encontrado = true;
                    continue;
                }

                tareasRestantes.Add((descripcion, estado));
            }

            if (!encontrado)
            {
                View.Vista.print("No existe una tarea con ese ID.");
                return false;
            }

            // Reconstruir las líneas con nuevos ids consecutivos y mantener descripcion y estado.
            var nuevasLineas = new List<string>();
            int nuevoId = 1;
            foreach (var t in tareasRestantes)
            {
                // Mantener formato: "Id, Descripcion, Estado;"
                string lineaReconstruida = $"{nuevoId}, {t.descripcion}, {t.estado};";
                nuevasLineas.Add(lineaReconstruida);
                nuevoId++;
            }

            string nuevoContenido = string.Join(Environment.NewLine, nuevasLineas);

            bool ok = FileHelper.EscribirTodo(nuevoContenido, out string guardarErr);
            if (!ok)
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
