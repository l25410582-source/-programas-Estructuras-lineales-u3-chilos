using System;

namespace Proyecto8_Banco
{
    public class ColaPrioridad
    {
        private Nodo frente;

        public void Insertar(Cliente cliente)
        {
            Nodo nuevo = new Nodo(cliente);

            // Cola vacía o el cliente tiene mayor prioridad (número menor) que el primero
            if (frente == null ||
                cliente.Prioridad < frente.Datos.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
                return;
            }

            Nodo actual = frente;

            // Avanza hasta encontrar la posición (los de igual prioridad quedan después, FIFO)
            while (actual.Siguiente != null &&
                   actual.Siguiente.Datos.Prioridad
                   <= cliente.Prioridad)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }

        public Cliente Atender()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;

            return cliente;
        }

        public void Mostrar()
        {
            Nodo actual = frente;

            while (actual != null)
            {
                Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
            }
        }

        public bool EstaVacia()
        {
            return frente == null;
        }
    }
}
