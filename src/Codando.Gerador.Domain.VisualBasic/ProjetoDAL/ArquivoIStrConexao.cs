using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoIStrConexao : Base.Arquivo
    {
        public ArquivoIStrConexao()
        {
            this.Nome = "IStrConexao";
            this.Extensao = ".vb";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            return "";
        }

        public override string GetConteudoRegerado()
        {
            var _str = new StringBuilder();
            _str.AppendLine("'================ [ IMPORTANTE ] ================");
            _str.AppendLine("' Arquivo Regerável. Não altere este arquivo.");
            _str.AppendLine("' As alterações serão perdidas sempre que o");
            _str.AppendLine("' Codando for executado");
            _str.AppendLine("'================================================");
            _str.AppendLine("");
            _str.AppendLine("Public Interface IStrConexao");
            _str.AppendLine("    Function ObterStrConexao() As String");
            _str.AppendLine("    Function ObterChaveCriptografia() As String");
            _str.AppendLine("End Interface");

            return _str.ToString();
        }
    }
}
