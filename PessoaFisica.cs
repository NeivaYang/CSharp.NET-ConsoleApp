using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
    public class PessoaFisica : Pessoa
    {
        public int cpf { get; set; }

        public DateTime dataNascimento { get; set; }
    }
}