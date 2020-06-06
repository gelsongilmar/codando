using System.Collections.Generic;
using System.Linq;

namespace Codando.Gerador.Domain.Base
{
    public class Pasta
    { 
        public string Nome { get; private set; }

        private readonly IList<Pasta> _subPastas;
        public IReadOnlyCollection<Pasta> SubPastas { get { return this._subPastas.ToArray(); } }

        private readonly IList<Arquivo> _arquivos;
        public IReadOnlyCollection<Arquivo> Arquivos { get { return this._arquivos.ToArray(); } }

        public Pasta(string nome)
        {
            this.Nome = nome;
            this._subPastas = new List<Pasta>();
            this._arquivos = new List<Arquivo>();
        }
        
        public void AddSubPasta(Pasta pasta)
        {
            this._subPastas.Add(pasta);
        }

        public void AddArquivo(Arquivo arquivo)
        {
            this._arquivos.Add(arquivo);
        }

    }
}
