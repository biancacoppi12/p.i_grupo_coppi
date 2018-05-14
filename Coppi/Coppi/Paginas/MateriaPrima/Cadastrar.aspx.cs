using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes.MP;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia.MP;
using GrupoCoppi.Persistencia;

public partial class Paginas_MateriaPrima_Cadastrar : System.Web.UI.Page
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
            else
                ;
        }
        catch (Exception)
        {

            Response.Redirect("../../Paginas/Login/Erro/AcessoNegado.aspx");
        }



    }

    private void LimparCampos()
    {
        txtNome.Text = "";

    }
    private bool NomeEncontrado(MateriaPrima mp)
    {
        bool retornoNome = false;
        if (mp != null)
        {
            retornoNome = true;
        }
        return retornoNome;
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        MateriaPrima materiaprima = new MateriaPrima();
        materiaprima.Nome = txtNome.Text;

        MateriaPrima validaNome = new MateriaPrima();

        MateriaPrimaBD bd = new MateriaPrimaBD();

        validaNome = bd.VerificaDupicidadeNome(materiaprima.Nome);

        if (NomeEncontrado(validaNome))
        {
            txtNome.Focus();
            lblMensagemErro.Text = "´Matéria Prima já cadastrada no sistema";
        }
        else
        {



            int retorno = bd.Insert(materiaprima);

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

