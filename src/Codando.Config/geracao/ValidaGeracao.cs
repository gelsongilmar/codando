using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Config.geracao
{
    public class ValidaGeracao : Shared.Notification
    {
        private readonly SolucaoGerada _solucaoGerada;

        public ValidaGeracao(SolucaoGerada solucaoGerada)
        {
            this._solucaoGerada = solucaoGerada;
        }

        public override void Validar()
        {
            if (this._solucaoGerada == null) {
                AddNotification("Informe a configuração a ser validada");
            } else
            {
                this.ValidarEntidadesSemPK();
            }
        }

        private void ValidarEntidadesSemPK()
        {
            foreach (var e in this._solucaoGerada.Entidades)
            {
                if (e.Atributos.Count == e.Atributos.Where(c => !c.IsPK).ToList().Count)
                {
                    AddNotification("Entidade " +  e.Nome + " sem chave primária definida!");
                }
            }
        }
    }
}
