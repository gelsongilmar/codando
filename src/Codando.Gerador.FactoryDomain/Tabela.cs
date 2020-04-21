using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.FactoryDomain
{
    public class Tabela
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Tabela(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

    }
}
