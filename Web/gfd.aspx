<%@ Page Title="Portal Fornecedores Duratex / GFD" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="gfd.aspx.vb"
    Inherits="PortalFornecedores.gfd" %>

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
                                Gestão de Fornecedores Duratex
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="700px" align="center">
                                <tr>
                                    <td>
                                    <br/>
                                        <p class="texto_justificado">
                                            Alinhada à sua Missão, Visão e Valores, a Companhia manteve o foco em garantir que
                                            seus parceiros sejam qualificados e homologados quanto a práticas socioambientais,
                                            exposição a riscos, evolução tecnológica e responsabilidade com clientes, fornecedores
                                            e colaboradores.
                                        </p>
                                        <br />
                                        <p class="texto_justificado">
                                            A Duratex visando o relacionamento ainda mais sólido com seus fornecedores e a maior
                                            transparência na relação e nos processos de concorrência, criou o Programa de Gestão
                                            Fornecedores da Duratex (GFD), que busca assegurar uma postura de cooperação mútua
                                            e permite evoluir em projetos socioambientais para um futuro sustentável.
                                        </p>
                                        <br />
                                        <p class="texto_justificado">
                                            O programa em contínuo avanço tem também como premissa engajar seus fornecedores
                                            às boas práticas de mercado e facilitar a comunicação de seus parceiros com a Duratex.
                                            Em linha a este entendimento, foi implementada em 2012 a Ouvidoria para fornecedores
                                            e, em 2013, este Portal de Fornecedores.
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <table width="700px">
                                <tr>
                                    <td align="right">
                                    <br/>
                                        <asp:Button class="bt_outros"  ID="btVoltar" runat="server" Text="Voltar" />
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
