namespace Proyecto6_Tareas
{
    internal class Tarea
    {
        public int id { get; private set; }
        public string Descripcion { get; private set; }
        public bool Completada { get; set; }

        public Tarea(int id, string descripcion)
        {
            this.id = id;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            string estado = Completada ? "Completada" : "Pendiente";
            return $"ID: {id} - {Descripcion} ({estado})";
        }
    }
}
