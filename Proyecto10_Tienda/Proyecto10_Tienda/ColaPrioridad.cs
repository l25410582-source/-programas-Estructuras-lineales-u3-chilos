using System;

namespace Proyecto10_Tienda
{
    // Cola de prioridad de pedidos urgentes (prioridad 1 sale antes que 2; empate = llegada)
    public class ColaPrioridad
    {
        private Nodo<Pedido> frente;

        public ColaPrioridad()
        {
            frente = null;
        }

        public bool EstaVacia()
        {
            return frente == null;
        }

        public void Encolar(Pedido p)
        {
            Nodo<Pedido> nuevo = new Nodo<Pedido>(p);

            // Va al frente si la cola está vacía o tiene mayor prioridad (número menor)
            if (frente == null || p.Prioridad < frente.Dato.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
                return;
            }

            Nodo<Pedido> actual = frente;
            while (actual.Siguiente != null && actual.Siguiente.Dato.Prioridad <= p.Prioridad)
                actual = actual.Siguiente;

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }

        public Pedido Desencolar()
        {
            if (frente == null) return null;

            Pedido p = frente.Dato;
            frente = frente.Siguiente;
            return p;
        }

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
                Console.WriteLine("(sin pedidos urgentes)");
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
