<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AcessoNegado.aspx.cs" Inherits="Paginas_Login_Erro_AcessoNegado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="lblAcessoNegado" runat="server" Text="ACESSO NEGADO!"></asp:Label>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="../Login.aspx" runat="server">Voltar para a tela de Login</asp:HyperLink>
    </div>
    </form>
</body>
</html>
