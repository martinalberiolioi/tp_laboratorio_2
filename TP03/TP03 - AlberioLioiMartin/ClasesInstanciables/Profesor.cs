using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;  

        static Profesor()
        {
            _random = new Random();           
        }

        private Profesor()
        {
            _clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
            this._randomClase();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            _clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
            this._randomClase();
        }

        /// <summary>
        /// Funcion que asigna una clase al azar
        /// </summary>
        private void _randomClase()
        {
            int RandomClases = _random.Next(0, 4);

            switch (RandomClases)
            {
                case 0:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                    break;
                case 1:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                    break;
                case 2:
                    this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                    break;
                case 3:
                    this._clasesDelDia.Enqueue(Universidad.EClases.SPD);
                    break;
            }

        }

        /// <summary>
        /// Muestra las clases del dia
        /// </summary>
        /// <returns>devuelve un string con las clases del dia</returns>
        protected override string MostrarDatos()
        {
            string datos = base.MostrarDatos() + "\nClases del dia: \n";

            foreach (Universidad.EClases aux in this._clasesDelDia)
            {

                datos += aux.ToString() + "\n";

            }

            return datos;

        }

        /// <summary>
        /// Crea un string con las clases del dia
        /// </summary>
        /// <returns>Devuelve las clases del dia</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Clases del dia: ");
            foreach (Universidad.EClases aux in this._clasesDelDia)
            {
                sb.AppendLine(aux.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// compara si un profesor es igual a una clase. Será igual si este profesor da esta clase
        /// </summary>
        /// <param name="i">profesor a comparar</param>
        /// <param name="clase">clase a comparar</param>
        /// <returns>devuelve true si da la clase, false si no</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases aux in i._clasesDelDia)
            {
                if (clase == aux)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return (!(i == clase));
        }
    }
}
