using System;

namespace Proyecto9_Procesos
{
    // Tabla general de procesos (todos los procesos del sistema)
    public class ListaEnlazada
    {
        private Nodo cabeza;
        public int Cantidad { get; private set; }

        public ListaEnlazada()
        {
            cabeza = null;
            Cantidad = 0;
        }

        // Inserta al final
        public void Insertar(Proceso p)
        {
            Nodo nuevo = new Nodo(p);
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                    actual = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
            Cantidad++;
        }

        public Proceso Buscar(int pid)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.Dato.PID == pid)
                    return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public bool Eliminar(int pid)
        {
            if (cabeza == null) return false;

            if (cabeza.Dato.PID == pid)
            {
                cabeza = cabeza.Siguiente;
                Cantidad--;
                return true;
            }

            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato.PID == pid)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    Cantidad--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        public bool EstaVacia()
        {
            return cabeza == null;
        }

        public void Mostrar()
        {
            if (cabeza == null)
            {
                Console.WriteLine("No hay procesos registrados.");
                return;
            }
            Nodo actual = cabeza;
            while (actual != null)
            {
                actual.Dato.Mostrar();
                actual = actual.Siguiente;
            }
        }
    }
}
