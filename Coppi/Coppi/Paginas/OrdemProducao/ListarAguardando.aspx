<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarAguardando.aspx.cs" Inherits="Paginas_OrdemProducao_ListarAguardando" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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

    <script type="text/javascript">

var tempo = new Number();

// Tempo em segundos

tempo = 1800;

function startCountdown(){
    // Se o tempo não for zerado
    if((tempo - 1) >= 0){
   // Pega a parte inteira dos minutos
        var min = parseInt(tempo/60);
        // Calcula os segundos restantes
        var seg = tempo%60;
        // Formata o número menor que dez, ex: 08, 07, ...
        if(min < 10){
            min = "0"+min;
            min = min.substr(0, 2);
        }
        if(seg <=9){
            seg = "0"+seg;
        }
        // Cria a variável para formatar no estilo hora/cronômetro
        horaImprimivel = '00:' + min + ':' + seg;
        //JQuery pra setar o valor
        $("#Sessao").html(horaImprimivel);
       // Define que a função será executada novamente em 1000ms = 1 segundo
        setTimeout('startCountdown()',1000);
        // diminui o tempo
        tempo--;
    // Quando o contador chegar a zero faz esta ação
    } 
        // mudar quando chegar a 0, pra avisar que a mesa já está quente]
        if (tempo <= 01) {
            $("#sessao").html("Mesa pronta para a vulcanização");
        }
       
         //window.open('../controllers/logout.php', '_self');
    }

// Chama a função ao carregar a tela
        // Colocar quando clicar no botão iniciar 
//startCountdown();
</script>

     <style>
      .example-modal .modal {
        position: relative;
        top: auto;
        bottom: auto;
        right: auto;
        left: auto;
        display: block;
        z-index: 1;
      }
      .example-modal .modal {
        background: transparent!important;
      }
    </style>
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

    <div>
     
      <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
        <br />
        <br />
       
        <asp:GridView ID="grvOPAberta" runat="server" CssClass="tabela" AutoGenerateColumns="False" Width="90%" CellPadding="4" GridLines="Vertical" BackColor="White" BorderColor="#336666" BorderStyle="None" BorderWidth="13px" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="pes_nomeFantasia" HeaderText="Cliente" />
                 <asp:BoundField DataField="ord_dataEntrada" HeaderText="Data de Entrada" />
                 <asp:BoundField DataField="ord_previsaoEntrega" HeaderText="Previsão de Entrega" />
               <asp:BoundField DataField="tap_largura" HeaderText="Largura (m)" />
                 <asp:BoundField DataField="tap_comprimento" HeaderText="Comprimento (m)" />
                  <asp:BoundField DataField="sta_descricao" HeaderText="Status" />
                  
               
                
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
      <asp:HyperLink ID="hlFechada" CssClass="btn btn-info" runat="server" NavigateUrl="~/Paginas/OrdemProducao/ListarOPFechada.aspx">Lista de OP Fechada</asp:HyperLink>
        <br />
        <br />
        <br />
        <div class="example-modal">
            <div class="modal modal-success">
              <div class="modal-dialog">
                <div class="modal-content">
                  <div class="modal-header">
                   
                    <h4 class="modal-title">Mesa de Vulcanização!!</h4>
                  </div>
                  <div id="Sessao" class="modal-body">
                    <p>Você está economizando pelo menos 8.800watts/hora &hellip;</p>
                  </div>
                  <div class="modal-footer">
                    
                    <button type="button" class="btn btn-outline" Onclick="startCountdown(); return false">Iniciar Aquecimento</button>
                  </div>
                </div><!-- /.modal-content -->
              </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->
          </div><!-- /.example-modal -->
       
              <div id="msgSucesso" class="small-box bg-green-gradient alert-success">
        <asp:Label ID="lblAviso" runat="server" Text=""></asp:Label> 
                  <div id="sessao">

                  </div>
             </div>
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


