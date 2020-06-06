﻿using Codando.Config.geracao;
using System.Collections.Generic;

namespace Codando.Gerador.Domain.Base
{
    public class Solucao
    {
        private readonly SolucaoGerada _configuracao;

        public List<Projeto> Projetos { get; set; }

        public Solucao(SolucaoGerada configuracao)
        {
            _configuracao = configuracao;
            this.Projetos = new List<Projeto>();
        }

        public string GetNomeSolucao()
        {
            return _configuracao.NomeGeracao;
        }

        public string GetDiretorioSolucao()
        {
            return _configuracao.SolucaoCodando.PastaGeracaoSolucao;
        }

        public string GetCaminhoCompletoSolucao(string extensao = ".sln")
        {
            return $"{GetDiretorioSolucao()}\\{GetNomeSolucao()}{extensao}";
        } 
    }
}
