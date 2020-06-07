using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.Base
{
    public abstract class TipoAtributoBaseGeracao : TipoAtributoBase
    {
        public abstract string ObterTipoSqlDbType(ETipoAtributoGerado tipoAtributo, string p_tamanho);
        public abstract string ObterTipoBDCompleto(ETipoAtributoGerado tipoAtributo, string p_tamanho, string p_precisao, string p_escala);
        public abstract string ObterTipoVbNet(string p_nomeCampoBD);

    }
}
