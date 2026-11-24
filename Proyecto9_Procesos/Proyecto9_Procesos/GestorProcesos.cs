using System;

namespace Proyecto9_Procesos
{
    public class GestorProcesos
    {
        private ListaEnlazada todos;        // tabla general de procesos
        private ColaCircular listos;        // cola circular de LISTOS
        private Cola bloqueados;            // cola de BLOQUEADOS
        private int siguientePID;
        private const int QUANTUM = 2;      // tiempo que se ejecuta cada proceso por turno

        public GestorProcesos(int capacidadListos)
        {
            todos = new ListaEnlazada();
            listos = new ColaCircular(capacidadListos);
            bloqueados = new Cola();
            siguientePID = 1;
        }

        public void CrearProceso(string nombre, int prioridad, int tiempo)
        {
            if (listos.EstaLlena())
            {
                Console.WriteLine("La cola de listos está llena. No se puede crear el proceso.");
                return;
            }

            Proceso p = new Proceso(siguientePID++, nombre, prioridad, tiempo);
            todos.Insertar(p);            // estado NUEVO
            p.Estado = EstadoProceso.LISTO;
            listos.Encolar(p);            // pasa a LISTO

            Console.WriteLine($"Proceso creado con PID {p.PID} (NUEVO -> LISTO).");
        }

        public void EliminarProceso(int pid)
        {
            Proceso p = todos.Buscar(pid);
            if (p == null)
            {
                Console.WriteLine("No existe un proceso con ese PID.");
                return;
            }

            listos.Quitar(pid);
            bloqueados.Quitar(pid);
            todos.Eliminar(pid);
            Console.WriteLine($"Proceso {pid} eliminado.");
        }

        // Toma el primero de la cola de listos y lo ejecuta un quantum
        public void EjecutarProceso()
        {
            Proceso p = listos.Desencolar();
            if (p == null)
            {
                Console.WriteLine("No hay procesos listos para ejecutar.");
                return;
            }

            p.Estado = EstadoProceso.EJECUTANDO;
            int uso = Math.Min(QUANTUM, p.TiempoRestante);
            p.TiempoRestante -= uso;
            Console.WriteLine($"Ejecutando P{p.PID:00} ({p.Nombre}) durante {uso} unidades...");

            if (p.TiempoRestante <= 0)
            {
                p.Estado = EstadoProceso.TERMINADO;
                Console.WriteLine($"P{p.PID:00} ha TERMINADO.");
            }
            else
            {
                p.Estado = EstadoProceso.LISTO;
                listos.Encolar(p);        // regresa al final de la cola circular
                Console.WriteLine($"P{p.PID:00} regresa a la cola (le faltan {p.TiempoRestante}).");
            }
        }

        public void BloquearProceso(int pid)
        {
            Proceso p = todos.Buscar(pid);
            if (p == null)
            {
                Console.WriteLine("No existe un proceso con ese PID.");
                return;
            }
            if (p.Estado != EstadoProceso.LISTO)
            {
                Console.WriteLine("Solo se puede bloquear un proceso que esté LISTO.");
                return;
            }

            listos.Quitar(pid);
            p.Estado = EstadoProceso.BLOQUEADO;
            bloqueados.Encolar(p);
            Console.WriteLine($"P{pid:00} bloqueado.");
        }

        public void DesbloquearProceso(int pid)
        {
            Proceso p = todos.Buscar(pid);
            if (p == null)
            {
                Console.WriteLine("No existe un proceso con ese PID.");
                return;
            }
            if (p.Estado != EstadoProceso.BLOQUEADO)
            {
                Console.WriteLine("El proceso no está bloqueado.");
                return;
            }
            if (listos.EstaLlena())
            {
                Console.WriteLine("La cola de listos está llena. No se puede desbloquear.");
                return;
            }

            bloqueados.Quitar(pid);
            p.Estado = EstadoProceso.LISTO;
            listos.Encolar(p);
            Console.WriteLine($"P{pid:00} desbloqueado (BLOQUEADO -> LISTO).");
        }

        public void MostrarProcesos()
        {
            Console.WriteLine("=== TABLA DE PROCESOS ===");
            todos.Mostrar();
        }

        public void BuscarProceso(int pid)
        {
            Proceso p = todos.Buscar(pid);
            if (p == null)
                Console.WriteLine("No existe un proceso con ese PID.");
            else
                p.Mostrar();
        }

        public void AdministrarColaProcesos()
        {
            Console.WriteLine("=== COLA DE PROCESOS ===");
            Console.Write("Listos (circular): ");
            listos.Mostrar();
            Console.Write("Bloqueados:        ");
            bloqueados.Mostrar();
            Console.WriteLine($"Total de procesos en el sistema: {todos.Cantidad}");
        }
    }
}
