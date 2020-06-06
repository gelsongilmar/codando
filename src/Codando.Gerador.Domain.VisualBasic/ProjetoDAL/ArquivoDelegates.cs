using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoDelegates : Base.Arquivo
    {
        public ArquivoDelegates(String nome)
        {
            this.Nome = nome;
        }

        public override string GetConteudo()
        {
            var _str = new StringBuilder();

            _str.AppendLine("Imports System.Data.SqlClient");
            _str.AppendLine("");
            _str.AppendLine("Public Delegate Sub DelPreencherAtributos(dr As SqlDataReader)");
            _str.AppendLine("Public Delegate Sub DelPreencherIdentidade(cmd As SqlCommand)");
            _str.AppendLine("");

            return _str.ToString();
        }
    }
}
