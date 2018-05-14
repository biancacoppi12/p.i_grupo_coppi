using GrupoCoppi.Classes.PJ;
using GrupoCoppi.Classes.Tapetes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoCoppi.Classes.MP
{
    /// <summary>
    /// Summary description for MateriaPrima
    /// </summary>
    public class MateriaPrima
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
       

        public List<Fornecedor> Fornecedores { get; set; }
        public List<Tapete> Tapetes { get; set; }

        public MateriaPrima()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}