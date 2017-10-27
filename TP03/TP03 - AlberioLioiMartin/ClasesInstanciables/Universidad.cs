using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }


        /// <summary>
        /// funcion que guarda los datos de una universidad en un archivo XML
        /// </summary>
        /// <param name="gim">universidda a guardar</param>
        /// <returns>devuelve true si pudo guardar, false si no</returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> unXML = new Xml<Universidad>();

            if(unXML.Guardar(@"\Universidad.xml", gim))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Funcion que lee los datos de un archivo XML
        /// </summary>
        /// <returns>devuelve los datos de una universidad</returns>
        public static Universidad Leer()
        {
            Universidad unaUniv = new Universidad();
            Xml<Universidad> unXML = new Xml<Universidad>();

            if (unXML.Leer(@"\Universidad.xml", out unaUniv))
            {
                return unaUniv;
            }

            return null;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// muestra los datos de una universidad
        /// </summary>
        /// <param name="gim">universidad a mostrar</param>
        /// <returns>devuelve un string con los datos</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada aux in gim.Jornadas)
            {
                sb.Append("Clase:");
                sb.Append(aux.ToString() + "\n");
            }

            return sb.ToString();
        }

        /// <summary>
        /// compara una universidad y un alumno. seran iguales si el alumno va a esta universidad
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>devuelve true si participa de la universidad, false si no</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool yaEsta = false;

            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == a)
                {
                    yaEsta = true;
                    break;
                }
            }

            return yaEsta;

        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return (!(g == a));
        }

        /// <summary>
        /// busca el primer profesor para dar una clase en una universidad
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="clase">clase a buscar</param>
        /// <returns>devuelve el profesor si encontro uno para que de la clase</returns>
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {

            foreach (Profesor aux in g.Instructores)
            {
                if (aux == clase)
                {

                    return aux;
                }
            }


            throw new SinProfesorException();

        }

        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor aux in g.Instructores)
            {
                if (!(aux == clase))
                {
                    return aux;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// compara una universidad con un profesor. seran iguales si el profesor da clase en esta universidad
        /// </summary>
        /// <param name="g">universidad a comparar</param>
        /// <param name="i">profesor a buscar</param>
        /// <returns>devuelve true si encontro al profesor, false si no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool yaEsta = false;

            foreach (Profesor aux in g.Instructores)
            {
                if (aux == i)
                {
                    yaEsta = true;
                    break;
                }
            }

            return yaEsta;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return (!(g == i));
        }

        /// <summary>
        /// agrega un alumno a una universidad
        /// </summary>
        /// <param name="g">universidad a cargar</param>
        /// <param name="a">alumno a cargar</param>
        /// <returns>devuelve la universidad, haya sido cargado el alumno o no</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            bool yaEsta = false;

            foreach (Alumno aux in g.Alumnos)
            {
                if (aux == a)
                {
                    yaEsta = true;
                    break;
                }
            }

            if (!yaEsta)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            

            return g;
        }

        /// <summary>
        /// agrega un profesor a una universidad
        /// </summary>
        /// <param name="g">universidad a cargar</param>
        /// <param name="i">profesor a cargar</param>
        /// <returns>devuelve la universidad, con el profesor cargado o no</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            bool yaEsta = false;

            foreach (Profesor aux in g.Instructores)
            {
                if (aux == i)
                {
                    yaEsta = true;
                    break;
                }
            }

            if (!yaEsta)
            {
                g.Instructores.Add(i);
            }

            return g;
        }

        /// <summary>
        /// se agrega una clase a la universidad
        /// </summary>
        /// <param name="g">universidad a cargar</param>
        /// <param name="clase">clase a cargar</param>
        /// <returns>devuelve la universidad, con la clase cargada o no</returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor aux in g.Instructores)
            {
                if (aux == clase)
                {
                    Jornada J = new Jornada(clase, aux);

                    foreach (Alumno auxA in g.Alumnos)
                    {
                        if (auxA.ClaseQueToma == clase)
                        {
                            J.Alumnos.Add(auxA);                            
                        }                        
                    }

                    g.Jornadas.Add(J);
                    return g;
                }

            }

            throw new SinProfesorException();
        }


    }
}
