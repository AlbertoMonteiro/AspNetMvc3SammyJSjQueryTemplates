using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SammyTest.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
    }
}