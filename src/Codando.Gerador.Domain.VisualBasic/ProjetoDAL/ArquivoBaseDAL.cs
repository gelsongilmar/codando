using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoBaseDAL : Base.Arquivo
    {
        public ArquivoBaseDAL()
        {
            this.Nome = "BaseDAL";
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
            _str.AppendLine("Imports System.Reflection");
            _str.AppendLine("");
            _str.AppendLine("Public MustInherit Class BaseDAL");
            _str.AppendLine("");
            _str.AppendLine("    Protected _strConexao As String");
            _str.AppendLine("    Protected _chaveCriptografia As String");
            _str.AppendLine("    Protected Conexao As IStrConexao");
            _str.AppendLine("");
            _str.AppendLine("    Public Sub New(p_strConexao As IStrConexao)");
            _str.AppendLine("        Me._strConexao = p_strConexao.ObterStrConexao");
            _str.AppendLine("        Me._chaveCriptografia = p_strConexao.ObterChaveCriptografia");
            _str.AppendLine("        Me.Conexao = p_strConexao");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("    <NotMappeableBD>");
            _str.AppendLine("    Public Property Found As Boolean");
            _str.AppendLine("");
            _str.AppendLine("    Protected Function ExecutarList(p_conexao As SqlConnection, p_adp As SqlDataAdapter) As DataTable");
            _str.AppendLine("        Return SQLCommands.ExecutarList(p_conexao, p_adp)");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Protected Sub ExecutarDataReader(p_conexao As SqlConnection, p_comando As SqlCommand)");
            _str.AppendLine("        SQLCommands.ExecutarDataReader(p_conexao, p_comando, AddressOf Me.PreencherAtributos)");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("    Protected Function ExecutarComando(p_conexao As SqlConnection, p_comando As SqlCommand, Optional p_preencherIdentidade As Boolean = False) As Boolean");
            _str.AppendLine("        Return SQLCommands.ExecutarComando(p_conexao, p_comando, p_preencherIdentidade, AddressOf Me.PreencherIdentidade)");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Protected Function ExecutarScalar(Of T)(p_conexao As SqlConnection, p_comando As SqlCommand) As T");
            _str.AppendLine("        Return SQLCommands.ExecutarScalar(Of T)(p_conexao, p_comando)");
            _str.AppendLine("    End Function");
            _str.AppendLine("");
            _str.AppendLine("    Protected MustOverride Sub PreencherAtributos(dr As SqlDataReader)");
            _str.AppendLine("    Protected Sub PreencherAtributosCRUD(dr As SqlDataReader)");
            _str.AppendLine("        If dr.Read Then");
            _str.AppendLine("            Me.Found = True");
            _str.AppendLine("            For Each prop In Me.GetType.GetProperties");
            _str.AppendLine("                If prop.GetCustomAttributes(Of NotMappeableBDAttribute)(True).Count = 0 Then");
            _str.AppendLine("                    If Not IsDBNull(dr.Item(prop.Name)) Then prop.SetValue(Me, dr.Item(prop.Name))");
            _str.AppendLine("                End If");
            _str.AppendLine("            Next");
            _str.AppendLine("        End If");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("");
            _str.AppendLine("    Protected Overridable Sub PreencherIdentidade(cmd As SqlCommand)");
            _str.AppendLine("    End Sub");
            _str.AppendLine("");
            _str.AppendLine("End Class");

            return _str.ToString();
        }
    }
}
