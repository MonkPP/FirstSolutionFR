using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSolution.Domain.ProjectDomain
{
    public class AtividadeComplementar
    {
        public int atividadeComplementarID { get; set; }
        public DateTime data { get; set; }
        public Pessoa aluno { get; set; }
        public TipoAtividade tipo { get; set; }
        public string instituicao { get; set; }
        public int anoFormacao { get; set; }

        public AtividadeComplementar(int atividadeComplementarID, DateTime data, Pessoa aluno, TipoAtividade tipo, string instituicao, int anoFormacao)
        {
            this.atividadeComplementarID = atividadeComplementarID;
            this.data = data;
            this.aluno = aluno;
            this.tipo = tipo;
            this.instituicao = instituicao;
            this.anoFormacao = anoFormacao;
        }


    }
}
