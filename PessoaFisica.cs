using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
    public class PessoaFisica : Pessoa
    {
        public string? CPF { get; set; }

        public DateTime dataNascimento { get; set; }

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


        public bool ValidarDataNascimento (DateTime dataNasc)
        {

            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 350;

            if (anos >= 18) {
                return true;
            } else {
                return false;
            }
        }


    }
}