$(document).on("change",
    "#IdMarca",
    function() {
        var cascataMarca = $(this),
            IdMarca = parseInt(cascataMarca.val()),
            cascataModelo = $("#IdModelo");

        if (IdMarca > 0) {
            var url = url_Listar_Marca_Modelo,
                param = { IdMarca: IdMarca };

            cascataModelo.empty();

            $.get(url,
                param,
                function(response) {
                    if (response && response.length > 0) {
                        cascataModelo.append('<option value= "" > Selecione </option>');
                        for (var i = 0; i < response.length; i++) {
                            cascataModelo.append("<option value=" +
                                response[i].idModelo +
                                ">" +
                                response[i].nmModelo +
                                "</option>");
                        }
                    }
                });
        }
    });

$(document).ready(function() {
    VeiculoEditView.bind();
});

VeiculoEditView = {
    urlUploadImagem: "",
    urlExcluirFoto: "",


    bind: function() {

    },
    excluirImagem: function(element) {
        var idFoto = $(element).data("idfoto");
        var idVeiculo = $(element).data("idveiculo");

        var params = { idVeiculo: idVeiculo, idFoto: idFoto };

        $.ajax({
            type: "DELETE",
            url: VeiculoEditView.urlExcluirFoto,
            data: params,
            success: function(data) {
                toastr.success(data);
                $(element).parent().parent().parent().parent().remove();
            },
            error: function(errorMessage) {
                toastr.success(errorMessage);
            }
        });


    }
};