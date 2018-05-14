<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Paginas_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Content/styles.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />


</head>
<body>
    <div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <div class="col-md-12 teste" id="imgCabecalho">
                        <img src="../../Imagens/Logo - Grupo Copi S2.png" class="img-responsive" alt="Logotipo">
                    </div>

                    <div class="modal-body">
                        <form id="form1" class="form col-md-12 center-block" runat="server">
                            <div>
                                <div class="form-group">
                                    <asp:Label ID="lblEmail" class="fa fa-envelope-open-o" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtEmail"  runat="server" pattern="[0-9]+$"  placeholder="Email" Width="100%"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lblSenha" class="fa fa-key" runat="server" Text=""></asp:Label>
                                    <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" Width="100%" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:LinkButton ID="lbEntrar" CssClass="btn btn-success" OnClick="lbEntrar_Click" runat="server"><span  class="glyphicon glyphicon-log-in" ></span> Entrar</asp:LinkButton>


                                    <div id="msgErro">
                                        <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
