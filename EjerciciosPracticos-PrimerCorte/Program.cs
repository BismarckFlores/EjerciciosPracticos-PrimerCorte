using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPracticos_PrimerCorte
{
    internal class Program
    {
        //Actividad 1: Variables Globales{
        static List<string> inventario = new List<string>();
        //}
        static void SistemaInventarioSimplificado()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nBienvenido al sistema de inventario.");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Retirar producto");
                Console.WriteLine("3. Consultar el inventario actual");
                Console.WriteLine("4. Salir");

                switch (Console.ReadLine())
                {
                    case "1":
                        AgregarProducto();
                        break;
                    case "2":
                        RetirarProducto();
                        break;
                    case "3":
                        ConsultarInventario();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void AgregarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto a agregar:");
            string producto = Console.ReadLine();
            inventario.Add(producto);
            Console.WriteLine($"Producto '{producto}' agregado al inventario.");
        }

        static void RetirarProducto()
        {
            Console.WriteLine("Ingrese el nombre del producto a retirar:");
            string producto = Console.ReadLine();
            if (inventario.Remove(producto))
            {
                Console.WriteLine($"Producto '{producto}' retirado del inventario.");
            }
            else
            {
                Console.WriteLine($"Producto '{producto}' no encontrado en el inventario.");
            }
        }

        static void ConsultarInventario()
        {
            Console.WriteLine("Inventario actual:");
            if (inventario.Count == 0)
            {
                Console.WriteLine("El inventario está vacío.");
            }
            else
            {
                foreach (var producto in inventario)
                {
                    Console.WriteLine($"- {producto}");
                }
            }
        }
    }
}
