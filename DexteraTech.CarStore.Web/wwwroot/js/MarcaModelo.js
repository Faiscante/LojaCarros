//$(document).on('change', '#IdMarca', function () {
//    var cascataMarca = $(this),
//        IdMarca = parseInt(cascataMarca.val()),
//        cascataModelo = $('#IdModelo');

//    if (IdMarca > 0) {
//        var url = url_Listar_Marca_Modelo,
//            param = { IdMarca: IdMarca };

//        cascataModelo.empty();

//        $.get(url, param, function (response) {
//            if (response && response.length > 0) {
//                cascataModelo.append('<option value= "" > Selecione </option>')
//                for (var i = 0; i < response.length; i++) {
//                    cascataModelo.append('<option value=' + response[i].idModelo + '>' + response[i].nmModelo + '</option>');
//                }
//            }
//        });
//    }
//});


MarcaModeloEditView = {
    excluirImagem: function(id) {

    },
    carregarImagens: function(id) {
    },

    adicionarImagens: function(id) {
    }
}