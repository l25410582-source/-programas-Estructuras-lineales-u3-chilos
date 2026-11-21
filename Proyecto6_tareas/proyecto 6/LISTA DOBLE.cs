using proyecto6_tareas;
using System;

namespace proyecto_6
{
    public class listaDoble
    {
        private Nodo inicio;
        private class Nodo
        {
            public Tarea Datos;
            public Nodo Anterior;
            public Nodo Siguiente;
            {
                Datos= tarea;
            }
        }
        public void insertar (Tarea tarea)
        {
            Nodo muevo = new Nodo(tarea);
            if (inicio== null)
            {
                inicio = nuevo;
                return;
        }
            Nodo actual = inicio;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            actual.Siguiente = nuevo;
            nuevo.Anterior= actual;

}
