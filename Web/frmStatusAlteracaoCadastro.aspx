<%@ Page Title="Portal Fornecedores Duratex / Status Alteração de Cadastro" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmStatusAlteracaoCadastro.aspx.vb"
    Inherits="PortalFornecedores.frmStatusAlteracaoCadastro" %>

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
                        <td width="340px" align="right" valign="TOP" colspan="2">
                            <asp:Label ID="lblFornecedor" runat="server" Text="EMPRESA A" class="label_identificacao"></asp:Label>
                            <br />
                            <asp:Button ID="btnSair" runat="server" Text="(Sair)" class="bt_sair" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <table>
                                <tr>
                                    <td width="410px">
                                    </td>
                                    <td width="200px">
                                        <p class="label_form">
                                            Solicitação de Alteração em:
                                        </p>
                                    </td>
                                    <td width="110px">
                                        <asp:TextBox ID="txtDataSolicitacao" runat="server" class="txt_form_label" Width="100px"></asp:TextBox>
                                    </td>
                                    <td width="60px">
                                        <p class="label_form">
                                            Status:
                                        </p>
                                    </td>
                                    <td width="110px">
                                        <asp:TextBox ID="txtStatusSolicitacao" runat="server" class="txt_form_label" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_atualiza_endereco" colspan="5">
                            <table width="850px">
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Endereço:</p>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtEndereco" runat="server" Width="435px"></asp:TextBox>
                                    </td>
                                    <td width="36px" align="left">
                                        <p class="label_form" align="left">
                                            No.:</p>
                                    </td>
                                    <td width="86px" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtNumero" runat="server" Width="68px"></asp:TextBox>
                                    </td>
                                    <td width="57px" align="left">
                                        <p class="label_form" align="left">
                                            Compl.:</p>
                                    </td>
                                    <td width="88px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtComplemento" runat="server" Width="71px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Bairro:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtBairro" runat="server" Width="285px"></asp:TextBox>
                                    </td>
                                    <td width="55px" align="left">
                                        <p class="label_form" align="left">
                                            CEP:</p>
                                    </td>
                                    <td width="98px" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtCep" runat="server" Width="78px"></asp:TextBox>
                                    </td>
                                    <td colspan="2" align="left">
                                        <p class="label_form" align="left">
                                            Caixa Postal:</p>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtCaixaPostal" runat="server" Width="133px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Cidade:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtCidade" runat="server" Width="285px"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <p class="label_form" align="left">
                                            Estado:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtEstado" runat="server" Width="78px"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <p class="label_form" align="left">
                                            País:</p>
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtSiglaPais" runat="server" Width="27px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_dados_contato_empresa" colspan="5">
                            <table width="850px">
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Nome:</p>
                                    </td>
                                    <td width="315px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtNomeContato" runat="server" Width="304px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Sobrenome:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtSobrenomeContato" runat="server" Width="304px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Função:</p>
                                    </td>
                                    <td width="315px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtFuncaoContato" runat="server" Width="304px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Departamento:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtDepartamentoContato" runat="server" Width="304px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Telefone:</p>
                                    </td>
                                    <td width="275px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtTelefoneContato" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Fax:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtFaxContato" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Celular:</p>
                                    </td>
                                    <td width="315px" align="left" style="width: 157px" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtCelularContato" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Email:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtEmailContato" runat="server" Width="304px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <table width="850px">
                                <tr>
                                    <td align="right">
                                        <asp:Button class="bt_outros" ID="btVoltar" runat="server" Text="Voltar" />
                                    </td>
                                </tr>
                            </table>
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
