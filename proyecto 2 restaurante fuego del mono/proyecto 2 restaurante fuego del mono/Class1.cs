using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_2_restaurante_fuego_del_mono
{
    internal class Nodo 
    {
        public Cliente Datos;
        public Nodo Siguiente;

        public Nodo(Cliente cliente)
        {
            Datos = cliente;
            Siguiente = null;

        }
    }
}
