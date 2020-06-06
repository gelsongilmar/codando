using Codando.Gerador.Domain.Base;
using Codando.Gerador.Domain.VisualBasic.ProjetoDAL;
using Codando.Shared;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    public class ProjetoDAL: Base.Projeto
    {
        public ProjetoDAL(Solucao solucao)
        {
            this.NomeProjeto = solucao.GetNomeSolucao() + ".DAL";
            this.ExtensaoProjeto = ".vbproj";
            this.ExtensaoCodigo = ".vb";
            this.GuIdTipoProjeto = "F184B08F-C81C-45F6-A57F-5ABD9991F28F";
            this.GuIdProjeto = Guid.NewGuid().ToString();

            this.Pastas = new List<Pasta>();
            this.Pastas.Add(this.GetPastaProjeto(solucao));

        }

        private Pasta GetPastaProjeto(Solucao solucao) {

            var pasta = new Pasta(this.NomeProjeto);
            pasta.AddSubPasta(this.GetPastaDelegates());
            pasta.AddSubPasta(this.GetPastaGeral());
            pasta.AddSubPasta(this.GetPastaInterface());

            foreach (var entidade in solucao.Entidades)
            {
                pasta.AddArquivo(new ArquivoEntidade(entidade));
            }

            return pasta;
        }

        private Pasta GetPastaDelegates()
        {

            var pasta = new Pasta("DELEGATES");
            pasta.AddArquivo(new ArquivoDelegates("Delegates.vb"));

            return pasta;
        }

        private Pasta GetPastaGeral()
        {

            var pasta = new Pasta("GERAL");

            return pasta;
        }

        private Pasta GetPastaInterface()
        {

            var pasta = new Pasta("INTERFACE");

            return pasta;
        }

    }
}
