using Arvores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _16189_16191_Projeto4ED
{
    class RegistroCidade : Entidade<Cidade>
    {
        public override void EscreverString(FileStream f, string s, int tamanho)
        {
            StringBuilder cadeia = null;

            if (s != null)
                cadeia = new StringBuilder(s);
            else
                cadeia = new StringBuilder(tamanho);

            cadeia.Length = tamanho;

            byte[] bytes = Encoding.ASCII.GetBytes(cadeia.ToString());

            f.Write(bytes, 0, tamanho);
        }

        public override void GravarRegistro(FileStream f, long posicao, Cidade dados)
        {
            try
            {
                f.Seek(posicao * Cidade.tamanhoRegistro, SeekOrigin.Begin);
            }
            finally
            {
                EscreverString(f, dados.Nome, Cidade.tamanhoNome);
            }
        }

        public override void LerRegistro(FileStream f, long posicao, ref Cidade dados)
        {
            byte[] nomeLido = new byte[Cidade.NomeEmBytes];

            f.Seek(posicao * Cidade.tamanhoRegistro, SeekOrigin.Begin);

            f.Read(nomeLido, 0, Cidade.NomeEmBytes);

            string nome = "";

            foreach (byte caracter in nomeLido)
                nome += char.ConvertFromUtf32(caracter);

            //for (int i = 0; i < Cidade.tamanhoNome; i++)
            //  nome += Char.ConvertFromUtf32(nomeLido[i]);

            dados.Nome = nome;
        }
    }
}
