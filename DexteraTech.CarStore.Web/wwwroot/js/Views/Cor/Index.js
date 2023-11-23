
$(document).ready(function() {
    CorIndexView.bind();
});

CorIndexView = {
    urlExcluirCor: "",

    bind: function() {
    },
    excluirCorConfirm: function(element) {
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
                CorIndexView.excluirCor(element);
            }
        });
    },
    excluirCor: function(element) {
        var idCor = $(element).data("idcor");

        var params = { idCor: idCor };

        $.ajax({
            type: "DELETE",
            url: CorIndexView.urlExcluirCor,
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