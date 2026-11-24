using System;

namespace Proyecto10_Tienda
{
    // Pila con el historial de operaciones (la más reciente se muestra primero)
    public class PilaHistorial
    {
        private Nodo<string> tope;
        public int Cantidad { get; private set; }

        public PilaHistorial()
        {
            tope = null;
            Cantidad = 0;
        }

        public bool EstaVacia()
        {
            return tope == null;
        }

        public void Push(string operacion)
        {
            Nodo<string> nuevo = new Nodo<string>($"[{DateTime.Now:HH:mm:ss}] {operacion}");
            nuevo.Siguiente = tope;
            tope = nuevo;
            Cantidad++;
        }

        public string Pop()
        {
            if (tope == null) return null;

            string dato = tope.Dato;
            tope = tope.Siguiente;
            Cantidad--;
            return dato;
        }

        public void Mostrar()
        {
            if (tope == null)
            {
                Console.WriteLine("No hay operaciones en el historial.");
                return;
            }
            Nodo<string> actual = tope;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }
    }
}
