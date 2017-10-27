using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException():base("ERROR-- - Nacionalidad Invalida\n")
        { 
        }

        public NacionalidadInvalidaException(string message):base(message)
        {
        }
    }
}
