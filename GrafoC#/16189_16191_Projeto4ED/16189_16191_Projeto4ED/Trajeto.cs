using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16189_16191_Projeto4ED
{
    class Trajeto : IComparable<Trajeto>
    {
        ListaSimples<Caminho> listaCaminho;
        int custoTot;
       public  string origemAbs;
       public  string destinoAbs;

        public Trajeto(ListaSimples<Caminho> lista)
        {
            this.listaCaminho = lista;
            this.custoTot = 0;
            this.origemAbs = lista.primeiro.Info.CidadeOrigem;
            this.destinoAbs = lista.ultimo.Info.CidadeDestino;
            lista.iniciarPercursoSequencial();

            while (lista.podePercorrer())
            {
                custoTot += lista.atual.Info.Custo;
            }

        }
        public Trajeto(ListaSimples<Trajeto> lista)
        {
            this.origemAbs = lista.primeiro.Info.origemAbs;
            this.destinoAbs = lista.ultimo.Info.destinoAbs;
            this.custoTot = 0;
            this.listaCaminho = new ListaSimples<Caminho>();
            lista.iniciarPercursoSequencial();
            while (lista.podePercorrer())
            {
                custoTot += lista.atual.Info.custoTot;
                ListaSimples<Caminho> aux = lista.atual.Info.listaCaminho;
                aux.iniciarPercursoSequencial();
                while (aux.podePercorrer())
                {
                    listaCaminho.insereAposFim(new NoLista<Caminho>(aux.atual.Info, null));
                }
            }
        }
        public static Trajeto menor(ListaSimples<Trajeto> trajetos)
        {
            trajetos.ordenar();
            return trajetos.primeiro.Info;
        }
        public int CompareTo(Trajeto aComparar)
        {
            return this.custoTot.CompareTo(aComparar.custoTot);
        }
        public override bool Equals(Object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || obj.GetType() != GetType())
                return false;
            Trajeto aComp = (Trajeto)obj;
            if (aComp.custoTot != this.custoTot || aComp.destinoAbs != this.destinoAbs || aComp.origemAbs != this.origemAbs || !aComp.listaCaminho.Equals(this.listaCaminho))
                return false;

            return true;
                    }
        public override string ToString()
        {
            string retorno = "";
            listaCaminho.iniciarPercursoSequencial();
            retorno += listaCaminho.atual.Info.CidadeOrigem ;
            while (listaCaminho.podePercorrer())
            {
                retorno += " -> \n"+listaCaminho.atual.Info.CidadeDestino;
            }
            retorno+= "\n (" + custoTot + " km ) ";
            return retorno;
        }
    }
}
