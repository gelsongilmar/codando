﻿using System;
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
        public bool IsPK { get; set; }
        public bool IsAutoIncremento { get; set; }

        public AtributoGerado(String nome)
        {
            this.Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
 