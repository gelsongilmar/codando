using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.TiposAtributo
{
    class TipoAtributoDataHora : TipoAtributoBaseGeracao
    {
        public override string ObterTipoBDCompleto(int p_tamanho, int p_precisao) => "DateTime";

        public override string ObterTipoSqlDbType(int p_tamanho) => "DateTime";

        public override string ObterTipoVbNet() => "DateTime";
    }
}
