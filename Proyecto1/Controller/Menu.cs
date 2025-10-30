using System;

namespace Proyecto1.Controller
{
    internal class Menu
    {
        public Menu() { }

        // Solo muestra el menú
        public void MostrarMenu()
        {
            View.Vista.print(null);
            View.Vista.print("----- Menú de Tareas -----");
            View.Vista.print("1. Agregar Tarea");
            View.Vista.print("2. Ver Tareas");
            View.Vista.print("3. Eliminar tarea (id)");
            View.Vista.print("4. Salir");
            View.Vista.print("Seleccione una opción: ");
        }

        // Procesa la opción; devuelve true para seguir, false para salir
        public bool ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    View.Vista.print("Ingrese la descripción de la tarea: ");
                    string desc = Console.ReadLine();

                    int ultimoId = Leer.ObtenerUltimoId();
                    int nuevoId = ultimoId + 1;

                    Controller.Registro.Registrar(new Modelo.Tarea(nuevoId, desc));

                    View.Vista.print(" Tarea guardada con ID"+nuevoId);
                    return true;

                case 2:
                    // Lógica para ver tareas
                    Controller.Leer.LeerTareas();
                    return true;

                case 3:
                    View.Vista.print("Ingrese el ID de la tarea a eliminar:");
                    int id;
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        Delete.EliminarID(id);
                    }
                    else
                    {
                        View.Vista.print("ID inválido.");
                    }
                    Console.ReadKey();
                    return true;    
                    break;
                case 4:
                    View.Vista.print("Saliendo del programa...");
                    return false;

                default:
                    View.Vista.print("Opción no válida. Intente de nuevo.");
                    return true;
            }
        }
    }
}
