using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Persistencia.MP;
using System.Data;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;

public partial class Paginas_MateriaPrima_Listar : System.Web.UI.Page
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


            MateriaPrimaBD bd = new MateriaPrimaBD();
            DataSet ds = bd.SelectAll();

            int quantidade = ds.Tables[0].Rows.Count;
            if (quantidade > 0)
            {
                grvMateria.DataSource = ds.Tables[0].DefaultView;
                grvMateria.DataBind();
                grvMateria.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            else
            {
                lblMensagem.Text = "Nenhuma matéria-prima cadastrada";
            }
        }

    }


    protected void grvMateria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;
        switch (e.CommandName)
        {
            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["IDMateriaPrima"] = codigo;
                Response.Redirect("Alterar.aspx");
                break;
            default:
                break;
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