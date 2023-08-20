using System;
using System.Collections.Generic;
using System.Text;

namespace Sdatcc_v2.Domain
{
   public  class Professor
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
    }
}
