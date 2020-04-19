Imports System
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class ConexaoXML

    Public Property Host As String
    Public Property Instancia As String
    Public Property NomeBancoDados As String
    Public Property Usuario As String
    Public Property Senha As String
    Public Property NamespacePrincipal As String


    Private _diretorio As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\Codando\Configs"
    Private _nomeArquivo As String = "ConfiguracaoCodando.xml"

    Private Sub CriarPasta()
        If Not IO.Directory.Exists(Me._diretorio) Then
            IO.Directory.CreateDirectory(Me._diretorio)
        End If
    End Sub

    Private Sub CriarArquivoXML()
        Dim str As New Text.StringBuilder
        str.Append("<?xml version=""1.0"" encoding=""utf-8"" ?>" + vbCrLf)
        str.Append("<container>" + vbCrLf)
        str.Append("  <conexao>" + vbCrLf)
        str.Append("    <host>" + Me.Host + "</host>" + vbCrLf)
        str.Append("    <instancia>" + Me.Instancia + "</instancia>" + vbCrLf)
        str.Append("    <bd>" + Me.NomeBancoDados + "</bd>" + vbCrLf)
        str.Append("    <usuario>" + Me.Usuario + "</usuario>" + vbCrLf)
        str.Append("    <senha>" + Me.Senha + "</senha>" + vbCrLf)
        str.Append("    <namespace>" + Me.NamespacePrincipal + "</namespace>" + vbCrLf)
        str.Append("  </conexao> " + vbCrLf)
        str.Append("</container>" + vbCrLf)

        Dim _caminhoXML As String = Me._diretorio + "\" + Me._nomeArquivo
        Dim sw As New IO.StreamWriter(_caminhoXML)
        sw.WriteLine(str.ToString)
        sw.Close()
        sw.Dispose()
    End Sub

    Public Sub Carregar()

        Me.CriarPasta()

        Dim _caminhoXML As String = Me._diretorio + "\" + Me._nomeArquivo
        If Not IO.File.Exists(_caminhoXML) Then
            Me.CriarArquivoXML()
        End If

        Dim _arquivoXML As New Xml.XmlDocument
        _arquivoXML.Load(_caminhoXML)

        Me.Host = _arquivoXML.SelectSingleNode("container").SelectSingleNode("conexao").SelectSingleNode("host").InnerText
        Me.Instancia = _arquivoXML.SelectSingleNode("container").SelectSingleNode("conexao").SelectSingleNode("instancia").InnerText
        Me.NomeBancoDados = _arquivoXML.SelectSingleNode("container").SelectSingleNode("conexao").SelectSingleNode("bd").InnerText
        Me.Usuario = _arquivoXML.SelectSingleNode("container").SelectSingleNode("conexao").SelectSingleNode("usuario").InnerText
        Me.Senha = _arquivoXML.SelectSingleNode("container").SelectSingleNode("conexao").SelectSingleNode("senha").InnerText
        Me.NamespacePrincipal = _arquivoXML.SelectSingleNode("container").SelectSingleNode("conexao").SelectSingleNode("namespace").InnerText

    End Sub

    Public Sub AtualizarXML()
        Dim _caminhoXML As String = Me._diretorio + "\" + Me._nomeArquivo
        IO.File.Delete(_caminhoXML)

        Me.CriarArquivoXML()
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
