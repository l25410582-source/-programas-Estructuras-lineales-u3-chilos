namespace Proyecto8_Banco
{
    public class Cliente
    {
        public int Turno { get; set; }
        public string Nombre { get; set; }
        public int Prioridad { get; set; }

        public Cliente(int turno, string nombre, int prioridad)
        {
            Turno = turno;
            Nombre = nombre;
            Prioridad = prioridad;
        }

        public override string ToString()
        {
            return $"Turno {Turno} | {Nombre} | Prioridad {Prioridad}";
        }
    }
}
