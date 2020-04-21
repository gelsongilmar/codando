using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codando.Gerador.Domain.Base;

namespace Codando.Gerador.Domain.VisualBasic
{
    public class Projeto: Base.Projeto
    {
        public Projeto()
        {
            this.ExtensaoProjeto = ".vbproj";
            this.ExtensaoCodigo = ".vb";
            this.GuIdTipoProjeto = "F184B08F-C81C-45F6-A57F-5ABD9991F28F";
        }

    }
}
