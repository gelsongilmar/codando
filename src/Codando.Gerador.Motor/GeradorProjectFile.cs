using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Motor
{
    class GeradorProjectFile
    {
        private readonly Solucao _solucao;

        public GeradorProjectFile(Solucao solucao)
        {
            this._solucao = solucao;
        }

        public void Gerar()
        { 
            foreach (var projeto in _solucao.Projetos)
            {
                this.CriarEstruturaProjeto(projeto);
                this.CriarArquivoProjeto(projeto);
            }
        }

        private void CriarEstruturaProjeto(Projeto projeto)
        {
            Diretorios.CriarEstruturaPasta(projeto.Pastas, _solucao.GetDiretorioSolucao());
        }

        private void CriarArquivoProjeto(Projeto projeto)
        {
            
        }

    }
}
