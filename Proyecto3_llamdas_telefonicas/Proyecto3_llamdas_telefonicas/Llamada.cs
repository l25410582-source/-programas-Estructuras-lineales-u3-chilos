using System;

namespace SimuladorLlamadas
{
    public class Llamada
    {
        public int Id { get; }
        public string Numero { get; }
        public string Contacto { get; }
        public DateTime HoraRegistro { get; }
        public EstadoLlamada Estado { get; set; }

        public Llamada(int id, string numero, string contacto)
        {
            Id = id;
            Numero = numero;
            Contacto = contacto;
            HoraRegistro = DateTime.Now;
            Estado = EstadoLlamada.Registrada;
        }

        public override string ToString()
        {
            return $"#{Id} | {Contacto} ({Numero}) | {Estado} | {HoraRegistro:HH:mm:ss}";
        }
    }
}
