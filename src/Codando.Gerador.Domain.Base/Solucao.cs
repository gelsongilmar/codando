using Codando.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.Base
{
    public class Solucao
    {
        private ConfigCodandoSolucao _configuracao;

        public List<Projeto> Projetos { get; set; }

        public Solucao(ConfigCodandoSolucao configuracao)
        {
            _configuracao = configuracao;
            this.Projetos = new List<Projeto>();
        }

        public string GetNomeSolucao()
        {
            return _configuracao.NomeSolucao;
        }

        public string GetDiretorioSolucao()
        {
            return _configuracao.PastaGeracaoSolucao;
        }

    }
}
