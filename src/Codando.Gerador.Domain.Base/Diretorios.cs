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
            if (!System.IO.Directory.Exists(folder)) {
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
                using (var sw = new StreamWriter(local + "\\" + arquivo.Nome, false))
                {
                    sw.WriteLine(arquivo.GetConteudo());
                }
                showProgresso("Arquivo " + arquivo.Nome + " gerado em " + local);
            }
        }

    }
}
