<%@ Page Language="C#" MasterPageFile="~/Paginas/MasterPage2.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Paginas_Login_Gerente_Index" %>


    



 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        
    <asp:Label ID="lblTitulo" runat="server" Text="Tela principal do Operador"></asp:Label>
        <br />
        <asp:HyperLink ID="hlCliente" runat="server" NavigateUrl="~/Paginas/Cliente/Cadastrar.aspx">Cadastro de Clientes</asp:HyperLink>
         <br />
         <asp:HyperLink ID="hlFornecedor" runat="server" NavigateUrl="~/Paginas/Fornecedor/Cadastrar.aspx">Cadastro de Fornecedores</asp:HyperLink>
 <br />
         <asp:HyperLink ID="hlMateriaPrima" runat="server" NavigateUrl="~/Paginas/MateriaPrima/Cadastrar.aspx">Cadastro de Materia Prima</asp:HyperLink>
        <br />
        <asp:HyperLink ID="hlFuncionario" runat="server" NavigateUrl="~/Paginas/Funcionario/Cadastrar.aspx">Cadastro de Funcionários</asp:HyperLink>
        <br />
         <asp:LinkButton ID="lbSair" runat="server" OnClick="lbSair_Click">Sair</asp:LinkButton>
        
    </div>
   </asp:Content>
