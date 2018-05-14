using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoCoppi.Classes
{
    /// <summary>
    /// Summary description for PessoaJuridica
    /// </summary>
    public class PessoaJuridica:Pessoa
    {
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }

        public PessoaJuridica()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}
