﻿using Codando.Gerador.Domain.Base;

namespace Codando.Gerador.Motor
{
    public class Gerador
    {
        private readonly Solucao _solucao;

        public Gerador(Solucao solucao)
        {
            _solucao = solucao;
        }

        public void Gerar()
        {

            new GeradorSolutionFile().Gerar(_solucao);

            foreach (var projeto in _solucao.Projetos)
            {
                
            }
        }
    }
}
