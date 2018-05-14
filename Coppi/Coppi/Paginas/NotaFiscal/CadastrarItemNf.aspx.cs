using GrupoCoppi.Classes.NF;
using GrupoCoppi.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes.MP;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Persistencia.MP;
using GrupoCoppi.Persistencia.NF;
using System.Data;
using GrupoCoppi.Classes;
// falta colocar materia prima e o botão de excluir na tabela
// falta salvar fornecedor e materia prima juntos
public partial class Paginas_NotaFiscal_Cadastrar : System.Web.UI.Page
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
                else
                    ;
            }
            catch (Exception ex)
            {

                Response.Redirect("../../Paginas/Login/Erro/AcessoNegado.aspx");
            }
            if (Session["IDNotaFiscal"] != null)
                Carrega();
            else
                Response.Redirect("../../Paginas/NotaFiscal/CadastrarNf.aspx");

        }
    }

    private void Carrega()
    {
        {
            ItemNotaFiscal itemnotafiscal = new ItemNotaFiscal();
            txtFabricacao.TextMode = TextBoxMode.Date;
            txtValidade.TextMode = TextBoxMode.Date;
            NotaFiscalBD bd = new NotaFiscalBD();
            NotaFiscal notafiscal = NotaFiscalBD.Select(Convert.ToInt32(Session["IDNotaFiscal"].ToString()));



          //  txtNumero.Text = Session["IDNotaFiscal"].ToString();


            txtNumero.Text = Convert.ToString(notafiscal.Numero);
            txtDataEmissao.Text = Convert.ToString(notafiscal.DataEmissao);
            txtValorTotal.Text = Convert.ToString(notafiscal.ValorTotal);
            ddlFornecedor.Items.Insert(0, new ListItem(notafiscal.Fornecedor.NomeFantasia, notafiscal.Fornecedor.pes_id.ToString()));

        }


        //Carrega Matéria-Prima
        MateriaPrimaBD materiaprimabd = new MateriaPrimaBD();
        DataSet materiaprimads = materiaprimabd.SelectAllNn();

        //vincula matéria-prima ao dropdownlist
        ddlMateria.DataSource = materiaprimads.Tables[0].DefaultView;
        ddlMateria.DataTextField = "map_nome";
        ddlMateria.DataValueField = "map_id";
        ddlMateria.DataBind();
        ddlMateria.Items.Insert(0, "Selecione");

        //ItemNotaFiscalBD bditem = new ItemNotaFiscalBD();
        //DataSet ds = bditem.SelectAll();
        //grvItem.DataSource = ds.Tables[0].DefaultView;
        //grvItem.DataBind();
    }
    //Verifica Materia
    private bool hasMateria()
    {
        return (ddlMateria.SelectedItem.Text != "Selecione");
    }
    private void LimparCampos()
    {
        txtQuantidadeItem.Text = "";
        txtFabricacao.Text = "";
        txtValidade.Text = "";
        txtLote.Text = "";
        txtValorUnitario.Text = "";
        txtValorTUnitario.Text = "";
        txtQuantidade.Text = "";


    }

    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        if (!hasMateria())
        {
            lblMensagemErro.Text = "Selecione uma matéria prima";
            return;
        }
        ItemNotaFiscal itemnotafiscal = new ItemNotaFiscal();
        itemnotafiscal.ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
        itemnotafiscal.ValorTUnitario = Convert.ToDouble(txtValorTUnitario.Text);
        itemnotafiscal.Quantidade = Convert.ToInt32(txtQuantidade.Text);
        itemnotafiscal.QuantidadeItem = Convert.ToDouble(txtQuantidadeItem.Text);
        itemnotafiscal.DataFabricacao = Convert.ToDateTime(txtFabricacao.Text);
        itemnotafiscal.DataValidade = Convert.ToDateTime(txtValidade.Text);
        itemnotafiscal.Lote = txtLote.Text;


        MateriaPrima mp = new MateriaPrima();
        MateriaPrimaBD mpbd = new MateriaPrimaBD();
        mp = mpbd.Select(Convert.ToInt32(ddlMateria.SelectedItem.Value));
            
        itemnotafiscal.MateriPrima = mp;

        NotaFiscal nf = new NotaFiscal();
        nf.Id = Convert.ToInt32(Session["IDNotaFiscal"]);

        itemnotafiscal.NotaFiscal = nf;
        ItemNotaFiscalBD bd = new ItemNotaFiscalBD();
        int retorno = bd.InsertRetornaId(itemnotafiscal);

        if (retorno > 0)
        {
            Session["IDItemNotaFiscal"] = retorno;
        }


        lblMensagem.Text = "Item incluído com sucesso";
        LimparCampos();

    }

    protected void grvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;

        switch (e.CommandName)
        {

            case "Excluir":
                codigo = Convert.ToInt32(e.CommandArgument);
                ItemNotaFiscalBD bd = new ItemNotaFiscalBD();
                bd.Delete(codigo);
                Carrega();  
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

