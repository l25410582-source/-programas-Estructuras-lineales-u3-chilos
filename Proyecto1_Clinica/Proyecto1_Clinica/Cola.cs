using System.Collections;
using System.Collections.Generic;

namespace Proyecto1_Clinica
{
    // ===================== COLA (FIFO) =====================
    // Cola FIFO construida sobre la lista enlazada.
    public class Cola : IEnumerable<Paciente>
    {
        private readonly ListaEnlazada lista = new ListaEnlazada();

        public int Cantidad => lista.Cantidad;
        public bool EstaVacia => lista.Cantidad == 0;

        public void Encolar(Paciente paciente) => lista.AgregarAlFinal(paciente);
        public Paciente Desencolar() => lista.RemoverPrimero();
        public Paciente Eliminar(int expediente) => lista.Eliminar(expediente);
        public Paciente Buscar(int expediente) => lista.Buscar(expediente);

        public IEnumerator<Paciente> GetEnumerator() => lista.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
