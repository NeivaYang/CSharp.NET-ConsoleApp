using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
    public abstract class Pessoa
    {
        public int cpf { get; set; }
        public string name { get; set; }
        public bool enrecoComercial { get; set; }

        public void PagarImposto() {

        }
    }
}