using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes.PJ;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Persistencia;


public partial class Paginas_Fornecedor_Cadastrar : System.Web.UI.Page
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
            txtNome.Focus();
            txtCep.TextMode = TextBoxMode.Number;
            txtEmail.TextMode = TextBoxMode.Email;

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

        }
    }
    private void LimparCampos()
    {
        txtNome.Text = "";
        txtCnpj.Text = "";
        txtRazao.Text = "";
        txtInscricao.Text = "";
        txtTelefone.Text = "";
        txtCelular.Text = "";
        txtEmail.Text = "";
        txtCep.Text = "";
        txtLogradouro.Text = "";
        txtNumero.Text = "";
        txtBairro.Text = "";
        txtCidade.Text = "";
        txtEstado.Text = "";
    }

    private bool EmailEncontrado(Fornecedor fornecedor)
    {
        bool retornoEmail = false;
        if (fornecedor != null)
        {
            retornoEmail = true;
        }
        return retornoEmail;
    }
    private bool CnpjEncontrado(Fornecedor fornecedor)
    {
        bool retornoCnpj = false;
        if (fornecedor != null)
        {
            retornoCnpj = true;
        }
        return retornoCnpj;
    }
    private bool RazaoSocialEncontrada(Fornecedor fornecedor)
    {
        bool retornoRazaoSocial = false;
        if (fornecedor != null)
        {
            retornoRazaoSocial = true;
        }
        return retornoRazaoSocial;
    }


    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        Fornecedor fornecedor = new Fornecedor();
        fornecedor.NomeFantasia = txtNome.Text;
        fornecedor.Cnpj = txtCnpj.Text;
        fornecedor.RazaoSocial = txtRazao.Text;
        fornecedor.InscricaoEstadual = txtInscricao.Text;
        fornecedor.Telefone = txtTelefone.Text;
        fornecedor.Celular = txtCelular.Text;
        fornecedor.Email = txtEmail.Text;
        fornecedor.Cep = txtCep.Text;
        fornecedor.Logradouro = txtLogradouro.Text;
        fornecedor.Numero = txtNumero.Text;
        fornecedor.Bairro = txtBairro.Text;
        fornecedor.Cidade = txtCidade.Text;
        fornecedor.Estado = txtEstado.Text;

        Fornecedor validaEmail = new Fornecedor();
        Fornecedor validaCnpj = new Fornecedor();
        Fornecedor validaRazaoSocial = new Fornecedor();

        FornecedorBD bd = new FornecedorBD();

        validaEmail = bd.VerificaDupicidadeEmail(fornecedor.Email);
        validaCnpj = bd.VerificaDupicidadeCnpj(fornecedor.Cnpj);
        validaRazaoSocial = bd.VerificaDupicidadeRazaoSocial(fornecedor.RazaoSocial);

        if (EmailEncontrado(validaEmail) || CnpjEncontrado(validaCnpj) || CnpjEncontrado(validaRazaoSocial))
        {
            if (EmailEncontrado(validaEmail))
            {
                txtEmail.Focus();
                lblMensagemErro.Text = "Email já cadastrado no sistema";
            }

            if (CnpjEncontrado(validaCnpj))
            {
                txtCnpj.Focus();
                lblMensagemErro.Text = "CNPJ já cadastrado no sistema";
            }

            if (CnpjEncontrado(validaRazaoSocial))
            {
                txtRazao.Focus();
                lblMensagemErro.Text = "Razão Social já cadastrada no sistema";
            }
        }
        else
        {

            int retorno = bd.Insert(fornecedor);

            switch (retorno)
            {
                case 0:
                    LimparCampos();
                    txtNome.Focus();
                    lblMensagemErro.Visible = false;
                    lblMensagem.Text = "Cadastro realizado com sucesso";
                    break;
                case 1:
                    //Erro no banco de dados
                    lblMensagem.Text = "Não foi possível realizar o cadastro.";
                    break;
                case 2:
                    //Erro geral
                    lblMensagem.Text = "Não foi possível realizar o cadastro.";
                    break;
                default:
                    break;
            }
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