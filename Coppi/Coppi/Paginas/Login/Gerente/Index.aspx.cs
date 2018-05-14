using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;

public partial class Paginas_Login_Gerente_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int codigo = Convert.ToInt32(Session["ID"]);
            FuncionarioBD bd = new FuncionarioBD();
            Funcionario funcionario = bd.Select(codigo);
            if (!IsGerente(funcionario.Tipo))
            {
                Response.Redirect("../Erro/AcessoNegado.aspx");
            }
            else
            {
                lblTitulo.Text = "Bem vindo Gerente: " + funcionario.Nome;
            }
        }
    }

    private bool IsGerente(int tipo)
    {
        bool retorno = false;
        if (tipo == 0)
        {
            retorno = true;
        }
        return retorno;
    }

    protected void lbSair_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("../Login.aspx");
    }

    

}
