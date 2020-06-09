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
        public bool GerouConteudoRegerado { get; set; } = false;
        public bool GerouConteudoGeradoApenasUmaVez { get; set; } = false;

        public abstract String GetConteudoRegerado();
        public abstract String GetConteudoGeradoApenasUmaVez();

        public string GetNomeParaSalvarRegeravel()
        {

            if (this.UsarArquivoSeparadoParaRegerar)
            {
                return Nome + ".codando" + Extensao;
            }
            else
            {
                return Nome + Extensao;

            }
        }

        public string GetNomeParaSalvarGeradoUmaVEz()
        {
            return Nome + Extensao;
        }

    }
}
