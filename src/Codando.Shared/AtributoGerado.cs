using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Shared
{
    public class AtributoGerado
    { 
        public String Nome { get; set; }
        public TipoAtributoBase Tipo { get; set; }
        public int Tamanho { get; set; }
        public int Precisao { get; set; }
        public bool IsPK { get; set; }
        public bool IsAutoIncremento { get; set; }
        public bool IsNulo { get; set; }

        public AtributoGerado(String nome)
        {
            this.Nome = nome;
            this.Tipo = new TipoAtributoBase();
            this.Tamanho = 100;
            this.IsNulo = true;
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
 