using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ArvoreBinaria
{
    class ArvoreDeBusca<Tipo> : IComparable<NoArvore<Tipo>>
                                                where Tipo : IComparable<Tipo>
    {
        public NoArvore<Tipo> raiz,
                                 atual,
                                 antecessor;

        public Panel painelArvore;

        public Panel OndeExibir
        {
            get { return painelArvore; }
            set { painelArvore = value; }
        }

        public ArvoreDeBusca()
        {
            raiz = null;
            atual = null;
            antecessor = null;
        }

        public NoArvore<Tipo> Raiz
        {
            get { return raiz; }
        }

        public String InOrdem  // propriedade que gera a string do percurso in-ordem da �rvore
        {
            get { return FazInOrdem(raiz); }
        }

        public String PreOrdem  // propriedade que gera a string do percurso pre-ordem da �rvore
        {
            get { return FazPreOrdem(raiz); }
        }

        public String PosOrdem  // propriedade que gera a string do percurso pos-ordem da �rvore
        {
            get { return FazPosOrdem(raiz); }
        }

        private String FazInOrdem(NoArvore<Tipo> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia
            else
            {
                return FazInOrdem(r.esq) +
                           " " + r.dados.ToString() + " " +
                           FazInOrdem(r.dir);
            }
        }

        private String FazPreOrdem(NoArvore<Tipo> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia
            else
            {
                return
                          r.dados.ToString() +
                          " " + FazPreOrdem(r.esq) + " " +
                           FazPreOrdem(r.dir);
            }
        }

        private String FazPosOrdem(NoArvore<Tipo> r)
        {
            if (r == null)
                return "";  // retorna cadeia vazia
            else
            {
                return FazPosOrdem(r.esq) + " " +
                           FazPosOrdem(r.dir) +
                           " " + r.dados.ToString();
            }
        }

        public int CompareTo(NoArvore<Tipo> o)
        {
            return atual.dados.CompareTo(o.dados);
        }

        public void inserir(Tipo novosDados)
        {
            bool achou = false, fim = false;
            NoArvore<Tipo> novoNo = new NoArvore<Tipo>(novosDados);
            if (raiz == null)         // �rvore vazia
                raiz = novoNo;
            else                         // �rvore n�o-vazia
            {
                antecessor = null;
                atual = raiz;
                while (!achou && !fim)
                {
                    antecessor = atual;
                    if (novosDados.CompareTo(atual.dados) < 0)
                    {
                        atual = atual.esq;
                        if (atual == null)
                        {
                            antecessor.esq = novoNo;
                            fim = true;
                        }
                    }
                    else
                        if (novosDados.CompareTo(atual.dados) == 0)
                            achou = true;  // pode-se disparar uma exce��o neste caso
                        else
                        {
                            atual = atual.dir;
                            if (atual == null)
                            {
                                antecessor.dir = novoNo;
                                fim = true;
                            }
                        }
                }
            }
        }

        public bool ApagarNo(Tipo chaveARemover)
        {
            atual = raiz;
            antecessor = null;
            bool ehFilhoEsquerdo = true;
            while (atual.dados.CompareTo(chaveARemover) != 0)  // enqto n�o acha a chave a remover
            {
                antecessor = atual;
                if (atual.dados.CompareTo(chaveARemover) > 0)
                {
                    ehFilhoEsquerdo = true;
                    atual = atual.esq;
                }
                else
                {
                    ehFilhoEsquerdo = false;
                    atual = atual.dir;
                }

                if (atual == null)  // neste caso, a chave a remover n�o existe e n�o pode
                    return false;   // ser exclu�da, dai retornamos falso indicando isso
            }  // fim do while

            // se fluxo de execu��o vem para este ponto, a chave a remover foi encontrada
            // e o ponteiro atual indica o n� que cont�m essa chave

            if ((atual.esq == null) && (atual.dir == null))  // � folha, n� com 0 filhos
            {
                if (atual == raiz)
                    raiz = null;   // exclui a raiz e a �rvore fica vazia
                else
                    if (ehFilhoEsquerdo)        // se for filho esquerdo, o antecessor deixar� 
                        antecessor.esq = null;  // de ter um descendente esquerdo
                    else                               // se for filho direito, o antecessor deixar� de 
                        antecessor.dir = null;  // apontar para esse filho

                atual = antecessor;  // feito para atual apontar um n� v�lido ao sairmos do m�todo
            }
            else   // verificar� as duas outras possibilidades, exclus�o de n� com 1 ou 2 filhos
                if (atual.dir == null)   // neste caso, s� tem o filho esquerdo
                {
                    if (atual == raiz)
                        raiz = atual.esq;
                    else
                        if (ehFilhoEsquerdo)
                            antecessor.esq = atual.esq;
                        else
                            antecessor.dir = atual.esq;
                    atual = antecessor;
                }
                else
                    if (atual.esq == null)  // neste caso, s� tem o filho direito
                    {
                        if (atual == raiz)
                            raiz = atual.dir;
                        else
                            if (ehFilhoEsquerdo)
                                antecessor.esq = atual.dir;
                            else
                                antecessor.dir = atual.dir;
                        atual = antecessor;
                    }
                    else // tem os dois descendentes
                    {
                        NoArvore<Tipo> menorDosMaiores = ProcuraMenorDosMaioresDescendentes(atual);
                        atual.dados = menorDosMaiores.dados;
                        menorDosMaiores = null; // para liberar o n� trocado da mem�ria
                    }
            return true;
        }

        public NoArvore<Tipo> ProcuraMenorDosMaioresDescendentes(NoArvore<Tipo> noAExcluir)
        {
            NoArvore<Tipo> paiDoSucessor = noAExcluir;
            NoArvore<Tipo> sucessor = noAExcluir;
            NoArvore<Tipo> atual = noAExcluir.dir;   // vai ao ramo direito do n� a ser exclu�do, pois este ramo cont�m
            // os descendentes que s�o maiores que o n� a ser exclu�do 
            while (atual != null)
            {
                if (atual.esq != null)
                    paiDoSucessor = atual;
                sucessor = atual;
                atual = atual.esq;
            }

            if (sucessor != noAExcluir.dir)
            {
                paiDoSucessor.esq = sucessor.dir;
                sucessor.dir = noAExcluir.dir;
            }
            return sucessor;
        }

        public int alturaArvore(NoArvore<Tipo> atual, ref bool balanceada)
        {
            int alturaDireita, alturaEsquerda, result;
            if (atual != null && balanceada)
            {
              alturaEsquerda = 1 + alturaArvore(atual.esq, ref balanceada);
              alturaDireita = 1 + alturaArvore(atual.dir, ref balanceada);
              result = Math.Max(alturaEsquerda, alturaDireita);
              
              //if (alturaDireita > alturaEsquerda)
              //    result = alturaDireita;
              //else
              //  result = alturaEsquerda;
              
              if (Math.Abs(alturaDireita - alturaEsquerda) > 1)
                 balanceada = false;
            }
            else
                result = 0;
            return result;
        }

        public int getAltura(NoArvore<Tipo> no)
        {
            if (no != null)
                return no.altura;
            else
                return -1;
        }

        public NoArvore<Tipo> Insert(Tipo item, NoArvore<Tipo> n) 
        {
          if (n == null)
          {
            n = new NoArvore<Tipo>(item);
            OndeExibir.Invalidate();
            Application.DoEvents();
            MessageBox.Show("Inclusao sem rotacao " + n.dados.ToString());
            OndeExibir.Invalidate();
            Application.DoEvents();
          }
          else
          {
            if (item.CompareTo(n.dados) < 0)
            {
              n.esq = Insert(item, n.esq);
              if (getAltura(n.esq) - getAltura(n.dir) == 2)  // a propriedade Altura testa nulo!
                if (item.CompareTo(n.esq.dados) < 0)
                  n = RotateWithLeftChild(n);
                else
                  n = DoubleWithLeftChild(n);
            }
            else
              if (item.CompareTo(n.dados) > 0)
              {
                n.dir = Insert(item, n.dir);
                if (getAltura(n.dir) - getAltura(n.esq) == 2)  // a propriedade Altura testa nulo!
                  if (item.CompareTo(n.dir.dados) > 0)
                    n = RotateWithRightChild(n);
                  else
                    n = DoubleWithRightChild(n);
              }
            //else ; - do nothing, duplicate value

            n.altura = Math.Max(getAltura(n.esq), getAltura(n.dir)) + 1;
            OndeExibir.Invalidate();
            Application.DoEvents();
          }
            return n;
    }

        private NoArvore<Tipo> RotateWithLeftChild(NoArvore<Tipo> no)
        {
            NoArvore<Tipo> temp = no;  // apenas para declarar

           temp = no.esq;
           no.esq = temp.dir;
           temp.dir = no;
           no.altura = Math.Max(getAltura(no.esq), getAltura(no.dir)) + 1;
           temp.altura = Math.Max(getAltura(temp.esq), getAltura(no)) + 1;
           // System.Threading.Thread.Sleep(2000);
           OndeExibir.Invalidate();
           Application.DoEvents();
           MessageBox.Show("Rota��o � direita do n� " + temp.dados.ToString());
           OndeExibir.Invalidate();
           Application.DoEvents();
           return temp;
        }

        private NoArvore<Tipo> RotateWithRightChild(NoArvore<Tipo> no)
        {
            NoArvore<Tipo> temp = no;  // apenas para declarar

            temp = no.dir;
            no.dir = temp.esq;
            temp.esq = no;
            no.altura = Math.Max(getAltura(no.esq), getAltura(no.dir)) + 1;
            temp.altura = Math.Max(getAltura(temp.dir), getAltura(no)) + 1;
            //System.Threading.Thread.Sleep(2000);
            OndeExibir.Invalidate();
            Application.DoEvents();
            MessageBox.Show("Rota��o � esquerda do n� "+temp.dados.ToString());
            OndeExibir.Invalidate();
            Application.DoEvents();
            return temp;
        }

        private NoArvore<Tipo> DoubleWithLeftChild(NoArvore<Tipo> no) 
        {
            OndeExibir.Invalidate();
            Application.DoEvents();
            MessageBox.Show("Rota��o dupla � direita do n� "+no.dados.ToString());
            no.esq = RotateWithRightChild( no.esq );
            OndeExibir.Invalidate();
            Application.DoEvents();
            return RotateWithLeftChild(no);
        }
        
        private NoArvore<Tipo> DoubleWithRightChild(NoArvore<Tipo> no) 
        {
            OndeExibir.Invalidate();
            Application.DoEvents();
            MessageBox.Show("Rota��o dupla � esquerda do n� " + no.dados.ToString());
            no.dir = RotateWithLeftChild( no.dir );
            OndeExibir.Invalidate();
            Application.DoEvents();
            return RotateWithRightChild( no );
        }
        
    }   
}
