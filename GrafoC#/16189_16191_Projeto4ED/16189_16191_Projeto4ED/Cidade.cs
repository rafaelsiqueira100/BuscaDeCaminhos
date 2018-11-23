using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _16189_16191_Projeto4ED
{
   public class Cidade : IComparable<Cidade>

    {
        public const int tamanhoNome = 30;      

        public readonly static int NomeEmBytes = tamanhoNome * Marshal.SizeOf(typeof(char));

        public readonly static int tamanhoRegistro = NomeEmBytes;

        private string nome;
       
        public string Nome {
            get { return nome; }
            set
            {
                nome = value;

                if (nome.Length > tamanhoNome)
                    nome = nome.Substring(0, tamanhoNome);
                while (nome.Length < tamanhoNome)
                    nome += " ";
            }
        }

        public Cidade() : this("")
        { }
        
        public Cidade(string n)
        {            
           Nome = n;
        }

        public override string ToString()
        {
            return Nome + "\n";
        }

        public int CompareTo(Cidade outro)
        {
            return nome.CompareTo(outro.nome);
        }
    }
}
