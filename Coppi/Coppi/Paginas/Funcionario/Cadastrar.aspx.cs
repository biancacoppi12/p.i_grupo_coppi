using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes.PJ;
using GrupoCoppi.Classes;
using GrupoCoppi.Classes.Funcionarios;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Persistencia;

public partial class Paginas_Funcionario_Cadastrar : System.Web.UI.Page
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
            txtSenha.TextMode = TextBoxMode.Password;
            txtConfirmaSenha.TextMode = TextBoxMode.Password;

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
            catch (Exception)
            {
                Response.Redirect("../../Paginas/Login/Erro/AcessoNegado.aspx");
            }

        }
    }

    private void LimparCampos()
    {
        txtNome.Text = "";
        txtCpf.Text = "";
        txtTelefone.Text = "";
        txtCelular.Text = "";
        txtEmail.Text = "";
        txtCep.Text = "";
        txtLogradouro.Text = "";
        txtNumero.Text = "";
        txtBairro.Text = "";
        txtCidade.Text = "";
        txtEstado.Text = "";
        txtLogin.Text = "";
        txtSenha.Text = "";

    }
    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        if (rbOperador.Checked)
        {
            Operador operador = new Operador();
            operador.Nome = txtNome.Text;
            operador.Cpf = txtCpf.Text;
            operador.Telefone = txtTelefone.Text;
            operador.Celular = txtCelular.Text;
            operador.Email = txtEmail.Text;
            operador.Cep = txtCep.Text;
            operador.Logradouro = txtLogradouro.Text;
            operador.Numero = txtNumero.Text;
            operador.Bairro = txtBairro.Text;
            operador.Cidade = txtCidade.Text;
            operador.Estado = txtEstado.Text;
            operador.Login = txtEmail.Text;
            operador.Senha = txtSenha.Text;

            OperadorBD bd = new OperadorBD();

            int retorno = bd.Insert(operador);

            switch (retorno)
            {
                case 0:
                    LimparCampos();
                    txtNome.Focus();
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
        else
        {
            Gerente gerente = new Gerente();
            gerente.Nome = txtNome.Text;
            gerente.Cpf = txtCpf.Text;
            gerente.Telefone = txtTelefone.Text;
            gerente.Celular = txtCelular.Text;
            gerente.Email = txtEmail.Text;
            gerente.Cep = txtCep.Text;
            gerente.Logradouro = txtLogradouro.Text;
            gerente.Numero = txtNumero.Text;
            gerente.Bairro = txtBairro.Text;
            gerente.Cidade = txtCidade.Text;
            gerente.Estado = txtEstado.Text;
            gerente.Login = txtEmail.Text;
            gerente.Senha = txtSenha.Text;

            GerenteBD bd = new GerenteBD();

            int retorno = bd.Insert(gerente);

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
