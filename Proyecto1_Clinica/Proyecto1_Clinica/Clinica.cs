using System.Collections.Generic;

namespace Proyecto1_Clinica
{
    // ===================== LÓGICA DE LA CLÍNICA =====================
    public class Clinica
    {
        private readonly ColaPrioridad espera = new ColaPrioridad();
        private readonly ListaEnlazada historial = new ListaEnlazada();

        public int CantidadEnEspera => espera.Cantidad;

        public static string NombrePrioridad(int prioridad)
        {
            switch (prioridad)
            {
                case 1: return "Emergencia";
                case 2: return "Urgencia";
                case 3: return "Consulta General";
                case 4: return "Cita Programada";
                default: return "Desconocida";
            }
        }

        public bool Registrar(int expediente, string nombre, int edad, int prioridad)
        {
            if (prioridad < ColaPrioridad.NivelMinimo || prioridad > ColaPrioridad.NivelMaximo) return false;
            if (espera.Buscar(expediente) != null || historial.Buscar(expediente) != null) return false;

            espera.Encolar(new Paciente(expediente, nombre, edad, prioridad));
            return true;
        }

        public bool Eliminar(int expediente) => espera.Eliminar(expediente) != null;

        public Paciente BuscarEnEspera(int expediente) => espera.Buscar(expediente);
        public Paciente BuscarEnHistorial(int expediente) => historial.Buscar(expediente);

        public Paciente AtenderSiguiente()
        {
            Paciente p = espera.Desencolar();
            if (p != null) historial.AgregarAlFinal(p);
            return p;
        }

        // Se saca de su cola actual y entra al final de la cola del nuevo nivel.
        public bool AsignarPrioridad(int expediente, int nuevaPrioridad)
        {
            if (nuevaPrioridad < ColaPrioridad.NivelMinimo || nuevaPrioridad > ColaPrioridad.NivelMaximo) return false;

            Paciente p = espera.Eliminar(expediente);
            if (p == null) return false;

            p.Prioridad = nuevaPrioridad;
            espera.Encolar(p);
            return true;
        }

        public int CantidadPorNivel(int nivel) => espera.CantidadPorNivel(nivel);

        public IEnumerable<Paciente> PacientesEnEspera() => espera;
        public IEnumerable<Paciente> PacientesAtendidos() => historial;
    }
}
