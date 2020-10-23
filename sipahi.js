//ekrandaki kaydı silerken, servera gitmeden ajax ile silmeyi sağlar.  
$(function () {
    $("#tblDepartmanlar").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
    $("#tblDepartmanlar").on("click", ".btnDepartmanSil", function () {
        var btn = $(this);
        bootbox.confirm("Departman silmeye emin misiniz?", function (result) {
            if (result) {
                var id = btn.data("id");

                $.ajax({
                    type: "GET",
                    url: "/Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }
                });
            }
        })
    });
});

$(function () {
    $("#tblPersoneller").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
});


function DateIsValid(date) {
    var value = $(date).val();
    if (value = '') {
        $(date).valid("false");
    }
    else {
        $(date).valid();
    }
}

