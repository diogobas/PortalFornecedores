<%@ Page Title="Portal Fornecedores Duratex / Fomulário de Cadastro II" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmCadastramento2.aspx.vb"
    Inherits="PortalFornecedores.frmCadastramento2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center">
                <div id="conteudo_pagina">
                    <table width="910px">
                        <tr class="box_titulo_internas">
                            <td>
                                <p class="titulo_internas">
                                    Cadastramento
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" class="box_como_conheceu">
                                <table width="850px">
                                    <tr>
                                        <td width="250px">
                                            <p class="label_form" align="left">
                                                Como Conheceu a Duratex:</p>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList clas="txt_form" Width="350px" ID="cmbComoConheceu" 
                                                runat="server" AutoPostBack="True">
                                                <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                <asp:ListItem Value="1">Sites de busca</asp:ListItem>
                                                <asp:ListItem Value="2">Redes sociais</asp:ListItem>
                                                <asp:ListItem Value="3">Blogs</asp:ListItem>
                                                <asp:ListItem Value="4">Jornais</asp:ListItem>
                                                <asp:ListItem Value="5">Revistas</asp:ListItem>
                                                <asp:ListItem Value="6">Banners</asp:ListItem>
                                                <asp:ListItem Value="7">Seus concorrentes</asp:ListItem>
                                                <asp:ListItem Value="8">Indicação de amigos</asp:ListItem>
                                                <asp:ListItem Value="9">Nossos profissionais</asp:ListItem>
                                                <asp:ListItem Value="10">Feiras e Eventos</asp:ListItem>
                                                <asp:ListItem Value="11">Lojas especializadas</asp:ListItem>
                                                <asp:ListItem Value="12">Outros</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="250px" align="left">
                                            <asp:Label class="label_form" ID="lblNomeContato" runat="server" 
                                                Text="Indique o nome completo do contato:" Visible="False"></asp:Label>
                                        </td>
                                        <td align="left">
                                              <asp:TextBox class="txt_form" ID="txtNomeContato" runat="server" Width="350px" 
                                                  MaxLength="70" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" class="box_materiais_servicos">
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
                            <td align="center">
                                <table width="850px">
                                    <tr>
                                        <td align="right">
                                            <asp:Button class="bt_outros" ID="btVoltar" runat="server" Text="&lt;&lt; Voltar" />
                                        </td>
                                        <td width="90px" align="right">
                                            <asp:Button class="bt_outros" ID="btFinalizar" runat="server" Text="Finalizar" />
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
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
