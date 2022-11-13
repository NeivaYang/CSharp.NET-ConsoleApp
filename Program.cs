using Teste;
using System.Threading;
using System.Collections.Generic;

namespace Teste
{

    class Program
    {
        static void Main(string[] args)
        {

            List<PessoaFisica> ListPF = new List<PessoaFisica>();
            List<PessoaJuridica> ListPJ = new List<PessoaJuridica>();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(@$"
============================================
|    Bem vindo ao sistema de cadastro      |
|    de pessoa física e pessoa jurídica    |
============================================
");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            BarraCarregamento("Iniciando");
            Console.ResetColor();

            string cOpcao = "1";
            
            while (cOpcao != "0")
            {
                Console.WriteLine(@$"
========================================
|    Escolha uma das opções abaixo     |
|            PESSOA FÍSICA             |
|    1 - Cadastrar Pessoa Física       |
|    2 - Listar Pessoa Física          |
|    3 - Remover Pessoa Física         |
|                                      |
|           PESSOA JURÍDICA            |
|    4 - Cadastrar Pessoa Jurídica     |
|    5 - Listar Pessoa Jurídica        |
|    6 - Remover Pessoa Jurídica       |
|                                      |
|    0 - Sair                          |
========================================
");  
                Console.ResetColor();
                cOpcao = Console.ReadLine();
                switch (cOpcao)
                {
                    /*
                        CADASTRAR PESSOA FISICA
                    */
                    case "1":
                        Endereco endPF = new Endereco();

                        Console.WriteLine($"Digite seu logradouro:");
                        endPF.Logradouro  = Console.ReadLine();

                        Console.WriteLine($"Digite seu número:");
                        endPF.Numero      = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite seu complemento (aperte ENTER para vazio):");
                        endPF.Complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço comercial? (S/N):");
                        string cTpEnd = Console.ReadLine().ToUpper();
                        if (cTpEnd == "S") {
                            endPF.EnderecoComercial = true;
                        } else {
                            endPF.EnderecoComercial = false;
                        }

                        PessoaFisica novaPF = new PessoaFisica();
                        Console.WriteLine($"Digite seu CFP:");
                        novaPF.CPF = Console.ReadLine();

                        Console.WriteLine($"Digite sua data de nascimento:");
                        novaPF.DataNascimento = DateTime.Parse(Console.ReadLine());

                        //novaPF.DataNascimento = new DateTime(1979, 11, 05);
                        Console.WriteLine($"Digite seu nome:");
                        novaPF.Nome = Console.ReadLine();
                        novaPF.Endereco = endPF;

                        Console.WriteLine($"Digite seu e-mail:");
                        novaPF.Email = Console.ReadLine();

                        Console.WriteLine($"Digite seu salario:");
                        novaPF.Salario = float.Parse(Console.ReadLine());

                        bool idadeValida = novaPF.ValidarDataNascimento(novaPF.DataNascimento);

                        if (idadeValida == true) {
                            Console.WriteLine($"Cadastro Aprovado");
                            Console.WriteLine(novaPF.PagarImposto(novaPF.Salario));                            
                            ListPF.Add(novaPF);
                            novaPF.GravarRegistro();
                        } else {
                            Console.WriteLine($"Cadastro Reprovado");
                        }

                        Thread.Sleep(3000);

                        break;

                    /*
                        LISTAR PESSOA FISICA
                    */
                    case "2":
                        foreach (var itPF in ListPF)
                        {
                            Console.WriteLine($"Nome: {itPF.Nome}");
                            Console.WriteLine($"CPF: {itPF.CPF}");
                            Console.WriteLine($"E-mail: {itPF.Email}");
                            Console.WriteLine($"DT.Nascimento: {itPF.DataNascimento}");
                            Console.WriteLine($"Logradouro: {itPF.Endereco.Logradouro}");
                            Console.WriteLine($"Número: {itPF.Endereco.Numero}");
                            Console.WriteLine($"Complemento: {itPF.Endereco.Complemento}");                            
                            Console.WriteLine($"");
                        }

                        Console.WriteLine($"Tecle ENTER para voltar ao menu principal");
                        Console.ReadLine();

                        break;

                    /*
                        REMOVER PESSOA FISICA
                    */
                    case "3":
                        Console.WriteLine($"Digite o CPF que deseja remover:");
                        string cCPF = Console.ReadLine();
                    
                        PessoaFisica pfEncontrada = ListPF.Find(itPF => itPF.CPF == cCPF);

                        if (pfEncontrada != null) {
                            ListPF.Remove(pfEncontrada);
                            Console.WriteLine($"Cadastro Removido.");
                        } else {
                            Console.WriteLine($"Pessoa física não localizada.");
                        }

                        Thread.Sleep(2000);

                        break;

                    /*
                        CADASTRAR PESSOA JURIDICA
                    */
                    case "4":
                        Endereco endPJ = new Endereco();
                        
                        Console.WriteLine($"Digite seu logradouro:");
                        endPJ.Logradouro  = Console.ReadLine();

                        Console.WriteLine($"Digite seu número:");
                        endPJ.Numero      = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite seu complemento:");
                        endPJ.Complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço comercial? (S/N):");
                        string cTpEndPJ = Console.ReadLine().ToUpper();
                        if (cTpEndPJ == "S") {
                            endPJ.EnderecoComercial = true;
                        } else {
                            endPJ.EnderecoComercial = false;
                        }

                        PessoaJuridica novaPJ = new PessoaJuridica();
                        Console.WriteLine($"Digite seu CNPJ:");
                        novaPJ.CNPJ        = Console.ReadLine();

                        Console.WriteLine($"Digite sua Razão Social:");
                        novaPJ.RazaoSocial = Console.ReadLine();
                        novaPJ.Endereco = endPJ;

                        Console.WriteLine($"Digite seu salário:");
                        novaPJ.Salario = float.Parse(Console.ReadLine());

                        bool CNPJValido = novaPJ.ValidarCNPJ(novaPJ.CNPJ);
                        
                        if (CNPJValido == true){
                            Console.WriteLine("CNPJ válido");
                            Console.WriteLine(novaPJ.PagarImposto(novaPJ.Salario));
                            Console.WriteLine($"Imposto PJ: {novaPJ.PagarImposto(novaPJ.Salario)}");
                            ListPJ.Add(novaPJ);
                        } else {
                            Console.WriteLine("CNPJ inválido");
                        }

                        Thread.Sleep(3000);

                        break;

                    /*
                        LISTAR PESSOA JURIDICA
                    */
                    case "5":
                        foreach (var itPJ in ListPJ)
                        {
                            Console.WriteLine($"Nome: {itPJ.Nome}");
                            Console.WriteLine($"CNPJ: {itPJ.CNPJ}");
                            Console.WriteLine($"E-mail: {itPJ.Email}");
                            Console.WriteLine($"Logradouro: {itPJ.Endereco.Logradouro}");
                            Console.WriteLine($"Número: {itPJ.Endereco.Numero}");
                            Console.WriteLine($"Complemento: {itPJ.Endereco.Complemento}");                            
                            Console.WriteLine($"");
                        }

                        Console.WriteLine($"Tecle ENTER para voltar ao menu principal");
                        Console.ReadLine();
                        break;

                    /*
                        REMOVER PESSOA JURIDICA
                    */
                    case "6":
                        Console.WriteLine($"Digite o CNPJ que deseja remover:");
                        string cCNPJ= Console.ReadLine();
                    
                        PessoaJuridica pjEncontrada = ListPJ.Find(itPJ => itPJ.CNPJ == cCNPJ);

                        if (pjEncontrada != null) {
                            ListPJ.Remove(pjEncontrada);
                            Console.WriteLine($"Cadastro Removido.");
                        } else {
                            Console.WriteLine($"Pessoa jurídica não localizada.");
                        }

                        Thread.Sleep(2000);
                        break;

                    /*
                        SAIR DO SISTEMA
                    */
                    case "0":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Obrigado por utilizar nosso sistema");                        
                        Console.WriteLine($"");
                        BarraCarregamento("Finalizado");
                        break;

                    /*
                        TRATAMENTO DE OPÇÃO INVÁLIDA
                    */
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção inválida. Escolha uma opção válida.");
                        Thread.Sleep(2000);
                        break;
                }
                Console.Clear();
            }

            Console.ResetColor();
        }
        static void BarraCarregamento(string cTexto){
            Console.Write($"{cTexto}");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(500);
                Console.Write($".");     
            } 
            Console.WriteLine($""); 
        }
    }
}