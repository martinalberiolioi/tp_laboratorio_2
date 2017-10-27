using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            Becado, Deudor, AlDia
        }

        public Universidad.EClases ClaseQueToma
        {
            get
            {
                return this._claseQueToma;
            }
        }

        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno() : base()
        {
            this._claseQueToma = Universidad.EClases.Laboratorio;
            this._estadoCuenta = EEstadoCuenta.AlDia;
        }

        /// <summary>
        /// Constructor parametrizado de Alumno
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="clasesQueToma">clase que toma el alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = clasesQueToma;
        }

        /// <summary>
        /// Constructor parametrizado de Alumno
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="clasesQueToma">clase que toma el alumno</param>
        /// <param name="estadoCuenta"">estado de la cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Funcion encargada de mostrar los datos
        /// </summary>
        /// <returns>devuelve un string con los datos</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + "\nClases que toma: " + this._claseQueToma + "\nEstado de cuenta: " + this._estadoCuenta +"\nLegajo: "+this.Legajo;
        }

        /// <summary>
        /// Funcion que devuelve las clases en las que el alumno participa
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "Toma clase de: " + this._claseQueToma;
        }

        /// <summary>
        /// Funcion que compara un alumno a una clase. Seran iguales si el alumno toma esta clase y si el estado de su cuenta no es deudor
        /// </summary>
        /// <param name="a">alumno</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>devuelve true si toma la clase, false si no</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (clase == a._claseQueToma && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (!(a == clase));
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

    }
}
