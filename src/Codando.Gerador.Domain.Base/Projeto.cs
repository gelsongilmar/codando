using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.Base
{
    public abstract class Projeto
    {
        public string NomeProjeto { get; set; }
        public string ExtensaoProjeto { get; set; }
        public string ExtensaoCodigo { get; set; }
        public string GuIdTipoProjeto { get; set; }
        public string GuIdProjeto { get; set; }

    }
}
