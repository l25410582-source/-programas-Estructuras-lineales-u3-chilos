using System;

namespace Proyecto9_Procesos
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorProcesos gestor = new GestorProcesos(10);
            int opcion;

            do
            {
                Console.WriteLine("\n===== SISTEMA DE CONTROL DE PROCESOS =====");
                Console.WriteLine("1. Crear proceso");
                Console.WriteLine("2. Eliminar proceso");
                Console.WriteLine("3. Ejecutar proceso");
                Console.WriteLine("4. Bloquear proceso");
                Console.WriteLine("5. Desbloquear proceso");
                Console.WriteLine("6. Mostrar procesos");
                Console.WriteLine("7. Buscar proceso");
                Console.WriteLine("8. Administrar cola de procesos");
                Console.WriteLine("0. Salir");
                opcion = LeerEntero("Opción: ");
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        int prioridad = LeerEntero("Prioridad: ");
                        int tiempo = LeerEntero("Tiempo de ejecución: ");
                        gestor.CrearProceso(nombre, prioridad, tiempo);
                        break;
                    case 2:
                        gestor.EliminarProceso(LeerEntero("PID a eliminar: "));
                        break;
                    case 3:
                        gestor.EjecutarProceso();
                        break;
                    case 4:
                        gestor.BloquearProceso(LeerEntero("PID a bloquear: "));
                        break;
                    case 5:
                        gestor.DesbloquearProceso(LeerEntero("PID a desbloquear: "));
                        break;
                    case 6:
                        gestor.MostrarProcesos();
                        break;
                    case 7:
                        gestor.BuscarProceso(LeerEntero("PID a buscar: "));
                        break;
                    case 8:
                        gestor.AdministrarColaProcesos();
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

        static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Valor no válido, intenta de nuevo: ");
            }
            return valor;
        }
    }
}
