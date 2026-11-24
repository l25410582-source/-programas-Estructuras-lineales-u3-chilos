using System;

namespace Proyecto10_Tienda
{
    // Cola FIFO de pedidos pendientes (normales)
    public class ColaPedidos
    {
        private Nodo<Pedido> frente;
        private Nodo<Pedido> final;

        public ColaPedidos()
        {
            frente = null;
            final = null;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(Pedido p)
        {
            Nodo<Pedido> nuevo = new Nodo<Pedido>(p);
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

        public Pedido Desencolar()
        {
            if (frente == null) return null;

            Pedido p = frente.Dato;
            frente = frente.Siguiente;
            if (frente == null) final = null;
            return p;
        }

        // Saca un pedido específico (para cancelarlo)
        public Pedido Quitar(int numero)
        {
            Nodo<Pedido> anterior = null;
            Nodo<Pedido> actual = frente;

            while (actual != null)
            {
                if (actual.Dato.Numero == numero)
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
                Console.WriteLine("(sin pedidos pendientes)");
                return;
            }
            Nodo<Pedido> actual = frente;
            while (actual != null)
            {
                actual.Dato.Mostrar();
                actual = actual.Siguiente;
            }
        }
    }
}
