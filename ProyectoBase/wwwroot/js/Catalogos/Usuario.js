var tabla_usuario;

$(document).ready(function () {
    tabla_usuario = $('#tblUsuarios').DataTable({
        "ajax": {
            "url": "/Catalogo/ListarUsuario",
            "type": "GET",
            "dataType": "json"
        },
        "columns": [
            { "data": "nombreTrabajador" },
            { "data": "nombrePerfil" },
            { "data": "nombreEstatus" },
            {
                "data": "claveUsuario", "render": function (data) {
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
        $("#ModalUsuario").modal("hide");
        $('#ValidacionCampoNombre').hide();
        $('#ValidacionCampoCuenta').hide();
        $("#ckbActivo").prop("checked", false);
        $('#ValidacionCampoPerfil').hide();
        $('#ValidacionCampoContrasena').hide();
    });
});

function abrirModal($ClaveUsuario) {

    $("#claveUsuario").val($ClaveUsuario);
    if ($ClaveUsuario != 0) {
        jQuery.ajax({
            url: "/Catalogo/ConsultarUsuario/" + "?claveUsuario=" + $ClaveUsuario,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data != null) {
                    $("#txtNombre").val(data.nombreTrabajador);
                    $("#txtCuenta").val(data.cuenta);
                    $("#txtContrasena").val(data.contrasena);
                    //Quitar el tipo de password para que se pueda visualizar la contraseña en el formulario
                    $('#txtContrasena').attr('type', 'text');
                    var activo = data.activo;
                    if (activo) {
                        $("#ckbActivo").prop("checked", true);
                    } else {
                        $("#ckbActivo").prop("checked", false);
                    }
                    $("#cmbPerfil option").filter(function () {
                        return $(this).text() == data.nombrePerfil;
                    }).prop('selected', true);
                }
            }
        });
    } else {
        $("#txtNombre").val("");
        $("#txtCuenta").val("");
        $("#txtContrasena").val("");
        $("#ckbActivo").prop("checked", true);
    }

    $("#ModalUsuario").modal("show");
}

function Guardar() {
    var opcionCombo;
    var opcionCheck;
    var comboPerfil;
    if ($('#ckbActivo').is(":checked")) {
        opcionCheck = true;
    } else {
        opcionCheck = false;
    }
    comboPerfil = $("#cmbPerfil").val();
    if (comboPerfil == 1) {
        opcionCombo = true;
    } else {
        opcionCombo = false;
    }

    var informacion = {
        ClaveUsuario: parseInt($("#claveUsuario").val()),
        NombreTrabajador: $("#txtNombre").val(),
        Cuenta: $("#txtCuenta").val(),
        Contrasena: $("#txtContrasena").val(),
        ClavePerfil: $("#cmbPerfil").val(),
        EsAdmin: opcionCombo,
        Activo: opcionCheck
    }

 /*   console.log(informacion);*/

    $.ajax({
        url: "/Catalogo/GuardarUsuario",
        type: "post",
        data: informacion,
        success: function (data) {
            if (data.resultado) {
                tabla_usuario.ajax.reload();
                $('#ModalUsuario').modal('hide');
                $('#ValidacionCampoNombre').hide();
                $('#ValidacionCampoCuenta').hide();
                $('#ValidacionCampoContrasena').hide();
            } else {
                $('#ValidacionCampoNombre').show();
                $('#ValidacionCampoCuenta').show();
                $('#ValidacionCampoContrasena').show();
            }
        },
        error: function (error) {
            console.log(error)
        }
    });
}

function Eliminar($ClaveUsuario) {
    var claveUsuario = parseInt($ClaveUsuario);
    $("#claveUsuario").val($ClaveUsuario);
    if ($ClaveUsuario != 0) {
        $.ajax({
            url: "/Catalogo/EliminarUsuario/" + "?claveUsuario=" + $ClaveUsuario,
            type: "get",
            data: claveUsuario,
            success: function (data) {
                if (data.resultado) {
                    tabla_usuario.ajax.reload();
                }
            },
            error: function (error) {
                console.log(error)
            }
        });
    }
}
