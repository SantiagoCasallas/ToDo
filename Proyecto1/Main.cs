using Proyecto1.Controller;
using Proyecto1.Modelo;
using Proyecto1.View;
using System;
using System.IO; // Es necesario incluir el espacio de nombres


namespace Proyecto1
{
    class prog
    {
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            View.Vista.print(Char.GetNumericValue('A').ToString());         
                bool running = true;

            while (running)
            {
                menu.MostrarMenu();

                string entrada = Controller.Capturar.capturar();
                if (!int.TryParse(entrada, out int op))
                {
                    View.Vista.print("Entrada inválida. Por favor ingrese un número.");
                    continue;
                }

                running = menu.ProcesarOpcion(op);
            }

            View.Vista.print("Programa finalizado. Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
