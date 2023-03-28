using System;

namespace FirstSolution.Domain.ProjectDomain
{
    public class Pessoa
    {
        public int pessoaID{ get;  set; }
        public string nome { get; set; }

        public DateTime dataNascimento { get; set; }

        public Pessoa(int pessoaID, String nome, DateTime dataNascimento)
        {
            this.pessoaID = pessoaID;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
        }
        public static Pessoa Parse(string v)
        {
            throw new NotImplementedException();
        }
    }
}
