using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {
        /// <summary>
        /// Funcion encargada de guardar un archivo de texto
        /// </summary>
        /// <param name="archivo">ruta y nombre del archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>devuelve "true" si pudo guardar con exito, "false" si no pudo</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter guardarArchivo = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory+archivo, false);

                guardarArchivo.Write(datos);
                guardarArchivo.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }


        }
        /// <summary>
        /// Funcion encargada de leer un archivo de texto
        /// </summary>
        /// <param name="archivo">ruta y nombre del archivo</param>
        /// <param name="datos">variable donde se guardaran los datos leidos</param>
        /// <returns>devuelve "true" si pudo guardar con exito, "false" si no pudo</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader leerArchivo = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+archivo, false);

                datos = leerArchivo.ReadToEnd();
                leerArchivo.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }
    }
}
