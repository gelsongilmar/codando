using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Linq;
using System.Text;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoBD
{
    internal class ArquivoProcedureSelect : Arquivo
    {
        private EntidadeGerada _entidade;

        public ArquivoProcedureSelect(EntidadeGerada entidade)
        {
            this._entidade = entidade;
            this.UsarArquivoSeparadoParaRegerar = false;
            this.Nome = "usp_" + this._entidade.Nome + "_Select";
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

            var _camposPK = from c in this._entidade.Atributos
                            where c.IsPK
                            select c;

            bool _isPossuiPK = _camposPK.Any();

            _str.AppendLine("CREATE PROCEDURE " + this.Nome);

            foreach (var campo in _camposPK)
            {
                string nomeCampoBD = campo.Nome;
                string _tipoBD = ((TipoAtributoBaseGeracao)campo.Tipo).ObterTipoBDCompleto(campo.Tamanho, campo.Precisao);

                string _strFimLinha = "";
                if (campo.Nome != _camposPK.Last().Nome)
                    _strFimLinha = ", \r\n";

                _str.AppendLine("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha);
            }

            _str.AppendLine(" AS ");
            _str.AppendLine("    SELECT * ");
            _str.AppendLine("    FROM " + this._entidade.Nome);
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
