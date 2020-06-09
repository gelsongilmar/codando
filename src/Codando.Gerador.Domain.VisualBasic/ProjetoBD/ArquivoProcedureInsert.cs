using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System;
using System.Linq;
using System.Text;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoBD
{
    internal class ArquivoProcedureInsert : Arquivo
    {
        private EntidadeGerada _entidade;

        public ArquivoProcedureInsert(EntidadeGerada entidade)
        {
            this._entidade = entidade;
            this.UsarArquivoSeparadoParaRegerar = false;
            this.Nome = "usp_" + this._entidade.Nome + "_Insert";
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

            var _camposIdentidade = from c in this._entidade.Atributos
                                    where c.IsAutoIncremento
                                    select c;
            var _camposNaoIdentidade = from c in this._entidade.Atributos
                                       where !c.IsAutoIncremento
                                       select c;

            bool _isPossuiIdentidade = _camposIdentidade.Any();

            _str.AppendLine("CREATE PROCEDURE " + this.Nome);

            foreach (var campo in _camposNaoIdentidade)
            {
                string nomeCampoBD = campo.Nome;
                string _tipoBD = ((TipoAtributoBaseGeracao)campo.Tipo).ObterTipoBDCompleto(campo.Tamanho, campo.Precisao);

                string _strFimLinha = "\r\n";
                if (campo.Nome != _camposNaoIdentidade.Last().Nome)
                {
                    _strFimLinha = ", \r\n";
                }
                else if (_isPossuiIdentidade)
                {
                    _strFimLinha = ", \r\n";
                }

                _str.Append("    @" + nomeCampoBD + " " + _tipoBD + _strFimLinha);
            }

            if (_isPossuiIdentidade)
            {

                foreach (var campo in _camposIdentidade)
                {
                    string _tipoBD = ((TipoAtributoBaseGeracao)campo.Tipo).ObterTipoBDCompleto(campo.Tamanho, campo.Precisao);
                    _str.AppendLine("    @Identity " + _tipoBD + " output ");
                }

            }

            _str.AppendLine("AS ");
            _str.AppendLine("    INSERT INTO " + this._entidade.Nome + " ( ");

            foreach (var campo in _camposNaoIdentidade)
            {
                string nomeCampoBD = campo.Nome;

                string _strFimLinha = "\r\n";
                if (campo.Nome != _camposNaoIdentidade.Last().Nome)
                {
                    _strFimLinha = ", \r\n";
                }

                _str.Append("        " + nomeCampoBD + _strFimLinha);
            }

            _str.AppendLine("    ) VALUES ( ");

            foreach (var campo in _camposNaoIdentidade)
            {
                string nomeCampoBD = campo.Nome;

                string _strFimLinha = "\r\n";
                if (campo.Nome != _camposNaoIdentidade.Last().Nome)
                {
                    _strFimLinha = ", \r\n";
                }

                _str.Append("        @" + nomeCampoBD + _strFimLinha);
            }

            _str.AppendLine("    )");

            if (_isPossuiIdentidade)
            {
                _str.AppendLine("    SET @Identity = SCOPE_IDENTITY()");
            }

            return _str.ToString();
        }

    }
}
