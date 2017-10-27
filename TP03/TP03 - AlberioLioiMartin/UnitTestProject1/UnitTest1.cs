using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Clases_Abstractas;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Ingresa una nacionalidad y DNI no validos, para ver si pasa la prueba
        /// </summary>
        [TestMethod]
        public void ValidarNacionalidadInvalida()
        {
            try
            {
                Alumno a = new Alumno(1, "John", "Salcichon", "99999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD); 
            }
            catch(NacionalidadInvalidaException e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Crea una universidad y comprueba que sus datos por defecto no sean null
        /// </summary>
        [TestMethod]
        public void ValidarDatosEnNull()
        {
            Alumno a = new Alumno();

            Assert.IsNotNull(a.Apellido);
            Assert.IsNotNull(a.Nombre);
            Assert.IsNotNull(a.DNI);
            Assert.IsNotNull(a.ClaseQueToma);
            Assert.IsNotNull(a.Legajo);
            Assert.IsNotNull(a.Nacionalidad);
        }

        /// <summary>
        /// Valida que el DNI no sea valido (menos de 1)
        /// </summary>
        [TestMethod]
        public void ValidarDniinvalido()
        {
            try
            {
                Alumno a = new Alumno(1, "Roberto", "Catodo", "-544456", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            }
            catch (DniInvalidoException e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
       
        /// <summary>
        /// valida que el legajo o dni sean validos
        /// </summary>
        [TestMethod]
        public void ValidarDNIlegajo()
        {
            Alumno a = new Alumno(2, "stas", "forte", "9999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsInstanceOfType(a.DNI, typeof(int));
            Assert.IsInstanceOfType(a.Legajo, typeof(int));
        }



    }   
}
