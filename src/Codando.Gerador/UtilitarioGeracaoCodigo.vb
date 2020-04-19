Imports Microsoft.VisualBasic

Public Class UtilitarioGeracaoCodigo

    Public Shared Function ObterTipoCSharp(p_nomeCampoBD As String) As String
        Select Case p_nomeCampoBD
            Case "bigint" : Return "long"
            Case "binary" : Return "-"
            Case "bit" : Return "bool"
            Case "char" : Return "string"
            Case "date" : Return "DateTime"
            Case "datetime" : Return "DateTime"
            Case "datetime2" : Return "DateTime"
            Case "datetimeoffset" : Return "DateTime"
            Case "decimal" : Return "double"
            Case "float" : Return "double"
            Case "geography" : Return "-"
            Case "geometry" : Return "-"
            Case "hierarchyid" : Return "-"
            Case "image" : Return "-"
            Case "int" : Return "int"
            Case "money" : Return "double"
            Case "nchar" : Return "string"
            Case "ntext" : Return "string"
            Case "numeric" : Return "int"
            Case "nvarchar" : Return "string"
            Case "real" : Return "double"
            Case "smalldatetime" : Return "DateTime"
            Case "smallint" : Return "single"
            Case "smallmoney" : Return "float"
            Case "sql_variant" : Return "-"
            Case "sysname" : Return "-"
            Case "text" : Return "string"
            Case "time" : Return "DateTime"
            Case "timestamp" : Return "DateTime"
            Case "tinyint" : Return "single"
            Case "uniqueidentifier" : Return "-"
            Case "varbinary" : Return "string"
            Case "varchar" : Return "string"
            Case "xml" : Return "-"
        End Select
        Return ""
    End Function
    Public Shared Function ObterTipoSqlDbType(p_nomeCampoBD As String, p_tamanho As String, p_precisao As String, p_escala As String) As String
        If IsNumeric(p_tamanho) AndAlso CInt(p_tamanho) < 0 Then
            p_tamanho = "-1"
        End If

        Select Case p_nomeCampoBD
            Case "bigint" : Return "BigInt"
            Case "binary" : Return "-"
            Case "bit" : Return "Bit"
            Case "char" : Return "Char"
            Case "date" : Return "Date"
            Case "datetime" : Return "DateTime"
            Case "datetime2" : Return "DateTime2"
            Case "datetimeoffset" : Return "DateTime"
            Case "decimal" : Return "Decimal"
            Case "float" : Return "Float"
            Case "geography" : Return "-"
            Case "geometry" : Return "-"
            Case "hierarchyid" : Return "-"
            Case "image" : Return "-"
            Case "int" : Return "Int"
            Case "money" : Return "Money"
            Case "nchar" : Return "NChar, " + p_tamanho
            Case "ntext" : Return "NText"
            Case "numeric" : Return "int"
            Case "nvarchar" : Return "NVarChar, " + p_tamanho
            Case "real" : Return "Real"
            Case "smalldatetime" : Return "SmallDateTime"
            Case "smallint" : Return "SmallInt"
            Case "smallmoney" : Return "SmallMoney"
            Case "sql_variant" : Return "-"
            Case "sysname" : Return "-"
            Case "text" : Return "Text"
            Case "time" : Return "Time"
            Case "timestamp" : Return "TimeStamp"
            Case "tinyint" : Return "TinyInt"
            Case "uniqueidentifier" : Return "-"
            Case "varbinary" : Return "-"
            Case "varchar" : Return "VarChar, " + p_tamanho
            Case "xml" : Return "-"
        End Select
        Return ""
    End Function
    Public Shared Function ObterTipoBDCompleto(p_nomeCampoBD As String, p_tamanho As String, p_precisao As String, p_escala As String) As String
        If IsNumeric(p_tamanho) AndAlso CInt(p_tamanho) < 0 Then
            p_tamanho = "MAX"
        End If
        Select Case p_nomeCampoBD
            Case "char" : Return "char(" + p_tamanho + ")"
            Case "decimal" : Return "decimal(" + p_precisao + "," + p_escala + ")"
            Case "nchar" : Return "nchar(" + p_tamanho + ")"
            Case "ntext" : Return "ntext(" + p_tamanho + ")"
            Case "nvarchar" : Return "nvarchar(" + p_tamanho + ")"
            Case "varbinary" : Return "varbinary(" + p_tamanho + ")"
            Case "varchar" : Return "varchar(" + p_tamanho + ")"
            Case Else : Return p_nomeCampoBD
        End Select
    End Function


    Public Shared Function ObterTipoVbNet(p_nomeCampoBD As String) As String
        Select Case p_nomeCampoBD
            Case "bigint" : Return "Long"
            Case "binary" : Return "-"
            Case "bit" : Return "Boolean"
            Case "char" : Return "String"
            Case "date" : Return "DateTime"
            Case "datetime" : Return "DateTime"
            Case "datetime2" : Return "DateTime"
            Case "datetimeoffset" : Return "DateTime"
            Case "decimal" : Return "Decimal"
            Case "float" : Return "Decimal"
            Case "geography" : Return "-"
            Case "geometry" : Return "-"
            Case "hierarchyid" : Return "-"
            Case "image" : Return "-"
            Case "int" : Return "Integer"
            Case "money" : Return "Decimal"
            Case "nchar" : Return "String"
            Case "ntext" : Return "String"
            Case "numeric" : Return "Integer"
            Case "nvarchar" : Return "String"
            Case "real" : Return "Decimal"
            Case "smalldatetime" : Return "DateTime"
            Case "smallint" : Return "Single"
            Case "smallmoney" : Return "Decimal"
            Case "sql_variant" : Return "-"
            Case "sysname" : Return "-"
            Case "text" : Return "String"
            Case "time" : Return "DateTime"
            Case "timestamp" : Return "DateTime"
            Case "tinyint" : Return "Single"
            Case "uniqueidentifier" : Return "-"
            Case "varbinary" : Return "String"
            Case "varchar" : Return "String"
            Case "xml" : Return "-"
        End Select
        Return ""
    End Function

    Public Shared Function PascalCasing(p_campo As String) As String
        Return Mid(p_campo, 1, 1).ToUpper + Mid(p_campo, 2)
    End Function

End Class
