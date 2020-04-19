Imports Codando.Config

Public Class DiretoriosGeracao

    Private _config As ConfigCodandoSolucao

    Public Sub New(config As ConfigCodandoSolucao)
        _config = config
    End Sub

    Public Function GetDiretorioProjetoDAL() As String
        Return _config.PastaGeracaoSolucao & "/" & _config.NomeSolucao & ".DAL"
    End Function

    Public Function GetDiretorioProjetoWEB() As String
        Return _config.PastaGeracaoSolucao & "/" & _config.NomeSolucao & ".WEB"
    End Function

    Public Function GetDiretorioProjetoBD() As String
        Return _config.PastaGeracaoSolucao & "/" & _config.NomeSolucao & ".BD"
    End Function

End Class
