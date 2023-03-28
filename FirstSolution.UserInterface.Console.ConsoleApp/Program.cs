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
                System.Console.WriteLine("Digite o que quer fazer: \r\n 1-Cadastrar Aluno \r\n 2-Cadastrar Tipo de Atividade \r\n 3-Cadastrar Atividade Complementar \r\n 7-Excluir Aluno \r\n 8-Excluir Tipo de Atividade \r\n 9-Excluir Atividade Complementar \r\n 10-Constar \r\n 11-Sair");
                int op = Int32.Parse(System.Console.ReadLine());

                switch (op)
                {
                    case 1:
                        //CADASTRAR ALUNO
                        System.Console.WriteLine("Digite o ID do aluno:");
                        int pessoaID = Int32.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("Digite o nome do aluno:");
                        string nome = System.Console.ReadLine();
                        System.Console.WriteLine("Digite a data de nascimento do aluno:");
                        DateTime dataNascimento = DateTime.Parse(System.Console.ReadLine());
                        Pessoa p = new Pessoa(pessoaID, nome, dataNascimento);
                        
                        pessoas.Add(p);
                        
                        break;

                    case 2:
                        //CADASTRAR TIPO ATIVIDADE
                        System.Console.WriteLine("Digite o ID do Tipo de Atividade: ");
                        int tipoAtividadeID = Int32.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("Digite o Tipo de Atividade: ");
                        string descricao = System.Console.ReadLine();

                        TipoAtividade ta = new TipoAtividade(tipoAtividadeID, descricao);

                        tiposAtividades.Add(ta);

                        break;

                    case 3:
                        //CADASTRAR ATIVIDADE COMPLEMENTAR
                        System.Console.WriteLine("Digite o ID da Atividade Complementar: ");
                        int atividadeComplementarID = Int32.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("Digite a data da Atividade: ");
                        DateTime data = DateTime.Parse(System.Console.ReadLine());
                        System.Console.WriteLine("ID do tipo de Atividade: ");
                        int id = Int32.Parse(System.Console.ReadLine());
                        var tipo = tiposAtividades.Where(y => y.tipoAtividadeId == id).SingleOrDefault();
                        System.Console.WriteLine("ID do Aluno: ");
                        int idAluno = Int32.Parse(System.Console.ReadLine());
                        var aluno = pessoas.Where(x => x.pessoaID == idAluno).SingleOrDefault();
                        System.Console.WriteLine("Qual instituição? ");
                        string instituicao = System.Console.ReadLine();
                        System.Console.WriteLine("Qual o ano de formação? ");
                        int anoFormacao = Int32.Parse(System.Console.ReadLine());

                        AtividadeComplementar ac = new AtividadeComplementar(atividadeComplementarID, data, aluno, tipo,instituicao, anoFormacao);

                        atividadesComplementares.Add(ac);

                        break;

                    case 4:
                        // alteração aluno
                        System.Console.WriteLine("Digite o ID do aluno a alterar:");
                        int idAlterar = Int32.Parse(System.Console.ReadLine());

                        var filtrado = pessoas.Where(x => x.pessoaID == idAlterar);


                        break;

                    case 5:
                        // alteração TA

                        break;

                    case 6:
                        // alteração AC
                        break;

                    case 7:
                        // exclusão Aluno
                        System.Console.WriteLine("Digite o ID do Aluno que quer excluir:");
                        int idExc = Int32.Parse(System.Console.ReadLine());

                        
                        break;

                    case 8:
                        // exclusão TA
                        System.Console.WriteLine("Digite o ID do Tipo de Atividade que quer excluir:");
                        int idExclu = Int32.Parse(System.Console.ReadLine());

                        
                        break;

                    case 9:
                        // exclusão AC
                        System.Console.WriteLine("Digite o ID da Atividade Complementar que quer excluir:");
                        int idExcluir = Int32.Parse(System.Console.ReadLine());

                        break;

                    case 10:
                        //CONSTAR

                        System.Console.WriteLine("Alunos: \r\n");
                        foreach (Pessoa a in pessoas)
                        {
                            System.Console.WriteLine(a.pessoaID + " - " + a.nome + " - dtnasc.: " + a.dataNascimento);
                        }
                        

                        System.Console.WriteLine("Tipos de Atividade:\r\n");
                        foreach (TipoAtividade a in tiposAtividades)
                        {
                            System.Console.WriteLine(a.tipoAtividadeId + " - " + a.descricao);
                        }
                        

                        System.Console.WriteLine("Atividades Complementares:\r\n");
                        foreach (AtividadeComplementar a in atividadesComplementares)
                        {
                            System.Console.WriteLine(a.atividadeComplementarID + " - " + a.aluno + " - dt: " + a.data + " - " + a.tipo + " - " + a.instituicao + " - dt Formação: " + a.anoFormacao);
                        }
                        System.Console.ReadKey();

                        break;

                    case 11:
                        //SAIR
                        Environment.Exit(0);
                        break;
                }
            }
        }

    }
}
