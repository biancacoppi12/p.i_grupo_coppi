using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;

public partial class Paginas_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtEmail.Focus();
        txtEmail.TextMode = TextBoxMode.Email;
        txtSenha.TextMode = TextBoxMode.Password;
    }

    private bool IsPreenchido(string str)
    {
        bool retorno = false;
        if (str != string.Empty)
        {
            retorno = true;
        }
        return retorno;
    }
    private bool UsuarioEncontrado(Funcionario funcionario)
    {
        bool retorno = false;
        if (funcionario != null)
        {
            retorno = true;
        }
        return retorno;
    }

    private void LimparCampos()
    {
        txtEmail.Text = "";
        txtSenha.Text = "";
    }

    protected void lbEntrar_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text.Trim();
        string senha = txtSenha.Text.Trim();

        if (!IsPreenchido(email))
        {       
            LimparCampos();
            txtEmail.Focus();
            lblMensagem.Text = "Preencha o Email";
            return;
        }
        if (!IsPreenchido(senha))
        {          
            
            txtSenha.Focus();
            lblMensagem.Text = "Preencha a senha";
            return;
        }


        FuncionarioBD bd = new FuncionarioBD();
        Funcionario funcionario = new Funcionario();
        funcionario = bd.Autentica(email, senha);
        if (!UsuarioEncontrado(funcionario))
        {
            LimparCampos();
            txtEmail.Focus();
            lblMensagem.Text = "Email e/ou Senha incorretos";           
            return;
        }

        Session["ID"] = funcionario.Id;
        switch (funcionario.Tipo)
        {
            case 0:
                Response.Redirect("../Cliente/Listar.aspx");
                break;
            case 1:
                Response.Redirect("../OrdemProducao/ListarOPAbertaOperador.aspx");
                break;
            default:
                break;
        }


    }
}