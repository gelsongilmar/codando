﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Shared
{
    public class EntidadeGerada
    {
        public String Nome { get; set; }
        public List<AtributoGerado> Atributos { get; set; }

        public EntidadeGerada(String nome)
        {
            this.Nome = nome;
            this.Atributos = new List<AtributoGerado>();
        }

        public override string ToString()
        {
            return Nome;
        }

    }
}
