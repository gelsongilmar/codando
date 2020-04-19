Imports System.Data
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Linq
Imports System
Imports Codando.DataBase

Public Class GeracaoCodigoClassesCSharp

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

        _str.Append("using System;" + vbCrLf)
        _str.Append("using System.Data;" + vbCrLf)
        _str.Append("using System.Collections.Generic;" + vbCrLf)
        _str.Append("using System.Data.SqlClient; " + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("namespace " + p_namespace + ".Dal" + vbCrLf)
        _str.Append("{" + vbCrLf)
        _str.Append("    public class " + p_nomeTabela + " : BaseDAL" + vbCrLf)
        _str.Append("    {" + vbCrLf)
        _str.Append("        #region ""Construtor""" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        public " + p_nomeTabela + "(IStrConexao p_strConexao) : base(p_strConexao) { }" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #endregion" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #region ""GET/SET""" + vbCrLf)
        _str.Append(vbCrLf)

        For Each dr As DataRow In _dtCampos.Rows

            Dim _tipoCampo As String = UtilitarioGeracaoCodigo.ObterTipoCSharp(dr.Item("NomeTipoCampo").ToString)
            Dim _nomeCampo As String = UtilitarioGeracaoCodigo.PascalCasing(dr.Item("NomeCampo").ToString)

            If CBool(dr.Item("IsNulo")) AndAlso _tipoCampo <> "string" Then
                _tipoCampo = _tipoCampo + "?"
            End If

            _str.Append("        public " + _tipoCampo + " " + _nomeCampo + " { get; set; }" + vbCrLf)
        Next

        _str.Append(vbCrLf)
        _str.Append("        #endregion" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #region ""Methods""" + vbCrLf)
        _str.Append(vbCrLf)
        If p_isCore Then
            _str.Append("        public List<Data.DataRow> List()" + vbCrLf)
        Else
            _str.Append("        public DataTable List()" + vbCrLf)
        End If
        _str.Append("        {" + vbCrLf)
        _str.Append("            var conexao = new SqlConnection(this._strConexao);" + vbCrLf)
        If p_isCore Then
            _str.Append("            var comando = new SqlCommand(""usp_" + p_nomeTabela + "_List"", conexao);" + vbCrLf)
        Else
            _str.Append("            var comando = new SqlDataAdapter(""usp_" + p_nomeTabela + "_List"", conexao);" + vbCrLf)
        End If
        _str.Append(vbCrLf)
        _str.Append("            return ExecutarList(conexao, comando);" + vbCrLf)
        _str.Append("        }" + vbCrLf)
        _str.Append("        public void Retrieve()" + vbCrLf)
        _str.Append("        {" + vbCrLf)
        _str.Append("            var conexao = new SqlConnection(this._strConexao);" + vbCrLf)
        _str.Append("            var comando = new SqlCommand(""usp_" + p_nomeTabela + "_Select"", conexao);" + vbCrLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = this." + nomeCampoCSharp + ";" + vbCrLf)
            Next

        ElseIf _isPossuiPK Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = this." + nomeCampoCSharp + ";" + vbCrLf)
            Next
        End If

        _str.Append(vbCrLf)
        _str.Append("            this.ExecutarDataReader(conexao, comando);" + vbCrLf)
        _str.Append("        }" + vbCrLf)
        _str.Append("        public bool Save()" + vbCrLf)
        _str.Append("        {" + vbCrLf)
        _str.Append("            var conexao = new SqlConnection(this._strConexao);" + vbCrLf)
        _str.Append("            var comando = new SqlCommand(""usp_" + p_nomeTabela + "_Insert"", conexao);" + vbCrLf)
        _str.Append("            this.PreencherParametros(comando);" + vbCrLf)

        If _isPossuiIdentidade Then
            _str.Append("            comando.Parameters.Add(""@Identity"", SqlDbType.Int).Direction = ParameterDirection.Output;" + vbCrLf)
        End If

        _str.Append("            return ExecutarComando(conexao, comando, true);" + vbCrLf)
        _str.Append("        }" + vbCrLf)
        _str.Append("        public bool Updade()" + vbCrLf)
        _str.Append("        {" + vbCrLf)
        _str.Append("            var conexao = new SqlConnection(this._strConexao);" + vbCrLf)
        _str.Append("            var comando = new SqlCommand(""usp_" + p_nomeTabela + "_Update"", conexao);" + vbCrLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then
            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = this." + nomeCampoCSharp + ";" + vbCrLf)
            Next
        ElseIf _isPossuiPK Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = this." + nomeCampoCSharp + ";" + vbCrLf)
            Next
        End If

        _str.Append("            this.PreencherParametros(comando);" + vbCrLf)
        _str.Append("            return ExecutarComando(conexao, comando, false);" + vbCrLf)
        _str.Append("        }" + vbCrLf)
        _str.Append("        public bool Delete()" + vbCrLf)
        _str.Append("        {" + vbCrLf)
        _str.Append("            var conexao = new SqlConnection(this._strConexao);" + vbCrLf)
        _str.Append("            var comando = new SqlCommand(""usp_" + p_nomeTabela + "_Delete"", conexao);" + vbCrLf)

        If _isPossuiIdentidade AndAlso Me.IsBuscarIdentidade Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = this." + nomeCampoCSharp + ";" + vbCrLf)
            Next
        ElseIf _isPossuiPK Then

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsPK")))

                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

                _str.Append(vbCrLf)
                _str.Append("            comando.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = this." + nomeCampoCSharp + ";" + vbCrLf)
            Next
        End If

        _str.Append("            return ExecutarComando(conexao, comando, false);" + vbCrLf)
        _str.Append("        }" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #endregion" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #region ""Aux""" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        private void PreencherParametros(SqlCommand cmd)" + vbCrLf)
        _str.Append("        {" + vbCrLf)

        For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) Not CBool(x.Item("IsIdentidade")))
            Dim nomeCampoBD As String = dr.Item("NomeCampo")
            Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
            Dim nomeTipoDbType As String = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString)

            If CBool(dr.Item("IsNulo")) Then
                _str.Append("            cmd.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = (object)this." + nomeCampoCSharp + " ?? DBNull.Value;" + vbCrLf)
            Else
                _str.Append("            cmd.Parameters.Add(""@" + nomeCampoBD + """, SqlDbType." + nomeTipoDbType + ").Value = this." + nomeCampoCSharp + ";" + vbCrLf)
            End If

        Next

        _str.Append("        }" + vbCrLf)

        If _isPossuiIdentidade Then

            _str.Append("        protected override void PreencherIdentidade(SqlCommand cmd)" + vbCrLf)
            _str.Append("        {" + vbCrLf)

            For Each dr As DataRow In _dtCampos.Rows.OfType(Of DataRow).Where(Function(x) CBool(x.Item("IsIdentidade")))
                Dim nomeCampoBD As String = dr.Item("NomeCampo")
                Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
                Dim tipoCampo As String = UtilitarioGeracaoCodigo.ObterTipoCSharp(dr.Item("NomeTipoCampo").ToString)
                If tipoCampo = "string" Then
                    _str.Append("            this." + nomeCampoCSharp + " = cmd.Parameters[""Identity""].Value.ToString();" + vbCrLf)
                Else
                    _str.Append("            this." + nomeCampoCSharp + " = " + tipoCampo + ".Parse(cmd.Parameters[""@Identity""].Value.ToString());" + vbCrLf)
                End If
            Next
            _str.Append("        }" + vbCrLf)
        End If

        _str.Append("        protected override void PreencherAtributos(SqlDataReader dr)" + vbCrLf)
        _str.Append("        {" + vbCrLf)
        _str.Append("            if (dr.Read())" + vbCrLf)
        _str.Append("            {" + vbCrLf)
        _str.Append("                this._found = true;" + vbCrLf)

        For Each dr As DataRow In _dtCampos.Rows

            Dim nomeCampoBD As String = dr.Item("NomeCampo")
            Dim nomeCampoCSharp As String = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD)
            Dim tipoCampo As String = UtilitarioGeracaoCodigo.ObterTipoCSharp(dr.Item("NomeTipoCampo").ToString)
            If tipoCampo = "string" Then
                _str.Append("                if (!string.IsNullOrEmpty(dr[""" + nomeCampoBD + """].ToString())) { this." + nomeCampoCSharp + " = dr[""" + nomeCampoBD + """].ToString(); }" + vbCrLf)
            Else
                _str.Append("                if (!string.IsNullOrEmpty(dr[""" + nomeCampoBD + """].ToString())) { this." + nomeCampoCSharp + " = " + tipoCampo + ".Parse(dr[""" + nomeCampoBD + """].ToString()); }" + vbCrLf)
            End If
        Next

        _str.Append("            }" + vbCrLf)
        _str.Append("        }" + vbCrLf)
        _str.Append(vbCrLf)
        _str.Append("        #endregion" + vbCrLf)
        _str.Append("    }" + vbCrLf)
        _str.Append("}" + vbCrLf)
        _str.Append(vbCrLf)

        Return _str.ToString
    End Function

End Class
