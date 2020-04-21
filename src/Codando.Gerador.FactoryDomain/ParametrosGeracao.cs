using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.FactoryDomain
{
    public class ParametrosGeracao
    {
        public Config.ConfigCodandoSolucao ConfigSolucao { get; set; }  
        public List<Tabela> TabelasSelecionadas { get; set; }
        public LinguagemGeracao LinguagemGeracao { get; set; }
        public bool GerarDAL { get; set; }
        public bool GerarTabelas { get; set; }
        public bool GerarProcedures { get; set; }

        public ParametrosGeracao()
        {
            this.TabelasSelecionadas = new List<Tabela>();
        }
    }
}
