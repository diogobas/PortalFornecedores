<%@ Page Title="Gestão de Fornecedores Duratex" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Page.Master" CodeBehind="frmCadastramento.aspx.vb" Inherits="PortalFornecedores_Intra.frmCadastramento" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="align" style="top: -20px;">
        <div class="align_content" sizcache="3" sizset="0">
            <div class="content_top">
            </div>
            <div class="content_center" style="overflow:hidden;">
                <table width="910px">
                    <tr class="box_titulo_internas">
                        <td>
                            <p class="titulo_internas">
                                Solicitação de Cadastro de Fornecedor
                            </p>
                        </td>
                    </tr>
                    
                    <tr>
                        <td width="100%" align="center" class="box_dados_empresa">
                            <asp:UpdatePanel id="pnlContatos" runat="server" UpdateMode="Conditional" >         
                                <ContentTemplate>
                                    <table width="850px">
                                        <tr>
                                            <td style="width:50px;">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblOperacao" runat="server" 
                                                        Text="Operação*:"></asp:Label></p>
                                            </td>
                                            <td align="left" >
                                                <asp:DropDownList class="cmb_form" ID="ddlOperacao" runat="server" AutoPostBack="True"
                                                    Width="251px">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                    <asp:ListItem Value="1">INCLUSÃO</asp:ListItem>
                                                    <asp:ListItem Value="2">ALTERAÇÃO</asp:ListItem>
                                                    <asp:ListItem Value="3">BLOQUEIO</asp:ListItem>
                                                    <asp:ListItem Value="4">DESBLOQUEIO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width:50px;">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblCategoria" runat="server" 
                                                        Text="Categoria Fornecedor:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlCategoria" class="cmb_form" runat="server" Visible="False"
                                                    AutoPostBack="True" Width="394px">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                    <asp:ListItem Value="1">GOVERNO </asp:ListItem>
                                                    <asp:ListItem Value="2">NACIONAL PESSOA JURIDICA</asp:ListItem>
                                                    <asp:ListItem Value="3">NACIONAL PESSOA FISICA</asp:ListItem>
                                                    <asp:ListItem Value="4">PRODUTOR RURAL</asp:ListItem>
                                                    <asp:ListItem Value="5">INTERNACIONAL</asp:ListItem>
                                                    <asp:ListItem Value="6">INTERCOMPANY</asp:ListItem>
                                                    <asp:ListItem Value="7">ESPECIAIS/PROCESSO TRABALHISTA</asp:ListItem>
                                                    <asp:ListItem Value="8">PENSIONISTAS - RH</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>                                               
                                            <td style="width:50px;">
                                                <p class="label_form" align="left">
                                                   <asp:Label class="label_form" ID="lblEmpresa" runat="server" 
                                                        Text="Empresa:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlEmpresa" class="cmb_form" runat="server" Visible="False"
                                                    Width="251px">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                    <asp:ListItem Value="1">1DX - Duratex S.A. </asp:ListItem>
                                                    <asp:ListItem Value="2">1DF - Duraflora S.A.</asp:ListItem>
                                                    <asp:ListItem Value="3">1EX - Duratex Coml Export. S.A.</asp:ListItem>
                                                    <asp:ListItem Value="4">1JM - Jacarandá Minoso Part Ltd</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblIndicacao" runat="server" 
                                                        Text="Indicação:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left" colspan=4>
                                                <asp:DropDownList ID="ddlIndicacao" class="cmb_form" runat="server" Visible="False"
                                                    Width="394px">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                    <asp:ListItem Value="1">Fornecedor</asp:ListItem>
                                                    <asp:ListItem Value="2">Fabricante</asp:ListItem>
                                                    <asp:ListItem Value="3">Fornecedor-Fabricante</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>                                         
                                        </tr>
                                        <tr>
                                            <td style="width:50px;" valign="top">
                                                    <p class="label_form" align="left">
                                                        <asp:Label class="label_form" ID="lblCodSap" runat="server" 
                                                        Text="Código SAP:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">                                                
                                                <asp:TextBox class="txt_form" ID="txtCodSap" runat="server" Width="150px" MaxLength="70" Visible="False"></asp:TextBox>
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
                                                <asp:DropDownList ID="ddlFornecimento" class="txt_form" runat="server" Visible="False" AutoPostBack="True" Width="251px">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                    <asp:ListItem Value="1">Material </asp:ListItem>
                                                    <asp:ListItem Value="2">Serviço</asp:ListItem>
                                                    <asp:ListItem Value="3">Material + Serviço</asp:ListItem>
                                                    <asp:ListItem Value="4">Ressarcimento</asp:ListItem>
                                                </asp:DropDownList>    
                                            </td>  
                                        </tr>                                        
                                        <tr>
                                            <td style="width:50px;" valign="top">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblMotivo" runat="server" 
                                                        Text="Motivo:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left" colspan=3>
                                                <asp:TextBox class="txt_form" ID="txtMotivo" runat="server" Width="742px"
                                                    MaxLength="70" Visible="False"></asp:TextBox>
                                            </td>                                                                                      
                                        </tr>
                                        <tr>
                                            <td style="width:50px;" >
		                                        <p class="label_form" align="left">
			                                        <asp:Label class="label_form" ID="lblTipoMaterial" runat="server" 
			                                        Text="Tipo de Material:" Visible="False"></asp:Label></p>
	                                        </td>
                                            <td align="left">                                                
                                                <asp:DropDownList ID="ddlTipoMaterial" class="txt_form" runat="server" 
                                                    Visible="False" Width="251px">
			                                        <asp:ListItem Value="0">Selecione...</asp:ListItem>
		                                        </asp:DropDownList> 
	                                        </td>
                                            <td align="left">
		                                        <p class="label_form" align="left" Width="20px">
			                                        <asp:Label class="label_form" ID="lblServico" runat="server" 
			                                        Text="Tipo de Serviço:" Visible="False"></asp:Label></p>
	                                        </td>
	                                        <td align="left">
		                                        <asp:DropDownList ID="ddlServico" class="txt_form" runat="server" 
                                                    Visible="False" Width="394px">
			                                        <asp:ListItem Value="0">Selecione...</asp:ListItem>
		                                        </asp:DropDownList>    
	                                        </td>
                                        </tr>                                                                                
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlOperacao" EventName="SelectedIndexChanged" />                                    
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>                                       

                    <tr>
                        <td>
                            <p class="titulo_internas_box">
                                Dados do Fornecedor
                            </p>
                        </td>
                    </tr>

                    <tr>
                        <td width="100%" align="center" class="box_dados_fornecedor">
                            <asp:UpdatePanel id="pnlDados" runat="server" UpdateMode="Conditional" >         
                                <ContentTemplate>
                                    <table width="850px">
                                        <tr>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblRazaoSocial" runat="server" 
                                                        Text="Razão Social:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td colspan="9" align="left">
                                                <asp:TextBox class="txt_form" ID="txtRazaoSocial" runat="server" Width="726px" 
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
                                                <asp:TextBox class="txt_form" ID="txtNomeFantasia" runat="server" Width="757px" 
                                                    MaxLength="70" Visible="False"></asp:TextBox>                                                
                                            </td>
                                        </tr>    
                                        <tr>
                                            <td width="55px" align="left">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblCep" runat="server" 
                                                        Text="CEP:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td width="98px" align="left">
                                                <asp:TextBox class="txt_form" ID="txtCep" runat="server" Width="88px" onkeyup="javascript:formataCEP(this,event);"
                                                    MaxLength="9" Visible="False" AutoPostBack="True" onkeydown="javascript:submeterCampo(event);"></asp:TextBox>
                                                <asp:Label class="label_form" ID="lblErro" runat="server" 
                                                        Text="CEP Inexistente!" Visible="False"></asp:Label>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblEndereco" runat="server" 
                                                        Text="Endereço:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtEndereco" runat="server" Width="285px" 
                                                    MaxLength="60" Visible="False"></asp:TextBox>
                                            </td>
                                            <td width="36px" align="left">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblNumero" runat="server" 
                                                        Text="No.:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td width="86px" align="left">
                                                <asp:TextBox class="txt_form" ID="txtNumero" runat="server" Width="68px" MaxLength="10" Visible="False"></asp:TextBox>
                                            </td>
                                            <td width="157px" align="left">
                                                <p class="label_form">
                                                    <asp:Label class="label_form" ID="lblComplemento" runat="server" 
                                                        Text="Compl.:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td width="88px" align="left">
                                                <asp:TextBox class="txt_form" ID="txtComplemento" runat="server" Width="175px" 
                                                    MaxLength="10" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblBairro" runat="server" 
                                                        Text="Bairro:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtBairro" runat="server" Width="285px" MaxLength="40" Visible="False"></asp:TextBox>
                                            </td>      
                                            <td align="left">
                                                <p class="label_form">
                                                    <asp:Label class="label_form" ID="lblCaixaPostal" runat="server" 
                                                        Text="Cx.Postal:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left"> 
                                                <asp:TextBox class="txt_form" ID="txtCaixaPostal" runat="server" Width="130px" 
                                                    MaxLength="10" Visible="False"></asp:TextBox>
                                            </td>                                                                                  
                                        </tr>
                                        <tr>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblCidade" runat="server" 
                                                        Text="Cidade:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtCidade" runat="server" Width="285px" MaxLength="40" Visible="False"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblEstado" runat="server" 
                                                        Text="Estado:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlEstado" class="txt_form" runat="server" Enabled="false" Visible="False">
                                                    <asp:ListItem Value="-" Selected>-</asp:ListItem>
                                                    <asp:ListItem Value="AC">AC</asp:ListItem>
                                                    <asp:ListItem Value="AL">AL</asp:ListItem>
                                                    <asp:ListItem Value="AP">AP</asp:ListItem>
                                                    <asp:ListItem Value="AM">AM</asp:ListItem>
                                                    <asp:ListItem Value="BA">BA</asp:ListItem>
                                                    <asp:ListItem Value="CE">CE</asp:ListItem>
                                                    <asp:ListItem Value="DF">DF</asp:ListItem>
                                                    <asp:ListItem Value="ES">ES</asp:ListItem>
                                                    <asp:ListItem Value="GO">GO</asp:ListItem>
                                                    <asp:ListItem Value="MA">MA</asp:ListItem>
                                                    <asp:ListItem Value="MT">MT</asp:ListItem>
                                                    <asp:ListItem Value="MS">MS</asp:ListItem>
                                                    <asp:ListItem Value="MG">MG</asp:ListItem>
                                                    <asp:ListItem Value="PA">PA</asp:ListItem>
                                                    <asp:ListItem Value="PB">PB</asp:ListItem>
                                                    <asp:ListItem Value="PR">PR</asp:ListItem>
                                                    <asp:ListItem Value="PE">PE</asp:ListItem>
                                                    <asp:ListItem Value="PI">PI</asp:ListItem>
                                                    <asp:ListItem Value="RJ">RJ</asp:ListItem>
                                                    <asp:ListItem Value="RN">RN</asp:ListItem>
                                                    <asp:ListItem Value="RS">RS</asp:ListItem>
                                                    <asp:ListItem Value="RO">RO</asp:ListItem>
                                                    <asp:ListItem Value="RR">RR</asp:ListItem>
                                                    <asp:ListItem Value="SC">SC</asp:ListItem>
                                                    <asp:ListItem Value="SP">SP</asp:ListItem>
                                                    <asp:ListItem Value="SE">SE</asp:ListItem>
                                                    <asp:ListItem Value="TO">TO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblPais" runat="server" 
                                                        Text="País:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td colspan="2" align="left">
                                                <asp:DropDownList ID="ddlSiglaPais" class="txt_form" name="Pais" runat="server" Width="175px" Visible="False">
                                                    <asp:ListItem Value="-" Selected>-</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                        </tr>                                    
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtCep" EventName="TextChanged" /> 
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlOperacao" EventName="SelectedIndexChanged" />                                                                         
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <p class="titulo_internas_box">
                                Contato Principal Fornecedor</p>
                        </td>
                    </tr>

                    <tr>
                        <td width="100%" align="center" class="box_dados_contato_empresa">
                            <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional" >         
                                <ContentTemplate>
                                    <table width="850px">
                                        <tr>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblNome" runat="server" 
                                                        Text="Nome:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td width="315px" align="left">
                                                <asp:TextBox class="txt_form" ID="txtNomeContato" runat="server" Width="304px" MaxLength="35" Visible="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblSobrenome" runat="server" 
                                                        Text="Sobrenome:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtSobrenomeContato" runat="server" Width="304px"
                                                    MaxLength="35" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblFuncao" runat="server" 
                                                        Text="Função:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td width="315px" align="left">
                                                <asp:TextBox class="txt_form" ID="txtFuncaoContato" runat="server" Width="304px"
                                                    MaxLength="50" Visible="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblDepartamento" runat="server" 
                                                        Text="Departamento:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtDepartamentoContato" runat="server" Width="304px"
                                                    MaxLength="50" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblTelefone" runat="server" 
                                                        Text="Telefone:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtTelefoneContato" runat="server" Width="150px"
                                                    MaxLength="18" onkeyup="javascript:formataTelefone(this,event);" Visible="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblFax" runat="server" 
                                                        Text="Fax:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtFaxContato" runat="server" Width="150px" MaxLength="18"
                                                    onkeyup="javascript:formataTelefone(this,event);" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblCelular" runat="server" 
                                                        Text="Celular:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtCelularContato" runat="server" Width="150px"
                                                    MaxLength="18" onkeyup="javascript:mascara(this, formataTel9digitos);" Visible="False"></asp:TextBox>
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblEmail" runat="server" 
                                                        Text="Email:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtEmailContato" runat="server" Width="304px" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>                                        
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlOperacao" EventName="SelectedIndexChanged" />                                     
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p class="titulo_internas_box">
                                Dados Gerais Fornecedor
                            </p>
                        </td>
                    </tr>

                    <tr>
                        <td width="100%" align="center" class="box_dados_iniciais" visible=false>
                            <asp:UpdatePanel id="pnlContato" runat="server" UpdateMode="Conditional" >         
                                <ContentTemplate>
                                    <table width="850px">   
                                        <tr>
                                            <td>
                                                <p align="left">
                                                    <asp:Label class="label_form" ID="lblCondPgmto" runat="server" 
                                                        Text="Cond.Pagamento:"></asp:Label></p>
                                            </td>
                                            <td width="98px" align="left" colspan=5>                                                
                                                <asp:DropDownList ID="ddlCondPgmto" class="txt_form" runat="server" Width="532px">		                                        
			                                        <asp:ListItem Value="0">Selecione...</asp:ListItem>
		                                        </asp:DropDownList>			                                       
                                            </td>
                                        </tr>                                                                             
                                        <tr>
                                            <td>
                                                <p align="left">
                                                    <asp:Label class="label_form" ID="lblInss" runat="server" 
                                                        Text="INSS(NIT-PIS-PASEP):" Visible="False"></asp:Label></p>
                                            </td>
                                            <td width="98px" align="left">
                                                <asp:TextBox class="txt_form" ID="txtInss" runat="server" Width="149px" 
                                                    MaxLength="11" Visible="False"></asp:TextBox>
                                            </td>
                                            <td width="55px" align="left">
                                                <p style="width: 114px">
                                                    <asp:Label class="label_form" ID="lblCbo" runat="server" 
                                                        Text="Código CBO:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtCbo" runat="server" Width="138px" 
                                                    MaxLength="9" Visible="False"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <p align="left" style="width: 126px">
                                                    <asp:Label class="label_form" ID="lblSefip" runat="server" 
                                                        Text="Cod. Categoria Trabalhador-SEFIP:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td>          
                                                <asp:DropDownList ID="ddlSefip" runat="server" AutoPostBack="True" Width="138px" Visible="false">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                    <asp:ListItem Value="1">13 - Contribuinte Individual (Cálculo de imposto sobre remuneração)</asp:ListItem>
                                                    <asp:ListItem Value="2">15 - Transportador (Cálculo sobre o valor do frete)</asp:ListItem>
                                                </asp:DropDownList>                                      
                                            </td>
                                        </tr>                                                                                
                                        <tr>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblOptante" runat="server" 
                                                        Text="Optante Simples:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButtonList ID="rdbOptante" runat="server" Visible="False" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="Sim" Value="1"/>
                                                    <asp:ListItem Text="Não" Value="0"/>
                                                </asp:RadioButtonList>                                                
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblNumIdFisc" runat="server" 
                                                        Text="N° Id Fiscal:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtNumIdFisc" runat="server" MaxLength="60" 
                                                    Visible="False" Width="150px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblInscricaoRural" runat="server" 
                                                        Text="Nº de Inscrição (CEI / INSS):" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtInscricaoRural" runat="server" 
                                                    MaxLength="60" Visible="False" Width="137px"></asp:TextBox>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblCPFCNPJ" runat="server" 
                                                        Text="CPF:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left" width="165px">
                                                <asp:TextBox class="txt_form" ID="txtCPF" onkeyup="javascript:formataCPF(this,event);"
                                                    runat="server" Width="150px" MaxLength="14" Visible="False"></asp:TextBox>
                                                <asp:TextBox class="txt_form" ID="txtCNPJ" onkeyup="javascript:formataCNPJ(this,event);"
                                                    runat="server" Width="150px" MaxLength="18" Visible="False"></asp:TextBox>                                                
                                            </td>
                                            <td align="left">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblInscEstadual" runat="server" 
                                                        Text="Insc. Estadual:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left" width="155px">
                                                <asp:TextBox class="txt_form" ID="txtInscEstadual" runat="server" Width="137px"
                                                    MaxLength="16" Visible="False"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblInscMunicipal" runat="server" 
                                                        Text="Insc. Municipal:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td>
                                                <asp:TextBox class="txt_form" ID="txtInscMunicipal" runat="server" Width="133px"
                                                     MaxLength="17" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>                                       
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlOperacao" EventName="SelectedIndexChanged" />     
                                    <asp:AsyncPostBackTrigger ControlID="ddlFornecimento" EventName="SelectedIndexChanged" />                                
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>       
                    
                    <tr>
                        <td>
                            <p class="titulo_internas_box">
                                Dados do Solicitante
                            </p>
                        </td>
                    </tr>

                    <tr>
                        <td width="100%" align="center" class="box_dados_contato_empresa">
                            <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >         
                                <ContentTemplate>
                                    <table width="850px">
                                        <tr>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblNomeSolicitante" runat="server" 
                                                        Text="Nome Solicitante:" Visible="true"></asp:Label></p>
                                            </td>
                                            <td width="315px" align="left">
                                                <asp:TextBox class="txt_form" ID="txtNomeSolicitante" runat="server" Width="304px" MaxLength="35" Visible="true"></asp:TextBox>
                                            </td>
                                            <td width="100px">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblTelefoneSolicitante" runat="server" 
                                                        Text="Telefone:" Visible="true"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtTelefoneSolicitante" runat="server" Width="150px"
                                                    MaxLength="15" onkeyup="javascript:formataTelefone(this,event);" Visible="true"></asp:TextBox>
                                            </td>                                            
                                        </tr>                                        
                                        <tr>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblCentro" runat="server" 
                                                        Text="Centro:" Visible="true"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList class="cmb_form" ID="ddlCentro" runat="server" AutoPostBack="True"
                                                    Width="304px">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>                                                    
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblArea" runat="server" 
                                                        Text="Área:" Visible="true"></asp:Label></p>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox class="txt_form" ID="txtArea" runat="server" Width="304px"
                                                    MaxLength="35" Visible="true"></asp:TextBox>
                                            </td>                                           
                                        </tr>                                        
                                        <tr>
                                            <td style="width:50px;" valign="top">
                                                <p class="label_form" align="left">
                                                    <asp:Label class="label_form" ID="lblObservacao" runat="server" 
                                                        Text="Observação:" Visible="False"></asp:Label></p>
                                            </td>
                                            <td align="left" colspan=3>
                                                <asp:TextBox class="txt_form" ID="txtObs" runat="server" Width="727px" Height="35px"
                                                    TextMode="MultiLine" MaxLength="70" Visible="False"></asp:TextBox>
                                            </td>                                                                                      
                                        </tr>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlCategoria" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlOperacao" EventName="SelectedIndexChanged" />                                     
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                                
                    <tr>
                        <td align="center">
                            <table width="850px">
                                <tr>
                                    <td align="right">
                                        <asp:Button class="bt_outros" ID="btFinalizar" runat="server" 
                                            Text="Finalizar" />
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
    <style type="text/css">
        .style2
        {
            width: 187px;
        }
    </style>
</asp:Content>
