namespace Codando.Config
{
    public class ConfigCodandoSolucao
    {
        public string NomeSolucao { get; set; }
        public string Host { get; set; }
        public string Instancia { get; set; }
        public string NomeBancoDados { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string NamespacePrincipal { get; set; }
        public string PastaGeracaoSolucao { get; set; }
                 
        public override string ToString() 
        {
            return NomeSolucao;
        }

    }
}
