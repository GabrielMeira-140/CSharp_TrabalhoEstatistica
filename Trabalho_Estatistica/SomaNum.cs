using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Estatistica
{
    class Soma
    {
        public double SomaNumeros(List<double> lista)
        {
            double contagem = 0;

            lista.ForEach(valor =>{ contagem = contagem + valor;});

            return contagem;
        }
    }
}
