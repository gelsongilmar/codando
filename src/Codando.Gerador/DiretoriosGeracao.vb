Imports Codando.Config

Public Class DiretoriosGeracao

    Private _config As ConfigCodandoSolucaoOld

    Public Sub New(config As ConfigCodandoSolucaoOld)
        _config = config
    End Sub

    Public Function GetDiretorioProjetoDAL() As String
        Return _config.PastaGeracaoSolucao & "/" & _config.NomeSolucao & ".DAL"
    End Function

    Public Function GetDiretorioGeracaoDAL() As String
        Return Me.GetDiretorioProjetoDAL & "/codando"
    End Function

    Public Function GetDiretorioProjetoWEB() As String
        Return _config.PastaGeracaoSolucao & "/" & _config.NomeSolucao & ".WEB"
    End Function

    Public Function GetDiretorioProjetoBD() As String
        Return _config.PastaGeracaoSolucao & "/" & _config.NomeSolucao & ".BD"
    End Function

    Public Function GetDiretorioGeracaoProcedures() As String
        Return Me.GetDiretorioProjetoBD & "/codando/procedures"
    End Function

End Class
