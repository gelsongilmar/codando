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
            Solucao solucao = new Solucao(parametrosGeracao.ConfigSolucao);

            if (parametrosGeracao.GerarDAL) { 
                solucao.Projetos.Add(GetProjetoDAL(parametrosGeracao));
            }

            return solucao;
        }

        private Domain.Base.Projeto GetProjetoDAL(ParametrosGeracao parametrosGeracao)
        {
            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.CSharp)
            {
                Domain.Base.Projeto projeto = new Domain.CSharp.Projeto();
                return projeto;
            }
            
            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.VisualBasic)
            {
                Domain.Base.Projeto projeto = new Domain.VisualBasic.Projeto();

                return projeto;
            }

            return null;
        }

    }
}
