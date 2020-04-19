Imports Codando.Config
Imports Codando.Notification

Public Class ValidaConfiguracao
    Inherits Notification.Notification

    Private config As ConfigCodandoSolucao

    Public Sub New(config As ConfigCodandoSolucao)
        Me.config = config
    End Sub

    Public Overrides Sub Validar()
        If config Is Nothing Then
            AddNotification("Informe a configuração a ser validara")
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
