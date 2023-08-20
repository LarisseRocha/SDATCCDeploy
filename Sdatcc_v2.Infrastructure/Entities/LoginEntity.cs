using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sdatcc_v2.Domain;


namespace Sdatcc_v2.Infrastructure.Entities
{
   public class LoginEntity
    {
        [Key]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
