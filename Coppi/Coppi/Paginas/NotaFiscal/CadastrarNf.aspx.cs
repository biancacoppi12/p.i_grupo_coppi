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
using GrupoCoppi.Classes.PJ;
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
            txtValorTotal.TextMode = TextBoxMode.Number;

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

            Carrega();
        }
    }

    private void Carrega()
    {
        {
            txtNumero.Focus();
            txtDataEmissao.TextMode = TextBoxMode.Date;
        }
        //Carrega Fornecedores
        FornecedorBD fornecedorbd = new FornecedorBD();
        DataSet fornecedords = fornecedorbd.SelectAll();

        //Vincula fornecedores ao dropdown
        ddlFornecedor.DataSource = fornecedords.Tables[0].DefaultView;
        ddlFornecedor.DataTextField = "pes_nomeFantasia";
        ddlFornecedor.DataValueField = "pes_id";
        ddlFornecedor.DataBind();
        ddlFornecedor.Items.Insert(0, "Selecione");



    }
    //Verifica Fornecedor
    private bool hasFornecedor()
    {
        return (ddlFornecedor.SelectedItem.Text != "Selecione");

    }

    private void LimparCampos()
    {
        txtNumero.Text = "";
        txtDataEmissao.Text = "";
        txtValorTotal.Text = "";
    }

    private bool NumeroNFEncontrado(NotaFiscal notafiscal)
    {
        bool retornoNf = false;
        if (notafiscal != null)
        {
            retornoNf = true;
        }
        return retornoNf;
    }


    protected void lbAdicionar_Click(object sender, EventArgs e)
    {
        if (!hasFornecedor())
        {
            lblMensagemErro.Text = "Selecione uma fornecedor";
            return;
        }
        NotaFiscal notafiscal = new NotaFiscal();
        notafiscal.Numero = txtNumero.Text;
        notafiscal.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
        notafiscal.ValorTotal = Convert.ToDouble(txtValorTotal.Text);

        Fornecedor fornecedor = new Fornecedor();
        //FornecedorBD fornecedorbd = new FornecedorBD();
        //fornecedor = fornecedorbd.Select(Convert.ToInt32(ddlFornecedor.SelectedItem.Value));
        fornecedor.pes_id = Convert.ToInt32(ddlFornecedor.SelectedItem.Value);
        notafiscal.Fornecedor = fornecedor;


        NotaFiscalBD bd = new NotaFiscalBD();



        NotaFiscal validaNumeroNf = new NotaFiscal();
        validaNumeroNf = bd.VerificaDuplicidadeNF(notafiscal.Numero);

        if (NumeroNFEncontrado(validaNumeroNf))
        {
            txtNumero.Focus();
            lblMensagemErro.Text = "Nota Fiscal já cadastrada no sistema";
        }
        else
        {

            int retorno = bd.InsertRetornaId(notafiscal);
            if (retorno > 0)
            {
                Session["IDNotaFiscal"] = retorno;
                Response.Redirect("../../Paginas/NotaFiscal/CadastrarItemNf.aspx?par=" + retorno);
                lblMensagemErro.Visible = false;
                lblMensagem.Text = "Cadastro realizado com sucesso";
            }
        }





        //ddlMateria.SelectedItem.Text = "Selecione";
        //txtFabricacao.Text = "";
        //txtValidade.Text = "";
        //txtLote.Text = "";
        //txtQuantidade.Text = "";
        //txtValorUnitario.Text = "";
        //txtValorTUnitario.Text = "";

        //ItemNotaFiscal i = new ItemNotaFiscal();
        //i.Quantidade = Convert.ToInt32(txtQuantidade.Text);
        //i.ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
        //i.ValorTUnitario = Convert.ToDouble(txtValorTUnitario.Text);

        //if (Session["LISTA"] != null)
        //{
        //    List<ItemNotaFiscal> list = (List<ItemNotaFiscal>)Session["LISTA"];
        //    list.Add(i);
        //    Session["LISTA"] = list;
        //    CarregaItens(list);
        //}
        //else
        //{
        //    List<ItemNotaFiscal> list = new List<ItemNotaFiscal>();
        //    list.Add(i);
        //    Session["LISTA"] = list;
        //    CarregaItens(list);
        //}




    }

    /*
        MateriaPrimaBD bd = new MateriaPrimaBD();
        for (int i = 0; i < ddlFornecedor.Items.Count; i++)
        {
            if (ddlFornecedor.Items[i].Selected)
            {
                int fornecedor = Convert.ToInt32(ddlFornecedor.Items[i].Value);
                int materia = Convert.ToInt32(ddlMateria.SelectedItem.Value);
                bd.Vincular(materia, fornecedor);
            }
        }


    }
    */
    protected void btnSalvar_Click(object sender, EventArgs e)
    {


        //NotaFiscal notaFiscal = new NotaFiscal();
        //if (Session["LISTA"] != null)
        //{
        //    notaFiscal.ItensNotaFiscal = (List<ItemNotaFiscal>)Session["LISTA"];

        //    string sql = "";
        //    foreach(ItemNotaFiscal i in notaFiscal.ItensNotaFiscal)
        //    {
        //        sql+="INSERT INTO inf_itemnotafiscal VALUES("+i.Quantidade+", " + i.ValorUnitario+"); ";
        //    }
        //    //NotaFiscalBD n = new NotaFiscalBD();
        //    //if (n.ExecutarSQL(sql) == 0)
        //    //{

        //    //}


        //}

        //notaFiscal.Numero = txtNumero.Text;
        //notaFiscal.DataEmissao = Convert.ToDateTime(txtDataEmissao.Text);
        //notaFiscal.ValorTotal = Convert.ToDouble(txtValorTotal.Text);

        //ItemNotaFiscal itemNotaFiscal = new ItemNotaFiscal();


        //itemNotaFiscal.Quantidade = Convert.ToInt32(txtQuantidade.Text);
        //itemNotaFiscal.ValorUnitario = Convert.ToDouble(txtValorUnitario.Text);
        //itemNotaFiscal.ValorTUnitario = Convert.ToDouble(txtValorTUnitario.Text);

        //ItemMateriaPrima itemMateriaPrima = new ItemMateriaPrima();

        //itemMateriaPrima.QuantidadeItem = Convert.ToDouble(txtQuantidadeItem.Text);
        //itemMateriaPrima.DataFabricacao = Convert.ToDateTime(txtFabricacao.Text);
        //itemMateriaPrima.DataValidade = Convert.ToDateTime(txtValidade.Text);
        //itemMateriaPrima.Lote = txtLote.Text;

        //NotaFiscalBD bd = new NotaFiscalBD();



        ///*   ItemNotaFiscalBD nfbd = new ItemNotaFiscalBD();
        //   ItemMateriaPrimaBD mpbd = new ItemMateriaPrimaBD();        */

        //int retorno = bd.Insert(notaFiscal);
        //switch (retorno)
        //{
        //    case 0:
        //        LimparCampos();
        //        txtNumero.Focus();
        //        lblMensagem.Text = "Cadastro realizado com sucesso";
        //        break;
        //    case 1:
        //        //Erro no banco de dados
        //        lblMensagem.Text = "Não foi possível realizar o cadastro.";
        //        break;
        //    case 2:
        //        //Erro geral
        //        lblMensagem.Text = "Não foi possível realizar o cadastro.";
        //        break;
        //    default:
        //        break;
        //}
    }
    protected void lbSair_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Redirect("../Login/Login.aspx");
    }
}

