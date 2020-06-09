using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Linq;
using System.Text;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoBD
{
    internal class ArquivoProcedureList : Arquivo
    {
        private EntidadeGerada _entidade;

        public ArquivoProcedureList(EntidadeGerada entidade)
        {
            this._entidade = entidade;
            this.UsarArquivoSeparadoParaRegerar = false;
            this.Nome = "usp_" + this._entidade.Nome + "_List";
            this.Extensao = ".sql";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            return "";
        }

        public override string GetConteudoRegerado()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("--================ [ IMPORTANTE ] ================");
            _str.AppendLine("-- Arquivo Regerável. Não altere este arquivo.");
            _str.AppendLine("-- As alterações serão perdidas sempre que o");
            _str.AppendLine("-- Codando for executado");
            _str.AppendLine("--================================================");
            _str.AppendLine("");
            _str.AppendLine("CREATE PROCEDURE " + this.Nome);
            _str.AppendLine("AS ");
            _str.AppendLine("    SELECT *  ");
            _str.AppendLine("    FROM " + this._entidade.Nome);

            return _str.ToString();
        }

    }
}
