using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoSQLCommands : Base.Arquivo
    {
        public ArquivoSQLCommands()
        {
            this.Nome = "SQLCommands";
            this.Extensao = ".vb";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            return "";
        }

        public override string GetConteudoRegerado()
        {
            var _str = new StringBuilder();
            _str.AppendLine("'================ [ IMPORTANTE ] ================");
            _str.AppendLine("' Arquivo Regerável. Não altere este arquivo.");
            _str.AppendLine("' As alterações serão perdidas sempre que o");
            _str.AppendLine("' Codando for executado");
            _str.AppendLine("'================================================");
            _str.AppendLine("");
            _str.AppendLine("Imports System.Data.SqlClient");
            _str.AppendLine("");
            _str.AppendLine("Public Class SQLCommands");
            _str.AppendLine("");
            _str.AppendLine("    Public Shared Function ExecutarList(p_conexao As SqlConnection, p_adp As SqlDataAdapter) As DataTable");
            _str.AppendLine("        Dim dt As New DataTable");
            _str.AppendLine("        Try");
            _str.AppendLine("            p_conexao.Open()");
            _str.AppendLine("            p_adp.SelectCommand.CommandType = CommandType.StoredProcedure");
            _str.AppendLine("            p_adp.Fill(dt)");
            _str.AppendLine("        Catch ex As Exception");
            _str.AppendLine("            Throw");
            _str.AppendLine("        Finally");
            _str.AppendLine("            p_conexao.Close()");
            _str.AppendLine("            p_adp.Dispose()");
            _str.AppendLine("        End Try");
            _str.AppendLine("        Return dt");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Public Shared Sub ExecutarDataReader(p_conexao As SqlConnection, p_comando As SqlCommand, p_callBack As DelPreencherAtributos)");
            _str.AppendLine("        Try");
            _str.AppendLine("            p_conexao.Open()");
            _str.AppendLine("            p_comando.CommandType = CommandType.StoredProcedure");
            _str.AppendLine("            p_callBack(p_comando.ExecuteReader)");
            _str.AppendLine("        Catch ex As Exception");
            _str.AppendLine("            Throw");
            _str.AppendLine("        Finally");
            _str.AppendLine("            p_conexao.Close()");
            _str.AppendLine("            p_comando.Dispose()");
            _str.AppendLine("        End Try");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("    Public Shared Function ExecutarComando(p_conexao As SqlConnection, p_comando As SqlCommand, Optional p_preencherIdentidade As Boolean = False, Optional p_callBack As DelPreencherIdentidade = Nothing) As Boolean");
            _str.AppendLine("        Dim resultado As Boolean = False");
            _str.AppendLine("        Try");
            _str.AppendLine("            p_conexao.Open()");
            _str.AppendLine("            p_comando.CommandType = CommandType.StoredProcedure");
            _str.AppendLine("            resultado = p_comando.ExecuteNonQuery > 0");
            _str.AppendLine("            If p_preencherIdentidade AndAlso p_callBack IsNot Nothing Then");
            _str.AppendLine("                p_callBack(p_comando)");
            _str.AppendLine("            End If");
            _str.AppendLine("        Catch ex As Exception");
            _str.AppendLine("            Throw");
            _str.AppendLine("        Finally");
            _str.AppendLine("            p_conexao.Close()");
            _str.AppendLine("            p_comando.Dispose()");
            _str.AppendLine("        End Try");
            _str.AppendLine("        Return resultado");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Public Shared Function ExecutarScalar(Of T)(p_conexao As SqlConnection, p_comando As SqlCommand) As T");
            _str.AppendLine("        Dim resultado As T");
            _str.AppendLine("        Try");
            _str.AppendLine("            p_conexao.Open()");
            _str.AppendLine("            p_comando.CommandType = CommandType.StoredProcedure");
            _str.AppendLine("            resultado = p_comando.ExecuteScalar");
            _str.AppendLine("        Catch ex As Exception");
            _str.AppendLine("            Throw");
            _str.AppendLine("        Finally");
            _str.AppendLine("            p_conexao.Close()");
            _str.AppendLine("            p_comando.Dispose()");
            _str.AppendLine("        End Try");
            _str.AppendLine("        Return resultado");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("End Class");

            return _str.ToString();
        }
    }
}
