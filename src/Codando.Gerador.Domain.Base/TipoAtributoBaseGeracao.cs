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
        public abstract string ObterTipoSqlDbType(int p_tamanho);
        public abstract string ObterTipoBDCompleto(int p_tamanho, int p_precisao);
        public abstract string ObterTipoVbNet();

    }
}
