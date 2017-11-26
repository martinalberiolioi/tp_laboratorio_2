using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Propiedad que setea el valor del atributo privado numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructor sin parametros. Por defecto, el valor de numero es 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que recibe un string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="binario">string del numero binario a convertir</param>
        /// <returns>Si pudo, devuelve el numero convertiro a binario. Caso contrario, devuelve "Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            try
            {
                if (binario != null)
                {
                    return Convert.ToInt32(binario, 2).ToString();
                }
            }
            catch (Exception)
            {
                return "Valor invalido";
            }

            return "Valor invalido";
        }

        /// <summary>
        /// Convierte un numero decimal en formato double a binario
        /// </summary>
        /// <param name="numero">double del numero decimal a convertir</param>
        /// <returns>Si pudo, devuelve el numero ya convertido a binario. Caso contrario, devuelve "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            int aux = Convert.ToInt32(numero);
            string retorno = "";

            if (aux > 0)
            {
                while (aux > 0)
                {
                    if (aux % 2 == 0)
                    {
                        retorno = "0" + retorno;
                    }
                    else
                    {
                        retorno = "1" + retorno;
                    }

                    aux /= 2;
                }
            }
            else if (aux == 0)
            {
                retorno = "0";
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }

        /// <summary>
        /// Convierte un numero decimal en formato string a binario
        /// </summary>
        /// <param name="numero">string del numero a convertir</param>
        /// <returns>Si puede, devuelve una llamada al metodo que recibe Double para convertir a binario. Caso contrario, devuelve "Valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            double numeroDouble = 0;

            if(double.TryParse(numero, out numeroDouble))
            {
                return this.DecimalBinario(numeroDouble);
            }

            return "Valor invalido";
        }

        /// <summary>
        /// Valida que el numero en formato string ingresado no sea letras o caracteres especiales
        /// </summary>
        /// <param name="strNumero">numero a validar</param>
        /// <returns>Si el numero ingresado es un numero, lo devuelve en formato Double. Caso contrario, devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double resultado;

            if(double.TryParse(strNumero, out resultado))
            {
                return resultado;
            }

            return 0;                
        }

        /// <summary>
        /// Sobrecarga del operador - para que reste dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">primer numero a operar</param>
        /// <param name="n2">segundo numero a operar</param>
        /// <returns>devuelve el resultado de la resta en formato Double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador * para que multiplique dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">primer numero a operar</param>
        /// <param name="n2">segundo numero a operar</param>
        /// <returns>devuelve el resultado de la multiplicacion en formato Double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador / para que divida dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">primer numero a operar</param>
        /// <param name="n2">segundo numero a operar</param>
        /// <returns>devuelve el resultado de la division en formato Double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador + para que sume dos objetos de la clase Numero
        /// </summary>
        /// <param name="n1">primer numero a operar</param>
        /// <param name="n2">segundo numero a operar</param>
        /// <returns>devuelve el resultado de la suma en formato Double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }        

    }
}
