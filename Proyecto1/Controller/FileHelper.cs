using System;
using System.IO;

namespace Proyecto1.Controller
{
    public static class FileHelper
    {
        // Ruta absoluta de la carpeta DB (al lado del ejecutable)

        public static String carp = "C:\\Users\\santi\\source\\repos\\Proyecto1\\Proyecto1\\DB\\";

        private static string RutaArchivo =>
            Path.Combine(carp, "Tareas.txt");

        // Escribe el texto (agrega en una nueva línea). Devuelve true si fue exitoso.
        public static bool EscribirEnTxt(string texto, out string mensajeError)
        {
            mensajeError = null;
            try
            {
                // Crear carpeta DB si no existe
                if (!Directory.Exists(carp))
                {
                    Directory.CreateDirectory(carp);
                }

                // Asegurarse de que texto no sea null (opcional)
                if (texto == null) texto = string.Empty;

                // Agregar texto con nueva línea al final; crea el archivo si no existe
                File.AppendAllText(RutaArchivo, texto + Environment.NewLine);

                return true;
            }
            catch (Exception ex)
            {
                // Devuelve el mensaje de error para debug
                mensajeError = ex.Message;
                return false;
            }
        }

        // Lee todo el contenido del archivo. Devuelve null si hay error (mensaje en out).
        public static string LeerTodo(out string mensajeError)
        {
            mensajeError = null;
            try
            {
                if (!File.Exists(RutaArchivo))
                {
                    return string.Empty; // archivo no existe -> vacío
                }

                return File.ReadAllText(RutaArchivo);
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
                return null;
            }
        }
        public static bool EscribirTodo(string texto, out string error)
        {
            error = null;
            try
            {
                if (!Directory.Exists(carp))
                    Directory.CreateDirectory(carp);

                File.WriteAllText(RutaArchivo, texto);
                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

    }
}