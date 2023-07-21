var tabla_perfil;

$(document).ready(function () {
    tabla_perfil = $('#tblPerfiles').DataTable({
        "ajax": {
            "url": "/Catalogo/ListarPerfil",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "nombrePerfil" },
            { "data": "descripcion" },
            {
                "data": "clavePerfil", "render": function (data) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='abrirModal(" + data + ")'><i class='fas fa-pen'></i></button>" +
                        "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='Eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "150px"
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            {
                text: 'Nuevo',
                attr: { class: 'btn btn-success' },
                action: function (e, dt, node, config) {
                    abrirModal(0);
                }
            }
        ],
        "language": {
            url: '//cdn.datatables.net/plug-ins/1.13.5/i18n/es-ES.json'
        }
    });

    $("#CerrarModal").click(function () {
        $("#ModalPerfil").modal("hide");
        $('#ValidacionCampoNombre').hide();
        $('#ValidacionCampoDescripcion').hide();
    });

    $("#CerrarModalValidacion").click(function () {
        $("#ModalValidacionEliminarPerfil").modal("hide");
    });
});

function abrirModal($ClavePerfil) {

    $("#clavePerfil").val($ClavePerfil);
    if ($ClavePerfil != 0) {
        jQuery.ajax({
            url: "/Catalogo/ConsultarPerfil/" + "?clavePerfil=" + $ClavePerfil,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data != null) {
                    $("#txtNombre").val(data.nombrePerfil);
                    $("#txtDescripcion").val(data.descripcion);
                }
            }
        });
    } else {
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
    }

    $("#ModalPerfil").modal("show");
}

function Guardar() {
    var informacion = {
        ClavePerfil: parseInt($("#clavePerfil").val()),
        NombrePerfil: $("#txtNombre").val(),
        Descripcion: $("#txtDescripcion").val()
    }

    /* console.log($data);*/

    $.ajax({
        url: "/Catalogo/GuardarPerfil",
        type: "post",
        data: informacion,
        success: function (data) {
            if (data.resultado) {
                tabla_perfil.ajax.reload();
                $('#ModalPerfil').modal('hide');
                $('#ValidacionCampoNombre').hide();
                $('#ValidacionCampoDescripcion').hide();
            } else {
                $('#ValidacionCampoNombre').show();
                $('#ValidacionCampoDescripcion').show();
            }
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function Eliminar($ClavePerfil) {
    var clavePerfil = parseInt($ClavePerfil);
    $("#clavePerfil").val($ClavePerfil);
    if ($ClavePerfil != 0) {
        $.ajax({
            url: "/Catalogo/EliminarPerfil/" + "?clavePerfil=" + $ClavePerfil,
            type: "get",
            data: clavePerfil,
            success: function (data) {
                if (data.resultado) {
                    tabla_perfil.ajax.reload();
                } else {
                    $('#ModalValidacionEliminarPerfil').modal("show");
                }
            },
            error: function (error) {
                console.log(error)
            }
        });
    }
}