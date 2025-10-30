using Proyecto1.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Controller
{
    internal class Registro
    {

        public static void Registrar(Tarea t)
        {
            Console.WriteLine("Escribe un texto para guardar en DB/datos.txt:");
            string entrada = t.getTarea();

            bool ok = FileHelper.EscribirEnTxt(entrada, out string error);

            if (ok)
                Console.WriteLine("Datos guardados correctamente.");
            else
            {
                Console.WriteLine("No se pudo guardar el archivo. Error:");
                Console.WriteLine(error);
            }


        }
    }
}
