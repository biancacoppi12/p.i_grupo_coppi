﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="CadastrarNf.aspx.cs" Inherits="Paginas_NotaFiscal_Cadastrar" %>

<head>
    <meta charset="UTF-8" />
    <title>Grupo Coppi</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />

    <!-- Bootstrap 3.3.2 -->
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- FontAwesome 4.3.0 -->
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons 2.0.0 -->
    <link href="http://code.ionicframework.com/ionicons/2.0.0/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../../dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins 
         folder instead of downloading all of them to reduce the load. -->
    <link href="../../dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link href="../../plugins/iCheck/flat/blue.css" rel="stylesheet" type="text/css" />
    <!-- Morris chart -->
    <link href="../../plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <!-- jvectormap -->
    <link href="../../plugins/jvectormap/jquery-jvectormap-1.2.2.css" rel="stylesheet" type="text/css" />
    <!-- Date Picker -->
    <link href="../../plugins/datepicker/datepicker3.css" rel="stylesheet" type="text/css" />
    <!-- Daterange picker -->
    <link href="../../plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />
    <!-- bootstrap wysihtml5 - text editor -->
    <link href="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />


    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <link href="../../Content/jquery.dataTables.min.css" rel="stylesheet" />


    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Content/styles.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />


</head>





<body class="skin-green">
    <form id="form1" runat="server">

        <div class="wrapper">
            <div class="cabecalho">
                <header class="main-header">
                    <!-- Logo -->
                    <a href="../Cliente/Listar.aspx" class="logo"><b>Grupo</b>Coppi</a>
                    <!-- Header Navbar: style can be found in header.less -->
                    <nav class="navbar navbar-static-top" role="navigation">
                        <!-- Sidebar toggle button-->
                        <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
                            <span class="sr-only">Toggle navigation</span>
                        </a>
                        <div class="pull-right">
                            <asp:LinkButton ID="lbSair" runat="server" CssClass="btn btn-danger" OnClick="lbSair_Click" CausesValidation="False">Sair</asp:LinkButton>
                        </div>
                    </nav>


                </header>
            </div>
            <!-- Left side column. contains the logo and sidebar -->
            <aside class="main-sidebar">
                <!-- sidebar: style can be found in sidebar.less -->
                <section class="sidebar">
                    <!-- Sidebar user panel -->
                    <div class="user-panel">

                        <div class="pull-left info">
                            <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
                            </br>
                            <a href="#"><i class="fa fa-circle text-success"></i>Online</a>
                        </div>
                    </div>
                    <!-- sidebar menu: : style can be found in sidebar.less -->
                    <ul class="sidebar-menu">
                        <li class="header">MENU</li>
                        <li class="active treeview">
                            <a href="#">
                                <i class="fa fa-dashboard"></i><span>Cadastros</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="<%= Page.ResolveUrl("../Cliente/Cadastrar.aspx") %>"><i class="fa fa-user-circle"></i>Cliente </a></li>
                                <li><a href="<%= Page.ResolveUrl("../Fornecedor/Cadastrar.aspx") %>"><i class="fa fa-industry"></i>Fornecedor</a></li>
                                <li><a href="<%= Page.ResolveUrl("../Funcionario/Cadastrar.aspx") %>"><i class="fa fa-id-card-o "></i>Funcionário</a></li>
                                <li><a href="<%= Page.ResolveUrl("../MateriaPrima/Cadastrar.aspx") %>"><i class="fa fa-cogs"></i>Matéria-Prima</a></li>
                                <li class="active"><a href="<%= Page.ResolveUrl("../NotaFiscal/CadastrarNf.aspx") %>"><i class="glyphicon glyphicon-duplicate"></i>Nota Fiscal</a></li>
                                <li><a href="<%= Page.ResolveUrl("../OrdemProducao/Cadastrar.aspx") %>"><i class="fa fa-book"></i>Ordem de Produção</a></li>

                            </ul>
                        </li>
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-table"></i><span>Listas</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li class="active"><a href="<%= Page.ResolveUrl("../Cliente/Listar.aspx") %>"><i class="fa fa-user-circle"></i>Cliente </a></li>
                                <li><a href="<%= Page.ResolveUrl("../Fornecedor/Listar.aspx") %>"><i class="fa fa-industry"></i>Fornecedor</a></li>
                                <li><a href="<%= Page.ResolveUrl("../Funcionario/Listar.aspx") %>"><i class="fa fa-id-card-o"></i>Funcionário</a></li>
                                <li><a href="<%= Page.ResolveUrl("../MateriaPrima/Listar.aspx") %>"><i class="fa fa-cogs"></i>Matéria-Prima</a></li>
                                <li><a href="<%= Page.ResolveUrl("../NotaFiscal/Listar.aspx") %>"><i class="glyphicon glyphicon-duplicate"></i>Nota Fiscal</a></li>
                                <li><a href="<%= Page.ResolveUrl("../OrdemProducao/ListarOPAberta.aspx") %>"><i class="fa fa-book"></i>Ordem de Produção</a></li>
                            </ul>
                        </li>

                           <li class="treeview">
                            <a href="#">
                                <i class="fa fa-table"></i><span>Relatório</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">

                                <li><a href="<%= Page.ResolveUrl("/Paginas/Relatorio/Listar.aspx") %>"><i class="fa fa-book"></i>Vendas</a></li>
                            </ul>
                        </li>


                    </ul>
                </section>
                <!-- /.sidebar -->
            </aside>

            <!-- Right side column. Contains the navbar and content of the page -->
            <div class="content-wrapper">
                <!-- Content Header (Page header) -->
                <!-- AQUI QUE COLOCA O CONTEÚDO -->
                <div class="container">
                    <div class="row main"></div>
                    <div class="main-login main-center">
                        <br />
                        <div id="tituloPagina" class="col-lg-12">
                            <asp:Label ID="lblCadastro" runat="server" CssClass="titulo" Text="Cadastro de Nota Fiscal"></asp:Label>
                        </div>
                        <br />
                       <div id="msgSucesso" class="small-box bg-green">
                            <asp:Label ID="lblMensagem" runat="server" CssClass="form"></asp:Label>
                        </div>
                        <br />
                        <div id="msgErro" class="small-box bg-red">
                            <asp:Label ID="lblMensagemErro" runat="server" CssClass="form"></asp:Label>
                            <asp:ValidationSummary ID="vsCadastro" runat="server" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblFornecedor" class="cols-sm-2 control-label" runat="server" AssociatedControlID="ddlFornecedor" Text="Fornecedor:"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlFornecedor"  class="form-control" runat="server" Width="40%">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>



                    <br />
                    <div class="form-group">
                        <asp:Label ID="lblNumero" runat="server" class="cols-sm-2 control-label" AssociatedControlID="txtNumero" Text="Número:"></asp:Label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-barcode" aria-hidden="true"></i></span>
                                <br />
                                <br />

                                <asp:TextBox ID="txtNumero" CssClass="txtFormatacao" class="tx form-control" Width="40%" ToolTip="Somente números" runat="server"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="rfvNumero" ControlToValidate="txtNumero" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o número da Nota Fiscal"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblDataEmissao" class="cols-sm-2 control-label" AssociatedControlID="txtDataEmissao" runat="server" Text="Data de Emissão:"></asp:Label>
                        <br />
                        <br />
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar" aria-hidden="true"></i></span>

                                <asp:TextBox ID="txtDataEmissao" CssClass="txtFormatacao" class="form-control" Width="40%" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvDataEmissao" ControlToValidate="txtDataEmissao" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha a data de emissão da Nota Fiscal"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblValorTotal" class="cols-sm-2 control-label" AssociatedControlID="txtValorTotal" runat="server" Text="Valor Total (R$):"></asp:Label>
                        <br />
                        <br />
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-shopping-cart" aria-hidden="true"></i></span>

                                <asp:TextBox ID="txtValorTotal" CssClass="txtFormatacao" class="form-control" Width="40%" runat="server"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="rfvValorTotal" ControlToValidate="txtValorTotal" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o valor total da Nota Fiscal"></asp:RequiredFieldValidator>
                                <br />
                                <br />
                                <br />
                            </div>

                        </div>
                    </div>



                    <asp:LinkButton ID="lbAdicionar" OnClick="lbAdicionar_Click" CssClass="btn btn-success" runat="server"><span  class="glyphicon glyphicon-floppy-disk" ></span> Adicionar</asp:LinkButton>
                    <br />
                    <br />
                    <%--   <asp:GridView ID="grvItem" runat="server" CssClass="tabela" AutoGenerateColumns="False" HeaderStyle-BackColor="Silver" HeaderStyle-BorderColor="Black" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderWidth="1 px" Width="90%">
                        <Columns>


                            <asp:BoundField DataField="inf_quantidade" HeaderText="Quantidade" />
                            <asp:BoundField DataField="inf_valorUnitario" HeaderText="Valor Unitário" />
                            <asp:BoundField DataField="inf_valorTotalUnitario" HeaderText="Valor Total" />

                        </Columns>
                    </asp:GridView>--%>
                    <br />

                    <br />
                    <asp:Literal ID="lblItens" runat="server"></asp:Literal>
                    <br />
                    <br />

                    <br />

             
                    <br />



                    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
                    <script src="http://cloud.github.com/downloads/digitalBush/jquery.maskedinput/jquery.maskedinput-1.3.min.js"></script>
                    <script src="../../Scripts/mascaraCadastroAlteracao.js"></script>
                </div>
            </div>


            <!-- jQuery 2.1.3 -->
            <script src="../../plugins/jQuery/jQuery-2.1.3.min.js"></script>
            <!-- jQuery UI 1.11.2 -->
            <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.min.js" type="text/javascript"></script>
            <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
            <script>
                $.widget.bridge('uibutton', $.ui.button);
    </script>
            <!-- Bootstrap 3.3.2 JS -->
            <script src="../../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
            <!-- Morris.js charts -->
            <script src="http://cdnjs.cloudflare.com/ajax/libs/raphael/2.1.0/raphael-min.js"></script>
            <script src="../../plugins/morris/morris.min.js" type="text/javascript"></script>
            <!-- Sparkline -->
            <script src="../../plugins/sparkline/jquery.sparkline.min.js" type="text/javascript"></script>
            <!-- jvectormap -->
            <script src="../../plugins/jvectormap/jquery-jvectormap-1.2.2.min.js" type="text/javascript"></script>
            <script src="../../plugins/jvectormap/jquery-jvectormap-world-mill-en.js" type="text/javascript"></script>
            <!-- jQuery Knob Chart -->
            <script src="../../plugins/knob/jquery.knob.js" type="text/javascript"></script>
            <!-- daterangepicker -->
            <script src="../../plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>
            <!-- datepicker -->
            <script src="../../plugins/datepicker/bootstrap-datepicker.js" type="text/javascript"></script>
            <!-- Bootstrap WYSIHTML5 -->
            <script src="../../plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>
            <!-- iCheck -->
            <script src="../../plugins/iCheck/icheck.min.js" type="text/javascript"></script>
            <!-- Slimscroll -->
            <script src="../../plugins/slimScroll/jquery.slimscroll.min.js" type="text/javascript"></script>
            <!-- FastClick -->
            <script src='../../plugins/fastclick/fastclick.min.js'></script>
            <!-- AdminLTE App -->
            <script src="../../dist/js/app.min.js" type="text/javascript"></script>

            <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
            <script src="../../dist/js/pages/dashboard.js" type="text/javascript"></script>

            <!-- AdminLTE for demo purposes -->
            <script src="../../dist/js/demo.js" type="text/javascript"></script>
            <script src="../../Scripts/jquery.maskedinput.js"></script>
            <script src="../../Scripts/jquery.dataTables.min.js"></script>
    </form>

</body>
</html>




