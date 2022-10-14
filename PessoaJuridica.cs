using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
    public class PessoaJuridica : Pessoa
    {
        public int cnpj { get; set; }

        public string razaoSocial { get; set; }
    }
}