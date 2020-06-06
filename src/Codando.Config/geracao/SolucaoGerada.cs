using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Config.geracao
{
    public class SolucaoGerada
    {
        public SolucaoCodando SolucaoCodando { get; set; }
        public String NomeGeracao { get; set; }

        public List<EntidadeGerada> Entidades { get; set; }

        public SolucaoGerada()
        {
            Entidades = new List<EntidadeGerada>();
        }
    }
}
