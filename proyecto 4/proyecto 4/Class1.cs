using System;
using System.Collections.Generic;
using System.Text;

namespace proyecto_4
{
    internal class Program
    {
        static int Prioridad (char operador)
        {
            if (operador == '+' || operador == '-')
                return 1;
            if (operador == '*' || operador == '/')
                return 2;
            if (operador == '^')
                return 3;
            return 0;


        }
        static string infijaAPostfija(string expresion)
        {

        }
    }
}
//aun me falta coregir varios ereos que tengo ya los actualizare durante el fin de semana