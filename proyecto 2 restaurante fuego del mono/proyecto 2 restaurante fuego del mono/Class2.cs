using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace proyecto_2_restaurante_fuego_del_mono
{
    public class Cola
    {
        private Nodo frente;
        private Nodo final;

        public void Encolar (Cliente cliente) {
            Nodo nuevo = new Nodo(cliente);
            if (frente == null) {
                frente = nuevo;
                final = nuevo;

    }
            else
            {
                final.Siguiente = nuevo;
                final= nuevo;
            }
           public Cliente Desencolar()
        {
            if (frente == null)
                return null;

            Cliente cliente = frente.Datos;
            frente = frente.Siguiente;
            if (frente == null)
                final = null;
            return cliente;

        }
        public void Mostrar()
        {
            Nodo actual = frente;
            while (actual != null) {
                System.Console.WriteLine(actual.Datos);
                actual = actual.Siguiente;
        }
       }
    }
}
