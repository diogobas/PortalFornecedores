<%@ Page Title="Portal - Acompanhamento da Solicitação de Cadastramento" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmDetalheSolicitacaoCadastramento_Intra.aspx.vb"
    Inherits="PortalFornecedores_Intra.frmDetalheSolicitacaoCadastramento_Intra" %>

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
                        <td width="400px">
                        </td>
                        <td width="130px">
                            <p class="label_form">
                                Data da Solicitação:
                            </p>
                            <td width="110px">
                                <asp:TextBox ID="txtDataSolicitacao" runat="server" class="txt_form_label" 
                                    Width="152px"></asp:TextBox>
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
                                    <td style="width:50px;">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblOperacao" runat="server" 
												Text="Operação:"></asp:Label></p>
									</td>
									<td align="left" >
										<asp:TextBox class="txt_form_label" ID="txtOperacao" runat="server" Width="251px" ReadOnly="True"></asp:TextBox>                                                 
									</td>
                                    <td style="width:50px;">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblCategoria" runat="server" 
												Text="Categoria Fornecedor:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtCategoria" runat="server" Width="394px" ReadOnly="True" Visible="False"></asp:TextBox>                                                
									</td>
                                </tr>
                                <tr>                                               
									<td style="width:50px;">
										<p class="label_form" align="left">
										   <asp:Label class="label_form" ID="lblEmpresa" runat="server" 
												Text="Empresa:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtEmpresa" runat="server" Width="251px" ReadOnly="True" Visible="False"></asp:TextBox>                                                
									</td>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblIndicacao" runat="server" 
												Text="Indicação:" Visible="False"></asp:Label></p>
									</td>
									<td align="left" colspan=4>
										<asp:TextBox class="txt_form_label" ID="txtIndicacao" runat="server" Width="394px" ReadOnly="True" Visible="False"></asp:TextBox>                                                
									</td>                                         
								</tr>
                                <tr>
									<td style="width:50px;" valign="top">
											<p class="label_form" align="left">
												<asp:Label class="label_form" ID="lblCodSap" runat="server" 
												Text="Código SAP:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">                                                
										<asp:TextBox class="txt_form_label" ID="txtCodSap" runat="server" Width="150px" MaxLength="70" Visible="False" ReadOnly="True"></asp:TextBox>
									</td> 
								</tr>
								<tr>
									<td style="width:50px;" >
											<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblFornecimento" runat="server" 
											Text="Fornecimento:" Visible="False" Width="86px"></asp:Label>
											</p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtFornecimento" runat="server" Width="251px" ReadOnly="True" Visible="False"></asp:TextBox>                                                  
									</td>  
								</tr>                                        
								<tr>
									<td style="width:50px;" valign="top">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblMotivo" runat="server" 
												Text="Motivo:" Visible="False"></asp:Label></p>
									</td>
									<td align="left" colspan=3>
										<asp:TextBox class="txt_form_label" ID="txtMotivo" runat="server" Width="742px"
											MaxLength="70" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>                                                                                      
								</tr>
                                <tr>
									<td style="width:50px;" >
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblTipoMaterial" runat="server" 
											Text="Tipo de Material:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtTipoMaterial" runat="server" 
                                            Width="251px" ReadOnly="True" Visible="False" TextMode="MultiLine"></asp:TextBox>                                                  
									</td>
									<td align="left">
										<p class="label_form" align="left" Width="20px">
											<asp:Label class="label_form" ID="lblServico" runat="server" 
											Text="Tipo de Serviço:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtTipoServico" runat="server" 
                                            Width="394px" ReadOnly="True" Visible="False" TextMode="MultiLine"></asp:TextBox>		                                        
									</td>
								</tr>    
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_dados_fornecedor" colspan="5">
                            <table width="850px">
                                <tr>
									<td width="100px">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblRazaoSocial" runat="server" 
												Text="Razão Social:" Visible="False" ReadOnly="True"></asp:Label></p>
									</td>
									<td colspan="9" align="left">
										<asp:TextBox class="txt_form_label" ID="txtRazaoSocial" runat="server" Width="765px" 
											MaxLength="70" Visible="False"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblNomeFantasia" runat="server" 
												Text="Nome Fantasia:" Visible="False"></asp:Label>                                                         
										</p>
									</td>
									<td colspan="9" align="left">
										<asp:TextBox class="txt_form_label" ID="txtNomeFantasia" runat="server" Width="768px" 
											MaxLength="70" Visible="False" ReadOnly="True"></asp:TextBox>                                                
									</td>
								</tr>    
								<tr>
									<td width="55px" align="left">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblCep" runat="server" 
												Text="CEP:" Visible="False"></asp:Label></p>
									</td>
									<td width="98px" align="left">
										<asp:TextBox class="txt_form_label" ID="txtCep" runat="server" Width="88px" 
											MaxLength="9" Visible="False" ReadOnly="True"></asp:TextBox>									
									</td>                                            
								</tr>
								<tr>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblEndereco" runat="server" 
												Text="Endereço:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtEndereco" runat="server" Width="285px" 
											MaxLength="60" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
									<td width="36px" align="left">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblNumero" runat="server" 
												Text="No.:" Visible="False"></asp:Label></p>
									</td>
									<td width="86px" align="left">
										<asp:TextBox class="txt_form_label" ID="txtNumero" runat="server" Width="68px" MaxLength="10" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
									<td width="157px" align="left">
										<p class="label_form">
											<asp:Label class="label_form" ID="lblComplemento" runat="server" 
												Text="Compl.:" Visible="False"></asp:Label></p>
									</td>
									<td width="88px" align="left">
										<asp:TextBox class="txt_form_label" ID="txtComplemento" runat="server" Width="161px" 
											MaxLength="10" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblBairro" runat="server" 
												Text="Bairro:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtBairro" runat="server" Width="285px" MaxLength="40" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>      
									<td align="left">
										<p class="label_form">
											<asp:Label class="label_form" ID="lblCaixaPostal" runat="server" 
												Text="Cx.Postal:" Visible="False"></asp:Label></p>
									</td>
									<td align="left"> 
										<asp:TextBox class="txt_form_label" ID="txtCaixaPostal" runat="server" Width="130px" 
											MaxLength="10" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>                                                                                  
								</tr>
								<tr>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblCidade" runat="server" 
												Text="Cidade:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtCidade" runat="server" Width="285px" MaxLength="40" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
									<td align="left">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblEstado" runat="server" 
												Text="Estado:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtEstado" runat="server" Visible="False" ReadOnly="True"></asp:TextBox>									
									</td>
									<td align="left">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblPais" runat="server" 
												Text="País:" Visible="False"></asp:Label></p>
									</td>
									<td colspan="2" align="left">
										<asp:TextBox class="txt_form_label" ID="txtSiglaPais" runat="server" Visible="False" 
                                            ReadOnly="True" Width="163px"></asp:TextBox>									
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
                                            <asp:Label class="label_form" ID="lblNome" runat="server" 
                                                        Text="Nome:" Visible="False"></asp:Label></p>
                                    </td>
                                    <td width="315px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtNomeContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblSobrenome" runat="server" 
                                                        Text="Sobrenome:" Visible="False"></asp:Label></p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtSobrenomeContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblFuncao" runat="server" 
                                                        Text="Função:" Visible="False"></asp:Label></p>
                                    </td>
                                    <td width="315px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtFuncaoContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblDepartamento" runat="server" 
                                                        Text="Departamento:" Visible="False"></asp:Label></p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtDepartamentoContato" runat="server" Width="304px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblTelefone" runat="server" 
                                                        Text="Telefone:" Visible="False"></asp:Label></p>
                                    </td>
                                    <td width="275px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtTelefoneContato" runat="server" Width="150px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblFax" runat="server" 
                                                        Text="Fax:" Visible="False"></asp:Label></p>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtFaxContato" runat="server" Width="150px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblCelular" runat="server" 
                                                        Text="Celular:" Visible="False"></asp:Label></p>
                                    </td>
                                    <td width="315px" align="left" style="width: 157px" colspan="2">
                                        <asp:TextBox class="txt_form_label" ID="txtCelularContato" runat="server" Width="150px"
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblEmail" runat="server" 
                                                        Text="Email:" Visible="False"></asp:Label></p>
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
                        <td width="100%" align="center" class="box_dados_iniciais" colspan="5">
							<table width="850px">
                                <tr>
                                    <td>
                                        <p align="left" >
                                            <asp:Label class="label_form" ID="lblCondPgmto" runat="server" 
                                                Text="Cond. Pagamento:"></asp:Label></p>
                                    </td>
                                    <td width="98px" align="left" colspan=5>                                                
                                        <asp:TextBox class="txt_form_label" ID="txtCondPgmto" runat="server" Width="732px" 
											MaxLength="70" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>   														
							    <tr>
									<td>
										<p align="left">
											<asp:Label class="label_form" ID="lblInss" runat="server" 
												Text="INSS(NIT-PIS-PASEP):" Visible="False"></asp:Label></p>
									</td>
									<td width="98px" align="left">                                        
										<asp:TextBox class="txt_form_label" ID="txtInss" runat="server" Width="149px" 
											MaxLength="11" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
									<td width="55px" align="left">
										<p style="width: 114px">
											<asp:Label class="label_form" ID="lblCbo" runat="server" 
												Text="Código CBO:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtCbo" runat="server" Width="138px" 
											MaxLength="9" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
									<td align="left">
										<p align="left" style="width: 126px">
											<asp:Label class="label_form" ID="lblSefip" runat="server" 
												Text="Cod. Categoria Trabalhador-SEFIP:" Visible="False"></asp:Label></p>
									</td>
									<td>        
										<asp:TextBox class="txt_form_label" ID="txtSefip" runat="server" Width="138px" 
                                            Visible="False" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
									</td>
								</tr>    
                                <tr>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblOptante" runat="server" 
												Text="Optante Simples:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtOptante" runat="server" Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblNumIdFisc" runat="server" 
												Text="N° Id Fiscal:" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtNumIdFisc" runat="server" MaxLength="60" 
											Visible="False" Width="150px" ReadOnly="True"></asp:TextBox>
									</td>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblInscricaoRural" runat="server" 
												Text="Nº de Inscrição (CEI / INSS):" Visible="False"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtInscricaoRural" runat="server" 
											MaxLength="60" Visible="False" Width="137px" ReadOnly="True"></asp:TextBox>
									</td>                                            
								</tr>
								<tr>
									<td width="100px">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblCPFCNPJ" runat="server" 
												Text="CPF:" Visible="False"></asp:Label></p>
									</td>
									<td align="left" width="165px">
										<asp:TextBox class="txt_form_label" ID="txtCPF" 
											runat="server" Width="150px" Visible="False" ReadOnly="True"></asp:TextBox>
										<asp:TextBox class="txt_form_label" ID="txtCNPJ" 
											runat="server" Width="150px" Visible="False" ReadOnly="True"></asp:TextBox>     
									</td>
									<td align="left">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblInscEstadual" runat="server" 
												Text="Insc. Estadual:" Visible="False"></asp:Label></p>
									</td>
									<td align="left" width="155px">
										<asp:TextBox class="txt_form_label" ID="txtInscEstadual" runat="server" Width="137px"
											Visible="False" ReadOnly="True"></asp:TextBox>
									</td>
									<td align="left">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblInscMunicipal" runat="server" 
												Text="Insc. Municipal:" Visible="False"></asp:Label></p>
									</td>
									<td>
										<asp:TextBox class="txt_form_label" ID="txtInscMunicipal" runat="server" Width="133px"
											 MaxLength="17" Visible="False" ReadOnly="True"></asp:TextBox>
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
											<asp:Label class="label_form" ID="lblNomeSolicitante" runat="server" 
												Text="Nome Solicitante:" Visible="true"></asp:Label></p>
									</td>
									<td width="315px" align="left">
										<asp:TextBox class="txt_form_label" ID="txtNomeSolicitante" runat="server" Width="304px" Visible="true" ReadOnly="True"></asp:TextBox>
									</td>
									<td width="100px">
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblTelefoneSolicitante" runat="server" 
												Text="Telefone:" Visible="true"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtTelefoneSolicitante" runat="server" Width="150px" Visible="true" ReadOnly="True"></asp:TextBox>
									</td>                                            
								</tr>                                        
								<tr>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblCentro" runat="server" 
												Text="Centro:" Visible="true"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtCentro" runat="server" Width="150px" Visible="true" ReadOnly="True"></asp:TextBox>                                                
									</td>
									<td>
										<p class="label_form" align="left">
											<asp:Label class="label_form" ID="lblArea" runat="server" 
												Text="Área:" Visible="true"></asp:Label></p>
									</td>
									<td align="left">
										<asp:TextBox class="txt_form_label" ID="txtArea" runat="server" Width="304px"
											MaxLength="35" Visible="true" ReadOnly="True"></asp:TextBox>
									</td>                                           
								</tr>  
                                <tr>
                                    <td style="width:50px;" valign="top">
                                        <p class="label_form" align="left">
                                            <asp:Label class="label_form" ID="lblObservacao" runat="server" 
                                                Text="Observação:"></asp:Label></p>
                                    </td>
                                    <td align="left" colspan=3>                                        
                                        <asp:TextBox class="txt_form_label" ID="txtObs" runat="server" Width="727px" Height="35px"
                                                    TextMode="MultiLine"></asp:TextBox>
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
