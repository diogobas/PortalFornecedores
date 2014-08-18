<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucrTopo.ascx.vb" Inherits="PortalFornecedores.ucrTopo" %>
    

    <link href="../App_Themes/Default/banners.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/colorbox.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/estilos.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/fontes/estilos.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/historia.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/jquery/jquery-ui-1.css" type="text/css" rel="stylesheet" />
    <link href="../App_Themes/Default/menu.css" type="text/css" rel="stylesheet" />

<!-- Piwik -->
<script type="text/javascript">
    var _paq = _paq || [];
    _paq.push(["trackPageView"]);
    _paq.push(["enableLinkTracking"]);

    (function () {
        var u = (("https:" == document.location.protocol) ? "https" : "http") + "://piwik.duratex.com.br/";
        _paq.push(["setTrackerUrl", u + "piwik.php"]);
        _paq.push(["setSiteId", "5"]);
        var d = document, g = d.createElement("script"), s = d.getElementsByTagName("script")[0]; g.type = "text/javascript";
        g.defer = true; g.async = true; g.src = u + "piwik.js"; s.parentNode.insertBefore(g, s);
    })();
</script>
<!-- End Piwik Code -->

<div class="align">
    <div class="div_top">
        <a id="HyperLink1" href="http://www.duratex.com.br">
            <img id="Image1" class="logo" src="../App_Themes/Imagens/logo.png" style="width: 92px;
                height: 80px; border-top-width: 0px; border-right-width: 0px; border-bottom-width: 0px;
                border-left-width: 0px;" />
        </a>

        <img id="Image2" runat=server class="logo" 
            src="~/App_Themes/Imagens/Portal.png" 
            style="border-width:0px; top:20px; left:570px" />
    </div>
</div>

<div class="div_menu">
    <ul id="topnav">
        <li sizcache="0" sizset="0"><a href="">Início</a>
        </li>

        <li sizcache="0" sizset="3"><a href="http://www.duratex.com.br/pt/Download/cdc.pdf"
            target="_blank">Código de Ética</a> </li>

        <li sizcache="0" sizset="2"><a href="http://www.duratex.com.br/ri/pt/Download/Politica_Compras_220512.pdf"
            target="_blank">Política de Compra</a> </li>

        <li sizcache="0" sizset="1"><a style="padding-top: 5px; height: 40px;" href="/gfd.aspx">
            Gestão de <br/> Fornecedores</a> </li>

        <li sizcache="0" sizset="5"><a href="http://ouvidoria.duratex.com.br" target="_blank">Ouvidoria</a>
        </li>


        <li sizcache="0" sizset="4"><a href="/frmAreaRestrita.aspx">Área Restrita</a>
        </li>
    </ul>
</div>
