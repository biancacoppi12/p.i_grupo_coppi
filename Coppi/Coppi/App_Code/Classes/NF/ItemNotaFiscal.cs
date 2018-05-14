using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes.MP;

/// <summary>
/// Summary description for ItemNotaFiscal
/// </summary>
namespace GrupoCoppi.Classes.NF
{
    public class ItemNotaFiscal
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public double ValorTUnitario { get; set; }
        public double QuantidadeItem { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Lote { get; set; }

        //relacionamentos
        public ItemMateriaPrima ItemMateriaPrima { get; set; }
        public NotaFiscal NotaFiscal { get; set; }
        public MateriaPrima  MateriPrima { get; set; }

        public ItemNotaFiscal()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}