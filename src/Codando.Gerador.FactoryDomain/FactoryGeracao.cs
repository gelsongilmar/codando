using Codando.Gerador.Domain.Base;
using Codando.Shared;
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
            solucao.Entidades = DefinirTiposAtributos(parametrosGeracao);
            solucao.Projetos.Add(GetProjetoBD(parametrosGeracao, solucao));
            solucao.Projetos.Add(GetProjetoDAL(parametrosGeracao, solucao));
            return solucao;

        }

        private List<EntidadeGerada> DefinirTiposAtributos(ParametrosGeracao parametrosGeracao)
        {
            var ret = new List<EntidadeGerada>();
            foreach (var e in parametrosGeracao.ConfigSolucao.Entidades)
            {
                foreach (var a in e.Atributos)
                {
                    if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.CSharp)
                    {
                        //TODO: Falta Fazer Para CSharp
                    }

                    if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.VisualBasic)
                    {
                        a.Tipo = new Domain.VisualBasic.TiposAtributo.FactoryTipoAtributo().GetTipoAtributo(a.Tipo);
                    }

                }
                ret.Add(e);

            }
            return ret;
        }

        private Projeto GetProjetoBD(ParametrosGeracao parametrosGeracao, Solucao solucao)
        {
            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.CSharp)
            {
                
            }

            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.VisualBasic)
            {
                var projeto = new Domain.VisualBasic.ProjetoBD.ProjetoBD(solucao);
                return projeto;
            }

            return null;
        }

        private Domain.Base.Projeto GetProjetoDAL(ParametrosGeracao parametrosGeracao, Solucao solucao)
        {
            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.CSharp)
            {
                var projeto = new Domain.CSharp.Projeto();
                return projeto;
            }
            
            if (parametrosGeracao.LinguagemGeracao == LinguagemGeracao.VisualBasic)
            {
                var projeto = new Domain.VisualBasic.ProjetoDAL.ProjetoDAL(solucao);
                return projeto;
            }

            return null;
        }

    }
}
