using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _16189_16191_Projeto4ED
{
    
    class Aresta : IComparable<Aresta>
    {

        public const int tamanhoCid = 30;
       
        public const int tamanhoCusto = 1;

        public readonly static int CidEmBytes = tamanhoCid * Marshal.SizeOf(typeof(char));
        public readonly static int CustoEmBytes = tamanhoCusto * Marshal.SizeOf(typeof(double));
        public readonly static int tamanhoRegistro = CustoEmBytes + CidEmBytes;

        private string cidOrig;
        private string cidDest;
        private double custo;
        public string CidOrig
        {
            get { return cidOrig; }
            set
            {
                cidOrig = value;
                if (cidOrig.Length > tamanhoCid)
                    cidOrig = cidOrig.Substring(0,tamanhoCid);
                while (cidOrig.Length < tamanhoCid)
                    cidOrig += " ";
            }
        }
        public string CidDest
        {
            get { return cidDest; }
            set
            {
                cidDest = value;
                if (cidDest.Length > tamanhoCid)
                    cidDest = cidDest.Substring(0, tamanhoCid);
                while (cidDest.Length < tamanhoCid)
                    cidDest += " ";
            }
        }
        public double Custo
        {
            get { return custo; }
            set {custo = value; }
        }
        public Aresta(string cidadeOrigem, string cidadeDestino, double c)
        {
            CidOrig = cidadeOrigem;
            CidDest = cidadeDestino;
            Custo = c;
        }
        public override string ToString()
        {
            return CidOrig + " --("+Custo+")-> " + CidDest;
        }
        public int CompareTo(Aresta outra) {
            return this.custo.CompareTo(outra.custo);
        }
    }
}
