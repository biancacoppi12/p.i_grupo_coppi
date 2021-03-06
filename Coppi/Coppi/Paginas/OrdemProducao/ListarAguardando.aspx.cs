﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrupoCoppi.Classes;
using GrupoCoppi.Persistencia;
using GrupoCoppi.Persistencia.OP;
using GrupoCoppi.Persistencia.Tapetes;
using GrupoCoppi.Persistencia.PJ;
using GrupoCoppi.Classes.OP;
using GrupoCoppi.Classes.Tapetes;
using GrupoCoppi.Classes.PJ;
using System.Data;

public partial class Paginas_OrdemProducao_ListarAguardando : System.Web.UI.Page
{
    private bool isGerente(int tipo)
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
                if (!isGerente(funcionario.Tipo))
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
        // op
        OrdemProducaoBD bd = new OrdemProducaoBD();
        DataSet ds = bd.SelectAllAguardando();


        int quantidade = ds.Tables[0].Rows.Count;

        if (quantidade > 0)
        {
            grvOPAberta.DataSource = ds.Tables[0].DefaultView;
            grvOPAberta.DataBind();
            grvOPAberta.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        else
        {
            lblMensagem.Text = "Nenhuma ordem de produção aguardando";
        }

        if (quantidade > 3)
        {
            lblAviso.Text = "Mesa de Vulcanização já pode ser ligada";
        }

        else
        {
            lblAviso.Text = "";
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



