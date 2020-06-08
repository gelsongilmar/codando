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
        public String Extensao { get; set; }
        public bool UsarArquivoSeparadoParaRegerar { get; set; } = true;

        public abstract String GetConteudoRegerado();
        public abstract String GetConteudoGeradoApenasUmaVez();

    }
}
