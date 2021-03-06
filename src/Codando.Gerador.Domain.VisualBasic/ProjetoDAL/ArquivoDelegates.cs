﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoDAL
{
    class ArquivoDelegates : Base.Arquivo
    {
        public ArquivoDelegates()
        {
            this.Nome = "Delegates";
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
            _str.AppendLine("Public Delegate Sub DelPreencherAtributos(dr As SqlDataReader)");
            _str.AppendLine("Public Delegate Sub DelPreencherIdentidade(cmd As SqlCommand)");
            _str.AppendLine("");

            return _str.ToString();
        }
    }
}
