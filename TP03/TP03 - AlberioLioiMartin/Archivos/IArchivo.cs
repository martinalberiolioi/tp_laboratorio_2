using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Funcion encargada de guardar un archivo 
        /// </summary>
        /// <param name="archivo">ruta y nombre del archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>devuelve "true" si pudo guardar con exito, "false" si no pudo</returns>
        bool Guardar(string archivo, T datos);
        
        /// <summary>
        /// Funcion encargada de leer un archivo
        /// </summary>
        /// <param name="archivo">ruta y nombre del archivo</param>
        /// <param name="datos">variable donde se guardaran los datos leidos</param>
        /// <returns>devuelve "true" si pudo guardar con exito, "false" si no pudo</returns>
        bool Leer(string archivo, out T datos);
    }
}
