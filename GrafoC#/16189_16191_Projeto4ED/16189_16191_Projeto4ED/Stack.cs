using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16189_16191_Projeto3ED
{
    interface Stack<Dado> where Dado: IComparable<Dado>
    {
       Dado Desempilhar();
       void empilhar(Dado elemento);

        int Tamanho();
        bool EstaVazia();


    }
}
