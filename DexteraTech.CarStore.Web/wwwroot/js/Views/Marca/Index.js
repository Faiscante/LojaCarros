
$(document).ready(function() {
    MarcaIndexView.bind();
});

MarcaIndexView = {
    urlExcluirMarca: "",

    bind: function() {
    },
    excluirMarcaConfirm: function(element) {
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
                MarcaIndexView.excluirMarca(element);
            }
        });
    },
    excluirMarca: function(element) {
        var idMarca = $(element).data("idmarca");

        var params = { idMarca: idMarca };

        $.ajax({
            type: "DELETE",
            url: MarcaIndexView.urlExcluirMarca,
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