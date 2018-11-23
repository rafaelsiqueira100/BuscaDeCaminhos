using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16189_16191_Projeto3ED
{
    class PilhaVaziaException : Exception 
    {
        public PilhaVaziaException(string erro) : base(erro) { }
    }
}
