namespace Proyecto10_Tienda
{
    // Un producto dentro de un pedido, con su cantidad
    public class ItemPedido
    {
        public Producto Producto { get; private set; }
        public int Cantidad { get; set; }
        public decimal Subtotal
        {
            get { return Producto.Precio * Cantidad; }
        }

        public ItemPedido(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
    }
}
