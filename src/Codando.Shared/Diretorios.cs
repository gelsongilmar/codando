using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Shared
{
   public class Diretorios
    {
        public static void CriarSeNaoExiste(string folder)
        {
            if (!System.IO.Directory.Exists(folder))
                System.IO.Directory.CreateDirectory(folder);
        }

        public static void CriarEstruturaPasta(IList<Pasta> pastas, string local)
        {
            foreach (var pasta in pastas)
            {
                CriarPasta(pasta, local);
            }
        }

        public static void CriarPasta(Pasta pasta, string local)
        {
            var localCompleto = $"{local}\\{pasta.Nome}";
            CriarSeNaoExiste(localCompleto);

            foreach (var subPasta in pasta.SubPastas)
            {
                CriarPasta(subPasta, localCompleto);
            }
        }
    }
}
