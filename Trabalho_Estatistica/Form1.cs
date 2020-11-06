using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Estatistica
{
    public partial class Form1 : Form
    {
        List<Double> listaValores = new List<double>();

        public Form1()
        {
            InitializeComponent();
        }

        ///////////////////////////////////////////////////////////////
        ///                                                         ///
        ///                                                         ///
        ///                                                         ///
        ///                        Botão                            ///
        ///                                                         ///
        ///                                                         ///
        ///                                                         ///
        ///////////////////////////////////////////////////////////////

        private void btnValor_Click(object sender, EventArgs e)
        {
            try
            {
                InserirValor(tBoxValor.Text);
                tBoxValor.Text = "";
                Resultado(listaValores);

            }
            catch
            {
            }            
        }

        ///////////////////////////////////////////////////////////////
        ///                                                         ///
        ///                                                         ///
        ///                                                         ///
        ///                       funcoes                           ///
        ///                                                         ///
        ///                                                         ///
        ///                                                         ///
        ///////////////////////////////////////////////////////////////

        public List<double> InserirValor(string valor)
        {  
            listaValores.Add(Convert.ToDouble(valor));
            listaValores.Sort();
            return listaValores;
        }


        public void Resultado(List<double> lista)
        {
            label2.Text = Media(Soma(listaValores), Linhas(listaValores)).ToString();
            label3.Text = Mediana(listaValores).ToString();
            label4.Text = Variancia(listaValores).ToString();
            label5.Text = DesvioPadrao(listaValores).ToString();
            label6.Text = CoeficienteVariação(listaValores).ToString();
            label7.Text = Determinar(listaValores).ToString();
        }

        public double Linhas(List<double> lista)
        {
            int contagem = lista.Count();
            label1.Text = contagem.ToString();
            return contagem;
        }

        public double Soma(List<double> lista)
        {
            double contagem = 0;
            lista.ForEach(valor =>
            {
                contagem = contagem + valor;
            });
            return contagem;
        }

        public double Media(double superior, double inferior)
        {
            double media = superior / inferior;
            return media;
        }

        public double Mediana(List<double> lista)
        {
            Double[] mediana = lista.ToArray();

            if ((mediana.Length - 1) % 2 != 0)
            {
                double valor1 = mediana[(mediana.Length - 1) / 2];
                double valor2 = mediana[(mediana.Length - 1) / 2 + 1];
                double soma = valor1 + valor2;

                return Media(soma, 2);
            }
            else
            {
                return mediana[(mediana.Length) / 2];
            }
        }

        public double Variancia(List<double> lista)
        {
            double media = Media(Soma(listaValores), Linhas(listaValores));
            double variancia = 0;

            foreach(double valores in listaValores)
            {
                variancia = variancia + (Math.Pow(valores - media, 2));
            }

            return variancia/(Linhas(listaValores) - 1);
        }

        public double DesvioPadrao(List<double> lista)
        {
            return Math.Sqrt(Variancia(listaValores));
        }

        public double CoeficienteVariação(List<double> lista)
        {
            return (DesvioPadrao(listaValores) / Media(Soma(listaValores), Linhas(listaValores)));
        }

        public string Determinar(List<double> lista)
        {
            if (CoeficienteVariação(listaValores) > 0.30)
            {
                return "Heterogêneo";
            }
            else
            {
                return "Homogêneo";
            }
        }

    }
}
