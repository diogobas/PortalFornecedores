<%@ Page Title="Portal - Acompanhamento da Solicitação de Cadastramento" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmDetalheSolicitacaoChaveAcesso.aspx.vb"
    Inherits="PortalFornecedores_Intra.frmDetalheSolicitacaoChaveAcesso" %>

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
                                Detalhe da Solicitação de Chave de Acesso
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="480px">
                        </td>
                        <td width="130px">
                            <p class="label_form">
                                Data da Solicitação:
                            </p>
                            <td width="110px">
                                <asp:TextBox ID="txtDataSolicitacao" runat="server" class="txt_form_label" Width="100px"></asp:TextBox>
                            </td>
                        <td width="60px">
                            <p class="label_form">
                                Status:
                            </p>
                            <td width="110px">
                                <asp:TextBox ID="txtStatusSolicitacao" runat="server" class="txt_form_label" Width="100px"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_chave" colspan="5">
                            <table width="550px" style="margin-top: 20px;">
                                <tr>
                                    <td width="120px">
                                        <p class="label_form" align="left">
                                            CNPJ:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtCNPJ" runat="server" Width="160px" ReadOnly="True">00.232.232/0001-00</asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Razão Social:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtRazaoSocial" runat="server" Width="375px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Nome:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtNomeSolicitante" runat="server" Width="375px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Email:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtEmailSolicitante" runat="server" Width="375px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <table width="600px">
                                <tr>
                                    <td width="560px">
                                    </td>
                                    <td align="right">
                                        <asp:Button class="bt_outros" ID="btVoltar" runat="server" Text="Voltar" />
                                    </td>
                                    <td align="right">
                                        <asp:Button class="bt_outros" ID="btValidar" runat="server" Text="Validar" />
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
                                        Título</p>
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
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
