using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes.NF;

/// <summary>
/// Summary description for ItemMateriaPrima
/// </summary>
namespace GrupoCoppi.Classes.MP
{
    public class ItemMateriaPrima
    {
        public int Id { get; set; }
        public Double QuantidadeItem { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Lote { get; set; }

        //relacionamentos
        public ItemNotaFiscal ItemNotaFiscal { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
        public ItemMateriaPrima()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}