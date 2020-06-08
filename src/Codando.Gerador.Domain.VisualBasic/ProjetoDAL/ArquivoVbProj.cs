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

            _str.AppendLine("  <Import Project=\"$(MSBuildToolsPath)\\Microsoft.VisualBasic.targets\" />");
            _str.AppendLine("</Project>");




            _str.AppendLine("");

            return _str.ToString();
        }
    }
}
