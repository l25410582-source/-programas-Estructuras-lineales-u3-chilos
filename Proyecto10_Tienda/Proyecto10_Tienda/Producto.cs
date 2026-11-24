using System;

namespace Proyecto10_Tienda
{
    public class Producto
    {
        public int ID { get; private set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencias { get; set; }
        public string Categoria { get; set; }
        public int Vendidos { get; set; }   // para las estadísticas

        public Producto(int id, string nombre, decimal precio, int existencias, string categoria)
        {
            ID = id;
            Nombre = nombre;
            Precio = precio;
            Existencias = existencias;
            Categoria = categoria;
            Vendidos = 0;
        }

        public void Mostrar()
        {
            Console.WriteLine($"ID: {ID,-4} | {Nombre,-18} | ${Precio,9:F2} | Existencias: {Existencias,-4} | {Categoria}");
        }
    }
}
