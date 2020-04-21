Imports System.Text
Imports Codando.Config

Public Class GeracaoSolutionFile

    Public Function GerarStrSln(p_configSolucao As ConfigCodandoSolucao, p_gerarClasseDal As Boolean) As String
        Dim _str As New StringBuilder

        _str.AppendLine("")
        _str.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00")
        _str.AppendLine("# Visual Studio Version 16")
        _str.AppendLine("VisualStudioVersion = 16.0.30002.166")
        _str.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1")


        If p_gerarClasseDal Then
            _str.AppendLine("Project(""{F184B08F-C81C-45F6-A57F-5ABD9991F28F}"") = """ & p_configSolucao.NomeSolucao & ".DAL"", """ & p_configSolucao.NomeSolucao & ".DAL\" & p_configSolucao.NomeSolucao & ".DAL.vbproj"", ""{56F3E5BE-8DAE-40DB-B4C5-A228CB779ECC}""")
            _str.AppendLine("EndProject")
        End If

        _str.AppendLine("Global")
        _str.AppendLine("	GlobalSection(SolutionConfigurationPlatforms) = preSolution")
        _str.AppendLine("		Debug|Any CPU = Debug|Any CPU")
        _str.AppendLine("		Release|Any CPU = Release|Any CPU")
        _str.AppendLine("	EndGlobalSection")
        _str.AppendLine("	GlobalSection(ProjectConfigurationPlatforms) = postSolution")
        _str.AppendLine("		{56F3E5BE-8DAE-40DB-B4C5-A228CB779ECC}.Debug|Any CPU.ActiveCfg = Debug|Any CPU")
        _str.AppendLine("		{56F3E5BE-8DAE-40DB-B4C5-A228CB779ECC}.Debug|Any CPU.Build.0 = Debug|Any CPU")
        _str.AppendLine("		{56F3E5BE-8DAE-40DB-B4C5-A228CB779ECC}.Release|Any CPU.ActiveCfg = Release|Any CPU")
        _str.AppendLine("		{56F3E5BE-8DAE-40DB-B4C5-A228CB779ECC}.Release|Any CPU.Build.0 = Release|Any CPU")
        _str.AppendLine("	EndGlobalSection")
        _str.AppendLine("	GlobalSection(SolutionProperties) = preSolution")
        _str.AppendLine("		HideSolutionNode = FALSE")
        _str.AppendLine("	EndGlobalSection")
        _str.AppendLine("	GlobalSection(ExtensibilityGlobals) = postSolution")
        _str.AppendLine("		SolutionGuid = {7FCB79FD-6ADE-4BA0-849D-53B4718D1052}")
        _str.AppendLine("	EndGlobalSection")
        _str.AppendLine("EndGlobal")
        _str.AppendLine("")

        Return _str.ToString
    End Function

End Class
