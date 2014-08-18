<%@ Page Title="Gestão de Fornecedores Duratex" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Page.Master" CodeBehind="frmSolicitacoesCadastro.aspx.vb" Inherits="PortalFornecedores_Intra.frmSolicitacoesCadastro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center">
                <table width="910px">
                    <tr class="box_titulo_internas">
                        <td>
                            <p class="titulo_internas">
                                Solicitações de Cadastro
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="900px" align="center">
                                <tr>
                                    <td>
                                        <table align="right">
                                            <tr>
                                                <td width="60px">
                                                    <p class="label_form" align="right">
                                                        Origem:</p>
                                                </td>
                                                <td width="110px">
                                                    <asp:DropDownList ID="ddlOrigem" class="cmb_form" runat="server" Width="100px" AutoPostBack="True">
                                                        <asp:ListItem Value="">(Todos)</asp:ListItem>
                                                        <asp:ListItem Value="I" Selected="True">Internos</asp:ListItem>
                                                        <asp:ListItem Value="E">Externos</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="70px">
                                                    <p class="label_form" align="right">
                                                        Operação:</p>
                                                </td>
                                                <td width="120px">
                                                    <asp:DropDownList ID="ddlOperacao" class="cmb_form"  runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="-1">(Todos)</asp:ListItem>
                                                        <asp:ListItem Value="1">INCLUSÃO</asp:ListItem>
                                                        <asp:ListItem Value="2">ALTERAÇÃO</asp:ListItem>
                                                        <asp:ListItem Value="3">BLOQUEIO</asp:ListItem>
                                                        <asp:ListItem Value="4">DESBLOQUEIO</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="85px">
                                                    <p class="label_form" align="left">
                                                        Data da Solicitação:</p>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="txt_form" ID="txtDataIni" runat="server" Width="80px" 
                                                        onkeyup="formataData(this,event);" MaxLength="10"></asp:TextBox>
                                                </td>
                                                <td width="20px">
                                                    <p class="label_form" align="center">
                                                        á</p>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="txt_form" ID="txtDataFim" runat="server" Width="80px" 
                                                        onkeyup="formataData(this,event);" MaxLength="10"></asp:TextBox>
                                                </td>
                                                <td width="70px">
                                                    <p class="label_form" align="right">
                                                        Status:</p>
                                                </td>
                                                <td width="110px">
                                                    <asp:DropDownList ID="cmbStatus" class="cmb_form" runat="server" Width="100px" AutoPostBack="True">
                                                        <asp:ListItem Value="-1">(Todos)</asp:ListItem>
                                                        <asp:ListItem Value="0" Selected="True">Pendente</asp:ListItem>
                                                        <asp:ListItem Value="1">Validado</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btBusca" class="bt_busca" runat="server" />
                                                </td>
                                                <td width="10px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr height="280">
                                    <td valign="top" style="padding-top: 10px">
                                        <asp:GridView ID="grdSolicitacoes" runat="server" AllowPaging="True" class="grid"
                                            AutoGenerateColumns="False" AllowSorting="True">
                                            <AlternatingRowStyle CssClass="grid_alternating" />
                                            <Columns>
                                                <asp:BoundField DataField="dc_operacao" HeaderText="Oper." >
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:ButtonField 
                                                    CommandName="Detalhar" DataTextField="nm_documento" HeaderText="Documento">
                                                    <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                </asp:ButtonField>
                                                <asp:BoundField HeaderText="Razão Social" DataField="no_razao_social">
                                                    <ItemStyle Width="300px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="dt_solicitacao" HeaderText="Data da Solicitação" 
                                                    DataFormatString="{0:dd/MM/yyyy}">
                                                    <ItemStyle Width="110px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Cidade" DataField="no_cidade" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle Width="150px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="Status" DataField="dc_status"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle Width="110px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cd_usuario_solicitacao" HeaderText="Solicitante" >
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:ButtonField ButtonType="Image" CommandName="Detalhar" 
                                                    DataTextField="nm_documento" 
                                                    ImageUrl="~/App_Themes/Imagens/bt_detalhe.png">
                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:ButtonField>
                                                <asp:BoundField DataField="id_solicitacao" HeaderText="id_solicitacao" >
                                                <ControlStyle CssClass="hiddencol" />
                                                <FooterStyle CssClass="hiddencol" />
                                                <HeaderStyle CssClass="hiddencol" />
                                                <ItemStyle CssClass="hiddencol" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle Wrap="True" />
                                            <HeaderStyle CssClass="grid_header" />
                                            <PagerSettings Mode="NextPreviousFirstLast" NextPageText="Próximo" PreviousPageText="Anterior" />
                                            <PagerStyle CssClass="grid_pager" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <table width="850px">
                                <tr>
                                    <td align=left>

                                        <asp:Label ID="lblQtdRegistros" runat="server" Text="Qtd. Registros:" class="label"></asp:Label>

                                    </td>
                                    <td align="right">
                                        <br />
                                        <asp:Button class="bt_outros" ID="btVoltar" runat="server" Text="Voltar" />
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
