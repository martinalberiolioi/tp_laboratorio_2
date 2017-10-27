using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensaje = "--ERROR-- DNI No valido";

        public DniInvalidoException():base(mensaje)
        {
        }

        public DniInvalidoException(Exception e):base(mensaje, e)
        {
        }

        public DniInvalidoException(string message):base(message)
        {
        }

        public DniInvalidoException(string message, Exception e):base(message, e)
        {
        }
    }
}
