using System;
using Proyecto1.Controller;
using Proyecto1.Modelo;

namespace Proyecto1
{
    class prog
    {
        public static void Main(string[] args)
        {
            // Ejemplos (si los necesitas)
            // Tarea t = new Tarea(1, "estudiar");
            // Tarea t1 = new Tarea(233, "barrer");
            // Controller.Registro.Registrar(t1);

            Menu menu = new Menu();
            bool running = true;

            while (running)
            {
                menu.MostrarMenu();

                string entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out int op))
                {
                    Console.WriteLine("Entrada inválida. Por favor ingrese un número.");
                    continue;
                }

                running = menu.ProcesarOpcion(op);
            }

            Console.WriteLine("Programa finalizado. Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
