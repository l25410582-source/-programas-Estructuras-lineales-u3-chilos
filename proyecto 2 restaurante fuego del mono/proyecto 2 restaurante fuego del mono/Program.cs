using System;
namespace proyecto_2_restaurante_fuego_del_mono
{
    public  class Cliente
    {
        public string Nombre { get; set; }
        public int Personas { get; set; }

        public Cliente(string nombre, int personas)
        {
            Nombre = nombre;
            Personas = personas;
        }
        public override string ToString()
        {
            return $"{Nombre}-{Personas}personas";
        }
    }
}