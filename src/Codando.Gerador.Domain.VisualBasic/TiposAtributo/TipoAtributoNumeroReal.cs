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
        public override string ObterTipoBDCompleto(ETipoAtributoGerado tipoAtributo, string p_tamanho, string p_precisao, string p_escala)
        {
            throw new NotImplementedException();
        }

        public override string ObterTipoSqlDbType(ETipoAtributoGerado tipoAtributo, string p_tamanho)
        {
            throw new NotImplementedException();
        }

        public override string ObterTipoVbNet(string p_nomeCampoBD)
        {
            throw new NotImplementedException();
        }
    }
}
