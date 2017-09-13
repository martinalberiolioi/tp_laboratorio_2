using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Metodo encargado de devolver el valor del atributo privado "numero"
        /// </summary>
        /// <returns>Devuelve el valor del atributo</returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Constructor por defecto de la clase. Asigna el valor "0"
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor de clase que recibe un double como valor para el atributo "numero"
        /// </summary>
        /// <param name="Numero">Ingresar un numero</param>
        public Numero(double Numero)
        {
            this.numero = Numero;
        }

        /// <summary>
        /// Constructor de clase que recibe un string como valor para el atributo "numero"
        /// </summary>
        /// <param name="Numero">Ingresar un numero</param>
        public Numero(string Numero)
        {
            setNumero(Numero);
        }

        /// <summary>
        /// Metodo encargado de setear/modificar el valor del atributo privado de la clase
        /// </summary>
        /// <param name="Numero">Ingresar un numero</param>
        public void setNumero(string Numero)
        {
            this.numero = validarNumero(Numero); 
        }

        /// <summary>
        /// Metodo encargado de validar que el numero ingresado se trate de un double
        /// </summary>
        /// <param name="numeroString">Ingresar un numero</param>
        /// <returns>Devuelve el valor convertido a double. Caso contrario, si falla, devuelve 0</returns>
        public static double validarNumero(string numeroString)
        {
            double numeroValidado = 0;

            if(double.TryParse(numeroString, out numeroValidado))
            {
                
            }
            else
            {
                numeroValidado = 0;
            }
            
            return numeroValidado;
        }

    }

    public class Calculadora
    {
        /// <summary>
        /// Metodo encargado de realizar operaciones matematicas entre dos numeros
        /// </summary>
        /// <param name="numero1">Ingresa el primer operando</param>
        /// <param name="numero2">Ingresa el segundo operando</param>
        /// <param name="operador">Ingresa el operador (+ - * /)</param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            switch (operador)
            {
                case "+":
                    resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero2.getNumero() != 0)
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                    //si el numero2 es 0, el valor de retorno va a ser 0 porque la variable se inicializo con CERO                  
                    break;
            }

            return resultado; 
        }

        /// <summary>
        /// Metodo encargado de validar que el operador sea + - * o /
        /// </summary>
        /// <param name="operador">Ingresa el operador</param>
        /// <returns>En caso que el operador ingresado sea valido, lo devuevle igual. En caso que no sea valido, devuelve el operador "+" por defecto</returns>
        public static string validarOperador(string operador)
        {
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }

            return operador;
        }

     }
}
