namespace Proyecto9_Procesos
{
    public class Nodo
    {
        public Proceso Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Proceso dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
