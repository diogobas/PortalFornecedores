<%@ Page Title="Portal de Fornecedores" Language="vb" AutoEventWireup="false" MasterPageFile="~/Page.Master"
    CodeBehind="HomeAnonymous.aspx.vb" Inherits="PortalFornecedores_Intra.HomeAnonymous" %>

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
                              Inicio
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
                                    <td align="center" width="585px" vallign=top>
                                        <table width="480px">
                                            <tr>
                                                <td align="left">
                                                    <p class="texto_justificado">
                                                        <B style="font-size: 16px; ">Bem Vindo ao Portal de Fornecedores Duratex!</b>
                                                    </p>
                                                    <P>
                                                        </br></br>
                                                    </p>
                                                    <p class="texto_justificado" style="font-size: 14px">
                                                        Por meio deste, você poderá enviar suas solicitações de cadastramento, alteração,
                                                        bloqueio e desbloqueio de fornecedores à Central de Cadastros.
                                                    </p>
                                                    <p>
                                                        </br>
                                                    </p>
                                                    <p class="texto_justificado" style="font-size: 14px">
                                                        Para iniciar sua solicitação, basta clicar na guia “Cadastro”, na parte superior
                                                        da tela e preencher os campos necessários.
                                                    </p>
                                                    <p>
                                                        </br></br></br></br>
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
