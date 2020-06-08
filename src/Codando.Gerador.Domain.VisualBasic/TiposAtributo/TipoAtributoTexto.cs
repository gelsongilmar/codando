using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.TiposAtributo
{
    class TipoAtributoTexto : TipoAtributoBaseGeracao
    {
        public override string ObterTipoBDCompleto(int p_tamanho, int p_precisao) => "Text";
        public override string ObterTipoSqlDbType(int p_tamanho) => "Text";
        public override string ObterTipoVbNet() => "String";
    }
}
