using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoCoppi.Classes
{
    /// <summary>
    /// Summary description for Funcionario
    /// </summary>
    public class Funcionario:Pessoa
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Funcionario()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}