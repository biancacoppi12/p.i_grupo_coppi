using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes.OP;
using GrupoCoppi.Classes.Tapetes;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia.OP;
using GrupoCoppi.Persistencia.Tapetes;
using GrupoCoppi.Persistencia;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Persistencia.MP;
using GrupoCoppi.Classes.MP;
using GrupoCoppi.Classes.PJ;
using System.Data;

public partial class Paginas_OrdemProducao_Cadastrar : System.Web.UI.Page
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
            txtDataEntrada.Focus();
            txtDataEntrada.TextMode = TextBoxMode.Date;
            txtPrevisaoEntrega.TextMode = TextBoxMode.Date;
            txtLargura.TextMode = TextBoxMode.Number;
            txtComprimento.TextMode = TextBoxMode.Number;
            txtValorVenda.TextMode = TextBoxMode.Number;

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
            ddlClientes.Focus();
        }


        // Carrega Clientes
        ClienteBD clientebd = new ClienteBD();
        DataSet clienteds = clientebd.SelectAll();
        ddlClientes.DataSource = clienteds.Tables[0].DefaultView;
        ddlClientes.DataTextField = "pes_nomeFantasia";
        ddlClientes.DataValueField = "pes_id";
        ddlClientes.DataBind();

        ddlClientes.Items.Insert(0, "Selecione");

        // Carrega MP
        MateriaPrimaBD materiaprimabd = new MateriaPrimaBD();
        DataSet mpds = materiaprimabd.SelectAll();
        ddlMP.DataSource = mpds.Tables[0].DefaultView;
        ddlMP.DataTextField = "map_nome";
        ddlMP.DataValueField = "map_id";
        ddlMP.DataBind();

        ddlMP.Items.Insert(0, "Selecione");

        //Carrega Status
        StatusOrdemProducaoBD statusbd = new StatusOrdemProducaoBD();
        DataSet statusds = statusbd.SelectAll();
        ddlStatus.DataSource = statusds.Tables[0].DefaultView;
        ddlStatus.DataTextField = "sta_descricao";
        ddlStatus.DataValueField = "sta_id";
        ddlStatus.DataBind();

        ddlStatus.Items.Insert(0, "Selecione");


    }

    private bool hasStatus()
    {
        return (ddlStatus.SelectedItem.Text != "Selecione");
    }
    private bool hassCliente()
    {
        return (ddlClientes.SelectedItem.Text != "Selecione");
    }
    private bool hassMP()
    {
        return (ddlMP.SelectedItem.Text != "Selecione");
    }

    private void LimparCampos()
    {
        txtDataEntrada.Text = "";
        txtPrevisaoEntrega.Text = "";
        txtLargura.Text = "";
        txtComprimento.Text = "";
        txtValorVenda.Text = "";
        ddlStatus.Items.Clear();
        ddlMP.Items.Clear();
        //adiciona item "Selecione" na primeira posição do ddl

    }

    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        if (!hasStatus())
        {
            lblMensagemErro.Text = "Selecione um Status";
            return;
        }

        if (!hassCliente())
        {
            lblMensagemErro.Text = "Selecione um Cliente";
            return;
        }
        if (!hassMP())
        {
            lblMensagemErro.Text = "Selecione uma matéria-prima";
            return;
        }
        OrdemProducao ordemproducao = new OrdemProducao();
        OrdemProducaoBD bd = new OrdemProducaoBD();

        StatusOrdemProducao statusOrdemProducao = new StatusOrdemProducao();

        ordemproducao.DataEntrada = Convert.ToDateTime(txtDataEntrada.Text);
        ordemproducao.PrevisaoEntrega = Convert.ToDateTime(txtPrevisaoEntrega.Text);

        StatusOrdemProducaoBD statusbd = new StatusOrdemProducaoBD();
        statusOrdemProducao = statusbd.Select(Convert.ToInt32(ddlStatus.SelectedItem.Value));

        // relacionamento op com status 
        ordemproducao.StatusOrdemProducao = statusOrdemProducao;

        // relacionamento op com funcionario 
        Funcionario funcionario = new Funcionario();
        FuncionarioBD funcionarioBD = new FuncionarioBD();
        funcionario = funcionarioBD.Select(Convert.ToInt32(Session["ID"]));
        ordemproducao.Pessoa = funcionario;

        //select ordem produção
        //  OrdemProducao ordemProducao = bd.Select(Convert.ToInt32(Session["IDOrdemProducao"]));


        //relacionamento op CLIENTE
        Cliente cliente = new Cliente();
        ClienteBD clienteBD = new ClienteBD();
        cliente = clienteBD.Select(Convert.ToInt32(ddlClientes.SelectedItem.Value));
        ordemproducao.Pessoa = cliente;

        //relacionamento op CLIENTE
       MateriaPrima mp = new MateriaPrima();
        MateriaPrimaBD mpBD = new MateriaPrimaBD();
        mp = mpBD.Select(Convert.ToInt32(ddlMP.SelectedItem.Value));
        ordemproducao.MP = mp;


        //   tapete.OrdemProducao = bd.SelectDaniel(ordemproducao.Id, ordemproducao.DataEntrada, ordemproducao.PrevisaoEntrega);

        int retorno = bd.Insert(ordemproducao);
        switch (retorno)
        {
            case 0:
                Tapete tapete = new Tapete();
                TapeteBD tapeteBD = new TapeteBD();
                tapete.Largura = Convert.ToDouble(txtLargura.Text);
                tapete.Comprimento = Convert.ToDouble(txtComprimento.Text);
                tapete.TipoArte = txtArte.Text;
                tapete.ValorVenda = Convert.ToDouble(txtValorVenda.Text);
                tapete.OrdemProducao = bd.Select(ordemproducao);

                tapeteBD.Insert(tapete);

                lblMensagemErro.Visible = false;
                lblMensagem.Text = "Cadastro realizado com sucesso";
                LimparCampos();
                Carrega();
                break;
            //LimparCampos();
            //txtDataEntrada.Focus();
            //lblMensagem.Text = "Cadastro realizado com sucesso";
            //break;
            case 1:
                //Erro no banco de dados
                lblMensagem.Text = "Não foi possível realizar o cadastro.";
                break;
            case 2:
                //Erro geral
                lblMensagem.Text = "Não foi possível realizar o cadastro.";
                break;
            case -1:
                lblMensagem.Text = "Não foi possível realizar o cadastro.";
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




    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!hasStatus())
        {
            lblMensagem.Text = "Selecione um Status";
            return;
        }
    }
}