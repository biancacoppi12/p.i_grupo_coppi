﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Alterar.aspx.cs" Inherits="Paginas_Cliente_Alterar" %>

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
       <link href="../../Content/styles.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>

    <link href="../../Content/font-awesome.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />

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
    <script src="../../Scripts/mascaraCadastroAlteracao.js"></script>
     <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-3.2.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <script src="../../Scripts/mascaraCadastroAlteracao.js"></script>
    <link href="../../Content/styles.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
        <script src="../../Scripts/cepAutomatico.js"></script>

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
                        <li class="treeview">
                            <a href="#">
                                <i class="fa fa-dashboard"></i><span>Cadastros</span>
                                <i class="fa fa-angle-left pull-right"></i>
                            </a>
                            <ul class="treeview-menu">
                                <li><a href="<%= Page.ResolveUrl("../Cliente/Cadastrar.aspx") %>"><i class="fa fa-user-circle"></i>Cliente </a></li>
                                <li><a href="<%= Page.ResolveUrl("../Fornecedor/Cadastrar.aspx") %>"><i class="fa fa-industry"></i>Fornecedor</a></li>
                                <li><a href="<%= Page.ResolveUrl("../Funcionario/Cadastrar.aspx") %>"><i class="fa fa-id-card-o "></i>Funcionário</a></li>
                                <li><a href="<%= Page.ResolveUrl("../MateriaPrima/Cadastrar.aspx") %>"><i class="fa fa-cogs"></i>Matéria-Prima</a></li>
                                    <li><a href="<%= Page.ResolveUrl("../NotaFiscal/Cadastrar.aspx") %>"><i class="glyphicon glyphicon-duplicate"></i>Nota Fiscal</a></li>
                                  <li><a href="<%= Page.ResolveUrl("../OrdemProducao/Cadastrar.aspx") %>"><i class="fa fa-book"></i>Ordem de Produção</a></li>

                            </ul>
                        </li>
                        <li class="active treeview">
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
                <asp:Label ID="lblAlteracao" runat="server" Text="Alteração de Cliente"></asp:Label>
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

            <div class="form-group">
                <asp:Label ID="lblNome" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtNome" Text="Nome Fantasia:"></asp:Label>
                <br />
                <div class="cols-sm-10">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-user" aria-hidden="true"></i></span>
                        <asp:TextBox ID="txtNome"  class="form-control" runat="server" placeholder="Nome da Empresa" runat="server" Width="40%"></asp:TextBox>
                        <br />
                        <br />
                    </div>
                </div>

            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCnpj" runat="server" class="cols-sm-2 control-label" AssociatedControlID="txtCnpj" Text="CNPJ:"></asp:Label>
            <br />
            <div class="cols-sm-10">

                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-edit" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtCnpj" CssClass="CnpjMascara" class="form-control" runat="server" Enabled="False" Width="40%"></asp:TextBox>
                    <br />
                    <br />

                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblRazao" runat="server" class="cols-sm-2 control-label" AssociatedControlID="txtRazao" Text="Razão Social:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-edit" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtRazao" class="form-control" runat="server" Enabled="False" Width="40%"></asp:TextBox>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblInscricao" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtInscricao" Text="Inscrição Estadual:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-edit" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtInscricao" class="form-control" runat="server" Enabled="False" Width="40%"></asp:TextBox>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblData" runat="server" class="cols-sm-2 control-label" AssociatedControlID="txtData" CssClass="form" Text="Data de Cadastro:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-calendar" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtData" runat="server" class="form-control" Enabled="False" CssClass="form"></asp:TextBox>
                    <br />
                    <br />
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="lblTelefone" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtTelefone" Text="Telefone:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-earphone" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtTelefone" CssClass="TelefoneMascara" class="form-control" runat="server" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTelefone" ControlToValidate="txtTelefone" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o número de Telefone"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCelular" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtCelular" Text="Celular:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-phone" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtCelular" CssClass="CelularMascara" class="form-control" runat="server" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCelular" runat="server" ErrorMessage="Preencha o número do Celular" ControlToValidate="txtCelular" Text="<b>*</b>" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEmail" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtEmail" Text="Email:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtEmail"  class="form-control" runat="server" placeholder="Email" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o Email"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCep" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtCep" Text="Cep:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-globe" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtCep" CssClass="CepMascara" class="form-control" runat="server" ToolTip="Somente números" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCep" ControlToValidate="txtCep" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o Cep apenas com números"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
      
        <div class="form-group">
            <asp:Label ID="lblLogradouro" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtLogradouro" Text="Logradouro:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-road" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtLogradouro"  class="form-control" runat="server" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLogradouro" ControlToValidate="txtLogradouro" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o Logradouro"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
     
        <div class="form-group">
            <asp:Label ID="lblBairro" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtBairro" Text="Bairro:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-pencil" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtBairro"  class="form-control" runat="server" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvBairro" ControlToValidate="txtBairro" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o Bairro"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCidade" class="cols-sm-2 control-label" runat="server" AssociatedControlID="txtCidade" Text="Cidade:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-home" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtCidade"  class="form-control" runat="server" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCidade" ControlToValidate="txtCidade" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha a Cidade"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="lblEstado" runat="server" class="cols-sm-2 control-label" AssociatedControlID="txtEstado" Text="Estado:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-home" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtEstado"  class="form-control" runat="server" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEstado" ControlToValidate="txtEstado" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o Estado"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
           <div class="form-group">
            <asp:Label ID="lblNumero" runat="server" class="cols-sm-2 control-label" AssociatedControlID="txtNumero" Text="Número:"></asp:Label>
            <br />
            <div class="cols-sm-10">
                <div class="input-group">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-option-horizontal" aria-hidden="true"></i></span>
                    <asp:TextBox ID="txtNumero"  class="form-control" runat="server" Width="40%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNumero" ControlToValidate="txtNumero" SetFocusOnError="True" Text="<b>*</b>" runat="server" ErrorMessage="Preencha o número"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <asp:LinkButton ID="lbSalvar" OnClick="lbSalvar_Click" CssClass="btn btn-success" runat="server"><span  class="glyphicon glyphicon-floppy-disk" ></span> Alterar</asp:LinkButton>
         <br />
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


