using FirstSolution.Domain.ProjectDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstSolution.UserInterface.Console.ConsoleApp
{
    class Program
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static List<TipoAtividade> tiposAtividades = new List<TipoAtividade>();
        private static List<AtividadeComplementar> atividadesComplementares = new List<AtividadeComplementar>();
        
        public static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine("Olá, bem-vindo ao sistema de cadastro de atividades de Alunos");
                System.Console.WriteLine("Digite o que quer fazer: \r\n 1-Cadastrar Aluno \r\n 2-Cadastrar Tipo de Atividade \r\n 3-Cadastrar Atividade Complementar\r\n 4-Alterar Aluno  \r\n 5-Alterar Tipo de Atividade \r\n 6-Alterar  Atividade Complementar\r\n 7-Excluir Aluno \r\n 8-Excluir Tipo de Atividade \r\n 9-Excluir Atividade Complementar \r\n 10-Constar \r\n 11-Sair");
                int op = Int32.Parse(System.Console.ReadLine());

                switch (op)
                {
                    case 1:
                        int pessoaID = pessoas.Count + 1;
                        System.Console.WriteLine("Digite o nome do aluno:");
                        string nome = System.Console.ReadLine();
                        while (string.IsNullOrEmpty(nome))
                        {
                            System.Console.WriteLine("Digite um nome válido para o aluno:");
                            nome = System.Console.ReadLine();
                        }

                        System.Console.WriteLine("Digite a data de nascimento do aluno:");
                        DateTime dataNascimento;
                        bool dataValida = DateTime.TryParse(System.Console.ReadLine(), out dataNascimento);
                        while (!dataValida)
                        {
                            System.Console.WriteLine("Digite uma data válida de nascimento do aluno:");
                            dataValida = DateTime.TryParse(System.Console.ReadLine(), out dataNascimento);
                        }
                        
                        Pessoa p = new Pessoa(pessoaID, nome, dataNascimento);                        
                        pessoas.Add(p);                        
                        break;

                    case 2:
                        //CADASTRAR TIPO ATIVIDADE
                        int tipoAtividadeID = tiposAtividades.Count + 1;
                        
                        System.Console.WriteLine("Digite o Tipo de Atividade: ");
                        string descricao = System.Console.ReadLine();
                        while (string.IsNullOrEmpty(descricao))
                        {
                            System.Console.WriteLine("Digite um tipo de atividade válido:");
                            descricao = System.Console.ReadLine();
                        }


                        TipoAtividade ta = new TipoAtividade(tipoAtividadeID, descricao);

                        tiposAtividades.Add(ta);

                        break;

                    case 3:
                        //CADASTRAR ATIVIDADE COMPLEMENTAR
                        int atividadeComplementarID = atividadesComplementares.Count + 1;

                        System.Console.WriteLine("Digite a data da Atividade: ");
                        DateTime data;
                        bool dataValid = DateTime.TryParse(System.Console.ReadLine(), out data);
                        while (!dataValid)
                        {
                            System.Console.WriteLine("Digite uma data válida de nascimento do aluno:");
                            dataValid = DateTime.TryParse(System.Console.ReadLine(), out data);
                        }


                        System.Console.WriteLine("ID do tipo de Atividade: ");
                        int id = Int32.Parse(System.Console.ReadLine());
                        var tipo = tiposAtividades.Where(y => y.tipoAtividadeId == id).SingleOrDefault();
                        System.Console.WriteLine("ID do Aluno: ");
                        int idAluno = Int32.Parse(System.Console.ReadLine());
                        var aluno = pessoas.Where(x => x.pessoaID == idAluno).SingleOrDefault();


                        System.Console.WriteLine("Qual instituição? ");
                        string instituicao = System.Console.ReadLine();
                        while (string.IsNullOrEmpty(instituicao))
                        {
                            System.Console.WriteLine("Digite uma instituição válida:");
                            instituicao = System.Console.ReadLine();
                        }


                        System.Console.WriteLine("Qual o ano de formação? ");
                        int anoFormacao;
                        bool anoValido = Int32.TryParse(System.Console.ReadLine(), out anoFormacao)
                            && ((anoFormacao >= DateTime.Today.Year - 3) && (anoFormacao <= DateTime.Today.Year));
                        while (!anoValido)
                        {
                            System.Console.WriteLine("Informe um ano de formação válido (máx. 3 anos atrás)? ");
                            anoValido = Int32.TryParse(System.Console.ReadLine(), out anoFormacao)
                                && ((anoFormacao >= DateTime.Today.Year - 3) && (anoFormacao <= DateTime.Today.Year));
                        }

                        AtividadeComplementar ac = new AtividadeComplementar(atividadeComplementarID, data, aluno, tipo,instituicao, anoFormacao);

                        atividadesComplementares.Add(ac);

                        break;

                    case 4:

                        // alteração aluno
                        System.Console.WriteLine("Digite o ID do aluno a alterar:");
                        int idAlterar = Int32.Parse(System.Console.ReadLine());

                        var alunoAlterar = GetPessoa(idAlterar);
                        if (alunoAlterar == null) continue;


                        System.Console.WriteLine("digite o novo nome:");
                        string novoNome = System.Console.ReadLine();
                        System.Console.WriteLine("digite o novo ano de nascimento:");
                        DateTime novaData = DateTime.Parse(System.Console.ReadLine());
                        alunoAlterar.dataNascimento = novaData;
                        alunoAlterar.nome = novoNome;

                        break;

                    case 5:
                        // alteração TA
                        System.Console.WriteLine("digite o id da atividade a alterar");
                        int idAtividadeAlterar = Int32.Parse(System.Console.ReadLine());

                        var atividadeAlterar = GetTipoAtividade(idAtividadeAlterar);
                        if (atividadeAlterar == null) continue;

                        System.Console.WriteLine("digite a nova descricao:");
                        string novaDescricao = System.Console.ReadLine();
                        atividadeAlterar.descricao = novaDescricao;


                        break;

                    case 6:
                        // alteração AC
                        System.Console.WriteLine("digite o id da atividade complementar a alterar");
                        int idAtividadeComplementarAlterar = Int32.Parse(System.Console.ReadLine());

                        var atividadeComplementarAlterar = GetAtividadeComplementar(idAtividadeComplementarAlterar);
                        if (atividadeComplementarAlterar == null) continue;

                        System.Console.WriteLine("digite a nova data :");
                        DateTime newData = DateTime.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("digite a nova instituição:");
                        string novaInstituicao = System.Console.ReadLine();
                        System.Console.WriteLine("Qual o ano de formação? ");
                        int novoAnoFormacao = Int32.Parse(System.Console.ReadLine());


                        System.Console.WriteLine("ID do tipo de Atividade: ");
                        int novoIdTa = Int32.Parse(System.Console.ReadLine());
                        var novoTipo = tiposAtividades.Where(y => y.tipoAtividadeId == novoIdTa).SingleOrDefault();

                        System.Console.WriteLine("ID do Aluno: ");
                        int novoIdAluno = Int32.Parse(System.Console.ReadLine());
                        var novoAluno = pessoas.Where(x => x.pessoaID == novoIdAluno).SingleOrDefault();


                        atividadeComplementarAlterar.data = newData;
                        atividadeComplementarAlterar.instituicao = novaInstituicao;
                        atividadeComplementarAlterar.anoFormacao = novoAnoFormacao;
                        atividadeComplementarAlterar.aluno = novoAluno;
                        atividadeComplementarAlterar.tipo = novoTipo;

                        break;

                    case 7:
                        // exclusão Aluno
                        System.Console.WriteLine("digite o id do aluno a ser excluido:");
                        int idAlunoExcluir = Int32.Parse(System.Console.ReadLine());
                        var alunoExcluir = GetPessoa(idAlunoExcluir);
                        pessoas.Remove(alunoExcluir);

                        break;

                    case 8:
                        // exclusão TA
                        System.Console.WriteLine("digite o id da atividade a ser excluida");
                        int idAtividadeExcluir = Int32.Parse(System.Console.ReadLine());
                        var atividadeExcluir = GetTipoAtividade(idAtividadeExcluir);
                        tiposAtividades.Remove(atividadeExcluir);

                        break;

                    case 9:
                        // exclusão AC
                        System.Console.WriteLine("Digite o ID da Atividade Complementar que quer excluir:");
                        int idExcluir = Int32.Parse(System.Console.ReadLine());
                        var atividadeComplementarExcluir = GetAtividadeComplementar(idExcluir);
                        atividadesComplementares.Remove(atividadeComplementarExcluir);

                        break;

                    case 10:
                        //CONSTAR

                        System.Console.WriteLine(" \r\nAlunos:");
                        foreach (Pessoa a in pessoas)
                        {
                            System.Console.WriteLine(a.pessoaID + " - " + a.nome + " - dtnasc.: " + a.dataNascimento);
                        }
                        

                        System.Console.WriteLine("\r\nTipos de Atividade:");
                        foreach (TipoAtividade a in tiposAtividades)
                        {
                            System.Console.WriteLine(a.tipoAtividadeId + " - " + a.descricao);
                        }
                        

                        System.Console.WriteLine("\r\nAtividades Complementares:");
                        foreach (AtividadeComplementar a in atividadesComplementares)
                        {
                            System.Console.WriteLine(a.atividadeComplementarID + " - " + a.aluno.nome + " - dt: " + a.data + " - " + a.tipo.descricao + " - " + a.instituicao + " - dt Formação: " + a.anoFormacao);
                        }
                        System.Console.WriteLine("\r\n");

                        break;

                    case 11:
                        //SAIR
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private static Pessoa GetPessoa(int pessoaId)
        {
            var pessoa = pessoas.Where(x => x.pessoaID == pessoaId).First();
            return pessoa;
        }

        private static TipoAtividade GetTipoAtividade(int tipoAtividadeId)
        {
            var atividade = tiposAtividades.Where(x => x.tipoAtividadeId == tipoAtividadeId).First();
            return atividade;

        }

        private static AtividadeComplementar GetAtividadeComplementar(int AtividadeComplementarId)
        {
            var complemento = atividadesComplementares.Where(x => x.atividadeComplementarID == AtividadeComplementarId).First();
            return complemento;
        }

    }
}
