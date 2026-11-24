namespace Proyecto8_Banco
{
    public class Nodo
    {
        public Cliente Datos;
        public Nodo Siguiente;

        public Nodo(Cliente cliente)
        {
            Datos = cliente;
            Siguiente = null;
        }
    }
}
