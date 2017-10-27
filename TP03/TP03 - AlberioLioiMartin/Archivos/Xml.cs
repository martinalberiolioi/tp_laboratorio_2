using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Clases_Abstractas;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Funcion encargada de leer un archivo XML
        /// </summary>
        /// <param name="archivo">ruta y nombre del archivo</param>
        /// <param name="datos">variable donde se guardaran los datos leidos</param>
        /// <returns>devuelve "true" si pudo guardar con exito, "false" si no pudo</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                StreamWriter guardarArchivo = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + archivo, false);
                XmlSerializer xml = new XmlSerializer(typeof(T));

                xml.Serialize(guardarArchivo, datos);
                return true;
            }            
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

        }

        /// <summary>
        /// Funcion encargada de leer un archivo XML
        /// </summary>
        /// <param name="archivo">ruta y nombre del archivo</param>
        /// <param name="datos">variable donde se guardaran los datos leidos</param>
        /// <returns>devuelve "true" si pudo guardar con exito, "false" si no pudo</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                StreamReader leerArchivo = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo, false);

                XmlSerializer xml = new XmlSerializer(typeof(T));

                datos = (T)xml.Deserialize(leerArchivo);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            
        }
    }
}
