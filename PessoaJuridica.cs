using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
        public class PessoaJuridica : Pessoa
    {
        public string? CNPJ {get;set;}
        public string? RazaoSocial {get;set;}

        public override float PagarImposto(float salario)
        {
            float imposto;

            imposto = salario * 0.06F;

            if (salario >= 5000.01F && salario <= 10000F) {
                imposto = salario * 0.08F;
            } else if (salario > 10000F) {
                imposto = salario * 0.10F;
            }

            return imposto;
        }

        public bool ValidarCNPJ(string CNPJ){
            if (CNPJ.Length != 14 || CNPJ.Substring(CNPJ.Length - 6,4) != "0001"){
                return false;
            } else {
                return true;
            }
        }

        public override bool GravarRegistro(){
            return true;
        }
    }
}