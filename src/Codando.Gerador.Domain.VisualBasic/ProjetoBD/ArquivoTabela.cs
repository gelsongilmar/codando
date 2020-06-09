using Codando.Gerador.Domain.Base;
using Codando.Shared;
using System.Linq;
using System.Text;

namespace Codando.Gerador.Domain.VisualBasic.ProjetoBD
{
    internal class ArquivoTabela : Arquivo
    {
        private EntidadeGerada _entidade;

        public ArquivoTabela(EntidadeGerada entidade)
        {
            this._entidade = entidade;
            this.UsarArquivoSeparadoParaRegerar = false;
            this.Nome = this._entidade.Nome;
            this.Extensao = ".sql";
        }

        public override string GetConteudoGeradoApenasUmaVez()
        {
            return "";
        }

        public override string GetConteudoRegerado()
        {
            StringBuilder _str = new StringBuilder();

            var _campos = this._entidade.Atributos;
            bool _isPossuiPK = (from c in _campos
                                where c.IsPK
                                select c).Any();

            _str.AppendLine(" CREATE TABLE " + this._entidade.Nome + " ( ");

            foreach (var campo in _campos)
            {

                string _nomeCampo = campo.Nome;
                string _tipoBD = ((TipoAtributoBaseGeracao)campo.Tipo).ObterTipoBDCompleto(campo.Tamanho, campo.Precisao);
                bool _isIdentidade = campo.IsAutoIncremento;
                bool _isNulo = campo.IsNulo;

                string _strIdentidade = "";
                if (_isIdentidade)
                    _strIdentidade = " IDENTITY(1,1)";

                string _strNulo = " NOT NULL";
                if (_isNulo)
                    _strNulo = " NULL";
                string _strFimLinha = "";
                if (_nomeCampo != _campos.Last().Nome)
                    _strFimLinha = ", \r\n";

                _str.Append(" 	" + _nomeCampo + " " + _tipoBD + _strIdentidade + _strNulo + _strFimLinha);
            }

            if (_isPossuiPK)
            {
                _str.AppendLine(",");
                _str.Append(" 	CONSTRAINT PK_" + this._entidade.Nome + " PRIMARY KEY (");

                var camposPK = (from c in _campos
                                where c.IsPK
                                select c).ToList();
                foreach (var campo in camposPK)
                {
                    string _nomeCampo = campo.Nome;

                    string _strFimLinha = "";
                    if (_nomeCampo != camposPK.Last().Nome)
                        _strFimLinha = ", ";

                    _str.Append(_nomeCampo + _strFimLinha);
                }

                _str.AppendLine(")");
            }

            _str.AppendLine("); ");

            return _str.ToString();
        }

    }
}
