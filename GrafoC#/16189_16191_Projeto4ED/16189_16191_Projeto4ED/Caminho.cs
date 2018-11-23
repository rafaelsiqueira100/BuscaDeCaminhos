using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16189_16191_Projeto4ED
{
    public class Caminho : IComparable<Caminho>
    {
        private string cidadeOrigem;
        private string cidadeDestino;
        private int custo;

        public const int MENOR_CUSTO_PERMITIDO = 1;

        public Caminho(string cidadeOrigem, string cidadeDestino,  int custo)
        {
            CidadeOrigem = cidadeOrigem;
            CidadeDestino = cidadeDestino;
            Custo = custo;
        }

        public string CidadeOrigem
        {
            get
            {
                return cidadeOrigem;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Caminho: cidade de origem nula");

                cidadeOrigem = value;
            }
        }

        public string CidadeDestino
        {
            get
            {
                return cidadeDestino;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Caminho: cidade de destino nula");

                cidadeDestino = value;
            }
        }

        public int Custo
        {
            get
            {
                return custo;
            }

            set
            {
                if (value < MENOR_CUSTO_PERMITIDO)
                    throw new Exception("Caminho: custo menor que o permitido");

                custo = value;
            }
        }

        public int CompareTo(Caminho aComparar)
        {
            if (aComparar == null)
                throw new Exception("Caminho: comparação com objeto nulo");

            var nomesCidades = CidadeOrigem + CidadeDestino;
            var nomesCidadesAComparar = aComparar.CidadeOrigem + aComparar.CidadeDestino;

            return nomesCidades.CompareTo(nomesCidadesAComparar);
        }


        public override string ToString()
        {
            return cidadeOrigem + " -> " + cidadeDestino + " (" + Custo + ") ";
        }
    }
}
