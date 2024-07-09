function validateCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf.length !== 11 || /^(\d)\1+$/.test(cpf)) {
        return false;
    }
    var sum = 0, remainder;

    for (var i = 1; i <= 9; i++) {
        sum += parseInt(cpf.substring(i - 1, i)) * (11 - i);
    }
    remainder = (sum * 10) % 11;

    if (remainder === 10 || remainder === 11) {
        remainder = 0;
    }
    if (remainder !== parseInt(cpf.substring(9, 10))) {
        return false;
    }

    sum = 0;
    for (i = 1; i <= 10; i++) {
        sum += parseInt(cpf.substring(i - 1, i)) * (12 - i);
    }
    remainder = (sum * 10) % 11;

    if (remainder === 10 || remainder === 11) {
        remainder = 0;
    }
    if (remainder !== parseInt(cpf.substring(10, 11))) {
        return false;
    }

    return true;
}

function validateCNPJ(cnpj) {
    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj.length !== 14) {
        return false;
    }

    if (/^(\d)\1+$/.test(cnpj)) {
        return false;
    }

    var length = cnpj.length - 2,
        numbers = cnpj.substring(0, length),
        digits = cnpj.substring(length),
        sum = 0,
        pos = length - 7,
        result;

    for (var i = length; i >= 1; i--) {
        sum += numbers.charAt(length - i) * pos--;
        if (pos < 2) {
            pos = 9;
        }
    }

    result = sum % 11 < 2 ? 0 : 11 - sum % 11;
    if (result !== parseInt(digits.charAt(0))) {
        return false;
    }

    length = length + 1;
    numbers = cnpj.substring(0, length);
    sum = 0;
    pos = length - 7;

    for (i = length; i >= 1; i--) {
        sum += numbers.charAt(length - i) * pos--;
        if (pos < 2) {
            pos = 9;
        }
    }

    result = sum % 11 < 2 ? 0 : 11 - sum % 11;
    if (result !== parseInt(digits.charAt(1))) {
        return false;
    }

    return true;
}

$(document).ready(function () {
    function setMaskAndValidation() {
        var type = $("#Tipo").val();
        var documentField = $("#Documento");
        var value = $("#Documento").val();
        if (type == 0) {
            $("#Documento").mask("000.000.000-00");
        } else if (type == 1) {
            $("#Documento").mask("00.000.000/0000-00");
        }
    }

    function Validate(type, value) {
        if (isNaN(value))
            if (type == 0) {
                if (!validateCPF(value)) {
                    alert("CPF inválido");
                    $("#Documento").val("");
                }
            }
            else if (type == 1) {
                var value = $("#Documento").val();
                if (!validateCNPJ(value)) {
                    alert("CNPJ inválido");
                    $("#Documento").val("");
                }
            }
    }

    $("#Tipo").change(function () {
        $("#Documento").val("");
        setMaskAndValidation();
    });

    $("#Documento").on("blur", function () {
        if (isNaN($("#Documento").val()))
            Validate($("#Tipo").val(), $("#Documento").val());
    });

    setMaskAndValidation();
});
