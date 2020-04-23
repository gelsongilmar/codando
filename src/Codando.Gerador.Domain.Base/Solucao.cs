using Codando.Config;
using System.Collections.Generic;

namespace Codando.Gerador.Domain.Base
{
    public class Solucao
    {
        private readonly ConfigCodandoSolucao _configuracao;

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

        public string GetCaminhoCompletoSolucao(string extensao = ".sln")
        {
            return $"{GetDiretorioSolucao()}\\{GetNomeSolucao()}{extensao}";
        } 
    }
}
