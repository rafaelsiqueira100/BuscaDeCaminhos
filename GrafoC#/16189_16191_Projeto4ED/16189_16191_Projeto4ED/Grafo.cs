using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16189_16191_Projeto4ED
{
    class Grafo
    {
        private const int max_verts = 20;
        int infinity = 10000000;
        Vertice[] vertices;
        int[,] adjMatrix;
        int numVerts;
        DistOriginal[] percurso;
        int verticeAtual;       // global usada para indicar o vértice atualmente sendo visitado no algoritmo de Djikstra
        int doInicioAteAtual;   // global usada para ajustar menor caminho no algoritmo de Djikstra
        int nTree;

        public Grafo(DataGridView dgv)
        {
            vertices = new Vertice[max_verts];
            adjMatrix = new int[max_verts, max_verts];
            numVerts = 0;
            nTree = 0;

            for (int j = 0; j <= max_verts - 1; j++)
                for (int k = 0; k <= max_verts - 1; k++)
                    adjMatrix[j, k] = infinity;         // indica distância tão grande que não existe
            percurso = new DistOriginal[max_verts];
        }

        public void NovoVertice(string lab)
        {
            vertices[numVerts] = new Vertice(lab);
            numVerts++;
        }
        public int indice(string lab)
        {
            for(int i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].rotulo.Equals(lab))
                {
                    return i;
                }
            }
            throw new Exception("Não existe !");
        }

        public void NovaAresta(int origem, int destino, int peso)
        {
            adjMatrix[origem, destino] = peso;
        }

        public string Caminho(int inicioDoPercurso, int finalDoPercurso)
        {
            for (int j = 0; j < numVerts; j++)
                vertices[j].foiVisitado = false;

            vertices[inicioDoPercurso].foiVisitado = true;
            for (int j = 0; j < numVerts; j++)           
            {
                // anotamos no vetor percurso a distância entre o inicioDoPercurso e cada vértice
                // se não há ligação direta, o valor da distância será infinity
                int tempDist = adjMatrix[inicioDoPercurso, j];
                percurso[j] = new DistOriginal(inicioDoPercurso, tempDist);
            }

            for (nTree = 0; nTree < numVerts; nTree++)
            {
                // Procuramos a saída não visitada do vértice inicioDoPercurso 
                // com a menor distância
                int indiceDoMenor = ObterMenorDistancia();

                // e anotamos essa menor distância
                int distanciaMinima = percurso[indiceDoMenor].distancia;

                // o vértice com a menor distância passa a ser o vértice atual
                // para compararmos com a distância calculada em AjustarMenorCaminho()
                verticeAtual = indiceDoMenor;                               
                doInicioAteAtual = percurso[indiceDoMenor].distancia;

                // visitamos o vértice com a menor distância desde o 
                // inicioDoPercurso
                vertices[verticeAtual].foiVisitado = true;                  
                AjustarMenorCaminho();
            }

            return ExibirPercursos(inicioDoPercurso, finalDoPercurso);
        }

        public int ObterMenorDistancia()
        {
            int distanciaMinima = infinity;
            int indiceDaMinima = 0;
            for (int j = 0; j < numVerts; j++)
                if (!(vertices[j].foiVisitado) && (percurso[j].distancia < distanciaMinima))
                {
                    distanciaMinima = percurso[j].distancia;
                    indiceDaMinima = j;
                }
            return indiceDaMinima;
        }

        public void AjustarMenorCaminho()
        {
            for (int coluna = 0; coluna < numVerts; coluna++)
                if (!vertices[coluna].foiVisitado)     // para cada vértice ainda não visitado
                {
                    // acessamos a distância desde o vértice atual (pode ser infinity)
                    int atualAteMargem = adjMatrix[verticeAtual, coluna];

                    // calculamos a distância desde inicioDoPercurso passando por vertice atual até esta saída
                    int doInicioAteMargem = doInicioAteAtual + atualAteMargem;

                    // quando encontra uma distância menor, marca o vértice a partir do
                    // qual chegamos no vértice de índice coluna, e a soma da distância
                    // percorrida para nele chegar
                    int distanciaDoCaminho = percurso[coluna].distancia;
                    if (doInicioAteMargem < distanciaDoCaminho)
                    {                                                           
                        percurso[coluna].verticePai = verticeAtual;             
                        percurso[coluna].distancia = doInicioAteMargem;     
                        ExibirTabela();
                    }
                }
            Console.WriteLine("==================Caminho ajustado==============");
            Console.WriteLine();
        }

        public void ExibirTabela()
        {
            string dist = "";
            Console.WriteLine("Vértice\tVisitado?\tPeso\tVindo de");
            for (int i = 0; i < numVerts; i++)
            {
                if (percurso[i].distancia == infinity)
                    dist = "inf";
                else
                    dist = Convert.ToString(percurso[i].distancia);

                Console.WriteLine(vertices[i].rotulo + "\t" + vertices[i].foiVisitado +
                      "\t\t" + dist + "\t" + vertices[percurso[i].verticePai].rotulo);
            }
            Console.WriteLine("-----------------------------------------------------");
        }

        public string ExibirPercursos(int inicioDoPercurso, int finalDoPercurso)
        {
            string resultado = "";
            for (int j = 0; j < numVerts; j++)
            {
                resultado+=(vertices[j].rotulo + "=");
                if (percurso[j].distancia == infinity)
                    resultado += ("inf");
                else
                    resultado += (percurso[j].distancia);
                string pai = vertices[percurso[j].verticePai].rotulo;
                resultado += ("(" + pai + ") ");
            }
            resultado += "\n\n";

            resultado += ("Caminho entre " + vertices[inicioDoPercurso].rotulo +
                                       " e " + vertices[finalDoPercurso].rotulo);
            resultado += "\n\n";

            int onde = finalDoPercurso;
            Stack<string> pilha = new Stack<string>();

            pilha.Push(vertices[finalDoPercurso].rotulo); // empilha o vértice final
            int cont = 0;
            while (onde != inicioDoPercurso)
            {
                onde = percurso[onde].verticePai;
                pilha.Push(vertices[onde].rotulo);
                cont++;
            }

            while (pilha.Count != 0)
            {
                resultado += pilha.Pop();
                if (pilha.Count != 0)
                    resultado += " --> ";
            }

            if ((cont == 1) && (percurso[finalDoPercurso].distancia == infinity))
                resultado = "Não há caminho";
            //else
            //    resultado += " --> " + vertices[finalDoPercurso].rotulo;
            return resultado;
        }


    }
}
