using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        /// <summary>
        /// Constructor por defecto de Universitario
        /// </summary>
        public Universitario() : base()
        {
            this._legajo = 0;
        }

        public int Legajo
        {
            get
            {
                return this._legajo;
            }
        }

        /// <summary>
        /// Constructor parametrizado de Universitario
        /// </summary>
        /// <param name="legajo">legajo del universitario</param>
        /// <param name="nombre">nombre del universitario</param>
        /// <param name="apellido">apellido del universitario</param>
        /// <param name="dni">dni del universitario</param>
        /// <param name="nacionalidad">nacionalidad del universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        /// <summary>
        /// Funcion que devuelve los datos del univesitario
        /// </summary>
        /// <returns>datos en formato string</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLegajo: " + this._legajo;
        }
        
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Funcion que compara si dos objetos son del mismo tipo, en este caso si son Universitario
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>devuelve "true" si son iguales, "false" si no lo son</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario && this == (Universitario)obj)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Funcion encargada de ver si dos universitarios son iguales, comparando sus DNI o legajo
        /// </summary>
        /// <param name="pg1">un universitario</param>
        /// <param name="pg2">otro universitario</param>
        /// <returns>devuelve true si son iguales, false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.DNI == pg2.DNI || pg1.Legajo == pg2.Legajo)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return (!(pg1 == pg2));
        }
    }
}
