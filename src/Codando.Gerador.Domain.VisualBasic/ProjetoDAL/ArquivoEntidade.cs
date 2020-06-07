using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoEntidade : Base.Arquivo
    {

        private EntidadeGerada _entidade;

        public ArquivoEntidade(EntidadeGerada entidade)
        {
            this._entidade = entidade;
            this.Nome = this._entidade.Nome;
            this.Extensao = ".vb";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            var _str = new StringBuilder();

            _str.AppendLine("Imports System");
            _str.AppendLine("Imports System.Data");
            _str.AppendLine("Imports System.Collections.Generic");
            _str.AppendLine("Imports System.Data.SqlClient ");
            _str.AppendLine("");
            _str.AppendLine("    Public Class " + this._entidade.Nome);
            _str.AppendLine("        Inherits BaseDAL");

            _str.AppendLine("        #Region \"Construtor\"");
            _str.AppendLine("");
            _str.AppendLine("        Public Sub New(p_strConexao As IStrConexao)");
            _str.AppendLine("           MyBase.New(p_strConexao)");
            _str.AppendLine("        End Sub");
            _str.AppendLine("");
            _str.AppendLine("        #End Region");
            _str.AppendLine("");
            _str.AppendLine("");
            _str.AppendLine("    End Class");
            _str.AppendLine("");

            return _str.ToString();
        }

        public override string GetConteudoRegerado()
        {
            var _str = new StringBuilder();

            var atributos = this._entidade.Atributos;

            bool _isPossuiIdentidade = (from a in atributos
                                        where a.IsAutoIncremento
                                        select a).Any();

            bool _isPossuiPK = (from a in atributos
                                where a.IsPK 
                                select a).Any();

            _str.AppendLine("Imports System");
            _str.AppendLine("Imports System.Data");
            _str.AppendLine("Imports System.Collections.Generic");
            _str.AppendLine("Imports System.Data.SqlClient ");
            _str.AppendLine("");
            _str.AppendLine("    Public Partial Class " + this._entidade.Nome);

            _str.AppendLine("");
            _str.AppendLine("        #Region \"GET/SET\"");
            _str.AppendLine("");

            foreach (AtributoGerado atributo in atributos)
            {
                string _tipoCampo = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoVbNet(dr.Item("NomeTipoCampo").ToString);
                string _nomeCampo = atributo.Nome.PascalCasing();

                if (System.Convert.ToBoolean(dr.Item("IsNulo")) && _tipoCampo != "String")
                    _tipoCampo = _tipoCampo + "?";

                _str.AppendLine("        Public Property " + _nomeCampo + " As " + _tipoCampo);
            }

            _str.AppendLine("");
            _str.AppendLine("        #End Region");
            _str.AppendLine("");
            _str.AppendLine("        #Region \"Methods\"");
            _str.AppendLine("");
            if (p_isCore)
                _str.AppendLine("        Public Function List() As List(Of Data.DataRow)");
            else
                _str.AppendLine("        Public Function List() As DataTable");
            _str.AppendLine("            Dim conexao As New SqlConnection(Me._strConexao)");
            if (p_isCore)
                _str.AppendLine("            Dim comando As New SqlCommand(\"usp_" + p_nomeTabela + "_List\", conexao)");
            else
                _str.AppendLine("            Dim comando As New SqlDataAdapter(\"usp_" + p_nomeTabela + "_List\", conexao)");
            _str.AppendLine("");
            _str.AppendLine("            return ExecutarList(conexao, comando)");
            _str.AppendLine("        End Function");
            _str.AppendLine("");
            _str.AppendLine("        Public Sub Retrieve()");
            _str.AppendLine("            Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("            Dim comando As New SqlCommand(\"usp_" + p_nomeTabela + "_Select\", conexao)");

            if (_isPossuiIdentidade && this.IsBuscarIdentidade)
            {
                foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => System.Convert.ToBoolean(x.Item("IsIdentidade"))))
                {
                    string nomeCampoBD = dr.Item("NomeCampo");
                    string nomeCampoVbNet = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                    string nomeTipoDbType = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString);

                    _str.AppendLine("");
                    _str.AppendLine("            comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet + "");
                }
            }
            else if (_isPossuiPK)
            {
                foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => System.Convert.ToBoolean(x.Item("IsPK"))))
                {
                    string nomeCampoBD = dr.Item("NomeCampo");
                    string nomeCampoVbNet = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                    string nomeTipoDbType = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString);

                    _str.AppendLine("");
                    _str.AppendLine("            comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet);
                }
            }

            _str.AppendLine("");
            _str.AppendLine("            Me.ExecutarDataReader(conexao, comando)");
            _str.AppendLine("        End Sub");
            _str.AppendLine("");
            _str.AppendLine("        Public Function Save() As Boolean");
            _str.AppendLine("            Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("            Dim comando As New SqlCommand(\"usp_" + p_nomeTabela + "_Insert\", conexao)");
            _str.AppendLine("            Me.PreencherParametros(comando)");

            if (_isPossuiIdentidade)
                _str.AppendLine("            comando.Parameters.Add(\"@Identity\", SqlDbType.Int).Direction = ParameterDirection.Output");

            _str.AppendLine("            return ExecutarComando(conexao, comando, true)");
            _str.AppendLine("        End Function");
            _str.AppendLine("");
            _str.AppendLine("        Public Function Update() As Boolean");
            _str.AppendLine("            Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("            Dim comando As New SqlCommand(\"usp_" + p_nomeTabela + "_Update\", conexao)");

            if (_isPossuiIdentidade && this.IsBuscarIdentidade)
            {
                foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => System.Convert.ToBoolean(x.Item("IsIdentidade"))))
                {
                    string nomeCampoBD = dr.Item("NomeCampo");
                    string nomeCampoCSharp = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                    string nomeTipoDbType = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString);

                    _str.AppendLine("");
                    _str.AppendLine("            comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp);
                }
            }
            else if (_isPossuiPK)
            {
                foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => System.Convert.ToBoolean(x.Item("IsPK"))))
                {
                    string nomeCampoBD = dr.Item("NomeCampo");
                    string nomeCampoCSharp = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                    string nomeTipoDbType = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString);

                    _str.AppendLine("");
                    _str.AppendLine("            comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp);
                }
            }

            _str.AppendLine("            Me.PreencherParametros(comando)");
            _str.AppendLine("            return ExecutarComando(conexao, comando, false)");
            _str.AppendLine("        End Function");
            _str.AppendLine("");
            _str.AppendLine("        Public Function Delete() As Boolean");
            _str.AppendLine("            Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("            Dim comando As New SqlCommand(\"usp_" + p_nomeTabela + "_Delete\", conexao)");

            if (_isPossuiIdentidade && this.IsBuscarIdentidade)
            {
                foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => System.Convert.ToBoolean(x.Item("IsIdentidade"))))
                {
                    string nomeCampoBD = dr.Item("NomeCampo");
                    string nomeCampoCSharp = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                    string nomeTipoDbType = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString);

                    _str.AppendLine("");
                    _str.AppendLine("            comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp);
                }
            }
            else if (_isPossuiPK)
            {
                foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => System.Convert.ToBoolean(x.Item("IsPK"))))
                {
                    string nomeCampoBD = dr.Item("NomeCampo");
                    string nomeCampoCSharp = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                    string nomeTipoDbType = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString);

                    _str.AppendLine("");
                    _str.AppendLine("            comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp);
                }
            }

            _str.AppendLine("            return ExecutarComando(conexao, comando, false)");
            _str.AppendLine("        End Function");
            _str.AppendLine("");
            _str.AppendLine("        #End Region");
            _str.AppendLine("");
            _str.AppendLine("        #Region \"Aux\"");
            _str.AppendLine("");
            _str.AppendLine("        Private Sub PreencherParametros(cmd As SqlCommand)");

            foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => !System.Convert.ToBoolean(x.Item("IsIdentidade"))))
            {
                string nomeCampoBD = dr.Item("NomeCampo");
                string nomeCampoCSharp = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                string nomeTipoDbType = UtilitarioGeracaoCodigo.ObterTipoSqlDbType(dr.Item("NomeTipoCampo"), dr.Item("TamanhoCampo").ToString, dr.Item("Precisao").ToString, dr.Item("Escala").ToString);

                if (System.Convert.ToBoolean(dr.Item("IsNulo")))
                    _str.AppendLine("            cmd.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = If(Me." + nomeCampoCSharp + ", DBNull.Value)");
                else
                    _str.AppendLine("            cmd.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoCSharp);
            }

            _str.AppendLine("        End Sub");
            _str.AppendLine("");

            if (_isPossuiIdentidade)
            {
                _str.AppendLine("        Protected Overrides Sub PreencherIdentidade(cmd As SqlCommand)");

                foreach (DataRow dr in _dtCampos.Rows.OfType<DataRow>.Where(x => System.Convert.ToBoolean(x.Item("IsIdentidade"))))
                {
                    string nomeCampoBD = dr.Item("NomeCampo");
                    string nomeCampoCSharp = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                    string tipoCampo = UtilitarioGeracaoCodigo.ObterTipoVbNet(dr.Item("NomeTipoCampo").ToString);
                    if (tipoCampo == "string")
                        _str.AppendLine("            Me." + nomeCampoCSharp + " = cmd.Parameters(\"@Identity\").Value");
                    else
                        _str.AppendLine("            Me." + nomeCampoCSharp + " = cmd.Parameters(\"@Identity\").Value");
                }
                _str.AppendLine("        End Sub");
                _str.AppendLine("");
            }

            _str.AppendLine("        Protected Overrides Sub PreencherAtributos(dr As SqlDataReader)");
            _str.AppendLine("            if dr.Read Then");
            _str.AppendLine("                Me._found = true");

            foreach (DataRow dr in _dtCampos.Rows)
            {
                string nomeCampoBD = dr.Item("NomeCampo");
                string nomeCampoCSharp = UtilitarioGeracaoCodigo.PascalCasing(nomeCampoBD);
                string tipoCampo = UtilitarioGeracaoCodigo.ObterTipoVbNet(dr.Item("NomeTipoCampo").ToString);
                if (tipoCampo == "String")
                    _str.AppendLine("                if Not IsDbNull(dr.Item(\"" + nomeCampoBD + "\")) Then Me." + nomeCampoCSharp + " = dr.Item(\"" + nomeCampoBD + "\").ToString() ");
                else
                    _str.AppendLine("                if Not IsDbNull(dr.Item(\"" + nomeCampoBD + "\")) Then Me." + nomeCampoCSharp + " = dr.Item(\"" + nomeCampoBD + "\").ToString() ");
            }

            _str.AppendLine("            End If");
            _str.AppendLine("        End Sub");
            _str.AppendLine("");
            _str.AppendLine("        #End Region");
            _str.AppendLine("");
            _str.AppendLine("    End Class");
            _str.AppendLine("");

            return _str.ToString();
        }
    }
}
