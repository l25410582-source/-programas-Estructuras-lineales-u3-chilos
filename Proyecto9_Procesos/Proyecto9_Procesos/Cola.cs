using System;

namespace Proyecto9_Procesos
{
    // Cola FIFO con nodos enlazados (se usa para los procesos BLOQUEADOS)
    public class Cola
    {
        private Nodo frente;
        private Nodo final;

        public Cola()
        {
            frente = null;
            final = null;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(Proceso p)
        {
            Nodo nuevo = new Nodo(p);
            if (final == null)
            {
                frente = nuevo;
                final = nuevo;
            }
            else
            {
                final.Siguiente = nuevo;
                final = nuevo;
            }
        }

        public Proceso Desencolar()
        {
            if (frente == null) return null;

            Proceso p = frente.Dato;
            frente = frente.Siguiente;
            if (frente == null) final = null;
            return p;
        }

        // Saca un proceso específico de la cola (sin importar su posición)
        public Proceso Quitar(int pid)
        {
            Nodo anterior = null;
            Nodo actual = frente;

            while (actual != null)
            {
                if (actual.Dato.PID == pid)
                {
                    if (anterior == null) frente = actual.Siguiente;
                    else anterior.Siguiente = actual.Siguiente;

                    if (actual == final) final = anterior;
                    return actual.Dato;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
            return null;
        }

        public void Mostrar()
        {
            if (frente == null)
            {
                Console.WriteLine("(vacía)");
                return;
            }
            Nodo actual = frente;
            while (actual != null)
            {
                Console.Write($"P{actual.Dato.PID:00}");
                if (actual.Siguiente != null) Console.Write(" -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine();
        }
    }
}
