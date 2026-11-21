using System.Collections;
using System.Collections.Generic;

namespace Proyecto1_Clinica
{
    // ===================== LISTA ENLAZADA =====================
    public class ListaEnlazada : IEnumerable<Paciente>
    {
        private Nodo cabeza;
        private Nodo cola;
        public int Cantidad { get; private set; }

        public void AgregarAlFinal(Paciente paciente)
        {
            Nodo nuevo = new Nodo(paciente);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                cola = nuevo;
            }
            Cantidad++;
        }

        public Paciente RemoverPrimero()
        {
            if (cabeza == null) return null;

            Paciente paciente = cabeza.Dato;
            cabeza = cabeza.Siguiente;
            if (cabeza == null) cola = null;
            Cantidad--;
            return paciente;
        }

        public Paciente Eliminar(int expediente)
        {
            Nodo previo = null;
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (actual.Dato.Expediente == expediente)
                {
                    if (previo == null) cabeza = actual.Siguiente;
                    else previo.Siguiente = actual.Siguiente;

                    if (actual == cola) cola = previo;

                    Cantidad--;
                    return actual.Dato;
                }
                previo = actual;
                actual = actual.Siguiente;
            }
            return null;
        }

        public Paciente Buscar(int expediente)
        {
            for (Nodo n = cabeza; n != null; n = n.Siguiente)
                if (n.Dato.Expediente == expediente)
                    return n.Dato;
            return null;
        }

        public IEnumerator<Paciente> GetEnumerator()
        {
            for (Nodo n = cabeza; n != null; n = n.Siguiente)
                yield return n.Dato;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
