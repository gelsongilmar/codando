using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Config
{
    public class Configuracao
    {
        string _diretorioConfigCodando = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\codando\configs";
        string _nomeArquivo = "codando.config";

        public Configuracao()
        {
            CriarPasta();
        }

        public ConfigCodando GetConfigCodando()
        {
            string caminho = $"{_diretorioConfigCodando}\\{_nomeArquivo}";
            if (!System.IO.File.Exists(caminho)) return new ConfigCodando();

            string json = "";

            System.IO.StreamReader sr = new System.IO.StreamReader(caminho);
            try
            {
                json = sr.ReadToEnd();
            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }

            return JsonConvert.DeserializeObject<ConfigCodando>(json);
        }

        public void AtualizarConfigCodando(ConfigCodando configCodando)
        {
            string caminho = $"{_diretorioConfigCodando}\\{_nomeArquivo}";
            System.IO.File.Delete(caminho);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(caminho);
            try
            {
                sw.WriteLine(JsonConvert.SerializeObject(configCodando));
            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
        }

        private void CriarPasta()
        {
            if (!System.IO.Directory.Exists(_diretorioConfigCodando))
            {
                System.IO.Directory.CreateDirectory(_diretorioConfigCodando);
            }
        }

    }
}
