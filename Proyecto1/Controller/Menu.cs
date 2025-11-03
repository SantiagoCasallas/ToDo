using System;

namespace Proyecto1.Controller
{
    internal class Menu
    {
        public Menu() { }
        String ruta;
        // Solo muestra el menú
        public void MostrarMenu( )
        {
            this.ruta = ruta;
            View.Vista.print(null);
            View.Vista.print("----- Menú de Tareas -----");
            View.Vista.print("1. Agregar Tarea");
            View.Vista.print("2. Leer tareas ");
            View.Vista.print("3. Borrar tarea");
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
                    string desc = Controller.Capturar.capturar();
                    string estado = Controller.Capturar.capturar();


                    int ultimoId = new LeerTareas().ObtenerUltimoId();
                    int nuevoId = ultimoId + 1;

                    Controller.Registro.Registrar(new Modelo.Tarea(nuevoId, desc, estado));

                    View.Vista.print(" Tarea guardada con ID " + nuevoId);
                    return true;

                case 4:
                    View.Vista.print("Saliendo del programa...");
                    return false;

                case 2: //prueba leer tareas objeto
                    LeerTareas lt = new LeerTareas();
                    var lista = lt.LeerTareasObjeto();
                    foreach (var tarea in lista)
                    {
                        tarea.mostrarTarea();
                    }
                    Console.ReadKey();
                    return true;
                case 3:
                    View.Vista.print("Ingrese el ID de la tarea a eliminar:");
                    if (int.TryParse(Controller.Capturar.capturar(), out int idEliminar))
                    {
                        DeleteTareaObjeto.EliminarPorId(idEliminar);
                    }
                    else
                    {
                        View.Vista.print("ID inválido.");
                    }
                    return true;
                    break;
                default:
                    View.Vista.print("Opción no válida. Intente de nuevo.");
                    return true;
            }
        }
    }
}
