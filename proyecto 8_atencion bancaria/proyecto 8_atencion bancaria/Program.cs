using System;

namespace Proyecto8_Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            ColaPrioridad cola = new ColaPrioridad();
            int turno = 1;
            int opcion;

            do
            {
                Console.WriteLine("\n=== SISTEMA DE ATENCIÓN BANCARIA ===");
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Atender cliente");
                Console.WriteLine("3. Mostrar cola");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = 0;

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Prioridad: 1 = Alta, 2 = Media, 3 = Normal");
                        Console.Write("Prioridad: ");
                        int prioridad;
                        if (!int.TryParse(Console.ReadLine(), out prioridad) || prioridad < 1 || prioridad > 3)
                        {
                            prioridad = 3;
                            Console.WriteLine("Prioridad inválida, se asignó 3 (Normal).");
                        }

                        Cliente cliente = new Cliente(turno++, nombre, prioridad);
                        cola.Insertar(cliente);
                        Console.WriteLine("Cliente registrado: " + cliente);
                        break;

                    case 2:
                        Cliente atendido = cola.Atender();
                        if (atendido == null)
                            Console.WriteLine("No hay clientes en espera.");
                        else
                            Console.WriteLine("Atendiendo a: " + atendido);
                        break;

                    case 3:
                        if (cola.EstaVacia())
                            Console.WriteLine("La cola está vacía.");
                        else
                        {
                            Console.WriteLine("--- Clientes en espera ---");
                            cola.Mostrar();
                        }
                        break;

                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            } while (opcion != 4);
        }
    }
}
