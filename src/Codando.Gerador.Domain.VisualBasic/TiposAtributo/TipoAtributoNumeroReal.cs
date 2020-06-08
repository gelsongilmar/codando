using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.TiposAtributo
{
    class TipoAtributoNumeroReal : TipoAtributoBaseGeracao
    {
        public override string ObterTipoBDCompleto(int p_tamanho, int p_precisao) => "Decimal(" + p_tamanho.ToString() + "," + p_precisao.ToString() + ")";
        public override string ObterTipoSqlDbType(int p_tamanho) => "Decimal";
        public override string ObterTipoVbNet() => "Decimal";
    }
}
