using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Hace una operacion aritmetica entre dos numeros
        /// </summary>
        /// <param name="num1">primer numero</param>
        /// <param name="num2">segundo numero</param>
        /// <param name="operador">operacion a realizar</param>
        /// <returns>devuelve el resultado de la operacion</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            switch(ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador ingresado sea +,-,* o /
        /// </summary>
        /// <param name="operador">operador a validar</param>
        /// <returns>si el operador es +,-,* o / devuelve el mismo. Caso contrario, devuelve +</returns>
        private static string ValidarOperador(string operador)
        {
            bool flag = false;

            if(operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                flag = true;
            }

            if(!flag)
            {
                operador = "+";
            }

            return operador;
        }
    }
}
