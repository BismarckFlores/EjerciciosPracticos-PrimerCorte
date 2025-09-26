using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPracticos_PrimerCorte
{
    internal class Program
    {
        // Actividad 10 - Variables Globales {
        private static int numeroOriginal;
        // }

        static void Main(string[] args)
        {
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
                        break;
                    case "2":
                        // Llamar a la función del segundo ejercicio
                        break;
                    case "3":
                        // Llamar a la función del tercer ejercicio
                        Actividad10();
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción entre 1 y 3.");
                        Console.Write("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (true);
        }

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