$(document).ready(function () {
    $(".cep").mask("00.000-000");
});

$(document).ready(function () {
    function limpa_formulario_cep() {
        $("#Estado").val("");
        $("#Cidade").val("");
        $("#Logradouro").val("");
        $("#Bairro").val("");
        $("#Complemento").val("");
    }

    $("#CEP").blur(function () {
        var cep = $(this).val().replace(/\D/g, '');

        if (cep != "") {
            var validacep = /^[0-9]{8}$/;

            if (validacep.test(cep)) {

                $("#Estado").val("...");
                $("#Cidade").val("...");
                $("#Logradouro").val("...");
                $("#Bairro").val("...");
                $("#Complemento").val("...");

                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        $("#Estado").val(dados.uf);
                        $("#Cidade").val(dados.localidade);
                        $("#Logradouro").val(dados.logradouro);
                        $("#Bairro").val(dados.bairro);
                        $("#Complemento").val(dados.complemento);
                    }
                    else {
                        limpa_fomulario_cep();
                        alert("CEP não encontrato");
                    }
                });
            }
            else {
                limpa_fomulario_cep();
                alert("Formato de CEP inválido");
            }
        }
        else {
            limpa_fomulario_cep();
        }
    });
});