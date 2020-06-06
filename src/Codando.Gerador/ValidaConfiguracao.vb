Imports Codando.Config

Public Class ValidaConfiguracao
    Inherits Codando.Shared.Notification

    Private ReadOnly config As ConfigCodandoSolucaoOld

    Public Sub New(config As ConfigCodandoSolucaoOld)
        Me.config = config
    End Sub

    Public Overrides Sub Validar()
        If config Is Nothing Then
            AddNotification("Informe a configuração a ser validada")
        Else
            ValidarPastaGeracaoPreenchida()
            ValidarPastaGeracaoExistente()
        End If
    End Sub

    Private Sub ValidarPastaGeracaoPreenchida()
        If config.PastaGeracaoSolucao.Trim = "" Then
            AddNotification("A pasta de geração da solução não está preenchida nas configurações!")
        End If
    End Sub

    Private Sub ValidarPastaGeracaoExistente()
        If config.PastaGeracaoSolucao.Trim <> "" AndAlso Not IO.Directory.Exists(config.PastaGeracaoSolucao) Then
            AddNotification("A pasta de geração da solução preenchida nas configurações não existe!")
        End If
    End Sub

End Class
