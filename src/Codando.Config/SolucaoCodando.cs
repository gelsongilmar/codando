using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Config
{
    public class SolucaoCodando
    {
        public string NomeSolucao { get; set; }

        public string PastaGeracaoSolucao { get; set; }

        public override string ToString()
        {
            return NomeSolucao;
        }

    }
}
