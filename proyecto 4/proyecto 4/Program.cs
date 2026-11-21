using System;
using System.Collections.Generic;
using System.Globalization;

namespace CalculadoraExpresiones
{
    // ===== Programa principal =====
    class Program
    {
        static void Main()
        {
            var calc = new Calculadora();

            Console.WriteLine("=== CALCULADORA DE EXPRESIONES MATEMÁTICAS (Pilas) ===");
            Console.WriteLine("Operadores: + - * / % ^    Paréntesis: ( )");
            Console.WriteLine("Ejemplo: (5+3)*2   |   Escribe 'salir' para terminar.");
            Console.WriteLine("(En la postfija, '~' representa el negativo unario)\n");

            while (true)
            {
                Console.Write("Expresión infija: ");
                string entrada = Console.ReadLine();

                if (entrada == null || entrada.Trim().ToLower() == "salir")
                    break;

                try
                {
                    List<string> tokens;
                    string error;

                    if (!calc.Validar(entrada, out tokens, out error))
                    {
                        Console.WriteLine("  Error: " + error + "\n");
                        continue;
                    }

                    List<string> postfija = calc.ConvertirAPostfija(tokens);
                    Console.WriteLine("  Postfija: " + string.Join(" ", postfija));

                    double resultado = calc.EvaluarPostfija(postfija);
                    Console.WriteLine("  Resultado = " +
                        resultado.ToString("G15", CultureInfo.InvariantCulture) + "\n");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("  Error matemático: " + ex.Message + "\n");
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine("  Error matemático: " + ex.Message + "\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("  Error: " + ex.Message + "\n");
                }
            }

            Console.WriteLine("¡Hasta luego!");
        }
    }
}
