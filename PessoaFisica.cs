using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace Teste
{
        public class PessoaFisica : Pessoa
    {
        public string? CPF {get;set;}

        public DateTime DataNascimento {get;set;}

        public override float PagarImposto(float salario)
        {
            float imposto;

            imposto = 0;

            if (salario >= 1500.01F && salario <= 5000F) {
                imposto = salario * 0.03F;
            } else if (salario > 5000F) {
                imposto = salario * 0.05F;
            }

            return imposto;
        }

        public bool ValidarDataNascimento(DateTime DataNasc){
            
            DateTime DataAtual = DateTime.Today;

            double Anos = (DataAtual - DataNasc).TotalDays / 365;

            if (Anos >= 18) {
                return true;
            } else {
                return false;
            }
        }

        public override bool GravarRegistro(){
            string cArqPF = AppDomain.CurrentDomain.BaseDirectory+"\\arquivos\\PessoaFisica.txt";
            var sStream = new StreamWriter(cArqPF,true);

            sStream.WriteLine($"CPF Cadastrado: {this.CPF} - Nome: {this.Nome}");
            sStream.Close();

            Console.WriteLine("Apresentando conteudo arquivo de log 'PessoaFisica.txt'");

            using (var sReader = new StreamReader(cArqPF)) {
                string cLine;
                while ((cLine = sReader.ReadLine()) != null)
                {
                    Console.WriteLine(cLine);
                }
            }

            return true;
        }
    }
}