<%@ Page Title="Portal Fornecedores Duratex / Login" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmLoginFornecedor.aspx.vb"
    Inherits="PortalFornecedores.frmLoginFornecedor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <table width="440px" align=center>
                    <tr align="center">
                        <td class="box_home" align=center>
                            <p class="titulo_box" align=left>
                                Acesso a Fornecedores</p>
                                    <table width="400px">
                                        <tr>
                                            <td colspan=2>
                                                <p class="texto_box_justificado">
                                                    Se possui chave de acesso, informe os dados abaixo e tenha acesso a funcionalidades restritas
                                                    a fornecedores Duratex.</p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p class="label_box_livre" align="right">
                                                    CNPJ:
                                                    <asp:TextBox ID="txtCNPJ" runat="server" Width="150px" class="txt_form" onkeyup="formataCNPJ(this,event);"
                                                        MaxLength="18"></asp:TextBox>
                                                </p>
                                                <p class="label_box_livre" align="right">
                                                    Chave de Acesso:
                                                    <asp:TextBox ID="txtChaveAcesso" runat="server" Width="150px" class="txt_form"></asp:TextBox>
                                                </p>
                                                <p class="label_box_livre" align="right">
                                                    <a href="frmRecuperaChave.aspx">Esqueci minha chave de acesso</a>
                                                </p>
                                                <p class="label_box_livre" align="right">
                                                    <a href="frmSolicitaChave.aspx">Não possuo chave de acesso</a>
                                                </p>
                                            </td>
                                            <td width="100">
                                                <asp:Button ID="btAcessoFornecedores" runat="server" Text="Enviar" class="bt_enviar"
                                                    action="frmAreaRestrita.aspx" />
                                            </td>
                                        </tr>
                                    </table>
                        </td>
                    </tr>
                </table>
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
            <div class="content_bottom">
            </div>
        </div>
    </div>
</asp:Content>
