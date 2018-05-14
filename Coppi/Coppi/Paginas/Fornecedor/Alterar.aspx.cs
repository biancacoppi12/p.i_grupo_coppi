using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Persistencia.PJ;
using System.Data;
using GrupoCoppi.Classes.PJ;
using GrupoCoppi.Persistencia;
using GrupoCoppi.Classes;

public partial class Paginas_Fornecedor_Alterar : System.Web.UI.Page
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



            FornecedorBD bd = new FornecedorBD();
            Fornecedor fornecedor = bd.Select(Convert.ToInt32(Session["IDFornecedor"]));

            txtNome.Text = fornecedor.NomeFantasia;
            txtCnpj.Text = fornecedor.Cnpj;
            txtRazao.Text = fornecedor.RazaoSocial;
            txtInscricao.Text = fornecedor.InscricaoEstadual;
            txtTelefone.Text = fornecedor.Telefone;
            txtCelular.Text = fornecedor.Celular;
            txtEmail.Text = fornecedor.Email;
            txtCep.Text = fornecedor.Cep;
            txtLogradouro.Text = fornecedor.Logradouro;
            txtNumero.Text = fornecedor.Numero;
            txtBairro.Text = fornecedor.Bairro;
            txtCidade.Text = fornecedor.Cidade;
            txtEstado.Text = fornecedor.Estado;



        }
    }
    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        FornecedorBD bd = new FornecedorBD();
        Fornecedor fornecedor = bd.Select(Convert.ToInt32(Session["IDFornecedor"]));
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

        if (bd.Update(fornecedor))
        {
            lblMensagemErro.Visible = false;

            lblMensagem.Text = "Fornecedor alterado com sucesso";
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