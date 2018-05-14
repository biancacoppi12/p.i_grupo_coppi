using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes.MP;
using GrupoCoppi.Classes.OP;
using GrupoCoppi.Classes.PJ;

/// <summary>
/// Summary description for Tapete
/// </summary>
namespace GrupoCoppi.Classes.Tapetes
{
    public class Tapete
    {
        public int Id { get; set; }
        public double Largura { get; set; }
        public double Comprimento { get; set; }
        public string TipoArte { get; set; }
        public double ValorVenda { get; set; }
        
        // relacionamentos
       public OrdemProducao OrdemProducao { get; set; }
        public Fornecedor Fornecedor { get; set; }
        // relacionamento n pra n com mp
        public List<MateriaPrima> MateriasPrimas { get; set; }
       
        public Tapete()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}