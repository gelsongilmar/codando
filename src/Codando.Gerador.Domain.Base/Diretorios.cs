using Codando.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.Base
{
    public class Diretorios
    {
        public static void CriarPastaSeNaoExiste(string folder, ShowProgresso showProgresso)
        {
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
                showProgresso("Diretório " + folder + " gerado");
            }
        }

        public static void CriarEstruturaPasta(IList<Pasta> pastas, string local, ShowProgresso showProgresso)
        {
            foreach (var pasta in pastas)
            {
                CriarPasta(pasta, local, showProgresso);
            }
        }

        public static void CriarPasta(Pasta pasta, string local, ShowProgresso showProgresso)
        {
            var localCompleto = $"{local}\\{pasta.Nome}";
            CriarPastaSeNaoExiste(localCompleto, showProgresso);

            foreach (var subPasta in pasta.SubPastas)
            {
                CriarPasta(subPasta, localCompleto, showProgresso);
            }
        }

        public static void CriarArquivos(IReadOnlyCollection<Arquivo> arquivos, string local, ShowProgresso showProgresso)
        {
            foreach (var arquivo in arquivos)
            {
                if (arquivo.UsarArquivoSeparadoParaRegerar)
                {
                    GerarArquivoRegeravel(local, showProgresso, arquivo);
                    GerarArquivoNaoRegeravel(local, showProgresso, arquivo);
                }
                else
                {
                    GerarArquivoNaoRegeravel(local, showProgresso, arquivo);
                    GerarArquivoRegeravel(local, showProgresso, arquivo);

                }

            }
        }

        private static void GerarArquivoRegeravel(string local, ShowProgresso showProgresso, Arquivo arquivo)
        {
            var pathArquivo = "";
            if (arquivo.UsarArquivoSeparadoParaRegerar)
            {
                pathArquivo = local + "\\" + arquivo.Nome + ".codando" + arquivo.Extensao;
            }
            else
            {
                pathArquivo = local + "\\" + arquivo.Nome + arquivo.Extensao;

            }
            var conteudo = arquivo.GetConteudoRegerado();
            if (conteudo.Trim() != "")
            {
                SalvarArquivo(showProgresso, pathArquivo, conteudo);
            }
        }

        private static void GerarArquivoNaoRegeravel(string local, ShowProgresso showProgresso, Arquivo arquivo)
        {
            var pathArquivo = local + "\\" + arquivo.Nome + arquivo.Extensao;
            var conteudo = arquivo.GetConteudoGeradoApenasUmaVez();
            if (conteudo.Trim() != "")
            {
                if (!File.Exists(pathArquivo))
                {
                    SalvarArquivo(showProgresso, pathArquivo, conteudo);
                }
            }
        }

        private static void SalvarArquivo(ShowProgresso showProgresso, string pathArquivo, string conteudo)
        {
            using (var sw = new StreamWriter(pathArquivo, false))
            {
                sw.WriteLine(conteudo);
            }
            showProgresso("Arquivo " + pathArquivo + " gerado.");
        }
    }
}
