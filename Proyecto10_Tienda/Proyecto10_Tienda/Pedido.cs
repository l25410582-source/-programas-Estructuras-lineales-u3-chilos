using System;
using System.Collections.Generic;

namespace Proyecto10_Tienda
{
    public class Pedido
    {
        public int Numero { get; private set; }
        public string Cliente { get; private set; }
        public DateTime Fecha { get; private set; }
        public List<ItemPedido> Productos { get; private set; }
        public int Prioridad { get; private set; }      // 1 = Urgente, 2 = Alta, 3 = Normal
        public EstadoPedido Estado { get; set; }

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (ItemPedido item in Productos)
                    total += item.Subtotal;
                return total;
            }
        }

        public bool EsUrgente
        {
            get { return Prioridad <= 2; }
        }

        public Pedido(int numero, string cliente, int prioridad)
        {
            Numero = numero;
            Cliente = cliente;
            Prioridad = prioridad;
            Fecha = DateTime.Now;
            Productos = new List<ItemPedido>();
            Estado = EstadoPedido.PENDIENTE;
        }

        public int CantidadEnPedido(int idProducto)
        {
            foreach (ItemPedido item in Productos)
                if (item.Producto.ID == idProducto)
                    return item.Cantidad;
            return 0;
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            foreach (ItemPedido item in Productos)
            {
                if (item.Producto.ID == producto.ID)
                {
                    item.Cantidad += cantidad;
                    return;
                }
            }
            Productos.Add(new ItemPedido(producto, cantidad));
        }

        public string NombrePrioridad()
        {
            switch (Prioridad)
            {
                case 1: return "Urgente";
                case 2: return "Alta";
                default: return "Normal";
            }
        }

        public void Mostrar()
        {
            Console.WriteLine($"Pedido #{Numero} | Cliente: {Cliente} | {Fecha:dd/MM/yyyy HH:mm} | " +
                              $"Prioridad: {NombrePrioridad()} | Estado: {Estado} | Total: ${Total:F2}");
            foreach (ItemPedido item in Productos)
                Console.WriteLine($"     - {item.Producto.Nombre} x{item.Cantidad} = ${item.Subtotal:F2}");
        }
    }
}
