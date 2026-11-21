using System;
using System.Text;

namespace NavegacionWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Navegador nav = new Navegador();
            int opcion;

            do
            {
                Console.WriteLine("\n===== NAVEGADOR WEB =====");
                Console.WriteLine($"Página actual: {nav.PaginaActual ?? "(ninguna)"}");
                Console.WriteLine("1. Visitar página");
                Console.WriteLine("2. Regresar");
                Console.WriteLine("3. Avanzar");
                Console.WriteLine("4. Mostrar historial");
                Console.WriteLine("5. Eliminar historial");
                Console.WriteLine("6. Buscar una página");
                Console.WriteLine("7. Mostrar última página visitada");
                Console.WriteLine("8. Ver estado de las pilas");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = -1;

                switch (opcion)
                {
                    case 1:
                        string pagina = LeerTexto("Nombre o URL de la página: ");
                        nav.Visitar(pagina);
                        break;
                    case 2: nav.Regresar(); break;
                    case 3: nav.Avanzar(); break;
                    case 4: nav.MostrarHistorial(); break;
                    case 5: nav.EliminarHistorial(); break;
                    case 6:
                        nav.Buscar(LeerTexto("Página a buscar: "));
                        break;
                    case 7: nav.MostrarUltimaVisitada(); break;
                    case 8: nav.MostrarPilas(); break;
                    case 0: Console.WriteLine("Cerrando navegador..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            } while (opcion != 0);
        }

        static string LeerTexto(string mensaje)
        {
            string texto;
            do
            {
                Console.Write(mensaje);
                texto = (Console.ReadLine() ?? "").Trim();
                if (texto == "")
                    Console.WriteLine("El valor no puede estar vacío.");
            } while (texto == "");
            return texto;
        }
    }
}
