using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Config
{
    public class ConfigCodando
    {
        public List<SolucaoCodando> Solucoes { get; set; }

        public ConfigCodando()
        {
            Solucoes = new List<SolucaoCodando>();
        }
    }
}
