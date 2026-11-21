using System.Collections;
using System.Collections.Generic;

namespace Proyecto1_Clinica
{
    // ===================== COLA DE PRIORIDAD =====================
    // Una cola FIFO por nivel (1 = Emergencia ... 4 = Cita Programada).
    // Siempre se atiende el nivel más urgente que tenga pacientes;
    // dentro del mismo nivel, por orden de llegada.
    public class ColaPrioridad : IEnumerable<Paciente>
    {
        public const int NivelMinimo = 1;
        public const int NivelMaximo = 4;

        private readonly Cola[] colas = new Cola[NivelMaximo];

        public ColaPrioridad()
        {
            for (int i = 0; i < colas.Length; i++)
                colas[i] = new Cola();
        }

        public int Cantidad
        {
            get
            {
                int total = 0;
                foreach (Cola c in colas) total += c.Cantidad;
                return total;
            }
        }

        public int CantidadPorNivel(int nivel) => colas[nivel - 1].Cantidad;

        public void Encolar(Paciente paciente) => colas[paciente.Prioridad - 1].Encolar(paciente);

        public Paciente Desencolar()
        {
            foreach (Cola c in colas)
                if (!c.EstaVacia) return c.Desencolar();
            return null;
        }

        public Paciente Eliminar(int expediente)
        {
            foreach (Cola c in colas)
            {
                Paciente p = c.Eliminar(expediente);
                if (p != null) return p;
            }
            return null;
        }

        public Paciente Buscar(int expediente)
        {
            foreach (Cola c in colas)
            {
                Paciente p = c.Buscar(expediente);
                if (p != null) return p;
            }
            return null;
        }

        public IEnumerator<Paciente> GetEnumerator()
        {
            foreach (Cola c in colas)
                foreach (Paciente p in c)
                    yield return p;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
