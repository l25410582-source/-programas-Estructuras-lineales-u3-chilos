using System;

namespace Proyecto10_Tienda
{
    // Lista enlazada de productos (inventario)
    public class ListaProductos
    {
        public Nodo<Producto> Cabeza { get; private set; }
        public int Cantidad { get; private set; }

        public ListaProductos()
        {
            Cabeza = null;
            Cantidad = 0;
        }

        public void Insertar(Producto p)
        {
            Nodo<Producto> nuevo = new Nodo<Producto>(p);
            if (Cabeza == null)
            {
                Cabeza = nuevo;
            }
            else
            {
                Nodo<Producto> actual = Cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
            Cantidad++;
        }

        public Producto Buscar(int id)
        {
            Nodo<Producto> actual = Cabeza;
            while (actual != null)
            {
                if (actual.Dato.ID == id)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(int id)
        {
            if (Cabeza == null) return false;

            if (Cabeza.Dato.ID == id)
            {
                Cabeza = Cabeza.Siguiente;
                Cantidad--;
                return true;
            }

            Nodo<Producto> actual = Cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.ID == id)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    Cantidad--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public void Mostrar()
        {
            if (Cabeza == null)
            {
                Console.WriteLine("El inventario está vacío.");
                return;
            }
            Nodo<Producto> actual = Cabeza;
            while (actual != null)
            {
                actual.Dato.Mostrar();
                actual = actual.Siguiente;
            }
        }
    }
}
