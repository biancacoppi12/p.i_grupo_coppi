
function AtribuirMascaras() {
    $(".CnpjMascara").unmask();
    $(".CnpjMascara").mask("99.999.999/9999-99");

    $(".TelefoneMascara").unmask();
    $(".TelefoneMascara").mask("(99)9999-9999");

    $(".CelularMascara").unmask();
    $(".CelularMascara").mask("(99)99999-9999");


    $(".CpfMascara").unmask();
    $(".CpfMascara").mask("999.999.999-99");
    

}

$(document).ready(function () {
    AtribuirMascaras();
});
