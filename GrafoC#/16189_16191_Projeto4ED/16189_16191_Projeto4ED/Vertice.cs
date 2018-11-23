using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16189_16191_Projeto4ED
{
    class Vertice
    {
        public bool   foiVisitado;
        public string rotulo;
        public Vertice(string label)
        {
            rotulo = label;
            foiVisitado = false;
        }

    }
}
