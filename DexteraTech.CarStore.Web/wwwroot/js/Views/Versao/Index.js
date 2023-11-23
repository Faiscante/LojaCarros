
$(document).ready(function() {
    VersaoIndexView.bind();
});

VersaoIndexView = {
    urlExcluirVersao: "",

    bind: function() {
    },
    excluirVersaoConfirm: function(element) {
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
                VersaoIndexView.excluirVersao(element);
            }
        });
    },
    excluirVersao: function(element) {
        var idVersao = $(element).data("idversao");

        var params = { idVersao: idVersao };

        $.ajax({
            type: "DELETE",
            url: VersaoIndexView.urlExcluirVersao,
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