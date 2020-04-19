Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Linq
Imports System


Public Class GeracaoCodigo

    Public Property IsBuscarIdentidade As Boolean
    Public Property IsGerarTabelas As Boolean
    Public Property IsGerarProcedures As Boolean

    Private _strConexao As String
    Public Sub New(p_strConexao As String)
        Me._strConexao = p_strConexao
    End Sub

    Public Function GerarStrClasse(p_idTabela As String, p_nomeTabela As String, p_isCSharp As Boolean, p_isCore As Boolean, p_namespace As String) As String
        If p_isCSharp Then
            Dim _geraCodigoTabela As New GeracaoCodigoClassesCSharp(Me._strConexao)
            _geraCodigoTabela.IsBuscarIdentidade = Me.IsBuscarIdentidade
            Return _geraCodigoTabela.GerarStrClasse(p_idTabela, p_nomeTabela, p_isCore, p_namespace)
        Else
            Dim _geraCodigoTabela As New GeracaoCodigoClassesVbNet(Me._strConexao)
            _geraCodigoTabela.IsBuscarIdentidade = Me.IsBuscarIdentidade
            Return _geraCodigoTabela.GerarStrClasse(p_idTabela, p_nomeTabela, p_isCore, p_namespace)
        End If
    End Function

    Public Function GerarStrTabelasStoredProcedures(p_idTabela As String, p_nomeTabela As String) As String
        Dim str As New StringBuilder
        If Me.IsGerarTabelas Then
            str.Append(Me.GerarStrTabelas(p_idTabela, p_nomeTabela))
        End If
        If Me.IsGerarProcedures Then
            str.Append(Me.GerarStrProcedures(p_idTabela, p_nomeTabela))
        End If
        Return str.ToString
    End Function

    Private Function GerarStrTabelas(p_idTabela As String, p_nomeTabela As String) As String
        Dim _geraCodigoTabela As New GeracaoCodigoBancoDados(Me._strConexao)
        _geraCodigoTabela.IsBuscarIdentidade = Me.IsBuscarIdentidade
        Return _geraCodigoTabela.GerarStrTabela(p_idTabela, p_nomeTabela)
    End Function

    Private Function GerarStrProcedures(p_idTabela As String, p_nomeTabela As String) As String
        Dim _geraCodigoTabela As New GeracaoCodigoBancoDados(Me._strConexao)
        _geraCodigoTabela.IsBuscarIdentidade = Me.IsBuscarIdentidade
        Return _geraCodigoTabela.GerarStrProcedures(p_idTabela, p_nomeTabela)
    End Function

End Class
