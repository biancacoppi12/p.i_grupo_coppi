using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCoppi.Classes.Tapetes;
using GrupoCoppi.Classes.PJ;
using GrupoCoppi.Classes.Funcionarios;
using GrupoCoppi.Classes.MP;
/// <summary>
/// Summary description for OrdemProducao
/// </summary>
namespace GrupoCoppi.Classes.OP
{
    public class OrdemProducao
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime PrevisaoEntrega { get; set; }
        public DateTime ControleInterno { get; set; }



        // relacionamentos
        public List<Tapete> Tapetes { get; set; }
        public StatusOrdemProducao StatusOrdemProducao { get; set; }
        public Pessoa Pessoa { get; set; }
        public MateriaPrima MP { get; set; }
        //public Cliente Cliente { get; set; }
        //public Funcionario Funcionario { get; set; }


        public OrdemProducao()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}