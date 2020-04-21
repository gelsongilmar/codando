using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.CSharp
{
    public class Projeto: Base.Projeto
    {
        public Projeto()
        {
            this.ExtensaoProjeto = ".csproj";
            this.ExtensaoCodigo = ".cs";
            this.GuIdTipoProjeto = "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC";
        }

    }
}
