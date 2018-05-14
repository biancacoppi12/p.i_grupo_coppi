using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Classes.PJ;
using System.Data;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;


public partial class Paginas_Cliente_Alterar : System.Web.UI.Page
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


            ClienteBD bd = new ClienteBD();
            Cliente cliente = bd.Select(Convert.ToInt32(Session["IDCliente"]));

            txtTelefone.Text = cliente.Telefone;
            txtCelular.Text = cliente.Celular;
            txtEmail.Text = cliente.Email;
            txtCep.Text = cliente.Cep;
            txtLogradouro.Text = cliente.Logradouro;
            txtNumero.Text = cliente.Numero;
            txtBairro.Text = cliente.Bairro;
            txtCidade.Text = cliente.Cidade;
            txtEstado.Text = cliente.Estado;
            txtNome.Text = cliente.NomeFantasia;
            txtCnpj.Text = cliente.Cnpj;
            txtRazao.Text = cliente.RazaoSocial;
            txtInscricao.Text = cliente.InscricaoEstadual;
            txtData.Text = cliente.DataCadastro.ToShortDateString();



        }
    }

    protected void lbSalvar_Click(object sender, EventArgs e)
    {
        ClienteBD bd = new ClienteBD();
        Cliente cliente = bd.Select(Convert.ToInt32(Session["IDCliente"]));
        cliente.Telefone = txtTelefone.Text;
        cliente.Celular = txtCelular.Text;
        cliente.Email = txtEmail.Text;
        cliente.Cep = txtCep.Text;
        cliente.Logradouro = txtLogradouro.Text;
        cliente.Numero = txtNumero.Text;
        cliente.Bairro = txtBairro.Text;
        cliente.Cidade = txtCidade.Text;
        cliente.Estado = txtEstado.Text;
        cliente.NomeFantasia = txtNome.Text;
        cliente.Cnpj = txtCnpj.Text;
        cliente.RazaoSocial = txtRazao.Text;
        cliente.InscricaoEstadual = txtInscricao.Text;


        if (bd.Update(cliente))
        {
            lblMensagemErro.Visible = false;

            lblMensagem.Text = "Cliente alterado com sucesso";
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