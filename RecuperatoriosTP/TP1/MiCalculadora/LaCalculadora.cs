using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {  
        /// <summary>
        /// Constructor por defecto de la clase LaCalculadora. Cambia el titulo del programa, elimina los botones de minimizar y maximizar, centra en la pantalla el programa al iniciar, bloquea cualquier tipo de modificacion de tamaño y agrega los operadores al ComboBox
        /// </summary>
        public LaCalculadora()
        {
            InitializeComponent();

            this.Text = "Calculadora de Martin Alberio Lioi del curso 2ºA"; //cambia el titulo del programa
            this.MinimizeBox = false; //elimina el boton de minimizar
            this.MaximizeBox = false; //elimina el boton de maximizar
            this.StartPosition = FormStartPosition.CenterScreen; //hace que el programa se inicie en el centro de la pantalla
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //hace que el programa no acepte ninguna modificacion de tamaño
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }      

        /// <summary>
        /// Metodo encargado de dejar en blanco todos los TextBox, ComboBox y Labels
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        /// <summary>
        /// Metodo encargado de operar dos numeros ingresados por el usuario
        /// </summary>
        /// <param name="numero1">primer numero a operar</param>
        /// <param name="numero2">segundo numero a operar</param>
        /// <param name="operador">operacion</param>
        /// <returns>devuelve el resultado de la operacion en formato Double</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Calculadora unaCalculadora = new Calculadora();
            Numero auxNumero1 = new Numero(numero1);
            Numero auxNumero2 = new Numero(numero2);

            return unaCalculadora.Operar(auxNumero1, auxNumero2, operador);
        }

        /// <summary>
        /// Metodo encargado de cerrar el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo encargado de llamar al metodo Limpiar(), para dejar en blanco los TextBox, ComboBox y Labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Metodo encargado de llamar al metodo Operar, el cual realiza las operaciones matematicas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = LaCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Metodo encargado de llamar al metodo BinarioDecimal, para convertir un numero binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero aux = new Numero();

            this.lblResultado.Text = aux.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// Metodo encargado de llamar al metodo DecimalBinario, para convertir un numero decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero aux = new Numero();

            lblResultado.Text = aux.DecimalBinario(this.lblResultado.Text);
        }
    }
}
