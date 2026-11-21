namespace Proyecto1_Clinica
{
    // ===================== NODO =====================
    // Nodo de la lista enlazada: guarda un paciente y apunta al siguiente nodo.
    public class Nodo
    {
        public Paciente Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Paciente dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}
