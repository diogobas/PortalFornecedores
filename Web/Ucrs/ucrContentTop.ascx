<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ucrContentTop.ascx.vb"
    Inherits="PortalFornecedores.ucrContentTop" %>

<div class="align_content">
<div class="div_ferramentas">
<ul class="menu_pg_internas">
<%  If Not Common.Configuracao.getManutencao() Then%>
    <li id="liSubMenu_001">
    <a id="MenuInterno_001" class="link_pg_internas" href="/Default.aspx" runat="server">Sobre a Ouvidoria</a>
    </li>
    <li id="liSubMenu_002">
    <a id="MenuInterno_002" class="link_pg_internas" href="/Contato.aspx" runat="server">Entre em contato</a>
    </li>
    <li id="liSubMenu_003">
    <a id="MenuInterno_003" class="link_pg_internas" href="/DuvidasFrequentes.aspx" runat="server">Dúvidas frequentes</a>
    </li>
    <li id="liSubMenu_004">
    <a id="MenuInterno_004" class="link_pg_internas" href="/CodigoEtica.aspx" runat="server">Código de Ética</a>
    </li>
    </ul>
    <br />
    <br />
<%End If%>

</div>
<div class="content_top top_Ferramentas">
<span id="strPaginaAtual" class="Titulo_Paginas"></span>
<div class="div_alinha_acessibilidade">
<a id="HyperLink1" class="link_menos"></a>
<a id="HyperLink2" class="link_mais"></a>
<a id="HyperLink3" class="link_print" href="javascript:(window.print());"></a>
</div>
</div>
</div>
