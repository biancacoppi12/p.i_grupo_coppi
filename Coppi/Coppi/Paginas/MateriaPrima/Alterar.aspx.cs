using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Persistencia.MP;
using GrupoCoppi.Classes.MP;
using System.Data;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;

public partial class Paginas_MateriaPrima_Alterar : System.Web.UI.Page
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
        catch (Exception)
        {
            Response.Redirect("../../Paginas/Login/Erro/AcessoNegado.aspx");
        }      


        if (!Page.IsPostBack)
        {
            MateriaPrimaBD bd = new MateriaPrimaBD();
            MateriaPrima materiaprima = bd.Select(Convert.ToInt32(Session["IDMateriaPrima"]));
            txtNome.Text = materiaprima.Nome;
            txtQuantidade.Text = Convert.ToString(materiaprima.Quantidade);
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        MateriaPrimaBD bd = new MateriaPrimaBD();
        MateriaPrima materiaprima = bd.Select(Convert.ToInt32(Session["IDMateriaPrima"]));
        materiaprima.Nome = txtNome.Text;
        materiaprima.Quantidade = Convert.ToDouble(txtQuantidade.Text);


        if (bd.Update(materiaprima))
        {
            lblMensagemErro.Visible = false;

            lblMensagem.Text = "Matéria-Prima alterada com sucesso";
            txtNome.Focus();
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