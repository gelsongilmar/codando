Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Collections.Generic
Imports Codando.Gerador
Imports Codando.DataBase

Public Class GeracaoCodigoBancoDados

    Public Property IsBuscarIdentidade As Boolean

    Private _strConexao As String

    Public Sub New(p_strConexao As String)
        Me._strConexao = p_strConexao
    End Sub

    Public Function GerarStrTabela(p_idTabela As String, p_nomeTabela As String) As String
        Dim str As New StringBuilder

        Dim _dtCampos As DataTable = New SchemaBD(Me._strConexao).ListarCampos(p_idTabela)
        Dim _isPossuiPK As Boolean = _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).Count() > 0

        str.Append(" CREATE TABLE " + p_nomeTabela + " ( " + vbLf)

        For index = 0 To _dtCampos.Rows.Count - 1
            Dim dr As DataRow = _dtCampos.Rows(index)

            Dim _nomeCampo As String = dr.Item("NomeCampo").ToString
            Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)
            Dim _isIdentidade As Boolean = CBool(dr.Item("IsIdentidade"))
            Dim _isNulo As Boolean = CBool(dr.Item("IsNulo"))

            Dim _strIdentidade As String = ""
            If _isIdentidade Then
                _strIdentidade = " IDENTITY(1,1)"
            End If

            Dim _strNulo As String = " NOT NULL"
            If _isNulo Then
                _strNulo = " NULL"
            End If
            Dim _strFimLinha As String = ""
            If index <> _dtCampos.Rows.Count - 1 Then
                _strFimLinha = ", "
            End If

            str.Append(" 	" + _nomeCampo + " " + _tipoBD + _strIdentidade + _strNulo + _strFimLinha + vbLf)

        Next

        str.Append(" ) " + vbLf)
        str.Append(" GO " + vbLf)

        If _isPossuiPK Then
            str.Append(" ALTER TABLE " + p_nomeTabela + " ")
            str.Append(" ADD CONSTRAINT PK_" + p_nomeTabela + " PRIMARY KEY (")

            Dim _dtPKs As List(Of DataRow) = _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).ToList()
            For index = 0 To _dtPKs.Count - 1

                Dim drPKs As DataRow = _dtPKs(index)
                Dim _nomeCampo As String = drPKs.Item("NomeCampo").ToString

                Dim _strFimLinha As String = ""
                If index <> _dtPKs.Count - 1 Then
                    _strFimLinha = ", "
                End If

                str.Append(_nomeCampo + _strFimLinha)

            Next

            str.Append(")" + vbLf)
            str.Append(" GO " + vbLf)
        End If

        Return str.ToString
    End Function

    Public Function GerarStrProcedures(p_idTabela As String, p_nomeTabela As String) As String
        Dim str As New StringBuilder

        Dim _dtCampos As DataTable = New SchemaBD(Me._strConexao).ListarCampos(p_idTabela)

        str.Append(Me.GerarScriptProcedure_List(p_idTabela, p_nomeTabela, _dtCampos))
        str.Append(Me.GerarScriptProcedure_Select(p_idTabela, p_nomeTabela, _dtCampos))
        str.Append(Me.GerarScriptProcedure_Insert(p_idTabela, p_nomeTabela, _dtCampos))
        str.Append(Me.GerarScriptProcedure_Update(p_idTabela, p_nomeTabela, _dtCampos))
        str.Append(Me.GerarScriptProcedure_Delete(p_idTabela, p_nomeTabela, _dtCampos))

        Return str.ToString
    End Function

    Private Function GerarScriptProcedure_List(p_idTabela As String, p_nomeTabela As String, p_dtCampos As DataTable) As String
        Dim str As New StringBuilder
        str.Append(" CREATE PROCEDURE usp_" + p_nomeTabela + "_List" + vbLf)
        str.Append(" AS " + vbLf)
        str.Append("    SELECT * FROM " + p_nomeTabela + vbLf)
        str.Append(" GO " + vbLf)
        Return str.ToString
    End Function
    Private Function GerarScriptProcedure_Select(p_idTabela As String, p_nomeTabela As String, p_dtCampos As DataTable) As String

        Dim _isPossuiIdentidade As Boolean = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).Count() > 0
        Dim _isPossuiPK As Boolean = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).Count() > 0

        Dim str As New StringBuilder
        str.Append(" CREATE PROCEDURE usp_" + p_nomeTabela + "_Select" + vbLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha + vbLf)
            Next

        ElseIf _isPossuiPK Then

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha + vbLf)
            Next
        End If

        str.Append(" AS " + vbLf)
        str.Append("    SELECT * FROM " + p_nomeTabela + vbLf)


        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            str.Append("    WHERE ")

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)
                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = " AND "
                End If

                str.Append(nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha)
            Next
            str.Append(vbLf)

        ElseIf _isPossuiPK Then
            str.Append("    WHERE ")

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = " AND "
                End If

                str.Append(nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha)
            Next
            str.Append(vbLf)
        End If

        str.Append(" GO " + vbLf)
        Return str.ToString
    End Function
    Private Function GerarScriptProcedure_Insert(p_idTabela As String, p_nomeTabela As String, p_dtCampos As DataTable) As String

        Dim _isPossuiIdentidade As Boolean = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).Count() > 0

        Dim str As New StringBuilder
        str.Append(" CREATE PROCEDURE usp_" + p_nomeTabela + "_Insert" + vbLf)

        If True Then
            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) Not CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                Else
                    If _isPossuiIdentidade Then
                        _strFimLinha = ","
                    End If
                End If

                str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha + vbLf)
            Next
        End If
        If _isPossuiIdentidade Then
            For Each dr As DataRow In p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).ToList

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                str.Append("    @Identity " + _tipoBD + " output " + vbLf)
            Next
        End If

        str.Append(" AS " + vbLf)
        str.Append("    INSERT INTO " + p_nomeTabela + " ( " + vbLf)
        If True Then
            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) Not CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)
                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("        " + nomeCampoBD + _strFimLinha + vbLf)
            Next
        End If
        str.Append("    ) VALUES (" + vbLf)
        If True Then
            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) Not CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)
                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("        @" + nomeCampoBD + _strFimLinha + vbLf)
            Next
        End If
        str.Append("    )" + vbLf)

        If _isPossuiIdentidade Then
            str.Append("    SET @Identity = SCOPE_IDENTITY()" + vbLf)
        End If
        str.Append(" GO " + vbLf)
        Return str.ToString
    End Function
    Private Function GerarScriptProcedure_Update(p_idTabela As String, p_nomeTabela As String, p_dtCampos As DataTable) As String

        Dim _isPossuiIdentidade As Boolean = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).Count() > 0
        Dim _isPossuiPK As Boolean = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).Count() > 0

        Dim str As New StringBuilder
        str.Append(" CREATE PROCEDURE usp_" + p_nomeTabela + "_Update" + vbLf)

        If True Then
            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).ToList()
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha + vbLf)
            Next
        End If

        str.Append(" AS " + vbLf)
        str.Append("    UPDATE " + p_nomeTabela + vbLf)
        str.Append("    SET " + vbLf)
        If True Then
            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) Not CBool(x.Item("isPK")) AndAlso Not CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)
                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("        " + nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha + vbLf)
            Next
        End If
        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            str.Append("    WHERE ")

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)
                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = " AND "
                End If

                str.Append(nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha)
            Next
            str.Append(vbLf)

        ElseIf _isPossuiPK Then
            str.Append("    WHERE ")

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = " AND "
                End If

                str.Append(nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha)
            Next
            str.Append(vbLf)
        End If
        str.Append(" GO " + vbLf)
        Return str.ToString
    End Function

    Private Function GerarScriptProcedure_Delete(p_idTabela As String, p_nomeTabela As String, p_dtCampos As DataTable) As String
        Dim _isPossuiIdentidade As Boolean = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).Count() > 0
        Dim _isPossuiPK As Boolean = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).Count() > 0

        Dim str As New StringBuilder
        str.Append(" CREATE PROCEDURE usp_" + p_nomeTabela + "_Delete" + vbLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha + vbLf)
            Next

        ElseIf _isPossuiPK Then

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim _tipoBD As String = UtilitarioGeracaoCodigo.ObterTipoBDCompleto(dr.Item("NomeTipoCampo").ToString, dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = ","
                End If

                str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha + vbLf)
            Next
        End If

        str.Append(" AS " + vbLf)
        str.Append("    DELETE FROM " + p_nomeTabela + vbLf)


        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            str.Append("    WHERE ")

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)
                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = " AND "
                End If

                str.Append(nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha)
            Next
            str.Append(vbLf)

        ElseIf _isPossuiPK Then
            str.Append("    WHERE ")

            Dim _lista As List(Of DataRow) = p_dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK"))).ToList
            For index = 0 To _lista.Count - 1

                Dim dr As DataRow = _lista(index)

                Dim nomeCampoBD As String = dr.Item("NomeCampo")

                Dim _strFimLinha As String = ""
                If index <> _lista.Count - 1 Then
                    _strFimLinha = " AND "
                End If

                str.Append(nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha)
            Next
            str.Append(vbLf)
        End If

        str.Append(" GO " + vbLf)
        Return str.ToString
    End Function

End Class
