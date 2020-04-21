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
