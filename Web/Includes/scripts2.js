function fechaMessagePopUp() {
    document.getElementById('message_popup').style.display = 'none';
    Enabled(document.getElementById('conteudo_pagina'));
}

function exibeMessagepopUp(sTitulo, sMessage, sNomeBotao, sAcaoBotao) {
    if (sAcaoBotao!=null) {
        document.getElementById('ctl00_MainContent_btFecharPopUp').onclick = new Function("event", sAcaoBotao);
    }
    if (sNomeBotao!=null) {
        document.getElementById('ctl00_MainContent_btFecharPopUp').value = sNomeBotao;
    }
    document.getElementById('message_popup').style.display = 'block';
    document.getElementById('tit_message_popup').innerHTML = sTitulo;
    document.getElementById('txt_message_popup').innerHTML = sMessage;
    Disabled(document.getElementById('conteudo_pagina'));
}

function Disabled(el) {
    if (el == null) { return }
    el.disabled = true;
    for (var i = 0; i < el.childNodes.length; i++)
        Disabled(el.childNodes[i]);
}

function Enabled(el) {
    if (el==null) { return }
    el.disabled = false;
    for (var i = 0; i < el.childNodes.length; i++)
        Enabled(el.childNodes[i]);
}