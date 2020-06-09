using Codando.Gerador.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoBD
{
    public class ProjetoBD : Base.Projeto
    {
        public ProjetoBD(Solucao solucao)
        {
            this.NomeProjeto = solucao.GetNomeSolucao() + ".BD";
            this.ExtensaoProjeto = ".sqlproj";
            this.GuIdTipoProjeto = "00D1A9C2-B5F0-4AF3-8072-F6C62B433612";
            this.GuIdProjeto = Guid.NewGuid().ToString();

            this.Pastas = new List<Pasta>();
            this.Pastas.Add(this.GetPastaProjeto(solucao));

        }

        private Pasta GetPastaProjeto(Solucao solucao)
        {

            var pasta = new Pasta(this.NomeProjeto);
            pasta.AddSubPasta(this.GetTabelas(solucao));
            pasta.AddSubPasta(this.GetPastaProcedure(solucao));

            pasta.AddArquivo(new ArquivoSqlProj(this));
            return pasta;
        }

        private Pasta GetPastaProcedure(Solucao solucao)
        {
            var pasta = new Pasta("Procedures");

            return pasta;
        }

        private Pasta GetTabelas(Solucao solucao)
        {
            var pasta = new Pasta("Tabelas");

            foreach (var entidade in solucao.Entidades)
            {
                pasta.AddArquivo(new ArquivoTabela(entidade));
            }

            return pasta;
        }
    }

}
