using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StatusOrdemProducao
/// </summary>
namespace GrupoCoppi.Classes.OP
{
    public class StatusOrdemProducao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        // relacionamentos
        public List<StatusOrdemProducao> StatusOrdensProducao { get; set; }

        public StatusOrdemProducao()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}