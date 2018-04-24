function Adicionar() {
    DatePickerPadrao($("#DataExecucaoModal"));

    $("#modalAdicionar").modal({
        backdrop: 'static',
        keyboard: false
    });
}

function Salvar() {
    var data = new FormData();
    data.append('DataExecucao', $("#DataExecucaoModal").val());
    data.append('Descricao', $("#DescricaoModal").val());
    data.append('Titulo', $("#TituloModal").val());

    $.ajax({
        url: urlSalvar,
        type: 'POST',
        contentType: false,
        processData: false,
        data: data,
        success: function (result) {
            alert(result.mensagem);

            $("#modalAdicionar").modal('hide');
        }
    });
}

function Pesquisar() {
    $.ajax({
        type: "POST",
        url: urlPesquisar,
        data: $("#formTarefa").serialize(),
        success: function (result) {
            $("#divGrid").html(result);
        }
    });
}

function Excluir(id) {
    $.ajax({
        type: "POST",
        url: urlExcluir,
        data: { id: id },
        success: function (result) {
            $("#divGrid").html(result);
        }
    });
}

function DatePickerPadrao(controle) {

    var format = 'DD/MM/YYYY';
    var locate = 'pt-BR';

    controle.datetimepicker(
        {
            locale: locate,
            format: format,
            minDate: '-1999/01/01'
        });
}
