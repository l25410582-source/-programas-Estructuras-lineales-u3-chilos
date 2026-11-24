using System;
using System.Collections.Generic;

namespace Proyecto10_Tienda
{
    public class Tienda
    {
        private ListaProductos productos = new ListaProductos();
        private ColaPedidos pendientes = new ColaPedidos();
        private ColaPrioridad urgentes = new ColaPrioridad();
        private PilaHistorial historial = new PilaHistorial();
        private List<Pedido> registro = new List<Pedido>();   // todos los pedidos (para buscar clientes y estadísticas)

        private int siguienteNumero = 1;
        private int procesados = 0;
        private int cancelados = 0;
        private decimal ingresos = 0;

        // ---------- PRODUCTOS ----------

        // 1. Registrar producto
        public void RegistrarProducto(int id, string nombre, decimal precio, int existencias, string categoria)
        {
            if (productos.Buscar(id) != null)
            {
                Console.WriteLine("Ya existe un producto con ese ID.");
                return;
            }
            productos.Insertar(new Producto(id, nombre, precio, existencias, categoria));
            historial.Push($"Registró producto {id} - {nombre}");
            Console.WriteLine("Producto registrado.");
        }

        // 2. Buscar producto
        public void BuscarProducto(int id)
        {
            Producto p = productos.Buscar(id);
            if (p == null) Console.WriteLine("Producto no encontrado.");
            else p.Mostrar();
        }

        // 3. Eliminar producto
        public void EliminarProducto(int id)
        {
            Producto p = productos.Buscar(id);
            if (p == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }
            productos.Eliminar(id);
            historial.Push($"Eliminó producto {id} - {p.Nombre}");
            Console.WriteLine("Producto eliminado.");
        }

        // 10. Consultar inventario
        public void ConsultarInventario()
        {
            Console.WriteLine("=== INVENTARIO ===");
            productos.Mostrar();
        }

        // ---------- PEDIDOS ----------

        // 4. Registrar pedido (en 3 pasos para poder pedir datos desde el menú)
        public Pedido CrearPedido(string cliente, int prioridad)
        {
            if (prioridad < 1 || prioridad > 3) prioridad = 3;
            return new Pedido(siguienteNumero, cliente, prioridad);
        }

        public bool AgregarAlPedido(Pedido pedido, int idProducto, int cantidad)
        {
            Producto prod = productos.Buscar(idProducto);
            if (prod == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return false;
            }
            if (cantidad <= 0)
            {
                Console.WriteLine("La cantidad debe ser mayor a 0.");
                return false;
            }
            if (pedido.CantidadEnPedido(idProducto) + cantidad > prod.Existencias)
            {
                Console.WriteLine($"Existencias insuficientes (disponibles: {prod.Existencias}).");
                return false;
            }
            pedido.AgregarProducto(prod, cantidad);
            return true;
        }

        public void ConfirmarPedido(Pedido pedido)
        {
            if (pedido.Productos.Count == 0)
            {
                Console.WriteLine("El pedido no tiene productos. No se registró.");
                return;
            }

            // Descontar existencias
            foreach (ItemPedido item in pedido.Productos)
                item.Producto.Existencias -= item.Cantidad;

            if (pedido.EsUrgente) urgentes.Encolar(pedido);
            else pendientes.Encolar(pedido);

            registro.Add(pedido);
            siguienteNumero++;
            historial.Push($"Registró pedido #{pedido.Numero} de {pedido.Cliente}");
            Console.WriteLine($"Pedido #{pedido.Numero} registrado. Total: ${pedido.Total:F2}");
        }

        // 5. Cancelar pedido
        public void CancelarPedido(int numero)
        {
            Pedido p = urgentes.Quitar(numero);
            if (p == null) p = pendientes.Quitar(numero);

            if (p == null)
            {
                Console.WriteLine("No existe un pedido pendiente con ese número.");
                return;
            }

            // Regresar existencias
            foreach (ItemPedido item in p.Productos)
                item.Producto.Existencias += item.Cantidad;

            p.Estado = EstadoPedido.CANCELADO;
            cancelados++;
            historial.Push($"Canceló pedido #{numero}");
            Console.WriteLine($"Pedido #{numero} cancelado.");
        }

        // 6. Procesar pedido (cola normal, FIFO)
        public void ProcesarPedido()
        {
            Pedido p = pendientes.Desencolar();
            if (p == null)
            {
                Console.WriteLine("No hay pedidos pendientes normales.");
                return;
            }
            Completar(p);
        }

        // 7. Atender pedido urgente (cola de prioridad)
        public void AtenderPedidoUrgente()
        {
            Pedido p = urgentes.Desencolar();
            if (p == null)
            {
                Console.WriteLine("No hay pedidos urgentes.");
                return;
            }
            Completar(p);
        }

        private void Completar(Pedido p)
        {
            p.Estado = EstadoPedido.PROCESADO;
            procesados++;
            ingresos += p.Total;
            foreach (ItemPedido item in p.Productos)
                item.Producto.Vendidos += item.Cantidad;

            historial.Push($"Procesó pedido #{p.Numero} ({p.NombrePrioridad()})");
            Console.WriteLine("Pedido procesado:");
            p.Mostrar();
        }

        // 8. Mostrar pedidos pendientes
        public void MostrarPedidosPendientes()
        {
            Console.WriteLine("=== PEDIDOS URGENTES (cola de prioridad) ===");
            urgentes.Mostrar();
            Console.WriteLine("\n=== PEDIDOS NORMALES (cola) ===");
            pendientes.Mostrar();
        }

        // 9. Mostrar historial
        public void MostrarHistorial()
        {
            Console.WriteLine("=== HISTORIAL DE OPERACIONES (más reciente primero) ===");
            historial.Mostrar();
        }

        // 11. Buscar cliente
        public void BuscarCliente(string cliente)
        {
            bool encontrado = false;
            foreach (Pedido p in registro)
            {
                if (p.Cliente.Equals(cliente, StringComparison.OrdinalIgnoreCase))
                {
                    p.Mostrar();
                    encontrado = true;
                }
            }
            if (!encontrado)
                Console.WriteLine("No hay pedidos de ese cliente.");
        }

        // 12. Mostrar estadísticas
        public void MostrarEstadisticas()
        {
            int pendientesTotal = 0;
            foreach (Pedido p in registro)
                if (p.Estado == EstadoPedido.PENDIENTE) pendientesTotal++;

            Producto masVendido = null;
            Nodo<Producto> actual = productos.Cabeza;
            while (actual != null)
            {
                if (actual.Dato.Vendidos > 0 &&
                    (masVendido == null || actual.Dato.Vendidos > masVendido.Vendidos))
                    masVendido = actual.Dato;
                actual = actual.Siguiente;
            }

            Console.WriteLine("=== ESTADÍSTICAS ===");
            Console.WriteLine($"Productos en inventario: {productos.Cantidad}");
            Console.WriteLine($"Pedidos registrados:     {registro.Count}");
            Console.WriteLine($"Pedidos pendientes:      {pendientesTotal}");
            Console.WriteLine($"Pedidos procesados:      {procesados}");
            Console.WriteLine($"Pedidos cancelados:      {cancelados}");
            Console.WriteLine($"Ingresos totales:        ${ingresos:F2}");
            if (procesados > 0)
                Console.WriteLine($"Venta promedio:          ${ingresos / procesados:F2}");
            if (masVendido != null)
                Console.WriteLine($"Producto más vendido:    {masVendido.Nombre} ({masVendido.Vendidos} unidades)");
            Console.WriteLine($"Operaciones en historial: {historial.Cantidad}");
        }
    }
}
