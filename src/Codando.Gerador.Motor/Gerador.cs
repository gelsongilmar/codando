using Codando.Gerador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Motor
{
    public class Gerador
    {
        private Solucao _solucao;

        public Gerador(Solucao solucao)
        {
            _solucao = solucao;
        }

        public void gerar() {

            new GeradorSolutionFile().gerar(_solucao);

        }
    }
}
