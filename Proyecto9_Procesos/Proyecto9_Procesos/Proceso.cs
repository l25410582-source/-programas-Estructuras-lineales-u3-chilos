using System;

namespace Proyecto9_Procesos
{
    public class Proceso
    {
        public int PID { get; private set; }
        public string Nombre { get; private set; }
        public int Prioridad { get; private set; }
        public EstadoProceso Estado { get; set; }
        public int TiempoEjecucion { get; private set; }   // tiempo total requerido
        public int TiempoRestante { get; set; }            // lo que le falta por ejecutar

        public Proceso(int pid, string nombre, int prioridad, int tiempoEjecucion)
        {
            PID = pid;
            Nombre = nombre;
            Prioridad = prioridad;
            TiempoEjecucion = tiempoEjecucion;
            TiempoRestante = tiempoEjecucion;
            Estado = EstadoProceso.NUEVO;
        }

        public void Mostrar()
        {
            Console.WriteLine($"PID: {PID,-3} | {Nombre,-12} | Prioridad: {Prioridad} | " +
                              $"Estado: {Estado,-10} | Tiempo: {TiempoEjecucion} | Restante: {TiempoRestante}");
        }
    }
}
