<%@ Page Title="Portal Fornecedores Duratex / Início" Language="vb" AutoEventWireup="false" MasterPageFile="~/Page.Master"
    CodeBehind="Default.aspx.vb" Inherits="PortalFornecedores._Default1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center">
                <table width="910px">
                    <tr>
                        <td class="box_home_1" width="50%">
                            <p class="titulo_box_home">
                                <a href="./frmSobreDuratex.aspx">Sobre a Duratex</a>
                                <p>
                            <p class="texto_box_home_justificado">
                                A Duratex é uma empresa brasileira que atende há mais de seis décadas os mercados
                                de construção civil e moveleiro. Por meio das marcas Deca, Hydra, Durafloor e Duratex,
                                a Companhia produz metais e louças sanitárias, pisos laminados, painéis de partículas
                                de média densidade (MDP), painéis de média e alta densidade (MDF e HDF) e chapas
                                de fibra.</p>
                            <br>
                            <p class="texto_box_home_justificado">
                                <a href="./frmSobreDuratex.aspx">Clique para saber mais. </a>
                            </p>
                        </td>
                        <td class="box_home_2" width="50%">
                            <p class="titulo_box_home">
                                <a href="./gfd.aspx">Gestão de Fornecedores Duratex<p>
                                </a>
                                <p class="texto_box_home_justificado">
                                    Programa de Gestão de Fornecedores da Duratex tem como premissa
                                        que seus parceiros sejam qualificados e homologados quanto a práticas socioambientais,
                                        exposição a riscos, evolução tecnológica e responsabilidade com clientes, fornecedores
                                        e colaboradores.
                                </p>
                            <br>
                            <p class="texto_box_home_justificado">
                                <a href="./gfd.aspx">Clique para saber mais. </a>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="box_home_3" width="50%">
                            <p class="titulo_box_home">
                                Cadastramento<p>
                            <p class="texto_box_home_justificado">
                                Se você ainda não é um fornecedor DURATEX cadastre sua empresa agora mesmo.</p>
                            <br/> <br/>
                            <p class="texto_box_home" align="right">
                                CNPJ:
                                <asp:TextBox ID="txtCNPJCadastramento" runat="server" onkeyup="formataCNPJ(this,event);" 
                                    Width="163px" class="txt_form" MaxLength="18"></asp:TextBox>
                            </p>
                            <p class="texto_box_home" align="right">
                                <asp:Button ID="btEnviarCadastramento" runat="server" Text="Enviar" class="bt_enviar" />
                            </p>
                        </td>
                        <td class="box_home_4" width="50%">
                            <p class="titulo_box_home">
                                Acesso a Fornecedores<p>
                            <p class="texto_box_home_justificado">
                                Se possui chave de acesso, informe os dados abaixo e tenha acesso a funcionalidades restritas
                                a fornecedores Duratex.</p>
                            <table>
                                <tr>
                                    <td width="400">
                                        <p class="texto_box_home" align="right">
                                            CNPJ:
                                            <asp:TextBox ID="txtCNPJ" runat="server" Width="150px" class="txt_form" 
                                                onkeyup="formataCNPJ(this,event);" MaxLength="18"></asp:TextBox>
                                        </p>
                                        <p class="texto_box_home" align="right">
                                            Chave de Acesso:
                                            <asp:TextBox ID="txtChaveAcesso" runat="server" Width="150px" class="txt_form"></asp:TextBox>
                                        </p>
                                        <p class="texto_box_home" align="right">
                                            <a href="frmRecuperaChave.aspx">Esqueci minha chave de acesso</a>
                                        </p>
                                        <p class="texto_box_home" align="right">
                                            <a href="frmSolicitaChave.aspx">Não possuo chave de acesso</a>
                                        </p>
                                    </td>
                                    <td width="110">
                                        <asp:Button ID="btAcessoFornecedores" runat="server" Text="Enviar" class="bt_enviar"
                                            action="frmCadastramento.aspx" />
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
