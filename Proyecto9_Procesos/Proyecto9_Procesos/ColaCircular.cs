using System;

namespace Proyecto9_Procesos
{
    // Cola circular con arreglo (se usa para los procesos LISTOS, estilo Round Robin)
    public class ColaCircular
    {
        private Proceso[] datos;
        private int frente;
        private int final;
        public int Cantidad { get; private set; }
        public int Capacidad { get; private set; }

        public ColaCircular(int capacidad)
        {
            Capacidad = capacidad;
            datos = new Proceso[capacidad];
            frente = 0;
            final = -1;
            Cantidad = 0;
        }

        public bool EstaVacia()
        {
            return Cantidad == 0;
        }

        public bool EstaLlena()
        {
            return Cantidad == Capacidad;
        }

        public bool Encolar(Proceso p)
        {
            if (EstaLlena()) return false;

            final = (final + 1) % Capacidad;
            datos[final] = p;
            Cantidad++;
            return true;
        }

        public Proceso Desencolar()
        {
            if (EstaVacia()) return null;

            Proceso p = datos[frente];
            datos[frente] = null;
            frente = (frente + 1) % Capacidad;
            Cantidad--;
            return p;
        }

        // Saca un proceso específico y mantiene el orden de los demás
        public Proceso Quitar(int pid)
        {
            Proceso encontrado = null;
            int total = Cantidad;

            for (int i = 0; i < total; i++)
            {
                Proceso p = Desencolar();
                if (p.PID == pid && encontrado == null)
                    encontrado = p;
                else
                    Encolar(p);
            }
            return encontrado;
        }

        public void Mostrar()
        {
            if (EstaVacia())
            {
                Console.WriteLine("(vacía)");
                return;
            }
            for (int i = 0; i < Cantidad; i++)
            {
                int pos = (frente + i) % Capacidad;
                Console.Write($"P{datos[pos].PID:00}");
                if (i < Cantidad - 1) Console.Write(" -> ");
            }
            Console.WriteLine($"   ({Cantidad}/{Capacidad})");
        }
    }
}
