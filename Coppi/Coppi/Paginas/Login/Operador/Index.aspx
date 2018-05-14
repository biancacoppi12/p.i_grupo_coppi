<%@ Page Language="C#" MasterPageFile="~/Paginas/MasterPage2.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Paginas_Login_Operador_Index" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../../../Scripts/bootstrap.min.js"></script>
    <link href="../../../Content/styles.css" rel="stylesheet" />
    <link href="../../../Content/font-awesome.css" rel="stylesheet" />
    <link href="../../../Content/font-awesome.min.css" rel="stylesheet" />
</asp:Content>

 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="height: 286px">
        
        <br />
            <div id="tituloPagina" class="col-lg-12">
                <asp:Label ID="lblTitulo" CssClass="titulo" runat="server" Text="Tela principal do Operador"></asp:Label>
            </div>
            <br />
                   
            
     <script src="http:/ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script src="http:/cloud.github.com/downloads/digitalBush/jquery.maskedinput/jquery.maskedinput-1.3.min.js"></script>
    <script src="../../../Scripts/mascaraCadastroAlteracao.js"></script>
         </div>
   </asp:Content>
