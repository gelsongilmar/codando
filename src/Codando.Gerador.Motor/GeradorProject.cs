using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Motor
{
    class GeradorProject
    {
        private readonly Solucao _solucao;

        public GeradorProject(Solucao solucao)
        {
            this._solucao = solucao;
        }

        public void Gerar(ShowProgresso showProgresso)
        { 
            foreach (var projeto in _solucao.Projetos)
            {
                this.CriarEstruturaProjeto(projeto, showProgresso);
                this.CriarArquivoProjeto(projeto, showProgresso);
            }
        }

        private void CriarEstruturaProjeto(Projeto projeto, ShowProgresso showProgresso)
        {
            Diretorios.CriarEstruturaPasta(projeto.Pastas, _solucao.GetDiretorioSolucao(), showProgresso);
        }

        private void CriarArquivoProjeto(Projeto projeto, ShowProgresso showProgresso)
        {
            foreach (var pasta in projeto.Pastas)
            {
                this.CriarArquivosDaPasta(_solucao.GetDiretorioSolucao(), pasta, showProgresso);
            }

        }

        private void CriarArquivosDaPasta(String local, Pasta pasta, ShowProgresso showProgresso)
        {
            var localCompleto = local + "\\" + pasta.Nome;

            foreach (var subPasta in pasta.SubPastas)
            {
                CriarArquivosDaPasta(localCompleto, subPasta, showProgresso);
            }

            Diretorios.CriarArquivos(pasta.Arquivos, localCompleto, showProgresso);

        }

    }
}
