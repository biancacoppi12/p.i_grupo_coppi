using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;

public partial class Paginas_Login_Operador_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int codigo = Convert.ToInt32(Session["ID"]);
            FuncionarioBD bd = new FuncionarioBD();
            Funcionario funcionario = bd.Select(codigo);
            if (!IsOperador(funcionario.Tipo))
            {
                Response.Redirect("../Erro/AcessoNegado.aspx");
            }
            else
            {
                lblTitulo.Text = "Bem vindo Operador : " + funcionario.Nome;
            }
        }
    }

    private bool IsOperador(int tipo)
    {
        bool retorno = false;
        if (tipo == 1)
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