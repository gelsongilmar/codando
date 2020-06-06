using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoEntidade : Base.Arquivo
    {
        public ArquivoEntidade(EntidadeGerada entidade)
        {
            this.Nome = entidade.Nome + ".vb";
        }

        public override string GetConteudo()
        {
            var _str = new StringBuilder();

            _str.AppendLine("Imports System.Data.SqlClient");
            _str.AppendLine("");
            _str.AppendLine("");

            return _str.ToString();
        }
    }
}
