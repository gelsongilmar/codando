using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Shared
{
    public class TipoAtributoBase
    {
        public ETipoAtributoGerado Tipo { get; set; }

        public TipoAtributoBase()
        {
            this.Tipo = ETipoAtributoGerado.Literal;
        }
    }
}
