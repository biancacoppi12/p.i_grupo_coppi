using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Classes.PJ;
using System.Data;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;
using GrupoCoppi.Classes.OP;
using GrupoCoppi.Classes.Tapetes;
using GrupoCoppi.Persistencia.OP;
using GrupoCoppi.Persistencia.Tapetes;

public partial class Paginas_OrdemProducao_Alterar : System.Web.UI.Page
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

            // ordem producao
            OrdemProducaoBD bd = new OrdemProducaoBD();
            OrdemProducao ordemproducao = bd.SelectAlterar(Convert.ToInt32(Session["IDOrdemProducao"]));

            txtDataEntrada.Text = ordemproducao.DataEntrada.ToShortDateString();
            txtPrevisaoEntrega.Text = ordemproducao.PrevisaoEntrega.ToShortDateString();

            // tapete
            TapeteBD bdd = new TapeteBD();
            Tapete tapete = TapeteBD.Select(Convert.ToInt32(Session["IDTapete"].ToString()));

            txtLargura.Text = Convert.ToString(tapete.Comprimento);
            txtComprimento.Text = Convert.ToString(tapete.Largura);
            txtTipoArte.Text = tapete.TipoArte;
            txtValorVenda.Text = Convert.ToString(tapete.ValorVenda);


            // Status
          StatusOrdemProducaoBD bddd = new StatusOrdemProducaoBD();
            StatusOrdemProducao statusOrdemProducao = bddd.Select(Convert.ToInt32(Session["IDStatus"]));

            ddlStatus.DataValueField = statusOrdemProducao.Descricao;
           
                   }
    }

    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        // ordem producao
        OrdemProducaoBD bd = new OrdemProducaoBD();
        OrdemProducao ordemproducao = bd.SelectAlterar(Convert.ToInt32(Session["IDOrdemProducao"]));
        
        ordemproducao.DataEntrada = Convert.ToDateTime(txtDataEntrada.Text);
        ordemproducao.PrevisaoEntrega = Convert.ToDateTime(txtPrevisaoEntrega.Text);
       
              

        if (bd.Update(ordemproducao))
        {
            //lblMensagemErro.Visible = false;

            lblMensagem.Text = "Ordem de procução alterada com sucesso";
            txtDataEntrada.Focus();
        }
        else
        {
            lblMensagem.Text = "Erro ao salvar.";
        }
    }
    protected void lbSair_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("../Login/Login.aspx");
    }
}