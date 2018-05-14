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

public partial class Paginas_Cliente_Cadastrar : System.Web.UI.Page
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
                else
                    ;
                ;
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
        txtData.Text = "";
        txtTelefone.Text = "";
        txtCelular.Text = "";
        txtEmail.Text = "";
        txtCep.Text = "";
        txtLogradouro.Text = "";
        txtBairro.Text = "";
        txtCidade.Text = "";
        txtEstado.Text = "";
        txtNumero.Text = "";
    }

    private bool EmailEncontrado(Cliente cliente)
    {
        bool retornoEmail = false;
        if (cliente != null)
        {
            retornoEmail = true;
        }
        return retornoEmail;
    }
    private bool CnpjEncontrado(Cliente cliente)
    {
        bool retornoCnpj = false;
        if (cliente != null)
        {
            retornoCnpj = true;
        }
        return retornoCnpj;
    }
    private bool RazaoSocialEncontrada(Cliente cliente)
    {
        bool retornoRazaoSocial = false;
        if (cliente != null)
        {
            retornoRazaoSocial = true;
        }
        return retornoRazaoSocial;
    }

    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        Cliente cliente = new Cliente();

        cliente.NomeFantasia = txtNome.Text;
        cliente.Cnpj = txtCnpj.Text;
        cliente.RazaoSocial = txtRazao.Text;
        cliente.InscricaoEstadual = txtInscricao.Text;
        cliente.Telefone = txtTelefone.Text;
        cliente.Celular = txtCelular.Text;
        cliente.Email = txtEmail.Text;
        cliente.Cep = txtCep.Text;
        cliente.Logradouro = txtLogradouro.Text;
        cliente.Bairro = txtBairro.Text;
        cliente.Cidade = txtCidade.Text;
        cliente.Estado = txtEstado.Text;
        cliente.Numero = txtNumero.Text;

        Cliente validaEmail = new Cliente();
        Cliente validaCnpj = new Cliente();
        Cliente validaRazaoSocial = new Cliente();

        ClienteBD bd = new ClienteBD();

        validaEmail = bd.VerificaDupicidadeEmail(cliente.Email);
        validaCnpj = bd.VerificaDupicidadeCnpj(cliente.Cnpj);
        validaRazaoSocial = bd.VerificaDupicidadeRazaoSocial(cliente.RazaoSocial);


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
            int retorno = bd.Insert(cliente);
            switch (retorno)
            {
                case 0:
                    LimparCampos();
                    txtNome.Focus();
                    lblMensagemErro.Visible = false;
                    lblMensagem.Text = "Cadastro realizado com sucesso";
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