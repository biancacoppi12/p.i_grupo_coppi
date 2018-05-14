using GrupoCoppi.Classes.MP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoCoppi.Classes.PJ
{
    /// <summary>
    /// Summary description for Fornecedor
    /// </summary>
    public class Fornecedor:PessoaJuridica
    {
        public int fmp_id { get; set; }
        public int pes_id { get; set; }
        public int map_id { get; set; }

        // relacionamento n pra n com materia prima
        public List<MateriaPrima> MateriasPrimas { get; set; }

        public Fornecedor()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}