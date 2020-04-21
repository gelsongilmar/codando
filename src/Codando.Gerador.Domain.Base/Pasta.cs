using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.Base
{
    public class Pasta
    { 
        public string Nome { get; private set; }

        private readonly IList<Pasta> _subPastas;
        public IReadOnlyCollection<Pasta> SubPastas { get { return this._subPastas.ToArray(); } }

        public Pasta(string nome)
        {
            this.Nome = nome;
            this._subPastas = new List<Pasta>();
        }

        public void AddSubPasta(Pasta pasta)
        {
            this._subPastas.Add(pasta);
        }
    }
}
