
$(document).ready(function() {
    CambioIndexView.bind();
});

CambioIndexView = {
    urlExcluirCambio: "",

    bind: function() {
    },
    excluirCambioConfirm: function(element) {
        Swal.fire({
            title: "Você tem certeza?",
            text: "Você não poderá reverter essa ação!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sim, deletar!",
            cancelButtonText: "Cancelar"
        }).then((result) => {
            if (result.isConfirmed) {
                CambioIndexView.excluirCambio(element);
            }
        });
    },
    excluirCambio: function(element) {
        var idCambio = $(element).data("idcambio");

        var params = { idCambio: idCambio };

        $.ajax({
            type: "DELETE",
            url: CambioIndexView.urlExcluirCambio,
            data: params,
            success: function(data) {
                toastr.success(data);
                $(element).parent().parent().parent().parent().remove();
            },
            error: function(data, exception) {
                toastr.error(data.responseText);
            }
        });


    }
};