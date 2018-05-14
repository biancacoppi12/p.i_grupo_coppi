using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Persistencia.MP;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Classes.MP;
using GrupoCoppi.Classes.PJ;
using System.Data;


public partial class Paginas_MateriaPrima_Vincular : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Carrega();
        }
    }
    private void Carrega()
    {
        //Carrega Matéria-Prima
        MateriaPrimaBD materiaprimabd = new MateriaPrimaBD();
        DataSet materiaprimads = materiaprimabd.SelectAllNn();

        //vincula matéria-prima ao dropdownlist
        ddlMateria.DataSource = materiaprimads.Tables[0].DefaultView;
        ddlMateria.DataTextField = "map_nome";
        ddlMateria.DataValueField = "map_id";
        ddlMateria.DataBind();
        ddlMateria.Items.Insert(0, "Selecione");

        //Carrega Fornecedores
        FornecedorBD fornecedorbd = new FornecedorBD();
        DataSet fornecedords = fornecedorbd.SelectAll();

        //Vincula fornecedores ao dropdownlist
        ddlFornecedor.DataSource = fornecedords.Tables[0].DefaultView;
        ddlFornecedor.DataTextField = "pes_nomeFantasia";
        ddlFornecedor.DataValueField = "pes_id";
        ddlFornecedor.DataBind();
        ddlFornecedor.Items.Insert(0, "Selecione");
    }
    //limpar ddl e cbl





    //Verifica Materia
    private bool hasMateria()
    {
        return (ddlMateria.SelectedItem.Text != "Selecione");
    }

    //Verifica Fornecedor
    private bool hasFornecedor()
    {
        return (ddlFornecedor.SelectedItem.Text != "Selecione");

    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        if (!hasMateria())
        {
            lblMensagem.Text = "Selecione uma matéria-prima";
            return;
        }
        if (!hasFornecedor())
        {
            lblMensagem.Text = "Selecione um fornecedor";
            return;
        }

        int materia = Convert.ToInt32(ddlMateria.SelectedItem.Value);
        MateriaPrimaBD bd = new MateriaPrimaBD();
        for (int i = 0; i < ddlFornecedor.Items.Count; i++)
        {
            if (ddlFornecedor.Items[i].Selected)
            {
                int fornecedor = Convert.ToInt32(ddlFornecedor.Items[i].Value);
                bd.Vincular(materia, fornecedor);
            }
        }
        lblMensagem.Text = "Produto vinculado com sucesso";
    }



    protected void ddlMateria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!hasMateria())
        {
            lblMensagem.Text = "Selecione um produto";
            return;
        }
        int produto = Convert.ToInt32(ddlMateria.SelectedItem.Value);
        MateriaPrimaBD bd = new MateriaPrimaBD();
        DataSet ds = bd.GetFornecedores(produto);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grvMateriaPrima.DataSource = ds.Tables[0].DefaultView;
            grvMateriaPrima.DataBind();
            grvMateriaPrima.Visible = true;
            lblMensagem.Text = "";
        }
        else
        {
            lblMensagem.Text = "Não existem fornecedores para esta Matéria Prima";
            grvMateriaPrima.Visible = false;
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
