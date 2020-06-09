using Codando.Shared;
using System.Collections.Generic;

namespace Codando.Gerador.Domain.Base
{
    public abstract class Projeto
    {
        public string NomeProjeto { get; set; }
        public string ExtensaoProjeto { get; set; }
        public string GuIdTipoProjeto { get; set; }
        public string GuIdProjeto { get; set; }
        public IList<Pasta> Pastas { get; set; } = new List<Pasta>();

    }
}
