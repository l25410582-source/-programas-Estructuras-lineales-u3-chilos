namespace Proyecto10_Tienda
{
    // Nodo genérico: sirve para la lista, las colas y la pila
    public class Nodo<T>
    {
        public T Dato { get; set; }
        public Nodo<T> Siguiente { get; set; }

        public Nodo(T dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
