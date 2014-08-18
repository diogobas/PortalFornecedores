<%@ Page Title="Portal Fornecedores Duratex / Solicita Chave de Acesso" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmSolicitaChave.aspx.vb"
    Inherits="PortalFornecedores.frmSolicitaChave" %>

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
                <table width="450px" align="center">
                    <tr align="center">
                        <td class="box_chave" align="center">
                            <p class="titulo_box" align="left">
                                Solicitação de Chave de Acesso</p>
                            <table width="400px">
                                <tr>
                                    <td colspan=2>
                                        <p class="texto_box_justificado">
                                            Caso sua empresa já seja um fornecedor Duratex e deseja obter uma chave de acesso, preencha os dados abaixo.</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td width=110px>
                                        <p class="label_box" align="right">
                                            CNPJ:
                                        </p>
                                    </td>
                                    <td width="290px" align="left">
                                        <asp:TextBox ID="txtCNPJ" runat="server" Width="145px" class="txt_form" onkeyup="formataCNPJ(this,event);"
                                            MaxLength="18"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_box" align="right">
                                            Razão social:
                                        </p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRazaoSolcial" runat="server" Width="270px" class="txt_form"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_box" align="right">
                                            Nome:
                                        </p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtNome" runat="server" Width="270px" class="txt_form"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_box" align="right">
                                            Email:
                                        </p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="270px" class="txt_form"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btVoltar" runat="server" Text="Voltar" class="bt_enviar" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btSolicitaChave" runat="server" Text="Enviar" 
                                class="bt_enviar" />
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
