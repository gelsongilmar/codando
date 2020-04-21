using Codando.Gerador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.FactoryDomain
{
    public class FactoryGeracao
    {
        public Solucao GetSolucao(ParametrosGeracao parametrosGeracao) {
            var solucao = new Solucao(parametrosGeracao.ConfigSolucao);

            if (parametrosGeracao.GerarDAL) { 
                solucao.Projetos.Add(GetProjetoDAL(parametrosGeracao));
            }

            return solucao;
        }

        private Domain.Base.Projeto GetProjetoDAL(ParametrosGeracao parametrosGeracao)
        {
            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.CSharp)
            {
                var projeto = new Domain.CSharp.Projeto();
                return projeto;
            }
            
            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.VisualBasic)
            {
                var projeto = new Domain.VisualBasic.Projeto();

                return projeto;
            }

            return null;
        }

    }
}
