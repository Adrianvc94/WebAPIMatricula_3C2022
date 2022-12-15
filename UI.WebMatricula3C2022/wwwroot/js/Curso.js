$(document).ready(function () {
    var codigoCurso;

    $('#CursosTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitoso").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCampos();
        location.reload();
    });

    $("#btnAgregarCurso").click(function () {
        if (validarCamposCurso()) {

            var codigoCurso = document.getElementById("IDAgregarCursoCodigo").value;

            if (codigoCurso == "") {

                $.ajax({
                    url: '/Curso/AgregarCurso',
                    type: 'POST',
                    data: {
                        creditos: document.getElementById("IDAgregarCursoCreditos").value,
                        nombre: document.getElementById("IDAgregarCursoNombre").value,
                        codigoHorario: document.getElementById("IDAgregarCursoCodigoHorario").value,
                        estado: document.getElementById("IDAgregarCursoEstado").value

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarCursoEstado");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Curso/EditarCurso',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarCursoCodigo").value,
                        creditos: document.getElementById("IDAgregarCursoCreditos").value,
                        nombre: document.getElementById("IDAgregarCursoNombre").value,
                        codigoHorario: document.getElementById("IDAgregarCursoCodigoHorario").value,
                        estado: estadoSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarCurso").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarCurso']").click(function () {

        codigoCurso = $(this).data("id");
        var verDetalle = VerDetalleCurso(codigoCurso);


    });

    $("a[name='btnEliminarCurso']").click(function () {

        codigoCurso = $(this).data("id");
        $('#modalVentanaEliminarCurso').modal('show');
    });

    $("#btnAbrirDialogAgregarCurso").click(function () {
        $('#modalAgregarCurso').modal('show');
    });

    $("#btnAceptarEliminarCursoConfirmacion").click(function () {

        $.ajax({
            url: '/Curso/EliminarCurso',
            type: 'POST',
            data: {
                Codigo: codigoCurso
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarCurso').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarCursoConfirmacion").click(function () {
        $('#modalVentanaEliminarCurso').modal('hide');
        location.reload();
    });

    $("#textoBuscarCurso").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#CursosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarCurso').modal('hide');

    document.getElementById("IDAgregarCursoCodigo").value = "";
    document.getElementById("IDAgregarCursoCreditos").value = "";
    document.getElementById("IDAgregarCursoNombre").value = "";
    document.getElementById("IDAgregarCursoCodigoHorario").value = "";
    document.getElementById("IDAgregarCursoEstado").value = "";

    $("IDAgregarCursoCreditos").css('border', '1px solid #ced4da');
    $("IDAgregarCursoNombre").css('border', '1px solid #ced4da');
    $("IDAgregarCursoCodigoHorario").css('border', '1px solid #ced4da');
    $("IDAgregarCursoEstado").css('border', '1px solid #ced4da');
}



function validarCamposCurso() {
    var bandera = true;
    var agregarCursoCreditos = document.getElementById("IDAgregarCursoCreditos").value;
    var agregarCursoNombre = document.getElementById("IDAgregarCursoNombre").value;
    var agregarCursoHorario = document.getElementById("IDAgregarCursoCodigoHorario").value;
    var agregarCursoEstado = document.getElementById("IDAgregarCursoEstado").value;

    if (agregarCursoCreditos == "") {
        $("#IDAgregarCursoCreditos").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoCreditos').css('border', '1px solid #ced4da');
    }

    if (agregarCursoNombre == "") {
        $("#IDAgregarCursoNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoNombre').css('border', '1px solid #ced4da');
    }

    if (agregarCursoHorario == "") {
        $("#IDAgregarCursoCodigoHorario").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoCodigoHorario').css('border', '1px solid #ced4da');
    }

    if (agregarCursoCreditos == "") {
        $("#IDAgregarCursoCreditos").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoCreditos').css('border', '1px solid #ced4da');
    }

    if (agregarCursoEstado == "") {
        $("#IDAgregarCursoEstado").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoEstado').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleCurso(codigo) {

    $.ajax({
        url: '/Curso/VerDetalleCurso',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarCursoEstado").value = response.estado;
            document.getElementById("IDAgregarCursoNombre").value = response.nombre;
            document.getElementById("IDAgregarCursoCodigoHorario").value = response.codigoHorario;
            document.getElementById("IDAgregarCursoCreditos").value = response.creditos;
            document.getElementById("IDAgregarCursoCodigo").value = response.codigo;
            $('#modalAgregarCurso').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
