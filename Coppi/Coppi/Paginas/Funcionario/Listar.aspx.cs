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

public partial class Paginas_Funcionario_Listar : System.Web.UI.Page
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
        bool retorno = true;
        try
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

                    else
                    {
                      

                        OperadorBD bd = new OperadorBD();
                        DataSet ds = bd.SelectAll();

                        grvFuncionarios.DataSource = ds.Tables[0].DefaultView;
                        grvFuncionarios.DataBind();
                        int quantidade = ds.Tables[0].Rows.Count;
                        if (quantidade > 0)
                        {
                            grvFuncionarios.DataSource = ds.Tables[0].DefaultView;
                            grvFuncionarios.DataBind();
                            grvFuncionarios.HeaderRow.TableSection = TableRowSection.TableHeader;


                        }
                        else
                        {
                            lblMensagem.Text = "funcionário cadastrado";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("../../Paginas/Login/Erro/AcessoNegado.aspx");
                }

            }
        }
        catch (Exception ex)
        {
            retorno = false;

        }
        
    }

    protected void grvFuncionarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int codigo = 0;

        switch (e.CommandName)
        {

            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument);
                Session["IDFuncionario"] = codigo;
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





