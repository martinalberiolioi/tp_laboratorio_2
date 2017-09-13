using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "VisualCasio";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        
        private void limpiar()
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.label1.Text = "0";
            this.comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(textBox1.Text);
            Numero numero2 = new Numero(textBox2.Text);


            label1.Text = Calculadora.operar(numero1, numero2, (Calculadora.validarOperador(comboBox1.Text))).ToString();
            //primer parametro - primer operando
            //segundo parametro - segundo operando
            //tercer parametro - llama a la funcion validarOperador, le pasa por parametro el texto del comboBox, y ese resultado entra a la funcion operar
            //al final usa .toString() para convertir el numero resultado a texto y poder mostrarlo en el label
        }
    }
}
