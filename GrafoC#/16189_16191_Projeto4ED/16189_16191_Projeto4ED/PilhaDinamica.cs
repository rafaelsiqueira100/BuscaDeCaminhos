using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16189_16191_Projeto4ED
{
    class PilhaDinamica<Dado> : Stack<Dado> where Dado : IComparable<Dado>
    {
        ListaSimples<Dado> pilha;
        public PilhaDinamica()
        {
            pilha = new ListaSimples<Dado>();
        }
        public void Listar(ListBox lsb)
        {
            pilha.listar(lsb);
        }
        public Dado Desempilhar()
        {try
            {
                return pilha.removerPrimeiro();
            }
            catch(Exception )
            {
                throw new Exception("Underflow da pilha");
            }
        }

        public void empilhar(Dado elemento)
        {
            pilha.insereAntesDoInicio(new NoLista<Dado>(elemento,  null));
        }

        public bool EstaVazia()
        {
            return Topo == null;
        }

        public int Tamanho()
        {
            return pilha.QtosNos;
        }
        public NoLista<Dado> Topo
        {
          
                get
            {
                
                    return pilha.primeiro;
                
            }
                set
            {

                    pilha.primeiro = value;
            } 
        }
    }
}
