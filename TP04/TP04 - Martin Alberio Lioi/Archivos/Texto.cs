using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string rutaArchivo;

        /// <summary>
        /// Constructor de la clase Texto que me permite definirle una ruta
        /// </summary>
        /// <param name="ruta">Ruta a ingresar</param>
        public Texto(string ruta)
        {
            this.rutaArchivo = ruta;
        }

        /// <summary>
        /// Metodo que guarda el historial de navegacion
        /// </summary>
        /// <param name="datos">Datos de navegacion a guardar</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter SW = new StreamWriter(@rutaArchivo, true);

                SW.WriteLine(datos);

                SW.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }           

        }

        /// <summary>
        /// Metodo que lee el archivo de historial
        /// </summary>
        /// <param name="datos">Atributo en el cual seran retornados los datos</param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();

            try
            {
                StreamReader SR = new StreamReader(@rutaArchivo);

                do
                {
                    datos.Add(SR.ReadLine());

                } while (!SR.EndOfStream);

                SR.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }


    }
}
