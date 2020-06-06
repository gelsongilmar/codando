using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System.IO;
using System.Text;

namespace Codando.Gerador.Motor
{
    class GeradorSolution
    {
        private readonly Solucao _solucao;

        public GeradorSolution(Solucao solucao)
        {
            this._solucao = solucao;
        }

        public void Gerar(ShowProgresso showProgresso)
        {
            var _str = new StringBuilder();

            _str.AppendLine("");
            _str.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            _str.AppendLine("# Visual Studio Version 16");
            _str.AppendLine("VisualStudioVersion = 16.0.30002.166");
            _str.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");

            foreach (Projeto proj in _solucao.Projetos)
            {
                _str.AppendLine("Project(\"{" + proj.GuIdTipoProjeto + "}\") = \"" + proj.NomeProjeto + "\", \"" + proj.NomeProjeto + "\\" + proj.NomeProjeto + proj.ExtensaoProjeto + "\", \"{" + proj.GuIdProjeto + "}\"");
                _str.AppendLine("EndProject");
            }

            _str.AppendLine("Global");
            _str.AppendLine("	GlobalSection(SolutionConfigurationPlatforms) = preSolution");
            _str.AppendLine("		Debug|Any CPU = Debug|Any CPU");
            _str.AppendLine("		Release|Any CPU = Release|Any CPU");
            _str.AppendLine("	EndGlobalSection");
            _str.AppendLine("	GlobalSection(ProjectConfigurationPlatforms) = postSolution");

            foreach (Projeto proj in _solucao.Projetos)
            {
                _str.AppendLine("		{" + proj.GuIdProjeto + "}.Debug|Any CPU.ActiveCfg = Debug|Any CPU");
                _str.AppendLine("		{" + proj.GuIdProjeto + "}.Debug|Any CPU.Build.0 = Debug|Any CPU");
                _str.AppendLine("		{" + proj.GuIdProjeto + "}.Release|Any CPU.ActiveCfg = Release|Any CPU");
                _str.AppendLine("		{" + proj.GuIdProjeto + "}.Release|Any CPU.Build.0 = Release|Any CPU");

            }

            _str.AppendLine("	EndGlobalSection");
            _str.AppendLine("	GlobalSection(SolutionProperties) = preSolution");
            _str.AppendLine("		HideSolutionNode = FALSE");
            _str.AppendLine("	EndGlobalSection");
            _str.AppendLine("	GlobalSection(ExtensibilityGlobals) = postSolution");
            _str.AppendLine("		SolutionGuid = {7FCB79FD-6ADE-4BA0-849D-53B4718D1052}");
            _str.AppendLine("	EndGlobalSection");
            _str.AppendLine("EndGlobal");
            _str.AppendLine("");

            using (var sw = new StreamWriter(_solucao.GetCaminhoCompletoSolucao(), false))
            {
                sw.WriteLine(_str.ToString());
            }
            showProgresso("Arquivo gerado " + _solucao.GetCaminhoCompletoSolucao());
        }
    }
}
