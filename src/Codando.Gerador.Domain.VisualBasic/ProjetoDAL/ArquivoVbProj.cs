using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoVbProj : Base.Arquivo
    {

        private Projeto _projeto;

        public ArquivoVbProj(Projeto projeto)
        {
            this.UsarArquivoSeparadoParaRegerar = false;
            this._projeto = projeto;
            this.Nome = this._projeto.NomeProjeto;
            this.Extensao = ".vbproj";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            return "";
        }

        public override string GetConteudoRegerado()
        {
            var _str = new StringBuilder();

            _str.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            _str.AppendLine("<Project ToolsVersion=\"15.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">");
            _str.AppendLine("  <Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />");

            _str.AppendLine("  <PropertyGroup>");
            _str.AppendLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
            _str.AppendLine("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>");
            _str.AppendLine("    <ProjectGuid>{" + this._projeto.GuIdProjeto + "}</ProjectGuid>");
            _str.AppendLine("    <OutputType>Library</OutputType>");
            _str.AppendLine("    <RootNamespace>" + this._projeto.NomeProjeto + "</RootNamespace>");
            _str.AppendLine("    <AssemblyName>" + this._projeto.NomeProjeto + "</AssemblyName>");
            _str.AppendLine("    <FileAlignment>512</FileAlignment>");
            _str.AppendLine("    <MyType>Windows</MyType>");
            _str.AppendLine("    <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>");
            _str.AppendLine("    <Deterministic>true</Deterministic>");
            _str.AppendLine("    <SccProjectName>SAK</SccProjectName>");
            _str.AppendLine("    <SccLocalPath>SAK</SccLocalPath>");
            _str.AppendLine("    <SccAuxPath>SAK</SccAuxPath>");
            _str.AppendLine("    <SccProvider>SAK</SccProvider>");
            _str.AppendLine("    <TargetFrameworkProfile />");
            _str.AppendLine("  </PropertyGroup>");


            _str.AppendLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">");
            _str.AppendLine("    <DebugSymbols>true</DebugSymbols>");
            _str.AppendLine("    <DebugType>full</DebugType>");
            _str.AppendLine("    <DefineDebug>true</DefineDebug>");
            _str.AppendLine("    <DefineTrace>true</DefineTrace>");
            _str.AppendLine("    <OutputPath>bin\\Debug\\</OutputPath>");
            _str.AppendLine("    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">");
            _str.AppendLine("    <DebugType>pdbonly</DebugType>");
            _str.AppendLine("    <DefineDebug>false</DefineDebug>");
            _str.AppendLine("    <DefineTrace>true</DefineTrace>");
            _str.AppendLine("    <Optimize>true</Optimize>");
            _str.AppendLine("    <OutputPath>bin\\Release\\</OutputPath>");
            _str.AppendLine("    <NoWarn>42016,41999,42017,42018,42019,42032,42036,42020,42021,42022</NoWarn>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup>");
            _str.AppendLine("    <OptionExplicit>On</OptionExplicit>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup>");
            _str.AppendLine("    <OptionCompare>Binary</OptionCompare>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup>");
            _str.AppendLine("    <OptionStrict>Off</OptionStrict>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup>");
            _str.AppendLine("    <OptionInfer>On</OptionInfer>");
            _str.AppendLine("  </PropertyGroup>");

            _str.AppendLine("  <ItemGroup>");
            _str.AppendLine("    <Reference Include=\"System\" />");
            _str.AppendLine("    <Reference Include=\"System.Data\" />");
            _str.AppendLine("  </ItemGroup>");

            _str.AppendLine("  <ItemGroup>");
            _str.AppendLine("    <Import Include=\"Microsoft.VisualBasic\" />");
            _str.AppendLine("    <Import Include=\"System\" />");
            _str.AppendLine("    <Import Include=\"System.Data\" />");
            _str.AppendLine("    <Import Include=\"System.Linq\" />");
            _str.AppendLine("  </ItemGroup>");

            _str.AppendLine("  <ItemGroup>");
            foreach (var pasta in this._projeto.Pastas)
            {
                if (pasta.Arquivos.Any() | pasta.SubPastas.Any())
                {
                    _str.AppendLine(this.GetArquivosPasta("", pasta));
                }
            }
            _str.AppendLine("  </ItemGroup>");

            _str.AppendLine("  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.VisualBasic.targets\" />");
            _str.AppendLine("</Project>");

            _str.AppendLine("");

            return _str.ToString();
        }

        private string GetArquivosPasta(string local, Pasta pasta)
        {
            var localSalvar = local;
            if (localSalvar != "") {
                localSalvar += "\\";
            }

            var _str = new StringBuilder();
            foreach (Arquivo arquivo in pasta.Arquivos)
            {
                if (arquivo.GerouConteudoGeradoApenasUmaVez)
                {
                    var pathArquivo = localSalvar + arquivo.GetNomeParaSalvarGeradoUmaVEz();
                    _str.AppendLine("    <Compile Include=\"" + pathArquivo + "\" />");
                }
                if (arquivo.GerouConteudoRegerado)
                {
                    var pathArquivo = localSalvar + arquivo.GetNomeParaSalvarRegeravel();
                    _str.AppendLine("    <Compile Include=\"" + pathArquivo + "\" />");
                }
            }

            foreach (var subPasta in pasta.SubPastas)
            {
                if (subPasta.Arquivos.Any() | subPasta.SubPastas.Any())
                {
                    _str.AppendLine(this.GetArquivosPasta(localSalvar + subPasta.Nome, subPasta));
                }
            }

            return _str.ToString();
        }

    }
}
