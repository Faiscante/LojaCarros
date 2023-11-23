
$(document).ready(function() {
    ModeloIndexView.bind();
});

ModeloIndexView = {
    urlExcluirModelo: "",

    bind: function() {
    },
    excluirModeloConfirm: function(element) {
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
                ModeloIndexView.excluirModelo(element);
            }
        });
    },
    excluirModelo: function(element) {
        var idModelo = $(element).data("idmodelo");

        var params = { idModelo: idModelo };

        $.ajax({
            type: "DELETE",
            url: ModeloIndexView.urlExcluirModelo,
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