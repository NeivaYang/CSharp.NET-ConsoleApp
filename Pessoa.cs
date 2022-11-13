using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste
{
    
    public abstract class Pessoa
    {
        public string? Nome {get;set;}
        public string? Email {get;set;}
        public Endereco? Endereco {get;set;}

        public float Salario {get;set;}

        public abstract float PagarImposto(float salario);

        public abstract bool GravarRegistro();
    }
}