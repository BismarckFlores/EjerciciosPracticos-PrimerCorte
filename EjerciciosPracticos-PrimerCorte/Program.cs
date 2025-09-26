using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosPracticos_PrimerCorte
{
    // Clase para almacenar información de cada producto
    class Producto
    {
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public double Subtotal => PrecioUnitario * Cantidad;
    }

    internal class Program
    {
        // Diccionario para almacenar productos por nombre
        static Dictionary<string, Producto> carrito = new Dictionary<string, Producto>();

        // Método para agregar un producto
        static void AgregarProducto(string nombre, double precioUnitario, int cantidad)
        {
            if (carrito.ContainsKey(nombre))
            {
                carrito[nombre].Cantidad += cantidad;
                carrito[nombre].PrecioUnitario = precioUnitario; // Actualiza el precio unitario si cambia
                Console.WriteLine($"Se agregaron {cantidad} unidades más de '{nombre}'. Total ahora: {carrito[nombre].Cantidad}.\n");
            }
            else
            {
                carrito[nombre] = new Producto
                {
                    Nombre = nombre,
                    PrecioUnitario = precioUnitario,
                    Cantidad = cantidad
                };
                Console.WriteLine($"Producto agregado: {nombre} ({cantidad} unidades a ${precioUnitario} cada una).\n");
            }
        }

        // Método para eliminar cantidad de un producto
        static void EliminarProducto(string nombre, int cantidadEliminar)
        {
            if (carrito.ContainsKey(nombre))
            {
                if (cantidadEliminar >= carrito[nombre].Cantidad)
                {
                    carrito.Remove(nombre);
                    Console.WriteLine($"Se eliminaron todas las unidades de '{nombre}'.\n");
                }
                else
                {
                    carrito[nombre].Cantidad -= cantidadEliminar;
                    Console.WriteLine($"Se eliminaron {cantidadEliminar} unidades de '{nombre}'. Quedan: {carrito[nombre].Cantidad}.\n");
                }
            }
            else
            {
                Console.WriteLine($"El producto '{nombre}' no está en el carrito.\n");
            }
        }

        // Función para mostrar el desglose y total
        static void ConsultarTotal()
        {
            double total = 0;
            Console.WriteLine("----- Carrito -----");
            if (carrito.Count == 0)
            {
                Console.WriteLine("No hay productos en el carrito.");
            }
            else
            {
                foreach (var prod in carrito.Values)
                {
                    Console.WriteLine($"Producto: {prod.Nombre} | Cantidad: {prod.Cantidad} | Precio unitario: ${prod.PrecioUnitario} | Subtotal: ${prod.Subtotal}");
                    total += prod.Subtotal;
                }
                Console.WriteLine("------------------------------");
                Console.WriteLine($"Total de la compra: ${total}\n");
            }
        }

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("===== Simulador de Tienda en Línea =====");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Eliminar producto");
                Console.WriteLine("3. Ver carrito");
                Console.WriteLine("4. Salir");
                Console.Write("Elige una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa el nombre del producto a agregar: ");
                        string nombreAgregar = Console.ReadLine();
                        Console.Write("Ingresa el precio unitario del producto: $");
                        if (double.TryParse(Console.ReadLine(), out double precioAgregar))
                        {
                            Console.Write("Ingresa la cantidad del producto: ");
                            if (int.TryParse(Console.ReadLine(), out int cantidadAgregar) && cantidadAgregar > 0)
                            {
                                AgregarProducto(nombreAgregar, precioAgregar, cantidadAgregar);
                            }
                            else
                            {
                                Console.WriteLine("Cantidad inválida.\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Precio inválido.\n");
                        }
                        break;

                    case "2":
                        Console.Write("Ingresa el nombre del producto a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        Console.Write("Ingresa la cantidad a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int cantidadEliminar) && cantidadEliminar > 0)
                        {
                            EliminarProducto(nombreEliminar, cantidadEliminar);
                        }
                        else
                        {
                            Console.WriteLine("Cantidad inválida.\n");
                        }
                        break;

                    case "3":
                        ConsultarTotal();
                        break;

                    case "4":
                        salir = true;
                        Console.WriteLine("Saliendo");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.\n");
                        break;
                }
            }
        }
    }
}