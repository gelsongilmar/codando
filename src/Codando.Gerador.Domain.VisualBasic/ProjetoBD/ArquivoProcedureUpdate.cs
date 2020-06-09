using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Linq;
using System.Text;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoBD
{
    internal class ArquivoProcedureUpdate : Arquivo
    {
        private EntidadeGerada _entidade;

        public ArquivoProcedureUpdate(EntidadeGerada entidade)
        {
            this._entidade = entidade;
            this.UsarArquivoSeparadoParaRegerar = false;
            this.Nome = "usp_" + this._entidade.Nome + "_Update";
            this.Extensao = ".sql";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            return "";
        }

        public override string GetConteudoRegerado()
        {
            StringBuilder _str = new StringBuilder();

            _str.AppendLine("--================ [ IMPORTANTE ] ================");
            _str.AppendLine("-- Arquivo Regerável. Não altere este arquivo.");
            _str.AppendLine("-- As alterações serão perdidas sempre que o");
            _str.AppendLine("-- Codando for executado");
            _str.AppendLine("--================================================");
            _str.AppendLine("");

            var _campos = this._entidade.Atributos;
            var _camposPK = from c in _campos
                            where c.IsPK
                            select c;
            var _camposNaoPK = from c in _campos
                               where !c.IsPK
                               select c;

            _str.AppendLine("CREATE PROCEDURE " + this.Nome);

            foreach (var campo in _campos)
            {
                string nomeCampoBD = campo.Nome;
                string _tipoBD = ((TipoAtributoBaseGeracao)campo.Tipo).ObterTipoBDCompleto(campo.Tamanho, campo.Precisao);

                string _strFimLinha = "\r\n";
                if (campo.Nome != _campos.Last().Nome)
                {
                    _strFimLinha = ", \r\n";
                }

                _str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha);
            }

            _str.AppendLine(" AS ");
            _str.AppendLine("    UPDATE " + this._entidade.Nome + " SET");

            foreach (var campo in _camposNaoPK)
            {
                string nomeCampoBD = campo.Nome;

                string _strFimLinha = "\r\n";
                if (campo.Nome != _campos.Last().Nome)
                {
                    _strFimLinha = ", \r\n";
                }

                _str.Append("        " + nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha);
            }

            _str.Append("    WHERE ");

            foreach (var campo in _camposPK)
            {
                string nomeCampoBD = campo.Nome;

                string _strFimLinha = "";
                if (campo.Nome != _camposPK.Last().Nome)
                    _strFimLinha = " AND \r\n";

                _str.Append(nomeCampoBD + " = @" + nomeCampoBD + _strFimLinha);
            }

            return _str.ToString();
        }

    }
}
