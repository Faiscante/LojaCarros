$(document).on("change",
    "#IdModelo",
    function() {
        var cascataModelo = $(this),
            IdModelo = parseInt(cascataModelo.val()),
            cascataVersao = $("#IdVersao");

        if (IdModelo > 0) {
            var url = url_Listar_Modelo_Versao,
                param = { IdModelo: IdModelo };

            cascataVersao.empty();

            $.get(url,
                param,
                function(response) {
                    if (response && response.length > 0) {
                        cascataVersao.append('<option value= "" > Selecione </option>');
                        for (var i = 0; i < response.length; i++) {
                            cascataVersao.append("<option value=" +
                                response[i].idVersao +
                                ">" +
                                response[i].nmVersao +
                                "</option>");
                        }
                    }
                });
        }
    });