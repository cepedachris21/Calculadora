using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double sumaTotal = 0;
        string valorEntrada;
        bool condicionOperacion = false;
        int contador = 0;
        double ultimoNumeroEntrada;
        double anteriorNumeroEntrada;
        string numero;
        bool a = true;
        

        int numeroEntradaOperacion = 0;
        double primerNumero;
        double total;

        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint;
        
        private double Calculo(string valorEntrada, double num1, double num2)
        {
            double sum = 0;
            switch (valorEntrada)
            {
                case "+":
                    sum = num1 + num2;
                    break;

                case "-":
                    sum = num1 - num2;
                    break;

                case "x":
                    sum = num1 * num2;
                    break;

                case "/":
                    sum = num1 / num2;
                    break;

                case "√":
                    cuadroResultad.Text = Math.Sqrt(sumaTotal).ToString();
                    condicionOperacion = false;
                    break;

                default:
                    Lbl_1.Text = "Argumento invalido";
                    break;
            }
            return sum;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            a = true;
            if (cuadroResultad.Text == "0" || condicionOperacion)
            {
                cuadroResultad.Clear();
            }

            condicionOperacion = false;

            if (((Button)sender).Text == ",")
            {
                if (!cuadroResultad.Text.Contains(","))
                {
                    cuadroResultad.Text += ((Button)sender).Text;
                }
            }
            else
            {
                if (contador != 0)
                {
                    cuadroResultad.Text = ((Button)sender).Text;
                    contador = 0;
                }
                else cuadroResultad.Text += ((Button)sender).Text;
            }

            ultimoNumeroEntrada = double.Parse(cuadroResultad.Text);

            numero = ((Button)sender).Text;
            

            if (numeroEntradaOperacion == 0)
            {
                primerNumero = double.Parse(cuadroResultad.Text);
            }
            if (numeroEntradaOperacion >= 1)
            {
                total = Calculo(valorEntrada, primerNumero, ultimoNumeroEntrada);
            }
        }


        private void Btn_borrar(object sender, EventArgs e)
        {
            cuadroResultad.Font = new Font("Nirmala UI", 24, FontStyle.Bold);
            Lbl_1.Font = new Font("Nirmala UI", 12, FontStyle.Bold);
            cuadroResultad.Text = "0";
            Lbl_1.Text = null;
            contador = 0;
            a = true;
            valorEntrada = null;
            anteriorNumeroEntrada = 0;
            numeroEntradaOperacion = 0;
            total = 0;
            

            numero = null;
            condicionOperacion = false;
            primerNumero = 0;
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            a = true;
            contador = 0;
            valorEntrada = ((Button)sender).Text;
            sumaTotal = double.Parse(cuadroResultad.Text);
            condicionOperacion = true;
            
            if (numeroEntradaOperacion >= 1)
            {
                cuadroResultad.Text = total.ToString();
                primerNumero = total;
                sumaTotal = total;
            }

            if (((Button)sender).Text != "√")
            {
                Lbl_1.Text = $"{cuadroResultad.Text} {valorEntrada} ";
            }
            else // √
            {
                Lbl_1.Text = $"{valorEntrada}({sumaTotal.ToString()})";
            }

            numeroEntradaOperacion++;
            anteriorNumeroEntrada = double.Parse(cuadroResultad.Text);

            if (cuadroResultad.Text.Length >= 14)
            {
                cuadroResultad.Font = new Font("Nirmala UI", 17, FontStyle.Bold);
                Lbl_1.Font = new Font("Nirmala UI", 9, FontStyle.Bold);
            }
        }


        private void Btn_Equals_OnClick(object sender, EventArgs e)
        {
            if ((cuadroResultad.Text != "0" && a && (!condicionOperacion || (condicionOperacion && valorEntrada == "√") || (condicionOperacion && numeroEntradaOperacion > 0))) || (cuadroResultad.Text == "0" && a && !condicionOperacion))
            {

                if (condicionOperacion)
                {
                    if (numeroEntradaOperacion > 0)
                    {
                        Lbl_1.Text += $"{cuadroResultad.Text} =";
                        condicionOperacion = false;
                    }
                    else Lbl_1.Text += " =";
                }
                else
                {
                    if (contador == 0)
                    {
                        Lbl_1.Text += $"{cuadroResultad.Text} =";
                    }
                    else
                    {
                        if (valorEntrada == "√")
                        {
                            Lbl_1.Text = $"{valorEntrada}({sumaTotal.ToString()}) =";
                        }
                        else
                        {
                            Lbl_1.Text = $"{cuadroResultad.Text} {valorEntrada} {ultimoNumeroEntrada} =";
                        }
                    }
                }

                switch (valorEntrada)
                {
                    case "+":
                        if (contador == 0)
                        {
                            ultimoNumeroEntrada = double.Parse(cuadroResultad.Text);
                            cuadroResultad.Text = (sumaTotal + double.Parse(cuadroResultad.Text)).ToString();
                        }
                        else
                        {
                            cuadroResultad.Text = (ultimoNumeroEntrada + double.Parse(cuadroResultad.Text)).ToString();
                        }
                        a = true;
                        break;

                    case "-":
                        if (contador == 0)
                        {
                            ultimoNumeroEntrada = double.Parse(cuadroResultad.Text);
                            cuadroResultad.Text = (sumaTotal - double.Parse(cuadroResultad.Text)).ToString();
                        }
                        else
                        {
                            cuadroResultad.Text = (double.Parse(cuadroResultad.Text) - ultimoNumeroEntrada).ToString();
                        }
                        a = true;
                        break;

                    case "x":
                        if (contador == 0)
                        {
                            ultimoNumeroEntrada = double.Parse(cuadroResultad.Text);
                            cuadroResultad.Text = (sumaTotal * double.Parse(cuadroResultad.Text)).ToString();
                        }
                        else
                        {
                            cuadroResultad.Text = (double.Parse(cuadroResultad.Text) * ultimoNumeroEntrada).ToString();
                        }
                        a = true;
                        break;

                    case "/":
                        if (contador == 0)
                        {
                            if (!condicionOperacion && numeroEntradaOperacion > 0)
                            {
                                ultimoNumeroEntrada = double.Parse(cuadroResultad.Text);
                                cuadroResultad.Text = (sumaTotal / double.Parse(cuadroResultad.Text)).ToString();

                            }
                        }
                        else
                        {
                            cuadroResultad.Text = (double.Parse(cuadroResultad.Text) / ultimoNumeroEntrada).ToString();
                        }
                        a = true;
                        break;

                    case "√":
                        cuadroResultad.Text = Math.Sqrt(sumaTotal).ToString();
                        condicionOperacion = false;
                        break;

                    default:
                        Lbl_1.Text = "El argumento no es valido.";
                        break;
                }
                contador++;
            }
            else
            {
                if (valorEntrada != "√")
                {
                    if (numero == null || valorEntrada == null)
                    {
                        Lbl_1.Text = "0 =";
                    }
                    else
                    {
                        Lbl_1.Text = $"{sumaTotal.ToString()} {valorEntrada} 0 =";
                    }
                }
                else // √
                {
                    Lbl_1.Text = $"{valorEntrada}({sumaTotal.ToString()}) =";
                }

                cuadroResultad.Text = "0";
                if (contador != 0) a = false;
            }

            if (cuadroResultad.Text.Length >= 14)
            {
                cuadroResultad.Font = new Font("Nirmala UI", 17, FontStyle.Bold);
                Lbl_1.Font = new Font("Nirmala UI", 9, FontStyle.Bold);
            }
            numeroEntradaOperacion = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void cuadroResultado(object sender, EventArgs e)
        {

        }

        private void Lbl_1_Click(object sender, EventArgs e)
        {

        }
    }
}
