Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Linq
Imports System
Imports Codando.DataBase

Public Class GeracaoCodigoClassesVbNet

    Public Property IsBuscarIdentidade As Boolean

    Private _strConexao As String
    Public Sub New(p_strConexao As String)
        Me._strConexao = p_strConexao
    End Sub

    Public Function GerarStrClasse(p_idTabela As String, p_nomeTabela As String, p_isCore As Boolean, p_namespace As String) As String
        Dim _str As New StringBuilder

        Dim _dtCampos As DataTable = New SchemaBD(Me._strConexao).ListarCampos(p_idTabela)
        Dim _isPossuiIdentidade As Boolean = _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).Count() > 0
        Dim _isPossuiPK As Boolean = _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).Count() > 0

        _str.Append("Imports System" + vbCrLf)
        _str.Append("Imports System.Data" + vbCrLf)
        _str.Append("Imports System.Collections.Generic" + vbCrLf)
        _str.Append("Imports System.Data.SqlClient " + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("    Public Class " + p_nomeTabela + vbCrLf)
        _str.Append("        Inherits BaseDAL" + vbCrLf)

        _str.Append("        #Region ""Construtor""" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        Public Sub New(p_strConexao As IStrConexao)" + vbCrLf)
        _str.Append("           MyBase.New(p_strConexao)" + vbCrLf)
        _str.Append("        End Sub" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #End Region" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #Region ""GET/SET""" + vbCrLf)
        _str.Append(vbCrLf)

        For Each dr As DataRow In _dtCampos.Rows

            Dim _tipoCampo As String = UtilitarioGeracaoCodigo.ObterTipoVbNet(dr.Item("NomeTipoCampo").ToString)
            Dim _nomeCampo As String = UtilitarioGeracaoCodigo.PascalCasing(dr.Item("NomeCampo").ToString)

            If CBool(dr.Item("IsNulo")) AndAlso _tipoCampo <> "String" Then
                _tipoCampo = _tipoCampo + "?"
            End If

            _str.Append("        Public Property " + _nomeCampo + " As " + _tipoCampo + vbCrLf)
        Next

        _str.Append(vbCrLf)
        _str.Append("        #End Region" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #Region ""Methods""" + vbCrLf)
        _str.Append(vbCrLf)
        If p_isCore Then
            _str.Append("        Public Function List() As List(Of Data.DataRow)" + vbCrLf)
        Else
            _str.Append("        Public Function List() As DataTable" + vbCrLf)
        End If
        _str.Append("            Dim conexao As New SqlConnection(Me._strConexao)" + vbCrLf)
        If p_isCore Then
            _str.Append("            Dim comando As New SqlCommand(""usp_" + p_nomeTabela + "_List"", conexao)" + vbCrLf)
        Else
            _str.Append("            Dim comando As New SqlDataAdapter(""usp_" + p_nomeTabela + "_List"", conexao)" + vbCrLf)
        End If
        _str.Append(vbCrLf)
        _str.Append("            return ExecutarList(conexao, comando)" + vbCrLf)
        _str.Append("        End Function" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        Public Sub Retrieve()" + vbCrLf)
        _str.Append("            Dim conexao As New SqlConnection(Me._strConexao)" + vbCrLf)
        _str.Append("            Dim comando As New SqlCommand(""usp_" + p_nomeTabela + "_Select"", conexao)" + vbCrLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoVbNet As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet + "" + vbCrLf)
            Next

        ElseIf _isPossuiPK Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoVbNet As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet + vbCrLf)
            Next
        End If

        _str.Append(vbCrLf)
        _str.Append("            Me.ExecutarDataReader(conexao, comando)" + vbCrLf)
        _str.Append("        End Sub" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        Public Function Save() As Boolean" + vbCrLf)
        _str.Append("            Dim conexao As New SqlConnection(Me._strConexao)" + vbCrLf)
        _str.Append("            Dim comando As New SqlCommand(""usp_" + p_nomeTabela + "_Insert"", conexao)" + vbCrLf)
        _str.Append("            Me.PreencherParametros(comando)" + vbCrLf)

        If _isPossuiIdentidade Then
            _str.Append("            comando.Parameters.Add(""@Identity"", SqlDbType.Int).Direction = ParameterDirection.Output" + vbCrLf)
        End If

        _str.Append("            return ExecutarComando(conexao, comando, true)" + vbCrLf)
        _str.Append("        End Function" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        Public Function Update() As Boolean" + vbCrLf)
        _str.Append("            Dim conexao As New SqlConnection(Me._strConexao)" + vbCrLf)
        _str.Append("            Dim comando As New SqlCommand(""usp_" + p_nomeTabela + "_Update"", conexao)" + vbCrLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then
            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp + vbCrLf)
            Next
        ElseIf _isPossuiPK Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp + vbCrLf)
            Next
        End If

        _str.Append("            Me.PreencherParametros(comando)" + vbCrLf)
        _str.Append("            return ExecutarComando(conexao, comando, false)" + vbCrLf)
        _str.Append("        End Function" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        Public Function Delete() As Boolean" + vbCrLf)
        _str.Append("            Dim conexao As New SqlConnection(Me._strConexao)" + vbCrLf)
        _str.Append("            Dim comando As New SqlCommand(""usp_" + p_nomeTabela + "_Delete"", conexao)" + vbCrLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp + vbCrLf)
            Next
        ElseIf _isPossuiPK Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp + vbCrLf)
            Next
        End If

        _str.Append("            return ExecutarComando(conexao, comando, false)" + vbCrLf)
        _str.Append("        End Function" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #End Region" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #Region ""Aux""" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        Private Sub PreencherParametros(cmd As SqlCommand)" + vbCrLf)

        For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) Not CBool(x.Item("IsIdentidade")))
            Dim nomeCampoBD As String = dr.Item("NomeCampo")
            Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
            Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

            If CBool(dr.Item("IsNulo")) Then
                _str.Append("            cmd.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = If(Me." + nomeCampoCSharp + ", DBNull.Value)" + vbCrLf)
            Else
                _str.Append("            cmd.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp + vbCrLf)
            End If

        Next

        _str.Append("        End Sub" + vbCrLf)
        _str.Append(vbCrLf)

        If _isPossuiIdentidade Then

            _str.Append("        Protected Overrides Sub PreencherIdentidade(cmd As SqlCommand)" + vbCrLf)

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))
                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim tipoCampo As String = UtilitarioGeracaoCodigo.ObterTipoVbNet(dr.Item("NomeTipoCampo").ToString)
                If tipoCampo = "string" Then
                    _str.Append("            Me." + nomeCampoCSharp + " = cmd.Parameters(""@Identity"").Value" + vbCrLf)
                Else
                    _str.Append("            Me." + nomeCampoCSharp + " = cmd.Parameters(""@Identity"").Value" + vbCrLf)
                End If
            Next
            _str.Append("        End Sub" + vbCrLf)
            _str.Append(vbCrLf)
        End If

        _str.Append("        Protected Overrides Sub PreencherAtributos(dr As SqlDataReader)" + vbCrLf)
        _str.Append("            if dr.Read Then" + vbCrLf)
        _str.Append("                Me._found = true" + vbCrLf)

        For Each dr As DataRow In _dtCampos.Rows

            Dim nomeCampoBD As String = dr.Item("NomeCampo")
            Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
            Dim tipoCampo As String = UtilitarioGeracaoCodigo.ObterTipoVbNet(dr.Item("NomeTipoCampo").ToString)
            If tipoCampo = "String" Then
                _str.Append("                if Not IsDbNull(dr.Item(""" + nomeCampoBD + """)) Then Me." + nomeCampoCSharp + " = dr.Item(""" + nomeCampoBD + """).ToString() " + vbCrLf)
            Else
                _str.Append("                if Not IsDbNull(dr.Item(""" + nomeCampoBD + """)) Then Me." + nomeCampoCSharp + " = dr.Item(""" + nomeCampoBD + """).ToString() " + vbCrLf)
            End If
        Next

        _str.Append("            End If" + vbCrLf)
        _str.Append("        End Sub" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #End Region" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("    End Class" + vbCrLf)
        _str.Append(vbCrLf)

        Return _str.ToString
    End Function

End Class
