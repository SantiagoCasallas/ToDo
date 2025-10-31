using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controller
{
    internal class Leer
    {
        public static void LeerTareas()
        {
            // Mostrar contenido actual del archivo
            string contenido = FileHelper.LeerTodo(out string leerErr);

            if (contenido != null)
            {
                View.Vista.print("\n--- BD/datos.txt ---");
                View.Vista.print(string.IsNullOrEmpty(contenido) ? "(vacío)" : contenido);
            }
            else
            {
                View.Vista.print("No se pudo leer el archivo. Error:");
                View.Vista.print(leerErr);
            }

            View.Vista.print("\nPresiona una tecla para salir...");
            Console.ReadKey();
        }
        public static int ObtenerUltimoId()
        {
            string contenido = FileHelper.LeerTodo(out string error);

            if (string.IsNullOrWhiteSpace(contenido))
                return 0; // retorna id=0 si el archivo está vacío

            try
            {
                // Obtener líneas válidas
                string[] lineas = contenido.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                // Última línea no vacía
                string ultimaLinea = lineas.Last().Trim();

                // Formato esperado: "Id, descripcion;"
                string[] partes = ultimaLinea.Split(',');

                // partes[0]:Id
                int ultimoId = int.Parse(partes[0].Trim());
                return ultimoId;
            }
            catch
            {
                return 0; // Si falla, empieza en 1
            }
        }

    }
}
