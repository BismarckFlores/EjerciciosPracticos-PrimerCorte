using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPracticos_PrimerCorte
{
    internal class Program
    {
        //Actividad 1: Variables Globales
        static List<string> inventario = new List<string>();
        
        // Actividad 10 - Variables Globales 
        private static int numeroOriginal;

        static void Main(string[] args)
        {
            bool programaActivo = true;
            do
            {
                Console.Clear();
                Console.WriteLine("====Selección de Actividad ====");
                Console.WriteLine("1. Sistema de Inventario simplificado");
                Console.WriteLine("2. Simulador de Tienda en Línea");
                Console.WriteLine("3. Verificación de Número Capicúa (Palíndromo Numérico)");
                Console.WriteLine("================================");
                Console.WriteLine("\n4. Salir");
                Console.Write("\n\n\nSeleccione una actividad (1-3): ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        // Llamar a la función del primer ejercicio
                        SistemaInventarioSimplificado();
                        break;
                    case "2":
                        // Llamar a la función del segundo ejercicio
                        break;
                    case "3":
                        // Llamar a la función del tercer ejercicio
                        Actividad10();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del sistema. ¡Hasta luego!");
                        programaActivo = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción entre 1 y 3.");
                        Console.Write("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (programaActivo);
        }
      
        
        // Actividad 1
        static void SistemaInventarioSimplificado()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
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
                        Console.Write("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
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
              
        // Actividad 10
        public static void Actividad10()
        {
            Console.Clear();
            PedirNumero();
            int numeroInvertido = InvertirNumero(numeroOriginal);
            DeterminarCapicua(numeroOriginal, numeroInvertido);
            Console.Write("\n\n\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void PedirNumero()
        {
            Console.WriteLine("--- Verificación de Número Capicúa (Palíndromo Numérico) ---");

            // Variables Locales
            int numeroIngresado;
            bool esValido = false;

            do
            {
                Console.Write("Ingrese un número entero positivo: ");
                string entrada = Console.ReadLine();
                // Validar que la entrada sea un número entero positivo
                if (int.TryParse(entrada, out numeroIngresado) && numeroIngresado >= 0)
                {
                    esValido = true;

                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero positivo.");
                }
            } while (!esValido);

            numeroOriginal = numeroIngresado; // Asignar a la variable global
        }

        public static int InvertirNumero(int n)
        {
            int numeroInvertido = 0;
            int temp = n;

            while (temp > 0)
            {
                int digito = temp % 10; // Obtener el último dígito
                numeroInvertido = (numeroInvertido * 10) + digito; // Construir el número invertido
                temp /= 10; // Eliminar el último dígito
            }
            return numeroInvertido;
        }

        public static void DeterminarCapicua(int n, int invertido)
        {
            if (n == invertido)
            {
                Console.WriteLine($"\nEl número {n} es **capicúa**.");
            }
            else
            {
                Console.WriteLine($"\nEl número {n} **no** es capicúa.");
            }
        }
    }
}