<%@ Page Title="Portal de Fornecedores" Language="vb" AutoEventWireup="false" MasterPageFile="~/Page.Master"
    CodeBehind="Login.aspx.vb" Inherits="PortalFornecedores_Intra.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center">
                <table width="910px">
                    <tr class="box_titulo_internas">
                        <td colspan="5">
                            <p class="titulo_internas">
                                Bem Vindo!
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <img src="App_Themes/Imagens/img_fornecedor.jpg" alt="" style="position: relative;
                                            top: 15px; left: 0px;">
                                    </td>
                                    <td align="center" width="585px">
                                        <table width="450px">
                                            <tr>
                                                <td class="box_home_intra" align="left">
                                                    <table width="420px">
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <p class="titulo_box_home_intra">
                                                                    Solicitações de Cadastro</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle">
                                                                <p class="texto_box_home_intra">
                                                                    Quantidade Pendente:
                                                                <asp:Label ID="lblQtdSolicCadPendentes" runat="server" Text="0" Width="40px" class="label_sumario"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle">
                                                                <p class="texto_box_home_intra">
                                                                Quantidade Validada:&nbsp;&nbsp;
                                                                <asp:Label ID="lblQtdSolicCadValidadas" runat="server" Text="0" Width="40px" class="label_sumario"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="box_home_intra" align="left">
                                                    <table width="420px">
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <p class="titulo_box_home_intra">
                                                                    Solicitações de Alteração de Dados</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle">
                                                                <p class="texto_box_home_intra">
                                                                    Quantidade Pendente:
                                                                
                                                                <asp:Label ID="lblQtdSolicAltPendentes" runat="server" Text="0" Width="40px" class="label_sumario"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle">
                                                                <p class="texto_box_home_intra">
                                                                    Quantidade Validada:&nbsp;&nbsp;
                                                                <asp:Label ID="lblQtdSolicAltValidadas" runat="server" Text="0" Width="40px" class="label_sumario"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="box_home_intra" align="left">
                                                    <table width="420px">
                                                        <tr>
                                                            <td colspan="2">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <p class="titulo_box_home_intra">
                                                                    Solicitações de Chave de Acesso</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle">
                                                                <p class="texto_box_home_intra">
                                                                    Quantidade Pendente:
                                                                
                                                                <asp:Label ID="lblQtdSolicChavePendentes" runat="server" Text="0" Width="40px" class="label_sumario"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle">
                                                                <p class="texto_box_home_intra">
                                                                    Quantidade Validada:&nbsp;&nbsp;
                                                                <asp:Label ID="lblQtdSolicChaveValidadas" runat="server" Text="0" Width="40px" class="label_sumario"></asp:Label>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="message_popup">
                    <table height="160px" width="460px">
                        <tr>
                            <td colspan="3">
                                <div id="tit_message_popup">
                                    <p>
                                        Títuloo Título</p>
                                </div>
                                <div id="txt_message_popup">
                                    <p>
                                        Message</p>
                                </div>
                            </td>
                            <tr valign="bottom">
                                <td align="right" width="400px">
                                </td>
                                <td align="right">
                                    <asp:Button class="bt_outros" ID="btOK" runat="server" Text="Sim" Visible="True" />
                                </td>
                                <td>
                                    <asp:Button class="bt_outros" OnClientClick="javascript:fechaMessagePopUp(); return false;"
                                        ID="btFecharPopUp" runat="server" Text="Fechar" />
                                </td>
                            </tr>
                    </table>
                </div>
            </div>
            <div class="content_bottom">
            </div>
        </div>
    </div>
</asp:Content>
