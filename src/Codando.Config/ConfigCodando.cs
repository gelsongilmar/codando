using System.Collections.Generic;

namespace Codando.Config
{
    public class ConfigCodando
    {
        public List<ConfigCodandoSolucao> Solucoes { get; set; }

        public ConfigCodando()
        {
            Solucoes = new List<ConfigCodandoSolucao>();
        }
    }
}
