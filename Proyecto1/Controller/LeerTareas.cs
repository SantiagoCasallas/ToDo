using System;
using System.Collections.Generic;
using System.IO;
using Proyecto1.Modelo;

namespace Proyecto1.Controller
{
    public class LeerTareas
    {

        //public static String carp = "C:\\Users\\santi\\source\\repos\\Proyecto1\\Proyecto1\\DB\\";
        public static String carp = FileHelper.carp;

        private static string rutaArchivo =>
            Path.Combine(carp, "Tareas.txt");
        public LeerTareas()
        {
            // Ruta relativa carpeta DB
            View.Vista.print("Ruta de la carpeta DB: " + carp);

            // Si no existe la carpeta, la crea
            Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo));

            // Si no existe el archivo, lo crea vacío
            if (!File.Exists(rutaArchivo))
            {
                File.WriteAllText(rutaArchivo, "");
            }
        }

        public List<Tarea> LeerTareasObjeto()
        {
            List<Tarea> listaTareas = new List<Tarea>();

            var lineas = File.ReadAllLines(rutaArchivo);

            foreach (string linea in lineas)
            {
                if (string.IsNullOrWhiteSpace(linea))
                    continue;

                // Formato esperado: Id, Descripcion, Estado
                var datos = linea.Split(',');

                if (datos.Length >= 3)
                {
                    int id = int.Parse(datos[0].Trim());
                    string descripcion = datos[1].Trim();
                    string estado = datos[2].Trim();

                    Tarea tarea = new Tarea(id, descripcion, estado);
                    listaTareas.Add(tarea);
                }
            }

            return listaTareas;
        }
    }
}
