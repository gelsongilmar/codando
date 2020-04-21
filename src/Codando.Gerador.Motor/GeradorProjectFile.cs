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
        public void Gerar(Solucao solucao)
        { 
            foreach (var projeto in solucao.Projetos)
            {
                this.CriarEstruturaProjeto(projeto);
                this.CriarArquivoProjeto(projeto);
            }
        }

        private void CriarEstruturaProjeto(Projeto projeto)
        {
            foreach (var pasta in projeto.Pastas)
            {
                CriarPasta(pasta);
            }
        }

        private void CriarArquivoProjeto(Projeto projeto)
        {
            
        }

        private void CriarPasta(Pasta pasta)
        {
            Diretorios.CriarSeNaoExiste(pasta.Nome);

            foreach (var subPasta in pasta.SubPastas)
            {
                CriarPasta(subPasta);
            }
        }
    }
}
