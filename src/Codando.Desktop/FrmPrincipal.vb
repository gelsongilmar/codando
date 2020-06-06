Public Class FrmPrincipal

    Private Sub btnGerarSQLServer_Click(sender As Object, e As EventArgs) Handles btnGerarSQLServer.Click
        Dim f As New FormGeracaoOld
        f.ShowDialog()
    End Sub

    Private Sub btnGerarCadastrandoEntidades_Click(sender As Object, e As EventArgs) Handles btnGerarCadastrandoEntidades.Click
        Dim f As New FrmGerar
        f.ShowDialog()
    End Sub

End Class