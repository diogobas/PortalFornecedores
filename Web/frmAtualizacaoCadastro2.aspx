<%@ Page Title="Portal Fornecedores Duratex / Atualização de Cadastro II" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmAtualizacaoCadastro2.aspx.vb"
    Inherits="PortalFornecedores.frmAtualizacaoCadastro2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center">
                <div id="conteudo_pagina">
                    <p class="titulo_internas">
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
                                    <p class="sub_menu_selecionado">
                                        <a href="/frmAtualizacaoCadastro.aspx">Atualização de Endereço </a>
                                    </p>
                                </td>
                                <td width="200px" class="box_sub_menu">
                                    <p class="sub_menu">
                                        <a href="/frmCotacoesPedidos.aspx">Cotações / Pedidos </a>
                                    </p>
                                </td>
                                <td width="200px" class="box_sub_menu">
                                    <p class="sub_menu">
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
                                <td width="100%" align="center" class="box_materiais_servicos" colspan="4">
                                    <table width="850px">
                                        <tr>
                                            <td width="100px" valign="top">
                                                <p class="label_form" align="left">
                                                    Serviços:</p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtServicos" runat="server" Width="725px" Height="95px"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100px" valign="top">
                                                <p class="label_form" align="left">
                                                    Materiais:</p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtMateriais" runat="server" Width="725px" Height="95px"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <table width="850px">
                                        <tr>
                                            <td align="right">
                                                <asp:Button class="bt_outros" ID="btVoltar" runat="server" Text="&lt;&lt; Voltar" />
                                            </td>
                                            <td width="90px" align="right">
                                                <asp:Button class="bt_outros" ID="btSalvar" runat="server" Text="Salvar" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </div>
                <div id="message_popup">
                    <table height="160px" width="460px">
                        <tr>
                            <td>
                                <div id="tit_message_popup">
                                    <p>
                                        Título</p>
                                </div>
                                <div id="txt_message_popup">
                                    <p>
                                        Message</p>
                                </div>
                            </td>
                            <tr valign="bottom">
                                <td align="right">
                                    <asp:Button class="bt_outros" OnClientClick="javascript:fechaMessagePopUp(); return false;"
                                        ID="btFecharPopUp" runat="server" Text="Fechar" />
                                </td>
                            </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="content_bottom">
        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
