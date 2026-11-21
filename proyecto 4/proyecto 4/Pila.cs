using System;

namespace CalculadoraExpresiones
{
    // ===== Pila genérica con nodos enlazados =====
    public class Pila<T>
    {
        private class Nodo
        {
            public T Dato;
            public Nodo Siguiente;
        }

        private Nodo cima;
        public int Cantidad { get; private set; }
        public bool EstaVacia => cima == null;

        public void Push(T dato)
        {
            cima = new Nodo { Dato = dato, Siguiente = cima };
            Cantidad++;
        }

        public T Pop()
        {
            if (cima == null)
                throw new InvalidOperationException("La pila está vacía.");
            T dato = cima.Dato;
            cima = cima.Siguiente;
            Cantidad--;
            return dato;
        }

        public T Peek()
        {
            if (cima == null)
                throw new InvalidOperationException("La pila está vacía.");
            return cima.Dato;
        }
    }
}
