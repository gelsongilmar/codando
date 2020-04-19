Imports System.Data.SqlClient
Imports Codando.Config

Public Class ConexaoSolucao

    Public Property Host As String
    Public Property Instancia As String
    Public Property NomeBancoDados As String
    Public Property Usuario As String
    Public Property Senha As String

    Public Sub Carregar(configCodandoSolucao As ConfigCodandoSolucao)

        Me.Host = configCodandoSolucao.Host
        Me.Instancia = configCodandoSolucao.Instancia
        Me.NomeBancoDados = configCodandoSolucao.NomeBancoDados
        Me.Usuario = configCodandoSolucao.Usuario
        Me.Senha = configCodandoSolucao.Senha

    End Sub

    Public Function MontarStringConexao() As String
        Return "Data Source=" + Me.Host + "\" + Me.Instancia + ";Initial Catalog=" + Me.NomeBancoDados + ";User Id=" + Me.Usuario + ";Password=" + Me.Senha + ";"
    End Function

    Public Function TestarConexao() As RetornoConexao
        Dim retornoConexao As New RetornoConexao
        Dim conexao As New SqlConnection(Me.MontarStringConexao)
        Try
            conexao.Open()
            retornoConexao.IsSucesso = True
            retornoConexao.Mensagem = "Conexão efetuada com sucesso"
        Catch ex As Exception
            retornoConexao.IsSucesso = False
            retornoConexao.Mensagem = "Conexão incorreta: " + ex.Message
        Finally
            conexao.Close()
        End Try
        Return retornoConexao
    End Function

End Class
