using System;

namespace Proyecto10_Tienda
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda tienda = new Tienda();
            int opcion;

            do
            {
                Console.WriteLine("\n===== TIENDA EN LÍNEA - GESTIÓN DE PEDIDOS =====");
                Console.WriteLine("1.  Registrar producto");
                Console.WriteLine("2.  Buscar producto");
                Console.WriteLine("3.  Eliminar producto");
                Console.WriteLine("4.  Registrar pedido");
                Console.WriteLine("5.  Cancelar pedido");
                Console.WriteLine("6.  Procesar pedido");
                Console.WriteLine("7.  Atender pedido urgente");
                Console.WriteLine("8.  Mostrar pedidos pendientes");
                Console.WriteLine("9.  Mostrar historial");
                Console.WriteLine("10. Consultar inventario");
                Console.WriteLine("11. Buscar cliente");
                Console.WriteLine("12. Mostrar estadísticas");
                Console.WriteLine("0.  Salir");
                opcion = LeerEntero("Opción: ");
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        int id = LeerEntero("ID: ");
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        decimal precio = LeerDecimal("Precio: ");
                        int existencias = LeerEntero("Existencias: ");
                        Console.Write("Categoría: ");
                        string categoria = Console.ReadLine();
                        tienda.RegistrarProducto(id, nombre, precio, existencias, categoria);
                        break;
                    case 2:
                        tienda.BuscarProducto(LeerEntero("ID a buscar: "));
                        break;
                    case 3:
                        tienda.EliminarProducto(LeerEntero("ID a eliminar: "));
                        break;
                    case 4:
                        RegistrarPedido(tienda);
                        break;
                    case 5:
                        tienda.CancelarPedido(LeerEntero("Número de pedido a cancelar: "));
                        break;
                    case 6:
                        tienda.ProcesarPedido();
                        break;
                    case 7:
                        tienda.AtenderPedidoUrgente();
                        break;
                    case 8:
                        tienda.MostrarPedidosPendientes();
                        break;
                    case 9:
                        tienda.MostrarHistorial();
                        break;
                    case 10:
                        tienda.ConsultarInventario();
                        break;
                    case 11:
                        Console.Write("Nombre del cliente: ");
                        tienda.BuscarCliente(Console.ReadLine());
                        break;
                    case 12:
                        tienda.MostrarEstadisticas();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            } while (opcion != 0);
        }

        static void RegistrarPedido(Tienda tienda)
        {
            Console.Write("Cliente: ");
            string cliente = Console.ReadLine();
            int prioridad = LeerEntero("Prioridad (1=Urgente, 2=Alta, 3=Normal): ");

            Pedido pedido = tienda.CrearPedido(cliente, prioridad);

            string otro;
            do
            {
                int idProd = LeerEntero("ID del producto: ");
                int cantidad = LeerEntero("Cantidad: ");
                if (tienda.AgregarAlPedido(pedido, idProd, cantidad))
                    Console.WriteLine("Producto agregado al pedido.");

                Console.Write("¿Agregar otro producto? (s/n): ");
                otro = Console.ReadLine().Trim().ToLower();
            } while (otro == "s");

            tienda.ConfirmarPedido(pedido);
        }

        static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
                Console.Write("Valor no válido, intenta de nuevo: ");
            return valor;
        }

        static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor))
                Console.Write("Valor no válido, intenta de nuevo: ");
            return valor;
        }
    }
}
