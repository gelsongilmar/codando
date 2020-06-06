using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Codando.Gerador.Domain.VisualBasic
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

            var pasta = new Pasta(this.NomeProjeto);
            pasta.AddSubPasta(new Pasta("DELEGATES"));
            pasta.AddSubPasta(new Pasta("GERAL"));
            pasta.AddSubPasta(new Pasta("INTERFACE"));

            this.Pastas = new List<Pasta>();
            this.Pastas.Add(pasta);

        }

    }
}
