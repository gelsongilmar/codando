Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class SchemaBD

    Private _strConexao As String

    Public Sub New(p_strConexao As String)
        Me._strConexao = p_strConexao
    End Sub

    Public Function ListarTabelas() As DataTable
        Dim conexao = Me.CreateConnection()
        Dim adp As New SqlDataAdapter("SELECT T.object_id IdTabela, name AS NomeTabela FROM SYS.TABLES T WHERE T.name not in ('sysdiagrams') ORDER BY T.name ASC", conexao)
        Return ExecDataTable(conexao, adp)
    End Function

    Public Function ListarCampos(p_idTabela As String) As DataTable
        Dim conexao = Me.CreateConnection()
        Dim adp As New SqlDataAdapter("SELECT	C.Object_id AS IdTabela,
		                                        C.column_id AS IdCampo,
		                                        C.name AS NomeCampo,
		                                        T.name AS NomeTipoCampo,
		                                        C.max_length AS TamanhoCampo,
		                                        C.precision AS Precisao,
		                                        C.scale AS Escala,
		                                        C.is_nullable AS IsNulo,
		                                        C.is_identity AS IsIdentidade,
		                                        CASE WHEN IC.column_id IS NULL THEN 0 
			                                         WHEN IC.column_id IS NOT NULL THEN 1
		                                        END IsPK 
                                        FROM SYS.columns C
                                        JOIN SYS.types T ON C.system_type_id = T.system_type_id
                                        LEFT JOIN sys.indexes I ON C.object_id = I.object_id
                                        LEFT JOIN sys.index_columns IC ON I.object_id = IC.object_id AND C.column_id = IC.column_id
                                        WHERE C.object_id = @idTabela
                                        ORDER BY C.column_id ASC", conexao)
        adp.SelectCommand.Parameters.Add("@idTabela", SqlDbType.VarChar, 100).Value = p_idTabela
        Return ExecDataTable(conexao, adp)
    End Function

    Private Function ExecDataTable(conexao As SqlConnection, adp As SqlDataAdapter) As DataTable
        Dim dt As New DataTable
        Try
            conexao.Open()
            adp.Fill(dt)
        Catch ex As Exception
            Throw
        Finally
            conexao.Close()
            adp.Dispose()
        End Try
        Return dt
    End Function

    Private Function CreateConnection() As SqlConnection
        Return New SqlConnection(Me._strConexao)
    End Function

End Class
