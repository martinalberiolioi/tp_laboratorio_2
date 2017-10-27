using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }

            set
            {
                this._apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }

            set
            {
                this._dni = ValidarDNI(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }

            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }

            set
            {
                if(ValidarNombreApellido(value) != null)
                {
                    this._nombre = value;
                }
               
            }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDNI(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Constructor por defecto de Persona
        /// </summary>
        public Persona()
        {
            this.Nombre = "";
            this.Apellido = "";
            this.Nacionalidad = ENacionalidad.Argentino;
            this._dni = 0;
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona (Argentino,Extranjero)</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona (Argentino,Extranjero)</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor parametrizado de Persona
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="dni">dni (como string) de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona (Argentino,Extranjero)</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Funcion que crea un String con los datos de la persona (nombre, apellido, DNI, nacionalidad)
        /// </summary>
        /// <returns>Devuelve el string con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nombre: " + this.Nombre + "\nApellido: " + this.Apellido + "\nDNI: " + this.DNI + "\nNacionalidad: " + this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Funcion encargada de validar la relacion entre un DNI y la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona (Argentina,Extranjero)</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>devuelve el mismo DNI, ya validado</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato <= 89999999)
                {
                    return dato;
                }
                else if(dato < 1)
                {
                    throw new DniInvalidoException();
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            
            }
            else if(dato < 0)
            {
                throw new DniInvalidoException();
            }
            else if(dato < 89999999)
            {
                throw new NacionalidadInvalidaException();
            }
            else
            {
                return dato;
            }
                    
        }

        /// <summary>
        /// Funcion encargada de validar la relacion entre un DNI (version string) y la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona (Argentina,Extranjero)</param>
        /// <param name="dato">DNI de la persona</param>
        /// <returns>devuelve el mismo DNI, ya validado</returns>
        private int ValidarDNI(ENacionalidad nacionalidad, string dato)
        {
            int datoINT = int.Parse(dato);

            return this.ValidarDNI(nacionalidad, datoINT);
        }

        /// <summary>
        /// Valida que el nombre y apellido no contengan numeros
        /// </summary>
        /// <param name="dato">nombre y apellido de la persona</param>
        /// <returns>devuelve el nombre y apellido ya validado</returns>
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato[i]))
                {

                    return null;

                }

            }

            return dato;
        }

    }
}
