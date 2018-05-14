using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Persistencia.PJ;
using System.Data;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;
using System.Text;
using GrupoCoppi.Persistencia.OP;

public partial class Paginas_Relatorio_Listar : System.Web.UI.Page
{
    private bool IsGerente(int tipo)
    {
        bool retorno = false;
        if (tipo == 0)
        {
            retorno = true;
        }
        return retorno;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int codigo = Convert.ToInt32(Session["ID"]);
            FuncionarioBD bd1 = new FuncionarioBD();
            Funcionario funcionario = bd1.Select(codigo);
            try
            {
                if (!IsGerente(funcionario.Tipo))
                {
                    Response.Redirect("../../Paginas/Login/Erro/AcessoNegado.aspx");
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("../../Paginas/Login/Erro/AcessoNegado.aspx");
            }
        }
    }

    protected void lbSair_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("../Login/Login.aspx");
    }


    [System.Web.Services.WebMethod]
    public static List<string> getChartData()
    {
        var returnData = new List<string>();
        var dataset = new DataSet();

        OrdemProducaoBD bd = new OrdemProducaoBD();


        dataset = bd.SelectAllInnerFechadaGrafico();


        var chartLabel = new StringBuilder();
        var chartData = new StringBuilder();
        chartLabel.Append("[");
        chartData.Append("[");


        foreach (DataRow row in dataset.Tables[0].Rows)
        {


            chartLabel.Append(string.Format("'{0}',", row["NomeMes"].ToString()));
            chartData.Append(string.Format("{0},", row["Valortotal"].ToString()));
            chartData.Length--; //For removing ','  
            chartData.Length--; //For removing ','  
            chartData.Length--; //For removing ','  


        }

        chartData.Length--; //For removing ','  
        chartData.Append("]");
        chartLabel.Length--; //For removing ',' 
        chartLabel.Append("]");

        returnData.Add(chartLabel.ToString());
        returnData.Add(chartData.ToString());
        return returnData;
    }

}



