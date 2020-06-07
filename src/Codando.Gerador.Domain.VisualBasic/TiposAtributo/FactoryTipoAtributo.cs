using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.TiposAtributo
{
    public class FactoryTipoAtributo
    {
        public TipoAtributoBaseGeracao GetTipoAtributo(TipoAtributoBase tipo) {

            switch (tipo.Tipo)
            {
                case ETipoAtributoGerado.Logico: return new TipoAtributoLogico();
                case ETipoAtributoGerado.Data: return new TipoAtributoData();
                case ETipoAtributoGerado.DataHora: return new TipoAtributoDataHora();
                case ETipoAtributoGerado.NumeralReal: return new TipoAtributoNumeroReal();
                case ETipoAtributoGerado.NumeralInteiro: return new TipoAtributoNumeroInteiro();
                case ETipoAtributoGerado.Texto: return new TipoAtributoTexto();
                case ETipoAtributoGerado.Literal: return new TipoAtributoLiteral();
            }
            return null;
        }
    }
}
