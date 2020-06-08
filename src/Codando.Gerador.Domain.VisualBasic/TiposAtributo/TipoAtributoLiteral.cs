using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.TiposAtributo
{
    class TipoAtributoLiteral : TipoAtributoBaseGeracao
    {
        public override string ObterTipoBDCompleto(int p_tamanho, int p_precisao)
        {
            if (p_tamanho < 0)
            {
                return "Varchar(MAX)";
            }
            else
            {
                return "Varchar(" + p_tamanho.ToString() + ")";
            }
        }

        public override string ObterTipoSqlDbType(int p_tamanho)
        {
            if (p_tamanho < 0) {
                p_tamanho = -1;
            }
            return "VarChar, " + p_tamanho.ToString();
        }

        public override string ObterTipoVbNet() => "String";
    }
}
