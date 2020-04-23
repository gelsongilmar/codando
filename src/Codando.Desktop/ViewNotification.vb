Imports Codando.Shared

Public Class ViewNotification

    Public Shared Sub Show(notificacao As Notification)
        MessageBox.Show(notificacao.ToString, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
