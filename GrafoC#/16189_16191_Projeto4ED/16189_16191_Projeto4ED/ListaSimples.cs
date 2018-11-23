using System;
using System.Windows.Forms;
namespace _16189_16191_Projeto4ED
{
    public class ListaSimples<Tipo> where Tipo : IComparable<Tipo>
    {
        public NoLista<Tipo> primeiro, ultimo, anterior, atual;
        private int qtdeNos;
        private bool primeiroAcessoDoPercurso;
        public int QtosNos
        {
            get
            {
                return qtdeNos;
            }
            set
            {
                if (value >= 0)
                    qtdeNos = value;
            }
        }

        public ListaSimples()
        {
            this.primeiro = this.ultimo = this.anterior = this.atual = null;
            QtosNos = 0;
            this.primeiroAcessoDoPercurso = false;
        }
        public bool estaVazia()
        {
            return (this.primeiro == null);
        }
        
        public bool existeEmOrdem(Tipo procurado)
        {
            bool achouMaior = false, achouIgual = false;
            this.anterior = null;
            this.atual = this.primeiro;
            while (!(achouIgual || achouMaior) && (this.atual != null))
            {
                if (this.atual.Info.CompareTo(procurado) == 0)
                {
                    achouIgual = true;
                }
                else
                {
                    if (this.atual.Info.CompareTo(procurado) > 0)
                    {
                        achouMaior = true;
                    }
                    else
                    {
                        this.anterior = this.atual;
                        this.atual = this.atual.Prox;
                    }
                }
            }
            return achouIgual;
        }
      

        public void iniciarPercursoSequencial()
        {
            if (!estaVazia())
            {
                this.anterior = null;
                this.atual = this.primeiro;
                this.primeiroAcessoDoPercurso = true;
            }
        }
        public void insereAntesDoInicio(NoLista<Tipo> novoNo)
        {
            if (estaVazia())
            {
                this.ultimo = novoNo;
            }
            novoNo.Prox = this.primeiro;
            this.primeiro = novoNo;
            QtosNos++;
        }
        public void insereAposFim(NoLista<Tipo> novoNo)
        {
            if (estaVazia())
            {
                this.primeiro = novoNo;
            }
            else
            {
                this.ultimo.Prox = novoNo;
            }
            novoNo.Prox = null;
            this.ultimo = novoNo;
            QtosNos++;


        }
        public void insereAposNo(NoLista<Tipo> qualNo, NoLista<Tipo> novoNo)
        {
            if ((qualNo == null) || estaVazia())
            {
                throw new Exception("Local inválido para inserção");
            }
            novoNo.Prox = qualNo.Prox;
            qualNo.Prox = novoNo;
            QtosNos++;
            if (qualNo == this.ultimo)
            {
                this.ultimo = novoNo;
            }
        }

        public bool inserirEmOrdem(Tipo dados)
        {
            if (!existeDado(dados)) // existeChave configura anterior e atual
            { // aqui temos certeza de que a chave não existe
                if (estaVazia()) // se a lista está vazia, então o
                    insereAntesDoInicio(new NoLista<Tipo>(dados, null)); // novo nó é o primeiro da lista
                else
                if (anterior == null && atual != null)
                    insereAntesDoInicio(new NoLista<Tipo>(dados, null)); // liga novo antes do primeiro
                else
                    insereNoMeio(new NoLista<Tipo>(dados, null)); // insere entre os nós anterior e atual

                return true;  // significa que incluiu
            }
            return false;   // significa que não incluiu

            //throw new Exception("Aluno já cadastrado!");
        }
        public void listar(ListBox listbox)
        {
            listbox.Items.Clear();
            this.atual = this.primeiro;
            while (atual != null)
            {
                listbox.Items.Add(this.atual.Info.ToString());
                this.atual = this.atual.Prox;
            }



        }

        public bool podePercorrer()
        {
            if (atual == null)
            {
                return false;
            }
            else
            {
                if (this.primeiroAcessoDoPercurso)
                {
                    this.primeiroAcessoDoPercurso = false;
                    return true;
                }
                else
                {
                    this.anterior = this.atual;
                    this.atual = this.atual.Prox;
                    return (atual != null);
                }
            }
        }
        public Tipo removerPrimeiro() {
            if (estaVazia())
            {
                throw new Exception("Remoção em lista vazia");
            }
            Tipo Info = this.primeiro.Info;
            this.primeiro = this.primeiro.Prox;
            return Info;
        }
        public void removerNo(NoLista<Tipo> qualNo, NoLista<Tipo> noAnterior)
        {
            if (!estaVazia())
            {
                if (qualNo == this.primeiro)
                {
                    this.primeiro = this.primeiro.Prox;
                }
                    if (this.primeiro == null)
                    {
                        this.ultimo = null;
                        qualNo.Prox = null;
                    }
                    else
                    {
                        if (qualNo == this.ultimo)
                        {
                            noAnterior.Prox = null;
                            this.ultimo = noAnterior;
                        }
                        else
                        {
                            if (noAnterior != null)
                            {
                                noAnterior.Prox = qualNo.Prox;
                            }
                            qualNo.Prox = null;
                        }
                        
                    
                }
            qualNo = null;
            --QtosNos;
        }
        }
        public void removerNo()
        {
            this.removerNo(this.atual, this.anterior);
        }
        public void removerUltimoNo()
        {
            NoLista<Tipo> aux = null;
            iniciarPercursoSequencial();
            while (podePercorrer())
            {
                if (atual.Prox == ultimo)
                    aux = atual;
            }
            this.removerNo(this.ultimo, aux);
        }
        public int contarNos()
        {
            int contador = 0;
            iniciarPercursoSequencial();
            while (podePercorrer())
            {
                contador++;
            }
            return contador;
        }
        public ListaSimples<Tipo> casamento(ListaSimples<Tipo> outra)
        {
            ListaSimples<Tipo> nova = new ListaSimples<Tipo>();
            this.iniciarPercursoSequencial();
            outra.iniciarPercursoSequencial();
            while (!this.estaVazia() && !outra.estaVazia())
            {
                switch (outra.atual.Info.CompareTo(this.atual.Info))
                {
                    case -1:
                        outra.primeiro = outra.primeiro.Prox;
                        outra.atual.Prox = null;
                        nova.insereAposFim(outra.atual);
                        outra.atual = outra.primeiro;
                        outra.QtosNos--;
                        break;
                    case 0:
                        outra.primeiro = outra.primeiro.Prox;
                        outra.atual.Prox = null;
                        nova.insereAposFim(outra.atual);
                        outra.atual = outra.primeiro;
                        outra.QtosNos--;
                        break;
                    case 1:
                        this.primeiro = this.primeiro.Prox;
                        this.atual.Prox = null;
                        nova.insereAposFim(this.atual);
                        this.atual = this.primeiro;
                        this.QtosNos--;
                        break;
                }
            }
            if (this.estaVazia())
            {
                nova.ultimo.Prox = outra.primeiro;
                nova.ultimo = outra.ultimo;
                nova.QtosNos = nova.QtosNos + outra.QtosNos;
            }
            else
            {
                if (outra.estaVazia())
                {
                    nova.ultimo.Prox = this.primeiro;
                    nova.ultimo = this.ultimo;
                    nova.QtosNos += this.QtosNos;
                }

            }
            return nova;
        }
        public void inverter()
        {
            if (!this.estaVazia())
            {
                NoLista<Tipo> um = null;
                NoLista<Tipo> dois = null;
                NoLista<Tipo> tres = null;
                dois = this.primeiro;
                tres = this.primeiro.Prox;
                while (um != this.ultimo)
                {
                    dois.Prox = um;
                    um = dois;
                    dois = tres;
                    if (tres.Prox != null)
                    {
                        tres = tres.Prox;
                    }

                }
                tres = primeiro;
                primeiro = um;
                ultimo = tres;
            }
        }

        
        public void removerMenorNo(NoLista<Tipo> ant, NoLista<Tipo> qual)
        {
            if (ant == null)
            {
                this.primeiro = this.primeiro.Prox;
                if (this.primeiro == null)
                {
                    this.ultimo = null;
                }
                else
                {
                    if (qual == this.ultimo)
                    {
                        this.ultimo = ant;
                        ant.Prox = null;
                    }
                    else
                    {
                        ant.Prox = qual.Prox;
                        qual.Prox = null;
                    }
                    this.QtosNos--;
                }

            }
        }

        private void encontrarMenor(ref NoLista<Tipo> oAntMenor, ref NoLista<Tipo> oMenor)
        {
            oMenor = this.atual = this.primeiro;
            oAntMenor = this.anterior = null;
            while (atual != null)
            {
                if (atual.Info.CompareTo(oMenor.Info) < 0)
                {
                    oAntMenor = this.anterior;
                    oMenor = this.atual;
                }
                this.anterior = this.atual;
                this.atual = this.atual.Prox;
            }
        }
      
        public void ordenar()
        {
            NoLista<Tipo> menor = null, antMenor = null;
            ListaSimples<Tipo> ordenada = new ListaSimples<Tipo>();
            while (!estaVazia())
            {
                encontrarMenor(ref antMenor, ref menor);
                if (menor == this.ultimo)
                {
                    this.ultimo = antMenor;
                }

                if (antMenor != null)
                {
                    antMenor.Prox = menor.Prox;
                    menor.Prox = null;
                }
                else
                {
                    this.primeiro = menor.Prox;
                    menor.Prox = null;
                }
                this.qtdeNos--;
                ordenada.insereAposFim(menor);
                
            }
            this.primeiro = ordenada.primeiro;
            this.ultimo = ordenada.ultimo;
            this.QtosNos = ordenada.QtosNos;
        }

        public bool existeDado(Tipo outroProcurado)
        {
            this.anterior = null;
            this.atual = this.primeiro;
            if (estaVazia())
            {
                return false;
            }
            if (outroProcurado.CompareTo(this.primeiro.Info) < 0)
            {
                return false;
            }
            if (outroProcurado.CompareTo(this.ultimo.Info) > 0)
            {
                this.anterior = this.ultimo;
                this.atual = null;
                return false;
            }
            bool achou = false;
            bool fim = false;
            while (!achou && !fim)
            {
                if (atual == null)
                {
                    fim = true;
                }
                else
                {
                    if (outroProcurado.CompareTo(atual.Info) == 0)
                    {
                        achou = true;
                    }
                    else
                    {
                        if (atual.Info.CompareTo(outroProcurado) > 0)
                        {
                            fim = true;
                        }
                        else
                        {
                            this.anterior = this.atual;
                            this.atual = this.atual.Prox;
                        }
                    }
                }
            }
            return achou;
        }
        public bool existe(Tipo no)
        {
            if(no == null)
            {
                return true;
            }
            iniciarPercursoSequencial();
            while (podePercorrer())
            {
                if (atual.Info.Equals(no) )
                {
                    return true;
                }
            }
            return false;
        }
        private void insereNoMeio(NoLista<Tipo> novo)
        {
            this.anterior.Prox = novo;
            novo.Prox = this.atual;
            if (this.anterior == this.ultimo)
            {
                this.ultimo = novo;
            }
            QtosNos++;
        }
    }
}
