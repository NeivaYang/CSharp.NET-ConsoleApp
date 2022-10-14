using Teste;

namespace Teste
{
    class Program
    {
        static void Main(String[] args)
        {
            Endereco endPF = new Endereco();
            endPF.Logradouro  = "Beatriz da Silva";
            endPF.Numero      = 119;
            endPF.Complemento = "Apt 208b";
            endPF.EnderecoComercial = false;

            PessoaFisica novaPF = new PessoaFisica();
            novaPF.CPF            = "12345678912";
            novaPF.dataNascimento = new DateTime(1985, 19, 01);
            novaPF.Nome           = "Yang Neiva";
            novaPF.Endereco       = endPF;
            novaPF.Email          = "email@mail.com";
            novaPF.Salario        = 7000F;

            Endereco endPJ = new Endereco();
            endPF.Logradouro  = "Beatriz da Silva";
            endPF.Numero      = 119;
            endPF.Complemento = "Apt 208b";
            endPF.EnderecoComercial = false;

            PessoaJuridica novaPJ = new PessoaJuridica();
            novaPJ.CNPJ        = "34567891234";
            novaPJ.RazaoSocial = "Razão Social";
            novaPJ.Endereco    = endPJ;
            novaPJ.Salario     = 20000F;

            bool CNPJValido = novaPJ.ValidarCNPJ(novaPJ.CNPJ);
            
            Console.WriteLine(novaPJ.PagarImposto(novaPJ.Salario));
            Console.WriteLine($"Imposto PJ: {novaPJ.PagarImposto(novaPJ.Salario)}");

            if (CNPJValido == true){
                Console.WriteLine("CNPJ válido");
            } else {
                Console.WriteLine("CNPJ inválido");
            }

            Console.WriteLine($"Rua: {novaPF.Endereco.Logradouro}, {novaPF.Endereco.Numero}");
            Console.WriteLine($"Data Nascimento : {novaPF.dataNascimento}");
            Console.WriteLine($"Imposto PF: {novaPF.PagarImposto(novaPF.Salario)}");

            bool idadeValida = novaPF.ValidarDataNascimento(novaPF.dataNascimento);

            if (idadeValida == true) {
                System.Console.WriteLine($"Cadastro Aprovado");
            } else {
                System.Console.WriteLine($"Cadastro Reprovado");
            }
        }
    }
}