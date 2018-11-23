using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Arvores
{
    class RegistroAluno : Entidade<Aluno>
    {
        public override void LerRegistro(FileStream f, long posicao, ref Aluno dados)
        {
            byte[] nomeLido = new byte[Aluno.NomeEmBytes];
            byte[] raLido = new byte[Aluno.RaEmBytes];
            byte[] cursoLido = new byte[Aluno.CursoEmBytes];
            byte[] umInteiro = new byte[Aluno.PeriodoEmBytes];

            f.Seek(posicao * Aluno.tamanhoRegistro, SeekOrigin.Begin);

            f.Read(raLido, 0, Aluno.RaEmBytes);
            f.Read(nomeLido, 0, Aluno.NomeEmBytes);
            f.Read(cursoLido, 0, Aluno.CursoEmBytes);
            f.Read(umInteiro, 0, Aluno.PeriodoEmBytes);

            string Ra = "";
            for (int i = 0; i < Aluno.tamanhoRA; i++)
                Ra += Char.ConvertFromUtf32(raLido[i]);
            dados.Ra = Ra;

            string Nome = "";
            for (int i = 0; i < Aluno.tamanhoNome; i++)
                Nome += Char.ConvertFromUtf32(nomeLido[i]);
            dados.Nome = Nome;

            string Curso = "";
            for (int i = 0; i < Aluno.tamanhoCurso; i++)
                Curso += Char.ConvertFromUtf32(cursoLido[i]);
            dados.Curso = Curso;

           // if (BitConverter.IsLittleEndian)
           //     Array.Reverse(umInteiro);
            dados.Periodo = umInteiro[3]; // BitConverter.ToInt32(umInteiro, 0); 
        }

        public override void GravarRegistro(FileStream f, long posicao, Aluno dados)
        {
            try
            {
                f.Seek(posicao * Aluno.tamanhoRegistro, SeekOrigin.Begin);
            }
            finally
            {
                EscreverString(f, dados.Ra, Aluno.tamanhoRA);
                EscreverString(f, dados.Nome, Aluno.tamanhoNome);
                EscreverString(f, dados.Curso, Aluno.tamanhoCurso);

                byte[] intBytes = BitConverter.GetBytes(dados.Periodo);
                if (BitConverter.IsLittleEndian)
                    Array.Reverse(intBytes);
                byte[] result = intBytes;
                f.Write(result, 0, Aluno.PeriodoEmBytes);
            }
        }

        public override void EscreverString(FileStream f, String s, int tamanho)
        {
            StringBuilder cadeia = null;
            if (s != null)
                cadeia = new StringBuilder(s);
            else
                cadeia = new StringBuilder(tamanho);
            cadeia.Length = tamanho;
            Byte[] bytes = Encoding.ASCII.GetBytes(cadeia.ToString());
            f.Write(bytes, 0, tamanho);
        }
    }
}
