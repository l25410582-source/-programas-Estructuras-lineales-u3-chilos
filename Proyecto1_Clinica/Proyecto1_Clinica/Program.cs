using System;
using System.Text;

namespace Proyecto1_Clinica
{
    // ===================== INTERFAZ DE CONSOLA =====================
    internal class Program
    {
        private static readonly Clinica clinica = new Clinica();

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int opcion;
            do
            {
                MostrarMenu();
                opcion = LeerEntero("Opción: ");
                Console.WriteLine();
                switch (opcion)
                {
                    case 1: Registrar(); break;
                    case 2: Eliminar(); break;
                    case 3: Buscar(); break;
                    case 4: MostrarEspera(); break;
                    case 5: Atender(); break;
                    case 6: AsignarPrioridad(); break;
                    case 7: MostrarHistorial(); break;
                    case 8: ConsultarCantidad(); break;
                    case 0: Console.WriteLine("Saliendo del sistema..."); break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey(true);
                }
            } while (opcion != 0);
        }

        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== CLÍNICA - GESTIÓN DE PACIENTES ===");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Eliminar paciente");
            Console.WriteLine("3. Buscar paciente por expediente");
            Console.WriteLine("4. Mostrar pacientes en espera");
            Console.WriteLine("5. Atender siguiente paciente");
            Console.WriteLine("6. Asignar prioridad");
            Console.WriteLine("7. Historial de pacientes atendidos");
            Console.WriteLine("8. Cantidad de pacientes en espera");
            Console.WriteLine("0. Salir");
            Console.WriteLine("======================================");
        }

        private static void Registrar()
        {
            int exp = LeerEntero("Expediente: ");
            string nombre = LeerTexto("Nombre: ");
            int edad = LeerEntero("Edad: ");
            int prioridad = LeerPrioridad();

            Console.WriteLine(clinica.Registrar(exp, nombre, edad, prioridad)
                ? "Paciente registrado correctamente."
                : "Error: ya existe un paciente con ese expediente.");
        }

        private static void Eliminar()
        {
            int exp = LeerEntero("Expediente a eliminar: ");
            Console.WriteLine(clinica.Eliminar(exp)
                ? "Paciente eliminado de la lista de espera."
                : "No se encontró el paciente en espera.");
        }

        private static void Buscar()
        {
            int exp = LeerEntero("Expediente a buscar: ");

            Paciente p = clinica.BuscarEnEspera(exp);
            if (p != null) { Console.WriteLine("EN ESPERA -> " + Detalle(p)); return; }

            p = clinica.BuscarEnHistorial(exp);
            Console.WriteLine(p != null ? "ATENDIDO -> " + Detalle(p) : "Paciente no encontrado.");
        }

        private static void MostrarEspera()
        {
            if (clinica.CantidadEnEspera == 0) { Console.WriteLine("No hay pacientes en espera."); return; }

            Console.WriteLine("Pacientes en espera (orden de atención):");
            int n = 1;
            foreach (Paciente p in clinica.PacientesEnEspera())
                Console.WriteLine($"{n++}. {Detalle(p)}");
        }

        private static void Atender()
        {
            Paciente p = clinica.AtenderSiguiente();
            Console.WriteLine(p == null ? "No hay pacientes en espera." : "Atendiendo a: " + Detalle(p));
        }

        private static void AsignarPrioridad()
        {
            int exp = LeerEntero("Expediente: ");
            if (clinica.BuscarEnEspera(exp) == null)
            {
                Console.WriteLine("No se encontró el paciente en espera.");
                return;
            }
            clinica.AsignarPrioridad(exp, LeerPrioridad());
            Console.WriteLine("Prioridad actualizada.");
        }

        private static void MostrarHistorial()
        {
            Console.WriteLine("Historial de pacientes atendidos:");
            bool hay = false;
            foreach (Paciente p in clinica.PacientesAtendidos())
            {
                hay = true;
                Console.WriteLine("- " + Detalle(p));
            }
            if (!hay) Console.WriteLine("(vacío)");
        }

        private static void ConsultarCantidad()
        {
            Console.WriteLine($"Total en espera: {clinica.CantidadEnEspera}");
            for (int nivel = ColaPrioridad.NivelMinimo; nivel <= ColaPrioridad.NivelMaximo; nivel++)
                Console.WriteLine($"  {Clinica.NombrePrioridad(nivel)}: {clinica.CantidadPorNivel(nivel)}");
        }

        // ---------- Helpers ----------
        private static string Detalle(Paciente p) =>
            p + $" ({Clinica.NombrePrioridad(p.Prioridad)})";

        private static string LeerTexto(string mensaje)
        {
            string s;
            do
            {
                Console.Write(mensaje);
                s = Console.ReadLine()?.Trim();
            } while (string.IsNullOrEmpty(s));
            return s;
        }

        private static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
                Console.Write("Valor inválido. " + mensaje);
            return valor;
        }

        private static int LeerPrioridad()
        {
            Console.WriteLine("Prioridad:");
            Console.WriteLine("  1. Emergencia");
            Console.WriteLine("  2. Urgencia");
            Console.WriteLine("  3. Consulta General");
            Console.WriteLine("  4. Cita Programada");
            int op;
            do { op = LeerEntero("Seleccione (1-4): "); } while (op < 1 || op > 4);
            return op;
        }
    }
}
