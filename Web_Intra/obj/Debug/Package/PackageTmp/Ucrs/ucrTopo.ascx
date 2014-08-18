<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucrTopo.ascx.vb" Inherits="PortalFornecedores_Intra.ucrTopo" %>
    

    <link href="../App_Themes/Default/banners.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/colorbox.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/estilos.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/Grid.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/fontes/estilos.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/historia.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/jquery/jquery-ui-1.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/menu.css" type="text/css" rel="stylesheet" />
    <% Dim objSchCAT As New ShL.schCAT
        Dim objCAT As New BLL.bllCAT%>
<div class="align">
    <div class="div_top">
        <a id="HyperLink1" href="http://portalfornecedores.intranet.duratex">
            <img id="Image1" class="logo" src="../App_Themes/Imagens/logo.png" style="width: 92px;
                height: 80px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px;
                border-left-width: 0px;" />
        </a>

        <% If Not Session("objCAT") Is Nothing Then
                objSchCAT = Session("objCAT")
                objCAT = New BLL.bllCAT
                
            End If%>

        <p class="label_user">
            <%=Session("sUsuario")%>
        </p>
    </div>
</div>

<div class="div_menu">
    <ul id="topnav">
        <li sizcache="0" sizset="0"><a href="Login.aspx">Início</a>
        </li>

        <li sizcache="0" sizset="0"><a style="margin-left: 38px;" href="frmCadastramento.aspx"> Cadastro</a> </li>

        <% If objSchCAT.bLogado AndAlso objCAT.ValidaPermissao(objSchCAT, "frmSolicitacoesCadastro", "A") Then%>
        <li sizcache="0" sizset="3"><a style="margin-left: 38px; padding-top: 5px; height: 40px;"
            href="frmSolicitacoesCadastro.aspx">Solicitações de <br /> Cadastro</a> </li>
        <% End If %>

        <% If objSchCAT.bLogado AndAlso objCAT.ValidaPermissao(objSchCAT, "frmSolicitacoesAlteracao", "A") Then%>
        <li sizcache="0" sizset="1"><a href="frmSolicitacoesAlteracao.aspx" style="margin-left: 38px; padding-top: 5px; height: 40px;">Alterações de <br /> Dados</a> 
        </li>
        <% End If %>

        <% If objSchCAT.bLogado AndAlso objCAT.ValidaPermissao(objSchCAT, "frmSolicitacoesChave", "A") Then%>
        <li sizcache="0" sizset="2"><a href="frmSolicitacoesChave.aspx" style="margin-left: 38px; padding-top: 5px; height: 40px;">Chave de <br /> Acesso</a>

        </li>
        <% End If %>
        <li sizcache="0" sizset="1"><a href="frmSair.aspx" style="margin-left: 38px;">Sair</a>

        </li>
    </ul>
</div>
