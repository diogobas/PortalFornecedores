<%@ Page Title="Portal Fornecedores Duratex / Entradas X Pagamentos" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmEntradaPagamentos.aspx.vb"
    Inherits="PortalFornecedores.frmEntradaPagamentos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center">
                <table width="910px">
                    <tr class="box_titulo_internas">
                        <td colspan="4">
                            <p class="titulo_internas">
                                Área Restrita
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="200px" class="box_sub_menu">
                            <p class="sub_menu">
                                <a href="/frmAtualizacaoCadastro.aspx">Atualização de Endereço </a>
                            </p>
                        </td>
                        <td width="200px" class="box_sub_menu">
                            <p class="sub_menu">
                                <a href="/frmCotacoesPedidos.aspx">Cotações / Pedidos </a>
                            </p>
                        </td>
                        <td width="200px" class="box_sub_menu">
                            <p class="sub_menu_selecionado">
                                <a href="/frmEntradaPagamentos.aspx">Entregas / Pagamentos </a>
                            </p>
                        </td>
                        <td width="340px" align="right" valign="TOP">
                            <asp:Label ID="lblFornecedor" runat="server" Text="EMPRESA A" class="label_identificacao"></asp:Label>
                            <br />
                            <asp:Button ID="btnSair" runat="server" Text="(Sair)" class="bt_sair" />
                        </td>
                    </tr>
                    <tr>
                        <td class="box_area_restrita" colspan="4">
                            <p>
                                Esta funcionalidade está em desenvolvimento e será disponibilizada em breve.
                            </p>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="content_bottom">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
