using Newtonsoft.Json;
using System;
using System.IO;

namespace Codando.Config
{
    public class Configuracao
    {
        private readonly string _diretorioConfigCodando = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\codando\configs";
        private readonly string _nomeArquivo = "codando.config";

        public Configuracao()
        {
            CriarPasta();
        }

        public ConfigCodando GetConfigCodando()
        {
            string caminho = $"{_diretorioConfigCodando}\\{_nomeArquivo}";
            if (!File.Exists(caminho)) return new ConfigCodando();

            string json = "";
            using (var sr = new StreamReader(caminho))
            {
                json = sr.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<ConfigCodando>(json);
        }

        public void AtualizarConfigCodando(ConfigCodando configCodando)
        {
            string caminho = $"{_diretorioConfigCodando}\\{_nomeArquivo}";
            using (var sw = new StreamWriter(caminho, false))
            {
                sw.WriteLine(JsonConvert.SerializeObject(configCodando, Formatting.Indented));
            }
        }

        private void CriarPasta()
        {
            if (!Directory.Exists(_diretorioConfigCodando))
                Directory.CreateDirectory(_diretorioConfigCodando);
        }
    }
}
