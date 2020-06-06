using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Config.geracao
{
    public class ConfiguracaoGeracao
    {
        private SolucaoCodando _solucaoCodando;
        private readonly string _nomeArquivo = "codando.config";

        public ConfiguracaoGeracao(SolucaoCodando solucaoCodando)
        {
            _solucaoCodando = solucaoCodando;
            CriarPasta();
        }

        public SolucaoGerada GetConfig()
        {
            string caminho = $"{_solucaoCodando.PastaGeracaoSolucao }\\{_nomeArquivo}";
            if (!File.Exists(caminho)) return new SolucaoGerada();

            string json = "";
            using (var sr = new StreamReader(caminho))
            {
                json = sr.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<SolucaoGerada>(json);
        }

        public void SetConfig(SolucaoGerada solucao)
        {
            string caminho = $"{_solucaoCodando.PastaGeracaoSolucao}\\{_nomeArquivo}";
            using (var sw = new StreamWriter(caminho, false))
            {
                sw.WriteLine(JsonConvert.SerializeObject(solucao, Formatting.Indented));
            }
        }

        private void CriarPasta()
        {
            if (!Directory.Exists(_solucaoCodando.PastaGeracaoSolucao))
                Directory.CreateDirectory(_solucaoCodando.PastaGeracaoSolucao);
        }
    }
}
