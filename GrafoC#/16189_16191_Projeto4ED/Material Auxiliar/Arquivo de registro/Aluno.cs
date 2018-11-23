using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Arvores
{
    public class Aluno : IComparable<Aluno>
    {
        public const int tamanhoRA = 5;
        public const int tamanhoNome = 30;
        public const int tamanhoCurso = 2;
        public const int tamanhoPeriodo = 1;

        public readonly static int RaEmBytes = tamanhoRA * Marshal.SizeOf(typeof(char));
        public readonly static int NomeEmBytes = tamanhoNome * Marshal.SizeOf(typeof(char));
        public readonly static int CursoEmBytes = tamanhoCurso * Marshal.SizeOf(typeof(char));
        public readonly static int PeriodoEmBytes = tamanhoPeriodo * Marshal.SizeOf(typeof(int));
        public static readonly int tamanhoRegistro = RaEmBytes + NomeEmBytes +
                                                CursoEmBytes + PeriodoEmBytes;
            
        private String ra;        // máximo de  5 posições
        private String nome;      // máximo de 30 posições
        private String curso;     // máximo de  2 posições
        private int periodo;      // 4 bytes, segundo o padrão 

        public string Ra
        {
            get { return ra; }
            set {
                    ra = value;
                    // garante que o RA possua 5 dígitos
                    if (ra.Length > tamanhoRA)    // trunca caracteres além da 5a posição
                        ra = ra.Substring(0, 5);
                    while (ra.Length < tamanhoRA)
                        ra = "0" + ra;
                }
        }

        public string Nome
        {
            get { return nome; }
            set {
                    nome = value;
                    if (nome.Length > tamanhoNome)     // trunca caracteres além da 30a posição
                        nome = nome.Substring(0, tamanhoNome);
                    while (nome.Length < tamanhoNome)
                        nome = nome + " ";
                }
        }

        public string Curso
        {
            get { return curso; }
            set {
                   curso = value;
                   if (curso.Length > tamanhoCurso)     // trunca caracteres além da 30a posição
                      curso = curso.Substring(0, tamanhoCurso);
                   while (curso.Length <  tamanhoCurso)
                     curso = "0" + curso;
                }
        }

        public int Periodo
        {
            get { return periodo; }
            set { periodo = value; }
        }

        public Aluno(): this("", "", "", 0)
        {
        }

        public Aluno(String r, String n, String c, int p)
        {
            Ra = r;
            Nome = n;
            Curso = c;
            Periodo = p;
        }

        public override String ToString()
        {
            return Ra;
        }
    
        public int CompareTo(Aluno outro)
        {
           return Ra.CompareTo(outro.Ra); // compara strings
        }
    }
}
