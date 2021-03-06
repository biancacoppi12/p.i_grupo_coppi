﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Paginas_Cliente_Listar" %>

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
                                    <li><a href="<%= Page.ResolveUrl("../NotaFiscal/CadastrarNf.aspx") %>"><i class="glyphicon glyphicon-duplicate"></i>Nota Fiscal</a></li>
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
                 <div style="height: 286px">
        <br />
        <div id="tituloPagina" class="col-lg-12">
            <asp:Label ID="lblAlteracao" runat="server" CssClass="titulo" Text="Lista de Clientes"></asp:Label>
        </div>
        <br />
        <br />
        <br />
        <div class="mensagem">
        <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
        </div>
            <br />
        <br />
        <asp:GridView ID="grvClientes" runat="server" AutoGenerateColumns="False" CssClass="tabela" OnRowCommand="grvClientes_RowCommand" Width="90%" CellPadding="4" GridLines="Vertical" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="13px" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="pes_nomeFantasia" HeaderText="Nome Fantasia" />
                <asp:BoundField DataField="pes_razaoSocial" HeaderText="Razão Social" />
                <asp:BoundField DataField="pes_Cnpj" HeaderText="CNPJ" />
                <asp:BoundField DataField="pes_telefone" HeaderText="Telefone" />
                <asp:BoundField DataField="pes_email" HeaderText="Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbAlterar" runat="server" CommandName="Alterar"
                            CommandArgument='<%# Bind("pes_id")%>'>Alterar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
           
            
            <FooterStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#edf7ed" ForeColor="#000000" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="#000000" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
           
            
        </asp:GridView>
        <br />
    </div>

    <script src="../../Scripts/jquery-1.12.4.js"></script>
    <script src="../../Scripts/jquery.dataTables.min.js"></script>

    <script>
        $(document).ready(function () {
            $('.tabela').DataTable({
                "oLanguage": {
                    "sProcessing": "Processando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "Nao foi encontrado nenhum resultado",
                    "sInfo": "Mostrando de _START_  até _END_ de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando de 0 até 0 de 0 registro",
                    "sInfoFiltered": "",
                    "sInfoPostFix": "",
                    "surl": "",
                    "sSearch": "Buscar",
                  
                    "oPaginate": {
                        "sFirst": "Primeiro",
                        "sPrevious": "Anterior",

                        "sNext": "Próximo",
                        "sLast": "Último"
                    }
                }
                })
        });
    </script>

        


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



    
