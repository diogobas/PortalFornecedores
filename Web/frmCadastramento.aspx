<%@ Page Title="Portal Fornecedores Duratex / Fomulário de Cadastro" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/Page.Master" CodeBehind="frmCadastramento.aspx.vb"
    Inherits="PortalFornecedores.frmCadastramento" %>

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
                                Cadastramento
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_dados_empresa">
                            <table width="850px">
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Razão Social:</p>
                                    </td>
                                    <td colspan="9" align="left">
                                        <asp:TextBox class="txt_form" ID="txtRazaoSocial" runat="server" Width="730px" MaxLength="70"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Nome Fantasia:</p>
                                    </td>
                                    <td colspan="9" align="left">
                                        <asp:TextBox class="txt_form" ID="txtNomeFantazia" runat="server" Width="730px" MaxLength="70"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            CNPJ:</p>
                                    </td>
                                    <td align="left" width="165px">
                                        <asp:TextBox class="txt_form_label" ID="txtCNPJ" onkeyup="javascript:formataCNPJ(this,event);"
                                            runat="server" Width="150px" MaxLength="18" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td width="130px" align="left">
                                        <p class="label_form" align="left">
                                            Inscrição Estadual:</p>
                                    </td>
                                    <td align="left" width="155px" colspan="2">
                                        <asp:TextBox class="txt_form" ID="txtInscEstadual" runat="server" Width="137px"
                                            MaxLength="16"></asp:TextBox>
                                    </td>
                                    <td width="130px" align="left" colspan="2">
                                        <p class="label_form" align="left">
                                            Inscrição Municipal:</p>
                                    </td>
                                    <td align="left" width="150px" colspan="3">
                                        <asp:TextBox class="txt_form" ID="txtInscMunicipal" runat="server" Width="133px"
                                             MaxLength="17"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Endereço:</p>
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:TextBox class="txt_form" ID="txtEndereco" runat="server" Width="435px" MaxLength="60"></asp:TextBox>
                                    </td>
                                    <td width="36px" align="left">
                                        <p class="label_form" align="left">
                                            No.:</p>
                                    </td>
                                    <td width="86px" align="left">
                                        <asp:TextBox class="txt_form" ID="txtNumero" runat="server" Width="68px" onkeyup="javascript:formataInteiro(this,event);"
                                            MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td width="57px" align="left">
                                        <p class="label_form" align="left">
                                            Compl.:</p>
                                    </td>
                                    <td width="88px" align="left" colspan="2">
                                        <asp:TextBox class="txt_form" ID="txtComplemento" runat="server" Width="71px" MaxLength="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Bairro:</p>
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:TextBox class="txt_form" ID="txtBairro" runat="server" Width="285px" MaxLength="40"></asp:TextBox>
                                    </td>
                                    <td width="55px" align="left">
                                        <p class="label_form" align="left">
                                            CEP:</p>
                                    </td>
                                    <td width="98px" align="left">
                                        <asp:TextBox class="txt_form" ID="txtCep" runat="server" Width="78px" onkeyup="javascript:formataCEP(this,event);"
                                            MaxLength="9"></asp:TextBox>
                                    </td>
                                    <td colspan="2" align="left">
                                        <p class="label_form" align="left">
                                            Caixa Postal:</p>
                                    </td>
                                    <td colspan="3" align="left">
                                        <asp:TextBox class="txt_form" ID="txtCaixaPostal" runat="server" Width="133px" MaxLength="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <p class="label_form" align="left">
                                            Cidade:</p>
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:TextBox class="txt_form" ID="txtCidade" runat="server" Width="285px" MaxLength="40"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <p class="label_form" align="left">
                                            Estado:</p>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlEstado" class="txt_form" runat="server">
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
                                            <asp:ListItem Value="SP" Selected>SP</asp:ListItem>
                                            <asp:ListItem Value="SE">SE</asp:ListItem>
                                            <asp:ListItem Value="TO">TO</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <p class="label_form" align="left">
                                            País:</p>
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:DropDownList ID="ddlSiglaPais" class="txt_form" name="Pais" runat="server" Width="230px">
                                            <asp:ListItem Value="AF">Afeganistão</asp:ListItem>
                                            <asp:ListItem Value="AL">Albânia</asp:ListItem>
                                            <asp:ListItem Value="DZ">Argélia</asp:ListItem>
                                            <asp:ListItem Value="AS">Samoa americana</asp:ListItem>
                                            <asp:ListItem Value="AD">Andorra</asp:ListItem>
                                            <asp:ListItem Value="AO">Angola</asp:ListItem>
                                            <asp:ListItem Value="AI">Anguilla</asp:ListItem>
                                            <asp:ListItem Value="AQ">Antártica</asp:ListItem>
                                            <asp:ListItem Value="AG">Antígua e Barbuda</asp:ListItem>
                                            <asp:ListItem Value="AR">Argentina</asp:ListItem>
                                            <asp:ListItem Value="AM">Armênia</asp:ListItem>
                                            <asp:ListItem Value="AW">Aruba</asp:ListItem>
                                            <asp:ListItem Value="AU">Austrália</asp:ListItem>
                                            <asp:ListItem Value="AT">Áustria</asp:ListItem>
                                            <asp:ListItem Value="AZ">Azerbaijão</asp:ListItem>
                                            <asp:ListItem Value="BS">Bahamas</asp:ListItem>
                                            <asp:ListItem Value="BH">Bahrain</asp:ListItem>
                                            <asp:ListItem Value="BD">Bangladesh</asp:ListItem>
                                            <asp:ListItem Value="BB">Barbados</asp:ListItem>
                                            <asp:ListItem Value="BY">Belarus</asp:ListItem>
                                            <asp:ListItem Value="BE">Bélgica</asp:ListItem>
                                            <asp:ListItem Value="BZ">Belize</asp:ListItem>
                                            <asp:ListItem Value="BJ">Benin</asp:ListItem>
                                            <asp:ListItem Value="BM">Bermudas</asp:ListItem>
                                            <asp:ListItem Value="BT">Butão</asp:ListItem>
                                            <asp:ListItem Value="BO">Bolívia</asp:ListItem>
                                            <asp:ListItem Value="BA">Bósnia e Herzegovina</asp:ListItem>
                                            <asp:ListItem Value="BW">Botswana</asp:ListItem>
                                            <asp:ListItem Value="BV">Ilha Bouvet</asp:ListItem>
                                            <asp:ListItem Value="BR" Selected>Brasil</asp:ListItem>
                                            <asp:ListItem Value="IO">Britânico do Oceano Índico</asp:ListItem>
                                            <asp:ListItem Value="BN">Brunei Darussalam</asp:ListItem>
                                            <asp:ListItem Value="BG">Bulgária</asp:ListItem>
                                            <asp:ListItem Value="BF">Burkina Faso</asp:ListItem>
                                            <asp:ListItem Value="BI">Burundi</asp:ListItem>
                                            <asp:ListItem Value="KH">Camboja</asp:ListItem>
                                            <asp:ListItem Value="CM">Camarões</asp:ListItem>
                                            <asp:ListItem Value="CA">Canadá</asp:ListItem>
                                            <asp:ListItem Value="CV">Cabo Verde</asp:ListItem>
                                            <asp:ListItem Value="KY">Ilhas Cayman</asp:ListItem>
                                            <asp:ListItem Value="CF">República Centro-Africano</asp:ListItem>
                                            <asp:ListItem Value="TD">Chade</asp:ListItem>
                                            <asp:ListItem Value="CL">Chile</asp:ListItem>
                                            <asp:ListItem Value="CN">China</asp:ListItem>
                                            <asp:ListItem Value="CX">Ilha de Natal</asp:ListItem>
                                            <asp:ListItem Value="CC">Cocos (Keeling)</asp:ListItem>
                                            <asp:ListItem Value="CO">Colômbia</asp:ListItem>
                                            <asp:ListItem Value="KM">Comores</asp:ListItem>
                                            <asp:ListItem Value="CG">Congo</asp:ListItem>
                                            <asp:ListItem Value="CK">Ilhas Cook</asp:ListItem>
                                            <asp:ListItem Value="CR">Costa Rica</asp:ListItem>
                                            <asp:ListItem Value="CI">Cote D'Ivoire</asp:ListItem>
                                            <asp:ListItem Value="HR">Croácia (nome local: Hrvatska)</asp:ListItem>
                                            <asp:ListItem Value="CU">Cuba</asp:ListItem>
                                            <asp:ListItem Value="CY">Chipre</asp:ListItem>
                                            <asp:ListItem Value="CZ">República Checa</asp:ListItem>
                                            <asp:ListItem Value="DK">Dinamarca</asp:ListItem>
                                            <asp:ListItem Value="DJ">Djibouti</asp:ListItem>
                                            <asp:ListItem Value="DM">Dominica</asp:ListItem>
                                            <asp:ListItem Value="DO">República Dominicana</asp:ListItem>
                                            <asp:ListItem Value="TP">Timor Leste</asp:ListItem>
                                            <asp:ListItem Value="EC">Equador</asp:ListItem>
                                            <asp:ListItem Value="EG">Egito</asp:ListItem>
                                            <asp:ListItem Value="SV">El Salvador</asp:ListItem>
                                            <asp:ListItem Value="GQ">Guiné Equatorial</asp:ListItem>
                                            <asp:ListItem Value="ER">Eritreia</asp:ListItem>
                                            <asp:ListItem Value="EE">Estônia</asp:ListItem>
                                            <asp:ListItem Value="ET">Etiópia</asp:ListItem>
                                            <asp:ListItem Value="FK">Ilhas Falkland (Malvinas)</asp:ListItem>
                                            <asp:ListItem Value="FO">Ilhas Faroe</asp:ListItem>
                                            <asp:ListItem Value="FJ">Fiji</asp:ListItem>
                                            <asp:ListItem Value="FI">Finlândia</asp:ListItem>
                                            <asp:ListItem Value="FR">França</asp:ListItem>
                                            <asp:ListItem Value="GF">Guiana Francesa</asp:ListItem>
                                            <asp:ListItem Value="PF">Polinésia Francesa</asp:ListItem>
                                            <asp:ListItem Value="TF">Territórios Franceses do Sul</asp:ListItem>
                                            <asp:ListItem Value="GA">Gabão</asp:ListItem>
                                            <asp:ListItem Value="GM">Gâmbia</asp:ListItem>
                                            <asp:ListItem Value="GE">Georgia</asp:ListItem>
                                            <asp:ListItem Value="DE">Alemanha</asp:ListItem>
                                            <asp:ListItem Value="GH">Gana</asp:ListItem>
                                            <asp:ListItem Value="GI">Gibraltar</asp:ListItem>
                                            <asp:ListItem Value="GR">Grécia</asp:ListItem>
                                            <asp:ListItem Value="GL">Groenlândia</asp:ListItem>
                                            <asp:ListItem Value="GD">Granada</asp:ListItem>
                                            <asp:ListItem Value="GP">Guadalupe</asp:ListItem>
                                            <asp:ListItem Value="GU">Guam</asp:ListItem>
                                            <asp:ListItem Value="GT">Guatemala</asp:ListItem>
                                            <asp:ListItem Value="GN">Guiné</asp:ListItem>
                                            <asp:ListItem Value="GW">Guiné-Bissau</asp:ListItem>
                                            <asp:ListItem Value="GY">Guiana</asp:ListItem>
                                            <asp:ListItem Value="HT">Haiti</asp:ListItem>
                                            <asp:ListItem Value="HM">Heard e Mc Donald Ilhas</asp:ListItem>
                                            <asp:ListItem Value="VA">Santa Sé (Cidade do Vaticano)</asp:ListItem>
                                            <asp:ListItem Value="HN">Honduras</asp:ListItem>
                                            <asp:ListItem Value="HK">Hong Kong</asp:ListItem>
                                            <asp:ListItem Value="HU">Hungria</asp:ListItem>
                                            <asp:ListItem Value="IS">Islândia</asp:ListItem>
                                            <asp:ListItem Value="IN">Índia</asp:ListItem>
                                            <asp:ListItem Value="ID">Indonésia</asp:ListItem>
                                            <asp:ListItem Value="IR">Irão (República Islâmica do)</asp:ListItem>
                                            <asp:ListItem Value="IQ">Iraque</asp:ListItem>
                                            <asp:ListItem Value="IE">Irlanda</asp:ListItem>
                                            <asp:ListItem Value="IL">Israel</asp:ListItem>
                                            <asp:ListItem Value="IT">Itália</asp:ListItem>
                                            <asp:ListItem Value="JM">Jamaica</asp:ListItem>
                                            <asp:ListItem Value="JP">Japão</asp:ListItem>
                                            <asp:ListItem Value="JO">Jordânia</asp:ListItem>
                                            <asp:ListItem Value="KZ">Cazaquistão</asp:ListItem>
                                            <asp:ListItem Value="KE">Quênia</asp:ListItem>
                                            <asp:ListItem Value="KI">Kiribati</asp:ListItem>
                                            <asp:ListItem Value="KP">Coréia, República Dem Popular</asp:ListItem>
                                            <asp:ListItem Value="KR">Coréia, República da</asp:ListItem>
                                            <asp:ListItem Value="KW">Kuweit</asp:ListItem>
                                            <asp:ListItem Value="KG">Quirguistão</asp:ListItem>
                                            <asp:ListItem Value="LA">Popular do Laos República Dem</asp:ListItem>
                                            <asp:ListItem Value="LV">Látvia</asp:ListItem>
                                            <asp:ListItem Value="LB">Líbano</asp:ListItem>
                                            <asp:ListItem Value="LS">Lesoto</asp:ListItem>
                                            <asp:ListItem Value="LR">Libéria</asp:ListItem>
                                            <asp:ListItem Value="LY">Jamahiriya Árabe Líbia</asp:ListItem>
                                            <asp:ListItem Value="LI">Liechtenstein</asp:ListItem>
                                            <asp:ListItem Value="LT">Lituânia</asp:ListItem>
                                            <asp:ListItem Value="LU">Luxemburgo</asp:ListItem>
                                            <asp:ListItem Value="MO">Macau</asp:ListItem>
                                            <asp:ListItem Value="MK">Macedonia</asp:ListItem>
                                            <asp:ListItem Value="MG">Madagáscar</asp:ListItem>
                                            <asp:ListItem Value="MW">Malavi</asp:ListItem>
                                            <asp:ListItem Value="MY">Malásia</asp:ListItem>
                                            <asp:ListItem Value="MV">Maldivas</asp:ListItem>
                                            <asp:ListItem Value="ML">Mali</asp:ListItem>
                                            <asp:ListItem Value="MT">Malta</asp:ListItem>
                                            <asp:ListItem Value="MH">Ilhas Marshall</asp:ListItem>
                                            <asp:ListItem Value="MQ">Martinica</asp:ListItem>
                                            <asp:ListItem Value="MR">Mauritânia</asp:ListItem>
                                            <asp:ListItem Value="MU">Maurício</asp:ListItem>
                                            <asp:ListItem Value="YT">Mayotte</asp:ListItem>
                                            <asp:ListItem Value="MX">México</asp:ListItem>
                                            <asp:ListItem Value="FM">Estados Federados da Micronésia</asp:ListItem>
                                            <asp:ListItem Value="MD">República da Moldávia</asp:ListItem>
                                            <asp:ListItem Value="MC">Mônaco</asp:ListItem>
                                            <asp:ListItem Value="MN">Mongólia</asp:ListItem>
                                            <asp:ListItem Value="MS">Montserrat</asp:ListItem>
                                            <asp:ListItem Value="MA">Marrocos</asp:ListItem>
                                            <asp:ListItem Value="MZ">Moçambique</asp:ListItem>
                                            <asp:ListItem Value="MM">Mianmar</asp:ListItem>
                                            <asp:ListItem Value="NA">Namíbia</asp:ListItem>
                                            <asp:ListItem Value="NR">Nauru</asp:ListItem>
                                            <asp:ListItem Value="NP">Nepal</asp:ListItem>
                                            <asp:ListItem Value="NL">Holanda</asp:ListItem>
                                            <asp:ListItem Value="AN">Netherlands Ant Illes</asp:ListItem>
                                            <asp:ListItem Value="NC">Nova Caledônia</asp:ListItem>
                                            <asp:ListItem Value="NZ">Nova Zelândia</asp:ListItem>
                                            <asp:ListItem Value="NI">Nicarágua</asp:ListItem>
                                            <asp:ListItem Value="NE">Níger</asp:ListItem>
                                            <asp:ListItem Value="NG">Nigéria</asp:ListItem>
                                            <asp:ListItem Value="NU">Niue</asp:ListItem>
                                            <asp:ListItem Value="NF">Ilha Norfolk</asp:ListItem>
                                            <asp:ListItem Value="MP">Ilhas Marianas do Norte</asp:ListItem>
                                            <asp:ListItem Value="NO">Noruega</asp:ListItem>
                                            <asp:ListItem Value="OM">Oman</asp:ListItem>
                                            <asp:ListItem Value="PK">Paquistão</asp:ListItem>
                                            <asp:ListItem Value="PW">Palau</asp:ListItem>
                                            <asp:ListItem Value="PA">Panamá</asp:ListItem>
                                            <asp:ListItem Value="PG">Papua Nova Guiné</asp:ListItem>
                                            <asp:ListItem Value="PY">Paraguai</asp:ListItem>
                                            <asp:ListItem Value="PE">Peru</asp:ListItem>
                                            <asp:ListItem Value="PH">Filipinas</asp:ListItem>
                                            <asp:ListItem Value="PN">Pitcairn</asp:ListItem>
                                            <asp:ListItem Value="PL">Polônia</asp:ListItem>
                                            <asp:ListItem Value="PT">Portugal</asp:ListItem>
                                            <asp:ListItem Value="PR">Porto Rico</asp:ListItem>
                                            <asp:ListItem Value="QA">Catar</asp:ListItem>
                                            <asp:ListItem Value="RE">Reunião</asp:ListItem>
                                            <asp:ListItem Value="RO">Romênia</asp:ListItem>
                                            <asp:ListItem Value="RU">Rússia</asp:ListItem>
                                            <asp:ListItem Value="RW">Ruanda</asp:ListItem>
                                            <asp:ListItem Value="KN">São K itts e Nevis</asp:ListItem>
                                            <asp:ListItem Value="LC">Santa Lúcia</asp:ListItem>
                                            <asp:ListItem Value="VC">São Vicente, Granadinas</asp:ListItem>
                                            <asp:ListItem Value="WS">Samoa</asp:ListItem>
                                            <asp:ListItem Value="SM">San Marino</asp:ListItem>
                                            <asp:ListItem Value="ST">São Tomé e Príncipe</asp:ListItem>
                                            <asp:ListItem Value="SA">Arábia Saudita</asp:ListItem>
                                            <asp:ListItem Value="SN">Senegal</asp:ListItem>
                                            <asp:ListItem Value="SC">Seychelles</asp:ListItem>
                                            <asp:ListItem Value="SL">Serra Leoa</asp:ListItem>
                                            <asp:ListItem Value="SG">Cingapura</asp:ListItem>
                                            <asp:ListItem Value="SK">Eslováquia (República Eslovaca)</asp:ListItem>
                                            <asp:ListItem Value="SI">Eslovenia</asp:ListItem>
                                            <asp:ListItem Value="SB">Ilhas Salomão</asp:ListItem>
                                            <asp:ListItem Value="SO">Somália</asp:ListItem>
                                            <asp:ListItem Value="ZA">África do Sul</asp:ListItem>
                                            <asp:ListItem Value="GS">Geórgia do Sul, Sandwich S é.</asp:ListItem>
                                            <asp:ListItem Value="ES">Espanha</asp:ListItem>
                                            <asp:ListItem Value="LK">Sri Lanka</asp:ListItem>
                                            <asp:ListItem Value="SH">St. Helena</asp:ListItem>
                                            <asp:ListItem Value="PM">St. Pierre e Miquelon</asp:ListItem>
                                            <asp:ListItem Value="SD">Sudão</asp:ListItem>
                                            <asp:ListItem Value="SR">Suriname</asp:ListItem>
                                            <asp:ListItem Value="SJ">Svalbard, Jan Mayen</asp:ListItem>
                                            <asp:ListItem Value="SZ">Sw Aziland</asp:ListItem>
                                            <asp:ListItem Value="SE">Suécia</asp:ListItem>
                                            <asp:ListItem Value="CH">Suíça</asp:ListItem>
                                            <asp:ListItem Value="SY">Síria</asp:ListItem>
                                            <asp:ListItem Value="TW">Taiwan</asp:ListItem>
                                            <asp:ListItem Value="TJ">Tajiquistão</asp:ListItem>
                                            <asp:ListItem Value="TZ">Tanzânia, República Unida da</asp:ListItem>
                                            <asp:ListItem Value="TH">Tailândia</asp:ListItem>
                                            <asp:ListItem Value="TG">Togo</asp:ListItem>
                                            <asp:ListItem Value="TK">Tokelau</asp:ListItem>
                                            <asp:ListItem Value="TO">Tonga</asp:ListItem>
                                            <asp:ListItem Value="TT">Trinidad e Tobago</asp:ListItem>
                                            <asp:ListItem Value="TN">Tunísia</asp:ListItem>
                                            <asp:ListItem Value="TR">Turquia</asp:ListItem>
                                            <asp:ListItem Value="TM">Turcomenistão</asp:ListItem>
                                            <asp:ListItem Value="TC">Turks And Caicos Islands</asp:ListItem>
                                            <asp:ListItem Value="TV">Tuvalu</asp:ListItem>
                                            <asp:ListItem Value="UG">Uganda</asp:ListItem>
                                            <asp:ListItem Value="UA">Ucrânia</asp:ListItem>
                                            <asp:ListItem Value="AE">Emirados Árabes Unidos</asp:ListItem>
                                            <asp:ListItem Value="GB">Reino Unido</asp:ListItem>
                                            <asp:ListItem Value="US">Estados Unidos</asp:ListItem>
                                            <asp:ListItem Value="UM">Estados Unidos Minor é.</asp:ListItem>
                                            <asp:ListItem Value="UY">Uruguai</asp:ListItem>
                                            <asp:ListItem Value="UZ">Uzbequistão</asp:ListItem>
                                            <asp:ListItem Value="VU">Vanuatu</asp:ListItem>
                                            <asp:ListItem Value="VE">Venezuela</asp:ListItem>
                                            <asp:ListItem Value="VN">Viet Nam</asp:ListItem>
                                            <asp:ListItem Value="VG">Virgin Islands (British)</asp:ListItem>
                                            <asp:ListItem Value="VI">Ilhas Virgens (EUA)</asp:ListItem>
                                            <asp:ListItem Value="WF">Wallis e Futuna</asp:ListItem>
                                            <asp:ListItem Value="EH">Saara Ocidental</asp:ListItem>
                                            <asp:ListItem Value="YE">Iémen</asp:ListItem>
                                            <asp:ListItem Value="YU">Iugoslávia</asp:ListItem>
                                            <asp:ListItem Value="ZR">Zaire</asp:ListItem>
                                            <asp:ListItem Value="ZM">Zâmbia</asp:ListItem>
                                            <asp:ListItem Value="ZW">Zimbábue</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" class="box_dados_contato_empresa">
                            <table width="850px">
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Nome:</p>
                                    </td>
                                    <td width="315px" align="left">
                                        <asp:TextBox class="txt_form" ID="txtNomeContato" runat="server" Width="304px" MaxLength="35"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Sobrenome:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form" ID="txtSobrenomeContato" runat="server" Width="304px"
                                            MaxLength="35"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Função:</p>
                                    </td>
                                    <td width="315px" align="left">
                                        <asp:TextBox class="txt_form" ID="txtFuncaoContato" runat="server" Width="304px"
                                            MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Departamento:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form" ID="txtDepartamentoContato" runat="server" Width="304px"
                                            MaxLength="50"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Telefone:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form" ID="txtTelefoneContato" runat="server" Width="150px"
                                            MaxLength="15" onkeyup="javascript:formataTelefone(this,event);"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Fax:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form" ID="txtFaxContato" runat="server" Width="150px" MaxLength="15"
                                            onkeyup="javascript:formataTelefone(this,event);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100px">
                                        <p class="label_form" align="left">
                                            Celular:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form" ID="txtCelularContato" runat="server" Width="150px"
                                            MaxLength="15" onkeyup="javascript:mascara(this, formataTel9digitos);"></asp:TextBox>
                                    </td>
                                    <td>
                                        <p class="label_form" align="left">
                                            Email:</p>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox class="txt_form" ID="txtEmailContato" runat="server" Width="304px"></asp:TextBox>
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
                                        <asp:Button class="bt_outros" ID="btProximo" runat="server" Text="Próximo &gt;&gt;" />
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
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
