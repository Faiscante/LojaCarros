
$(document).ready(function() {
    CarroceriaIndexView.bind();
});

CarroceriaIndexView = {
    urlExcluirCarroceria: "",

    bind: function() {
    },
    excluirCarroceriaConfirm: function(element) {
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
                CarroceriaIndexView.excluirCarroceria(element);
            }
        });
    },
    excluirCarroceria: function(element) {
        var idCarroceria = $(element).data("idcarroceria");

        var params = { idCarroceria: idCarroceria };

        $.ajax({
            type: "DELETE",
            url: CarroceriaIndexView.urlExcluirCarroceria,
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