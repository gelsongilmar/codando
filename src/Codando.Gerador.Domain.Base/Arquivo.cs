using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.Base
{
    public abstract class Arquivo
    {
        public String Nome { get; set; }

        public abstract String GetConteudo();

    }
}
