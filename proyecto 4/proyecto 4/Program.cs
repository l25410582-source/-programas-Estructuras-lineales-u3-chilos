using Proyecto4_calculadora;
using System;
using System.Security.Cryptography.X509Certificates;
namespace Proyecto4_calculadora;
public class pila;
{
    public class tope;
{
    private Nodo tope;

private class Nodo;
{
    public char Dato;
    public class Siguiente;
    public Nodo (char dato)
    { Dato = dato}
}
}
public bool Vacia ()
{
    return tope==null;
}
public  void Apilar (char dato)
{

    Nodo nuevo = new Nodo(dato);
    nuevo.Siguiente = tope;
    tope= nuevo;

}
public char Desapilar()
{ if (Vacia())
        return '\0';

            
}
{ public char tope;
{ }
}