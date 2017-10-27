using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }

            set
            {
                this._alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }

            set
            {
                this._clase = value;
            }

        }

        public Profesor Instructor
        {
            get
            {
                return this._instructor;
            }

            set
            {
                this._instructor = value;
            }

        }

        /// <summary>
        /// Constructor por defecto de Jornada
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor parametrizado de Jornada
        /// </summary>
        /// <param name="clase">clase del dia</param>
        /// <param name="instructor">profesor que da la clase</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Funcion encargada de guardar los datos de una jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">jornada a guardar</param>
        /// <returns>devuelve true si se pudo guardar con exito, false si no</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto save = new Texto();

            if (save.Guardar(@"\Jornada.txt", jornada.ToString()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Funcion encargada de leer los datos de una jornada de un archivo de texto
        /// </summary>
        /// <returns>devuelve true si los pudo leer, false si no</returns>
        public static string Leer()
        {
            string auxRetorno = "";
            Texto open = new Texto();

            if(open.Leer(@"\Jornada.txt", out auxRetorno))
            {
                return auxRetorno;
            }

            return null;
        }

        /// <summary>
        /// Una jornada sera igual a un alumno si el mismo participa de la clase
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>devuelve true si participa de la clase, false si no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno aux in j._alumnos)
            {
                if (aux == a)
                {
                    return true;
                }
            }

            return false;

        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return (!(j == a));
        }

        /// <summary>
        /// funcion que agrega un alumno a una jornada, si es que no estan agregados de antes
        /// </summary>
        /// <param name="j">joranda a comparar</param>
        /// <param name="a">alumno a buscar</param>
        /// <returns>devuelve la jornada,se haya agregado el alumno o no</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool yaEsta = false;

            foreach (Alumno aux in j._alumnos)
            {
                if (aux == a)
                {
                    yaEsta = true;
                    break;
                }
            }

            if (!yaEsta)
            {
                j._alumnos.Add(a);
            }

            return j;

        }

        /// <summary>
        /// Funcion que muestra los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retorno = "\n---------JORNADA---------\n" + "Clase de: " + this._clase + " dada por " + this.Instructor.ToString() + "--ALUMNOS--:\n";

            foreach (Alumno aux in this._alumnos)
            {
                if (aux == _clase)
                {
                    retorno += aux.ToString();
                }
                    
            }

            return retorno;
        }
    }
}
