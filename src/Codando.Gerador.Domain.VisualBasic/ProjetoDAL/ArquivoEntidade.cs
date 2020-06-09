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
            _str.AppendLine("Public Class " + this._entidade.Nome);
            _str.AppendLine("    Inherits BaseDAL");

            _str.AppendLine("    #Region \"Construtor\"");
            _str.AppendLine("");
            _str.AppendLine("    Public Sub New(p_strConexao As IStrConexao)");
            _str.AppendLine("       MyBase.New(p_strConexao)");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("    #End Region");
            _str.AppendLine("");
            _str.AppendLine("");
            _str.AppendLine("End Class");
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

            _str.AppendLine("'================ [ IMPORTANTE ] ================");
            _str.AppendLine("' Arquivo Regerável. Não altere este arquivo.");
            _str.AppendLine("' As alterações serão perdidas sempre que o");
            _str.AppendLine("' Codando for executado");
            _str.AppendLine("'================================================");
            _str.AppendLine("");
            _str.AppendLine("Imports System");
            _str.AppendLine("Imports System.Data");
            _str.AppendLine("Imports System.Collections.Generic");
            _str.AppendLine("Imports System.Data.SqlClient ");
            _str.AppendLine("");
            _str.AppendLine("Public Partial Class " + this._entidade.Nome);

            _str.AppendLine("");
            _str.AppendLine("    #Region \"GET/SET\"");
            _str.AppendLine("");

            foreach (AtributoGerado atributo in atributos)
            {
                string _tipoCampo = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoVbNet();
                string _nomeCampo = atributo.Nome.PascalCasing();

                if (atributo.IsNulo && _tipoCampo != "String")
                {
                    _tipoCampo += "?";
                }

                _str.AppendLine("    Public Property " + _nomeCampo + " As " + _tipoCampo);
            }

            _str.AppendLine("");
            _str.AppendLine("    #End Region");
            _str.AppendLine("");
            _str.AppendLine("    #Region \"Methods\"");
            _str.AppendLine("");
            _str.AppendLine("    Public Function List() As DataTable");
            _str.AppendLine("        Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("        Dim comando As New SqlDataAdapter(\"usp_" + this._entidade.Nome + "_List\", conexao)");
            _str.AppendLine("");
            _str.AppendLine("        return ExecutarList(conexao, comando)");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Public Sub Retrieve()");
            _str.AppendLine("        Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("        Dim comando As New SqlCommand(\"usp_" + this._entidade.Nome + "_Select\", conexao)");

            if (_isPossuiIdentidade)
            {
                foreach (var atributo in atributos.Where(x => x.IsAutoIncremento))
                {
                    string nomeCampoBD = atributo.Nome;
                    string nomeCampoVbNet = atributo.Nome.PascalCasing();
                    string nomeTipoDbType = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoSqlDbType(atributo.Tamanho);

                    _str.AppendLine("");
                    _str.AppendLine("        comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet + "");
                }
            }
            else if (_isPossuiPK)
            {
                foreach (var atributo in atributos.Where(x => x.IsPK))
                {
                    string nomeCampoBD = atributo.Nome;
                    string nomeCampoVbNet = atributo.Nome.PascalCasing();
                    string nomeTipoDbType = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoSqlDbType(atributo.Tamanho);

                    _str.AppendLine("");
                    _str.AppendLine("        comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet);
                }
            }

            _str.AppendLine("");
            _str.AppendLine("        Me.ExecutarDataReader(conexao, comando)");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("    Public Function Save() As Boolean");
            _str.AppendLine("        Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("        Dim comando As New SqlCommand(\"usp_" + this._entidade.Nome + "_Insert\", conexao)");
            _str.AppendLine("        Me.PreencherParametros(comando)");

            if (_isPossuiIdentidade)
                _str.AppendLine("        comando.Parameters.Add(\"@Identity\", SqlDbType.Int).Direction = ParameterDirection.Output");

            _str.AppendLine("        return ExecutarComando(conexao, comando, true)");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Public Function Update() As Boolean");
            _str.AppendLine("        Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("        Dim comando As New SqlCommand(\"usp_" + this._entidade.Nome + "_Update\", conexao)");

            if (_isPossuiIdentidade)
            {
                foreach (var atributo in atributos.Where(x => x.IsAutoIncremento))
                {
                    string nomeCampoBD = atributo.Nome;
                    string nomeCampoVbNet = atributo.Nome.PascalCasing();
                    string nomeTipoDbType = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoSqlDbType(atributo.Tamanho);

                    _str.AppendLine("");
                    _str.AppendLine("        comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet);
                }
            }
            else if (_isPossuiPK)
            {
                foreach (var atributo in atributos.Where(x => x.IsPK))
                {
                    string nomeCampoBD = atributo.Nome;
                    string nomeCampoVbNet = atributo.Nome.PascalCasing();
                    string nomeTipoDbType = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoSqlDbType(atributo.Tamanho);

                    _str.AppendLine("");
                    _str.AppendLine("        comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet);
                }
            }

            _str.AppendLine("        Me.PreencherParametros(comando)");
            _str.AppendLine("        return ExecutarComando(conexao, comando, false)");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Public Function Delete() As Boolean");
            _str.AppendLine("        Dim conexao As New SqlConnection(Me._strConexao)");
            _str.AppendLine("        Dim comando As New SqlCommand(\"usp_" + this._entidade.Nome + "_Delete\", conexao)");

            if (_isPossuiIdentidade)
            {
                foreach (var atributo in atributos.Where(x => x.IsAutoIncremento))
                {
                    string nomeCampoBD = atributo.Nome;
                    string nomeCampoVbNet = atributo.Nome.PascalCasing();
                    string nomeTipoDbType = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoSqlDbType(atributo.Tamanho);

                    _str.AppendLine("");
                    _str.AppendLine("        comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet);
                }
            }
            else if (_isPossuiPK)
            {
                foreach (var atributo in atributos.Where(x => x.IsPK))
                {
                    string nomeCampoBD = atributo.Nome;
                    string nomeCampoVbNet = atributo.Nome.PascalCasing();
                    string nomeTipoDbType = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoSqlDbType(atributo.Tamanho);

                    _str.AppendLine("");
                    _str.AppendLine("        comando.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet);
                }
            }

            _str.AppendLine("        return ExecutarComando(conexao, comando, false)");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    #End Region");
            _str.AppendLine("");
            _str.AppendLine("    #Region \"Aux\"");
            _str.AppendLine("");
            _str.AppendLine("    Private Sub PreencherParametros(cmd As SqlCommand)");

            foreach (var atributo in atributos.Where(x => x.IsAutoIncremento))
            {
                string nomeCampoBD = atributo.Nome;
                string nomeCampoVbNet = atributo.Nome.PascalCasing();
                string nomeTipoDbType = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoSqlDbType(atributo.Tamanho);

                if (atributo.IsNulo)
                    _str.AppendLine("        cmd.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = If(Me." + nomeCampoVbNet + ", DBNull.Value)");
                else
                    _str.AppendLine("        cmd.Parameters.Add(\"@" + nomeCampoBD + "\", SqlDbType." + nomeTipoDbType + ").Value = Me." + nomeCampoVbNet);
            }

            _str.AppendLine("    End Sub");
            _str.AppendLine("");

            if (_isPossuiIdentidade)
            {
                _str.AppendLine("    Protected Overrides Sub PreencherIdentidade(cmd As SqlCommand)");

                foreach (var atributo in atributos.Where(x => x.IsAutoIncremento))
                {
                    string nomeCampoBD = atributo.Nome;
                    string nomeCampoVbNet = atributo.Nome.PascalCasing();
                    string tipoCampo = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoVbNet();
                    _str.AppendLine("        Me." + nomeCampoVbNet + " = cmd.Parameters(\"@Identity\").Value");
                }

                _str.AppendLine("    End Sub");
                _str.AppendLine("");
            }

            _str.AppendLine("    Protected Overrides Sub PreencherAtributos(dr As SqlDataReader)");
            _str.AppendLine("        if dr.Read Then");
            _str.AppendLine("            Me.Found = true");

            foreach (var atributo in atributos)
            {
                string nomeCampoBD = atributo.Nome;
                string nomeCampoVbNet = atributo.Nome.PascalCasing();
                string tipoCampo = ((TipoAtributoBaseGeracao)atributo.Tipo).ObterTipoVbNet();
                _str.AppendLine("            if Not IsDbNull(dr.Item(\"" + nomeCampoBD + "\")) Then Me." + nomeCampoVbNet + " = dr.Item(\"" + nomeCampoBD + "\").ToString() ");
            }

            _str.AppendLine("        End If");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("    #End Region");
            _str.AppendLine("");
            _str.AppendLine("End Class");
            _str.AppendLine("");

            return _str.ToString();
        }
    }
}
