using Codando.Gerador.Domain.Base;
using Codando.Shared;

namespace Codando.Gerador.Motor
{
    public class Gerador
    {
        private readonly Solucao _solucao;

        public Gerador(Solucao solucao)
        {
            _solucao = solucao;
        }

        public void Gerar(ShowProgresso showProgresso)
        { 
            new GeradorSolution(_solucao).Gerar(showProgresso);
            new GeradorProject(_solucao).Gerar(showProgresso);
        }
    }
}
