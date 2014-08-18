<%@ Page Title="Portal - Acompanhamento da Solicitação de Cadastramento" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmDetalheSolicitacaoCadastramento.aspx.vb"
    Inherits="PortalFornecedores_Intra.frmDetalheSolicitacaoCadastramento" %>

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
                                Detalhe da Solicitação de Cadastramento
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
                        <td width="100%" align="center" class="box_dados_empresa" colspan="5">
                            <table width="850px">
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Razão Social:</p>
                                    </td>
                                    <td colspan="9" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtRazaoSocial" runat="server" Width="725px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Nome Fantasia:</p>
                                    </td>
                                    <td colspan="9" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtNomeFantazia" runat="server" Width="725px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            CNPJ:</p>
                                    </td>
                                    <td align="left" width="160px">
                                        <asp:TextBox class="txt_form_label" ID="txtCNPJ" runat="server" Width="145px" ReadOnly="True">00.232.232/0001-00</asp:TextBox>
                                    </td>
                                    <td width="130px" align="left">
                                        <p class="label_form" align="left">
                                            Inscrição Estadual:</p>
                                    </td>
                                    <td align="left" width="155px" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtInscEstadual" runat="server" Width="137px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="130px" align="left" colspan="2">
                                        <p class="label_form" align="left">
                                            Inscrição Municipal:</p>
                                    </td>
                                    <td align="left" width="150px" colspan="3">
                                        <asp:TextBox class="txt_form_label" ID="txtInscMunicipal" runat="server" Width="133px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Endereço:</p>
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtEndereco" runat="server" Width="435px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="36px" align="left">
                                        <p class="label_form" align="left">
                                            No.:</p>
                                    </td>
                                    <td width="86px" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtNumero" runat="server" Width="68px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="57px" align="left">
                                        <p class="label_form" align="left">
                                            Compl.:</p>
                                    </td>
                                    <td width="88px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtComplemento" runat="server" Width="71px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Bairro:</p>
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtBairro" runat="server" Width="285px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="55px" align="left">
                                        <p class="label_form" align="left">
                                            CEP:</p>
                                    </td>
                                    <td width="98px" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtCep" runat="server" Width="78px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td colspan="2" align="left">
                                        <p class="label_form" align="left">
                                            Caixa Postal:</p>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtCaixaPostal" runat="server" Width="133px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Cidade:</p>
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtCidade" runat="server" Width="285px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <p class="label_form" align="left">
                                            Estado:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtEstado" runat="server" Width="78px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <p class="label_form" align="left">
                                            País:</p>
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtSiglaPais" runat="server" Width="27px"
                                            ReadOnly="True"></asp:TextBox>
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
                                        <asp:TextBox class="txt_form_label" ID="txtNomeContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Sobrenome:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtSobrenomeContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Função:</p>
                                    </td>
                                    <td width="315px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtFuncaoContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Departamento:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtDepartamentoContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Telefone:</p>
                                    </td>
                                    <td width="275px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtTelefoneContato" runat="server" Width="150px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Fax:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtFaxContato" runat="server" Width="150px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Celular:</p>
                                    </td>
                                    <td width="315px" align="left" style="width: 157px" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtCelularContato" runat="server" Width="150px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Email:</p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtEmailContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_como_conheceu" colspan="5">
                            <table width="850px">
                                <tr>
                                    <td width="250px">
                                        <p class="label_form" align="left">
                                            Como Conheceu a Duratex:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtComoConheceu" runat="server" Width="350px"
                                            MaxLength="70"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="250px" align="left">
                                        <asp:Label class="label_form" ID="lblNomeContato" runat="server" Text="Indique o nome completo do contato:"
                                            Visible="False"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtContato" runat="server" Width="350px"
                                            MaxLength="70"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_materiais_servicos" colspan="5">
                            <table width="850px">
                                <tr>
                                    <td width="100px" valign="top">
                                        <p class="label_form" align="left">
                                            Serviços:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtServicos" runat="server" Width="725px"
                                            Height="95px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px" valign="top">
                                        <p class="label_form" align="left">
                                            Materiais:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form_label" ID="txtMateriais" runat="server" Width="725px"
                                            Height="95px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <table width="850px">
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
