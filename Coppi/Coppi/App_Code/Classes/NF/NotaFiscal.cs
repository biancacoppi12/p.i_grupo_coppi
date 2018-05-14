using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes.MP;
using GrupoCoppi.Classes.PJ;
/// <summary>
/// Summary description for ItemMateriaPrima
/// </summary>
namespace GrupoCoppi.Classes.NF
{
    public class NotaFiscal
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorTotal { get; set; }
        //relacionamentos
        public ItemMateriaPrima ItemMateriaPrima { get; set; }
        public ItemNotaFiscal ItemNotaFiscal { get; set; }
        public Fornecedor Fornecedor { get; set; }

        // relacionamento n pra n com itens
        public List<ItemNotaFiscal> ItensNotaFiscal { get; set; }
       

        public NotaFiscal()
        {

            //
            // TODO: Add constructor logic here
            //
        }
    }
}