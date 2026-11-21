using System;

namespace SimuladorLlamadas
{
    class Program
    {
        static void Main()
        {
            var gestor = new GestorLlamadas();
            int opcion;

            do
            {
                Console.WriteLine();
                Console.WriteLine("===== SIMULADOR DE LLAMADAS TELEFÓNICAS =====");
                Console.WriteLine("1. Registrar llamada");
                Console.WriteLine("2. Atender llamada");
                Console.WriteLine("3. Finalizar llamada");
                Console.WriteLine("4. Mostrar llamadas activas");
                Console.WriteLine("5. Recuperar última llamada");
                Console.WriteLine("6. Buscar llamada");
                Console.WriteLine("7. Eliminar llamada");
                Console.WriteLine("0. Salir");
                Console.Write("Elige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = -1;

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Número: ");
                        string numero = Console.ReadLine();
                        Console.Write("Contacto: ");
                        string contacto = Console.ReadLine();
                        gestor.Registrar(numero, contacto);
                        break;
                    case 2:
                        gestor.Atender();
                        break;
                    case 3:
                        gestor.Finalizar();
                        break;
                    case 4:
                        gestor.Mostrar();
                        break;
                    case 5:
                        gestor.RecuperarUltima();
                        break;
                    case 6:
                        Console.Write("Número o nombre a buscar: ");
                        gestor.Buscar(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Id de la llamada a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                            gestor.Eliminar(id);
                        else
                            Console.WriteLine("Id inválido.");
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
    }
}
