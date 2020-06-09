using Codando.Gerador.Domain.Base;
using System;
using System.Linq;
using System.Text;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoBD
{
    internal class ArquivoSqlProj : Arquivo
    {
        private Projeto _projeto;

        public ArquivoSqlProj(Projeto projeto)
        {
            this.UsarArquivoSeparadoParaRegerar = false;
            this._projeto = projeto;
            this.Nome = this._projeto.NomeProjeto;
            this.Extensao = ".sqlproj";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            return "";
        }

        public override string GetConteudoRegerado()
        {

            var _str = new StringBuilder();
            _str.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            _str.AppendLine("<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\" ToolsVersion=\"4.0\">");
            _str.AppendLine("  <PropertyGroup>");
            _str.AppendLine("    <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>");
            _str.AppendLine("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>");
            _str.AppendLine("    <Name>" + this._projeto.NomeProjeto + "</Name>");
            _str.AppendLine("    <SchemaVersion>2.0</SchemaVersion>");
            _str.AppendLine("    <ProjectVersion>4.1</ProjectVersion>");
            _str.AppendLine("    <ProjectGuid>{" + this._projeto.GuIdProjeto + "}</ProjectGuid>");
            _str.AppendLine("    <DSP>Microsoft.Data.Tools.Schema.Sql.Sql130DatabaseSchemaProvider</DSP>");
            _str.AppendLine("    <OutputType>Database</OutputType>");
            _str.AppendLine("    <RootPath>");
            _str.AppendLine("    </RootPath>");
            _str.AppendLine("    <RootNamespace>" + this._projeto.NomeProjeto + "</RootNamespace>");
            _str.AppendLine("    <AssemblyName>" + this._projeto.NomeProjeto + "</AssemblyName>");
            _str.AppendLine("    <ModelCollation>1033,CI</ModelCollation>");
            _str.AppendLine("    <DefaultFileStructure>BySchemaAndSchemaType</DefaultFileStructure>");
            _str.AppendLine("    <DeployToDatabase>True</DeployToDatabase>");
            _str.AppendLine("    <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>");
            _str.AppendLine("    <TargetLanguage>VB</TargetLanguage>");
            _str.AppendLine("    <AppDesignerFolder>Properties</AppDesignerFolder>");
            _str.AppendLine("    <SqlServerVerification>False</SqlServerVerification>");
            _str.AppendLine("    <IncludeCompositeObjects>True</IncludeCompositeObjects>");
            _str.AppendLine("    <TargetDatabaseSet>True</TargetDatabaseSet>");
            _str.AppendLine("    <SccProjectName>SAK</SccProjectName>");
            _str.AppendLine("    <SccProvider>SAK</SccProvider>");
            _str.AppendLine("    <SccAuxPath>SAK</SccAuxPath>");
            _str.AppendLine("    <SccLocalPath>SAK</SccLocalPath>");
            _str.AppendLine("    <TargetFrameworkProfile />");
            _str.AppendLine("    <DefaultCollation>Latin1_General_CI_AS</DefaultCollation>");
            _str.AppendLine("    <DefaultFilegroup>PRIMARY</DefaultFilegroup>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">");
            _str.AppendLine("    <OutputPath>bin\\Release\\</OutputPath>");
            _str.AppendLine("    <BuildScriptName>$(MSBuildProjectName).sql</BuildScriptName>");
            _str.AppendLine("    <TreatWarningsAsErrors>False</TreatWarningsAsErrors>");
            _str.AppendLine("    <DebugType>pdbonly</DebugType>");
            _str.AppendLine("    <Optimize>true</Optimize>");
            _str.AppendLine("    <DefineDebug>false</DefineDebug>");
            _str.AppendLine("    <DefineTrace>true</DefineTrace>");
            _str.AppendLine("    <ErrorReport>prompt</ErrorReport>");
            _str.AppendLine("    <WarningLevel>4</WarningLevel>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">");
            _str.AppendLine("    <OutputPath>bin\\Debug\\</OutputPath>");
            _str.AppendLine("    <BuildScriptName>$(MSBuildProjectName).sql</BuildScriptName>");
            _str.AppendLine("    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>");
            _str.AppendLine("    <DebugSymbols>true</DebugSymbols>");
            _str.AppendLine("    <DebugType>full</DebugType>");
            _str.AppendLine("    <Optimize>false</Optimize>");
            _str.AppendLine("    <DefineDebug>true</DefineDebug>");
            _str.AppendLine("    <DefineTrace>true</DefineTrace>");
            _str.AppendLine("    <ErrorReport>prompt</ErrorReport>");
            _str.AppendLine("    <WarningLevel>4</WarningLevel>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <PropertyGroup>");
            _str.AppendLine("    <VisualStudioVersion Condition=\"'$(VisualStudioVersion)' == ''\">11.0</VisualStudioVersion>");
            _str.AppendLine("    <!-- Default to the v11.0 targets path if the targets file for the current VS version is not found -->");
            _str.AppendLine("    <SSDTExists Condition=\"Exists('$(MSBuildExtensionsPath)\\Microsoft\\VisualStudio\\v$(VisualStudioVersion)\\SSDT\\Microsoft.Data.Tools.Schema.SqlTasks.targets')\">True</SSDTExists>");
            _str.AppendLine("    <VisualStudioVersion Condition=\"'$(SSDTExists)' == ''\">11.0</VisualStudioVersion>");
            _str.AppendLine("  </PropertyGroup>");
            _str.AppendLine("  <Import Condition=\"'$(SQLDBExtensionsRefPath)' != ''\" Project=\"$(SQLDBExtensionsRefPath)\\Microsoft.Data.Tools.Schema.SqlTasks.targets\" />");
            _str.AppendLine("  <Import Condition=\"'$(SQLDBExtensionsRefPath)' == ''\" Project=\"$(MSBuildExtensionsPath)\\Microsoft\\VisualStudio\\v$(VisualStudioVersion)\\SSDT\\Microsoft.Data.Tools.Schema.SqlTasks.targets\" />");
            _str.AppendLine("  <ItemGroup>");

            foreach (var pasta in this._projeto.Pastas)
            {
                if (pasta.SubPastas.Any())
                {
                    _str.AppendLine(this.GetFolders("", pasta));
                }
            }

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
            _str.AppendLine("</Project>");

            return _str.ToString();
        }

        private string GetFolders(string local, Pasta pasta)
        {
            var localSalvar = local;
            if (localSalvar != "")
            {
                localSalvar += "\\";
            }

            var _str = new StringBuilder();
            foreach (var subPasta in pasta.SubPastas)
            {
                _str.AppendLine("    <Folder Include=\""+ localSalvar + subPasta.Nome+ "\" />");
                if (subPasta.SubPastas.Any())
                {
                    _str.AppendLine(this.GetArquivosPasta(localSalvar + subPasta.Nome, subPasta));
                }
            }

            return _str.ToString();
        }

        private string GetArquivosPasta(string local, Pasta pasta)
        {
            var localSalvar = local;
            if (localSalvar != "")
            {
                localSalvar += "\\";
            }

            var _str = new StringBuilder();
            foreach (Arquivo arquivo in pasta.Arquivos)
            {
                if (arquivo.GerouConteudoGeradoApenasUmaVez)
                {
                    var pathArquivo = localSalvar + arquivo.GetNomeParaSalvarGeradoUmaVEz();
                    _str.AppendLine("    <Build Include=\"" + pathArquivo + "\" />");

                }
                if (arquivo.GerouConteudoRegerado)
                {
                    var pathArquivo = localSalvar + arquivo.GetNomeParaSalvarRegeravel();
                    _str.AppendLine("    <Build Include=\"" + pathArquivo + "\" />");
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