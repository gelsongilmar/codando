using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoWeb
{
    public class ProjetoWeb: Base.Projeto
    {
        public ProjetoWeb(Solucao solucao)
        {
            this.NomeProjeto = solucao.GetNomeSolucao() + ".Web";
            this.ExtensaoProjeto = ".vbproj";
            this.GuIdTipoProjeto = "F184B08F-C81C-45F6-A57F-5ABD9991F28F";
            this.GuIdProjeto = Guid.NewGuid().ToString();

            this.Pastas = new List<Pasta>();
            this.Pastas.Add(this.GetPastaProjeto(solucao));

        }

        private Pasta GetPastaProjeto(Solucao solucao) {

            var pasta = new Pasta(this.NomeProjeto);
            
            pasta.AddArquivo(new ArquivoVbProj(this));
            return pasta;
        }

    }
}
