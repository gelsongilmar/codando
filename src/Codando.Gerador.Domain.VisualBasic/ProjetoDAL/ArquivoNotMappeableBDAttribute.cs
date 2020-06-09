using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoNotMappeableBDAttribute : Base.Arquivo
    {
        public ArquivoNotMappeableBDAttribute()
        {
            this.Nome = "NotMappeableBDAttribute";
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
            _str.AppendLine("Public Class NotMappeableBDAttribute");
            _str.AppendLine("    Inherits Attribute");
            _str.AppendLine("End Class");

            return _str.ToString();
        }
    }
}
