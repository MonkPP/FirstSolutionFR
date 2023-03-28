using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSolution.Domain.ProjectDomain
{
    public class TipoAtividade
    {
        public int tipoAtividadeId { get; set; }
        public string descricao { get; set; }

        public TipoAtividade(int tipoAtividadeID, String descricao)
        {
            this.tipoAtividadeId = tipoAtividadeID;
            this.descricao = descricao;
        }

        public static TipoAtividade Parse(string v)
        {
            throw new NotImplementedException();
        }
    }
}
