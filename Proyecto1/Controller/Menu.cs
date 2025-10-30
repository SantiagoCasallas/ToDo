using System;

namespace Proyecto1.Controller
{
    internal class Menu
    {
        public Menu() { }

        // Solo muestra el menú
        public void MostrarMenu()
        {
            Console.WriteLine();
            Console.WriteLine("----- Menú de Tareas -----");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Ver Tareas");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
        }

        // Procesa la opción; devuelve true para seguir, false para salir
        public bool ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la descripción de la tarea: ");
                    string desc = Console.ReadLine();

                    int ultimoId = Leer.ObtenerUltimoId();
                    int nuevoId = ultimoId + 1;

                    Controller.Registro.Registrar(new Modelo.Tarea(nuevoId, desc));

                    Console.WriteLine($" Tarea guardada con ID {nuevoId}");
                    return true;

                case 2:
                    // Lógica para ver tareas
                    Controller.Leer.LeerTareas();
                    return true;

                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    return false;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    return true;
            }
        }
    }
}
