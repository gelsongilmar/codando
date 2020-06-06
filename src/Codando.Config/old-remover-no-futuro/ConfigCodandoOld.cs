using System.Collections.Generic;

namespace Codando.Config
{
    public class ConfigCodandoOld
    {
        public List<ConfigCodandoSolucaoOld> Solucoes { get; set; }
        
        public ConfigCodandoOld()
        {
            Solucoes = new List<ConfigCodandoSolucaoOld>();
        }
    }
}
