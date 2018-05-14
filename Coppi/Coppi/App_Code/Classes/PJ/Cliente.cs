using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoCoppi.Classes.PJ
{
    /// <summary>
    /// Summary description for Cliente
    /// </summary>
    public class Cliente:PessoaJuridica
    {
        public DateTime DataCadastro { get; set; }

        public Cliente()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}