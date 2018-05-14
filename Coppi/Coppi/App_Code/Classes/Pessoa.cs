using GrupoCoppi.Classes.OP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoCoppi.Classes
{
    /// <summary>
    /// Summary description for Pessoa
    /// </summary>
    public class Pessoa
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string TipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Tipo { get; set; }

        // Relacionamentos
        public List<OrdemProducao> OrdensProducao { get; set; }




        public Pessoa()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}