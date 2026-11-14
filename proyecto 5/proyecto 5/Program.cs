using System;
using System.Collections.Generic;

namespace Proyecto5_Navegador
  public class Nodo
{
    public string Pagina;
    public Nodo Siguiente;
    public Nodo (string pagina)
    {
        Pagina = pagina;
    }
    
}
public void Push(string pagina)
    {
        Nodo nuevo = new.Nodo (pagina);
        nuevo.Siguiente = tope;
        tope = nuevo;+
    }
    public string pop()
    {
        if (tope == null)
            return null;
        string pagina = tope.Pagina;
        tope= tope.Siguiente;
        return pagina;
    }