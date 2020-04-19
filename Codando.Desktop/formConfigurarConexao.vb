Imports System
Imports System.Windows.Forms
Imports Codando.DataBase

Public Class formConfigurarConexao

    Public Sub Inicial()

        Dim arquivoXML As New ConexaoXML
        arquivoXML.Carregar()

        txt_host.Text = arquivoXML.Host
        txt_instancia.Text = arquivoXML.Instancia
        txt_nomeBanco.Text = arquivoXML.NomeBancoDados
        txt_usuario.Text = arquivoXML.Usuario
        txt_senha.Text = arquivoXML.Senha
        txt_namespace.Text = arquivoXML.NamespacePrincipal

    End Sub

    Private Sub btn_testar_Click(sender As Object, e As System.EventArgs) Handles btn_testar.Click
        Dim arquivoXML As New ConexaoXML
        arquivoXML.Carregar()
        MessageBox.Show(arquivoXML.TestarConexao.Mensagem)
    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As System.EventArgs) Handles btn_salvar.Click
        Dim arquivoXML As New ConexaoXML
        arquivoXML.Carregar()

        arquivoXML.Host = txt_host.Text.Trim
        arquivoXML.Instancia = txt_instancia.Text.Trim
        arquivoXML.NomeBancoDados = txt_nomeBanco.Text.Trim
        arquivoXML.Usuario = txt_usuario.Text.Trim
        arquivoXML.Senha = txt_senha.Text.Trim
        arquivoXML.NamespacePrincipal = txt_namespace.Text

        arquivoXML.AtualizarXML()

        MessageBox.Show("Informações atualizadas com sucesso")

        Me.Close()

    End Sub

End Class